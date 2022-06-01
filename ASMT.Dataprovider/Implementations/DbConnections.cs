using System;
using System.Data;
using System.Data.SqlClient;
using ASMT.Dataprovider.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace ASMT.Dataprovider.Implementations
{
    public class DbConnections
    {
        private static readonly string conString;
        SqlConnection sqlCon;

        static DbConnections()
        {
            conString = @"Data Source=LAPTOP-D6L7G6JO\SQLEXPRESS05;Initial Catalog=ASMT;Integrated Security=True";
        }

        public DbConnections()
        {
            sqlCon = new SqlConnection(conString);
        }

        public Booking GetBookingData(long bookingId)
        {
            Booking booking = new Booking();

            try
            {
                string sqlCommand = "SELECT [BookingId], [Location], [Name], [Phone], [Email], [VehicleNumber], [VehicleModel], [CreatedDate], [RequestedDate], [CompletedDate] " +
                                    "FROM[dbo].[Bookings] " +
                                    "WHERE[BookingId] = @BookingId";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        booking.BookingId = Convert.ToInt64(reader["BookingId"]);
                        booking.Location = reader["Location"].ToString();
                        booking.Name = reader["Name"].ToString();
                        booking.Phone = reader["Phone"].ToString();
                        booking.Email = reader["Email"].ToString();
                        booking.VehicleNumber = reader["VehicleNumber"].ToString();
                        booking.VehicleModel = reader["VehicleModel"].ToString();
                        booking.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                        booking.RequestedDate = Convert.ToDateTime(reader["RequestedDate"].ToString());
                        if (reader["CompletedDate"] != DBNull.Value)
                            booking.CompletedDate = Convert.ToDateTime(reader["CompletedDate"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return booking;
        }

        public bool UpdateBookingData(Booking booking)
        {
            bool isUpdated = false;

            try
            {
                string sqlCommand = "UPDATE [dbo].[Bookings] SET CompletedDate = @CompletedDate Where BookingId = @BookingId";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", booking.BookingId.ToString());
                cmd.Parameters.AddWithValue("@CompletedDate", booking.CompletedDate.ToString());

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return isUpdated;
        }

        public List<Booking> GetBookings(string location)
        {
            var bookings = new List<Booking>();

            try
            {
                string sqlCommand = "SELECT [BookingId], [Location], [Name], [Phone], [Email], [VehicleNumber], [VehicleModel], [CreatedDate], [RequestedDate], [CompletedDate] " +
                                    "FROM[dbo].[Bookings] " +
                                    "WHERE[Location] = @location";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@location", location);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var booking = new Booking();
                        booking.BookingId = Convert.ToInt64(reader["BookingId"].ToString());
                        booking.Name = reader["Name"].ToString();
                        booking.Email = reader["Email"].ToString();
                        booking.Phone = reader["Phone"].ToString();
                        booking.Location = reader["Location"].ToString();
                        booking.VehicleModel = reader["VehicleModel"].ToString();
                        booking.VehicleNumber = reader["VehicleNumber"].ToString();
                        booking.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                        booking.RequestedDate = Convert.ToDateTime(reader["RequestedDate"].ToString());
                        if (reader["CompletedDate"] != DBNull.Value)
                            booking.CompletedDate = Convert.ToDateTime(reader["CompletedDate"].ToString());

                        bookings.Add(booking);
                    }
                }

                return bookings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateBooking(Booking booking)
        {
            bool isCreated = false;

            try
            {
                string sqlCommand = "INSERT INTO [dbo].[Bookings]([BookingId], [Location], [Name], [Phone], [Email], [VehicleNumber], [VehicleModel], [CreatedDate], [RequestedDate], [CompletedDate])" +
                                    "VALUES (@BookingId, @Location, @Name, @Phone, @Email, @VehicleNumber, @VehicleModel, @CreatedDate, @RequestedDate, @CompletedDate)";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", booking.BookingId.ToString());
                cmd.Parameters.AddWithValue("@Location", booking.Location);
                cmd.Parameters.AddWithValue("@Name", booking.Name);
                cmd.Parameters.AddWithValue("@Phone", booking.Phone);
                if (booking.Email != null)
                {
                    cmd.Parameters.AddWithValue("@Email", booking.Email);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@VehicleNumber", booking.VehicleNumber);
                cmd.Parameters.AddWithValue("@VehicleModel", booking.VehicleModel);
                cmd.Parameters.AddWithValue("@CreatedDate", booking.CreatedDate.ToString());
                cmd.Parameters.AddWithValue("@RequestedDate", booking.RequestedDate.ToString());
                cmd.Parameters.AddWithValue("@CompletedDate", DBNull.Value);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                cmd.ExecuteNonQuery();
                isCreated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return isCreated;
        }

        public AutoService GetServiceData(string bookingId)
        {
            AutoService service = new AutoService();
            try
            {
                string sqlCommand = "SELECT [BookingId], [VehicleNumber], [VehicleModel], [ServiceType], [ServiceInstructions], [ServiceTasks], [RequestedDate], [CompletedDate] " +
                                    "FROM[dbo].[Services] " +
                                    "WHERE[BookingId] = @BookingId";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        service.BookingId = Convert.ToInt64(reader["BookingId"]);
                        service.VehicleNumber = reader["VehicleNumber"].ToString();
                        service.VehicleModel = reader["VehicleModel"].ToString();
                        service.ServiceType = reader["ServiceType"].ToString();
                        service.ServiceInstructions = reader["ServiceInstructions"].ToString();
                        byte[] byteArr = (byte[])reader["ServiceTasks"];
                        Stream s = new MemoryStream(byteArr);
                        var binFormatter = new BinaryFormatter();
                        service.ServiceTasks = (Dictionary<string, bool>)binFormatter.Deserialize(s);
                        service.RequestedDate = Convert.ToDateTime(reader["RequestedDate"].ToString());
                        if (reader["CompletedDate"] != DBNull.Value)
                            service.CompletedDate = Convert.ToDateTime(reader["CompletedDate"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return service;
        }

        public bool UpdateServiceData(AutoService service)
        {
            bool isUpdated = false;

            try
            {
                string sqlCommand = "UPDATE [dbo].[Services] SET ServiceInstructions = @ServiceInstructions, ServiceTasks = @ServiceTasks, CompletedDate = @CompletedDate  Where BookingId = @BookingId";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", service.BookingId.ToString());
                if (service.ServiceInstructions != null)
                {
                    cmd.Parameters.AddWithValue("@ServiceInstructions", service.ServiceInstructions);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ServiceInstructions", DBNull.Value);
                }

                if (service.ServiceTasks != null)
                {
                    var binFormatter = new BinaryFormatter();
                    var mStream = new MemoryStream();
                    binFormatter.Serialize(mStream, service.ServiceTasks);
                    var serviceTasks = mStream.ToArray();
                    cmd.Parameters.AddWithValue("@ServiceTasks", serviceTasks);
                }
                else
                {
                    cmd.Parameters.Add("@ServiceTasks", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                }
                if (service.CompletedDate != DateTime.MinValue)
                    cmd.Parameters.AddWithValue("@CompletedDate", service.CompletedDate.ToString());
                else
                    cmd.Parameters.AddWithValue("@CompletedDate", DBNull.Value);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return isUpdated;
        }

        public bool CreateService(AutoService service)
        {
            bool isCreated = false;
            try
            {
                string sqlCommand = "INSERT INTO [dbo].[Services]([BookingId], [VehicleNumber], [VehicleModel], [ServiceType], [ServiceInstructions], [ServiceTasks], [RequestedDate], [CompletedDate])" +
                                    "VALUES (@BookingId, @VehicleNumber, @VehicleModel, @ServiceType, @ServiceInstructions, @ServiceTasks, @RequestedDate, @CompletedDate)";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", service.BookingId.ToString());
                cmd.Parameters.AddWithValue("@VehicleNumber", service.VehicleNumber);
                cmd.Parameters.AddWithValue("@VehicleModel", service.VehicleModel);
                cmd.Parameters.AddWithValue("@ServiceType", service.ServiceType);
                if (service.ServiceInstructions != null)
                {
                    cmd.Parameters.AddWithValue("@ServiceInstructions", service.ServiceInstructions);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ServiceInstructions", DBNull.Value);
                }

                if (service.ServiceTasks != null)
                {
                    var binFormatter = new BinaryFormatter();
                    var mStream = new MemoryStream();
                    binFormatter.Serialize(mStream, service.ServiceTasks);
                    var serviceTasks = mStream.ToArray();
                    cmd.Parameters.AddWithValue("@ServiceTasks", serviceTasks);
                }
                else
                {
                    cmd.Parameters.Add("@ServiceTasks", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                }

                cmd.Parameters.AddWithValue("@RequestedDate", service.RequestedDate.ToString());
                cmd.Parameters.AddWithValue("@CompletedDate", DBNull.Value);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                cmd.ExecuteNonQuery();
                isCreated = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return isCreated;
        }

        public TrackStatus GetTrackingData(string bookingId)
        {
            TrackStatus trackingData = new TrackStatus();

            try
            {
                string sqlCommand = "SELECT [BookingId], [TasksDone], [TasksTotal], [IsPaymentDone], [IsCompleted], [ExpectedDate] " +
                                    "FROM[dbo].[TrackStatus] " +
                                    "WHERE[BookingId] = @BookingId";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trackingData.BookingId = Convert.ToInt64(reader["BookingId"]);
                        trackingData.TasksDone = Convert.ToInt64(reader["TasksDone"].ToString());
                        trackingData.TasksTotal = Convert.ToInt64(reader["TasksTotal"].ToString());
                        trackingData.IsPaymentDone = Convert.ToBoolean(reader["IsPaymentDone"].ToString());
                        trackingData.IsCompleted = Convert.ToBoolean(reader["IsCompleted"].ToString());
                        trackingData.ExpectedDate = Convert.ToDateTime(reader["ExpectedDate"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return trackingData;
        }

        public bool UpdateTrackingData(TrackStatus trackService)
        {
            bool isUpdated = false;

            try
            {
                string sqlCommand = "UPDATE [dbo].[TrackStatus] SET TasksDone = @TasksDone, IsPaymentDone = @IsPaymentDone, IsCompleted = @IsCompleted, ExpectedDate = @ExpectedDate Where BookingId = @BookingId";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", trackService.BookingId.ToString());
                cmd.Parameters.AddWithValue("@TasksDone", trackService.TasksDone.ToString());
                cmd.Parameters.AddWithValue("@IsPaymentDone", trackService.IsPaymentDone ? 1 : 0);
                cmd.Parameters.AddWithValue("@IsCompleted", trackService.IsCompleted ? 1 : 0);
                cmd.Parameters.AddWithValue("@ExpectedDate", trackService.ExpectedDate.ToString());

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                cmd.ExecuteNonQuery();
                isUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return isUpdated;
        }

        public bool CreateTracking(TrackStatus trackService)
        {
            bool isCreated = false;
            try
            {
                string sqlCommand = "INSERT INTO [dbo].[TrackStatus]([BookingId], [TasksDone], [TasksTotal], [IsPaymentDone], [IsCompleted], [ExpectedDate])" +
                                                    "VALUES (@BookingId, @TasksDone, @TasksTotal, @IsPaymentDone, @IsCompleted, @ExpectedDate)";
                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", trackService.BookingId.ToString());
                cmd.Parameters.AddWithValue("@TasksDone", trackService.TasksDone.ToString());
                cmd.Parameters.AddWithValue("@TasksTotal", trackService.TasksTotal.ToString());
                cmd.Parameters.AddWithValue("@IsPaymentDone", trackService.IsPaymentDone ? 1 : 0);
                cmd.Parameters.AddWithValue("@IsCompleted", trackService.IsCompleted ? 1 : 0);
                cmd.Parameters.AddWithValue("@ExpectedDate", trackService.ExpectedDate.ToString());

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                cmd.ExecuteNonQuery();
                isCreated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return isCreated;
        }

        public bool Login(Credential credsFromUser)
        {
            bool isAuthorized = false;
            Credential credsFromDB = new Credential();

            try
            {
                string sqlCommand = "SELECT [Location], [Username], [Password] " +
                                    "FROM[dbo].[Credentials] " +
                                    "WHERE[Username] = @Username";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@Username", credsFromUser.UserName);

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        credsFromDB.Location = reader["Location"].ToString();
                        credsFromDB.UserName = reader["Username"].ToString();
                        credsFromDB.Password = reader["Password"].ToString();
                    }
                }
                if (credsFromDB.UserName == credsFromUser.UserName && credsFromDB.Password == credsFromUser.Password)
                {
                    isAuthorized = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return isAuthorized;
        }
    }
}
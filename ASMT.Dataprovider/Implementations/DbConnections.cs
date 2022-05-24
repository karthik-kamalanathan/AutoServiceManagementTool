using System;
using System.Data;
using System.Data.SqlClient;
using ASMT.Dataprovider.Models;

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

        public Booking GetBookingData(int bookingId)
        {
            Booking booking = new Booking();

            try
            {
                string sqlCommand = "SELECT [BookingId], [LocationId], [Name], [VehicleNumber], [VehicleModel], [PickUp], [PickUpAddress], [Drop], [DropAddress], [CreatedDate] " +
                                    "FROM[dbo].[Bookings] " + 
                                    "WHERE[BookingId] = @BookingId";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                sqlCon.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        booking.Id = Convert.ToInt64(reader["BookingId"]);
                        booking.Location = reader["LocationId"].ToString();
                        booking.Name = reader["Name"].ToString();
                        booking.VehicleModel = reader["VehicleModel"].ToString();
                        booking.VehicleNumber = reader["VehicleNumber"].ToString();
                        booking.PickUpRequested = reader["PickUp"].ToString() == "1" ? true : false;
                        booking.PickUpAddress = reader["PickUpAddress"].ToString();
                        booking.DropRequested = reader["Drop"].ToString() == "1" ? true : false;
                        booking.DropAddress = reader["DropAddress"].ToString();
                        booking.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
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

        public bool CreateBooking(Booking booking)
        {
            bool isCreated = false;

            try
            {
                string sqlCommand = "INSERT INTO [dbo].[Bookings]([BookingId], [LocationId], [Name], [VehicleNumber], [VehicleModel], [PickUp], [PickUpAddress], [Drop], [DropAddress], [CreatedDate])" +
                                    "VALUES (@BookingId, @LocationId, @Name, @VehicleNumber, @VehicleModel, @PickUp, @PickUpAddress, @Drop, @DropAddress, @CreatedDate)";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", booking.Id.ToString());
                cmd.Parameters.AddWithValue("@LocationId", booking.Location);
                cmd.Parameters.AddWithValue("@Name", booking.Name);
                cmd.Parameters.AddWithValue("@VehicleNumber", booking.VehicleNumber);
                cmd.Parameters.AddWithValue("@VehicleModel", booking.VehicleModel);
                cmd.Parameters.AddWithValue("@PickUp", booking.PickUpRequested ? 1 : 0);
                cmd.Parameters.AddWithValue("@PickUpAddress", booking.PickUpAddress);
                cmd.Parameters.AddWithValue("@Drop", booking.DropRequested ? 1 : 0);
                cmd.Parameters.AddWithValue("@DropAddress", booking.DropAddress);
                cmd.Parameters.AddWithValue("@CreatedDate", booking.CreatedDate.ToString());

                sqlCon.Open();

                cmd.ExecuteNonQuery();
                isCreated = true;
            }
            catch (Exception ex)
            {
                throw;
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

    }
}

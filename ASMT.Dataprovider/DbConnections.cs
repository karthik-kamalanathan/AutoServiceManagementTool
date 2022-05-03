﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ASMT.Dataprovider.Models;

namespace ASMT.Dataprovider
{
    internal class DbConnections
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
                string sqlCommand = "";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", bookingId);

                sqlCon.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //booking.Id = Convert.ToInt32(reader["BookingId"]);
                        //booking.LocationId = Convert.ToInt32(reader["LocationId"]);
                        //booking.Name = reader["Name"].ToString();
                        //booking.VehicleModel = reader["VehicleModel"].ToString();
                        //booking.VehicleNumber = reader["VehicleNumber"].ToString();
                        //booking.PickUpRequested = Convert.ToBoolean(reader["PickUp"]);
                        //booking.PickUpAddress = reader["PickUpAddress"].ToString();
                        //booking.DropRequested = Convert.ToBoolean(reader["Drop"]);
                        //booking.DropAddress = reader["DropAddress"].ToString();
                        //booking.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
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
                string sqlCommand = "";

                var cmd = new SqlCommand(sqlCommand, sqlCon);
                cmd.Parameters.AddWithValue("@BookingId", booking.Id);
                cmd.Parameters.AddWithValue("@LocationId", booking.LocationId);
                cmd.Parameters.AddWithValue("@Name", booking.Name);
                cmd.Parameters.AddWithValue("@VehicleModel", booking.VehicleModel);
                cmd.Parameters.AddWithValue("@VehicleNumber", booking.VehicleNumber);
                cmd.Parameters.AddWithValue("@PickUp", booking.PickUpRequested);
                cmd.Parameters.AddWithValue("@PickUpAddress", booking.PickUpAddress);
                cmd.Parameters.AddWithValue("@Drop", booking.DropRequested);
                cmd.Parameters.AddWithValue("@DropAddress", booking.DropAddress);
                cmd.Parameters.AddWithValue("@CreatedDate", booking.CreatedDate.ToString());

                sqlCon.Open();

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
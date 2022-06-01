using ASMT.Dataprovider.Models;
using System;
using System.Collections.Generic;

namespace ASMT.Dataprovider.Implementations
{
    public class DealerService
    {
        DbConnections db;

        public DealerService()
        {
            db = new DbConnections();
        }

        public List<Booking> GetBookings(string location)
        {
            try
            {
                var bookings = db.GetBookings(location);

                return bookings;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AutoService GetServiceData(string bookingId)
        {
            AutoService service;
            try
            {
                service = db.GetServiceData(bookingId);

                return service;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateBooking(Booking booking)
        {
            try
            {
                return db.UpdateBookingData(booking);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateService(AutoService service)
        {
            try
            {
                return db.UpdateServiceData(service);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DealerLogin(Credential creds)
        {
            bool isAuthorized = false;

            if (creds != null)
            {
                if (creds.UserName != null && creds.UserName != "" && creds.Password != null && creds.Password != "")
                    isAuthorized = db.Login(creds);
            }

            return isAuthorized;
        }
    }
}
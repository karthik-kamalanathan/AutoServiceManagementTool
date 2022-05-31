using ASMT.Dataprovider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AutoService GetServiceData(long bookingId)
        {
            AutoService service;
            try
            {
                service = db.GetServiceData(bookingId.ToString());        

                return service;
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
                if (creds.Location != null && creds.Location != "" && creds.UserName != null && creds.UserName != "" && creds.Password != null && creds.Password != "")
                    isAuthorized = db.Login(creds);
            }

            return isAuthorized;
        }
    }
}

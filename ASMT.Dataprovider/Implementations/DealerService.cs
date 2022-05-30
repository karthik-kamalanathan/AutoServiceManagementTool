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
    }
}

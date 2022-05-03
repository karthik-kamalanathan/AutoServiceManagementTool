using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ASMT.Dataprovider;
using ASMT.Dataprovider.Models;

namespace ASMT.Application.Implementations
{
    public class BookingService
    {
        private DbConnections dbConnections;

        public BookingService()
        {
            dbConnections = new DbConnections();
        }

        public string BookAService(Booking booking)
        {
            var temp = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var barcode = Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, 12);
            booking.Id = Convert.ToInt64(barcode);

            booking.PickUpRequested = false;
            booking.PickUpAddress = " ";
            booking.DropRequested = false;
            booking.DropAddress = " ";

            try
            {       
                if (dbConnections.CreateBooking(booking))
                {
                    return barcode;
                }                
            }
            catch (Exception ex)
            {
                return barcode;
                //return string.Empty;
            }

            return string.Empty;
        }

    }
}

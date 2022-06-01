using System;
using System.Text.RegularExpressions;
using ASMT.Dataprovider.Models;

namespace ASMT.Dataprovider.Implementations
{
    public class BookingService
    {
        private DbConnections dbConnections;

        public BookingService()
        {
            dbConnections = new DbConnections();
        }

        public string BookAService(Booking booking, AutoService service)
        {
            var temp = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var barcode = Regex.Replace(temp, "[a-zA-Z]", string.Empty).Substring(0, 12);

            booking.BookingId = Convert.ToInt64(barcode);
            service.BookingId = Convert.ToInt64(barcode);

            TrackStatus trackStatus = new TrackStatus()
            {
                BookingId = Convert.ToInt64(barcode),
                TasksDone = 0,
                IsCompleted = false,
                IsPaymentDone = false,
                ExpectedDate = booking.CreatedDate + TimeSpan.FromDays(2),
            };

            if (service.ServiceTasks != null)
            {
                trackStatus.TasksTotal = service.ServiceTasks.Count;
            }
            else
            {
                trackStatus.TasksTotal = 0;
            }

            if (dbConnections.CreateBooking(booking) && dbConnections.CreateService(service) && dbConnections.CreateTracking(trackStatus))
            {
                return barcode;
            }

            return string.Empty;
        }
    }
}
using System;

namespace ASMT.Dataprovider.Models
{
    public class Booking
    {
        public long BookingId { get; set; }
        public string Location{ get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
    }
}
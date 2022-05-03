using System;

namespace ASMT.Dataprovider.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public bool PickUpRequested { get; set; }
        public string PickUpAddress { get; set; }
        public bool DropRequested { get; set; }
        public string DropAddress { get; set; }
    }
}
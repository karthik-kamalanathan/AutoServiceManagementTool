using System;

namespace ASMT.Dataprovider.Models
{
    public class Booking
    {
        public long Id { get; set; }
        public string Location{ get; set; }
        public string Name { get; set; }
        public string PhNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public bool PickUpRequested { get; set; }
        public string PickUpAddress { get; set; }
        public bool DropRequested { get; set; }
        public string DropAddress { get; set; }
        public string ServiceIntructions { get; set; }
        public string ServiceType { get; set; }
    }
}
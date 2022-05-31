using System;
using System.Collections.Generic;

namespace ASMT.Dataprovider.Models
{
    public class AutoService
    {
        public long BookingId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleModel { get; set; }
        public string ServiceType { get; set; }
        public Dictionary<string, bool> ServiceTasks { get; set; }
        public string ServiceInstructions { get; set; }
    }
}
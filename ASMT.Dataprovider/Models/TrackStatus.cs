using System;

namespace ASMT.Dataprovider.Models
{
    public class TrackStatus
    {
        public long BookingId { get; set; }
        public long TasksDone { get; set; }
        public long TasksTotal { get; set; }
        public bool IsPaymentDone { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime ExpectedDate { get; set; }
    }
}
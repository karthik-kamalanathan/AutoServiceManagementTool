using ASMT.Dataprovider.Models;
using System;

namespace ASMT.Dataprovider.Implementations
{
    public class TrackService
    {
        DbConnections db;

        public TrackService()
        {
            db = new DbConnections();
        }

        public TrackStatus GetBookingStatus(string bookingId)
        {
            TrackStatus status = new TrackStatus();

            try
            {
                status = db.GetTrackingData(bookingId);

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Booking GetBookingData(string bookingId)
        {
            Booking booking = new Booking();
            try
            {
                booking = db.GetBookingData(Convert.ToInt64(bookingId));

                return booking;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateTrackingData(TrackStatus trackStatus)
        {
            try
            {
                return db.UpdateTrackingData(trackStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
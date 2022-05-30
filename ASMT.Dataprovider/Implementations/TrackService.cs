using ASMT.Dataprovider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
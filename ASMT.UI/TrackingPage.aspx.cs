using System;
using System.Web.UI;
using ASMT.Dataprovider.Implementations;

namespace ASMT.UI
{
    public partial class TrackingPage :Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                trackdetails.Visible = false;
                billDetails.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void trackStatus(object sender, EventArgs e)
        {
            try
            {
                string bookingId = trackingId.Text;

                TrackService trackService = new TrackService();

                var trackStatus = trackService.GetBookingStatus(bookingId);
                var booking = trackService.GetBookingData(bookingId);

                int percentComplete = (int)Math.Round((double)(100 * trackStatus.TasksDone) / trackStatus.TasksTotal);

                if (trackStatus != null)
                {
                    progressbar.Style.Add(HtmlTextWriterStyle.Width, percentComplete + "%");
                    progressbar.Attributes.Add("aria-valuenow", percentComplete.ToString());
                    progressbar.InnerText = percentComplete + "%";

                    name.InnerHtml = "<strong>Name : </strong>" + booking.Name;
                    vehicleModel.InnerHtml = "<strong>Model : </strong>" + booking.VehicleModel;
                    vehicleNum.InnerHtml = "<strong>Vehicle.No : </strong>" + booking.VehicleNumber;
                    bookedDate.InnerHtml = "<strong>Service Date : </strong>" + booking.RequestedDate.ToString("MM/dd/yyyy");
                    if (trackStatus.IsCompleted)
                    {
                        expectedDate.InnerHtml = "<strong>Completed Date : </strong>" + trackStatus.ExpectedDate.ToString("MM/dd/yyyy");
                        status.InnerHtml = "<strong>Status : </strong>Service is Completed";
                    }
                    else
                    {
                        expectedDate.InnerHtml = "<strong>Expected Date : </strong>" + trackStatus.ExpectedDate.ToString("MM/dd/yyyy");
                        status.InnerHtml = "<strong>Status : </strong>Service is In Progress";
                    }

                    trackdetails.Visible = true;
                    if (trackStatus.IsCompleted && !trackStatus.IsPaymentDone)
                    {
                        billDetails.Visible = true;
                    }
                    else if(trackStatus.IsCompleted && trackStatus.IsPaymentDone)
                    {
                        billDetails.Visible = true;
                        paymentText.Visible = true;
                        paymentText.InnerText = "You have already Checked Out";

                        amount.Visible = false;
                        payBtn.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}
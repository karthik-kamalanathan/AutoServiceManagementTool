﻿using System;
using System.Web.UI;
using ASMT.Dataprovider.Implementations;

namespace ASMT.UI
{
    public partial class TrackingPage : Page
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
                        amount.Value = CalculateAmount(bookingId);
                    }
                    else if (trackStatus.IsCompleted && trackStatus.IsPaymentDone)
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

        private string CalculateAmount(string bookingId)
        {
            try
            {
                string amount = "";

                double totalCharge = 0;
                double baseCharge = 300;

                DealerService dealerService = new DealerService();
                var service = dealerService.GetServiceData(bookingId);

                totalCharge += baseCharge;

                if (service.ServiceTasks.ContainsKey("EngineOilChange"))
                {
                    totalCharge += 800;
                }

                if (service.ServiceTasks.ContainsKey("BreakOilChange"))
                {
                    totalCharge += 300;
                }

                double GST = (totalCharge / 100) * 18 * 2;

                totalCharge += GST;

                amount = Math.Round(totalCharge, 2).ToString();

                return amount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void PayBill(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BillingPage.aspx?BillAmount=" + amount.Value.Replace(".", "_"), false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}
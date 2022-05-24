using ASMT.Dataprovider.Implementations;
using ASMT.Dataprovider.Models;
using System;
using System.Web.UI;

namespace ASMT.UI
{
    public partial class BookingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void bookClick(object sender, EventArgs e)
        {
            try
            {
                //BookingService bookingService = new BookingService();

                //Booking booking = new Booking();
                //booking.Name = firstName.Text + " " + lastName.Text;
                //booking.VehicleNumber = vehicleNum.Text;
                //booking.VehicleModel = vehicleModel.Text;
                //booking.Location = location.Text;
                //booking.CreatedDate = DateTime.Now;
                //booking.PhNo = phonenum.Text;
                //booking.ServiceType = serviceType.Text;
                //booking.ServiceIntructions = serviceIns.Text;

                //string bookingId = bookingService.BookAService(booking);

                //if (bookingId == string.Empty)
                //{
                //    throw new Exception();
                //}

                //txtBookingId.Text = "1234";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openSuccessModal();", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void goBackClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("IndexPage.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}
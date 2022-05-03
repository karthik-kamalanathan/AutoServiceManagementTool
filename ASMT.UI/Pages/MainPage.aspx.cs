using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASMT.Dataprovider.Models;
using ASMT.Application.Implementations;


namespace ASMT.UI
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Contents.RemoveAll();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void bookService_Click(object sender, EventArgs e)
        {
            try
            {
                BookingService bookingService = new BookingService();

                Booking booking = new Booking();
                booking.Name = txtCustName.Text;
                booking.VehicleNumber = txtAutoNum.Text;
                booking.VehicleModel = txtAutoModel.Text;
                booking.Location = txtLocId.Text;
                booking.CreatedDate = DateTime.Now;
                booking.PhNo = txtPhNum.Text;
                booking.ServiceType = DropDownServiceType.Text;
                booking.ServiceIntructions = txtInstructions.Text;

                string bookingId = bookingService.BookAService(booking);

                if(bookingId == string.Empty)
                {
                    throw new Exception();
                }

                txtBookingId.Text = bookingId;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openSuccessModal();", true);

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void trackStatus_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

    }

}
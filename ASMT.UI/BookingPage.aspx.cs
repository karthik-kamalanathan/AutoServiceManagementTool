using ASMT.Dataprovider.Implementations;
using ASMT.Dataprovider.Models;
using System;
using System.Collections.Generic;
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
                BookingService bookingService = new BookingService();

                Booking booking = new Booking()
                {
                    CreatedDate = DateTime.Now,
                    Name = firstName.Text.Trim() + " " + lastName.Text.Trim(),
                    Phone = phonenum.Text,
                    Location = location.Text,
                    VehicleNumber = vehicleNum.Text,
                    VehicleModel = vehicleModel.Text,
                    RequestedDate = Convert.ToDateTime(serviceDate.Text)   
                };

                AutoService service = new AutoService()
                {
                    RequestedDate = Convert.ToDateTime(serviceDate.Text),
                    VehicleNumber = vehicleNum.Text,
                    VehicleModel = vehicleModel.Text,
                    ServiceType = serviceType.Text,
                    ServiceTasks = ReadServiceTasks(serviceItems.Text),
                    ServiceInstructions = serviceIns.Text
                };

                string bookingId = bookingService.BookAService(booking, service);

                if (bookingId == string.Empty)
                {
                    throw new Exception();
                }

                string script = "openSuccessModal(" + bookingId + ");";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", script, true);
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

        private Dictionary<string, string> ReadServiceTasks(string serviceItems)
        {
            try
            {
                var tasks = new Dictionary<string, string>();

                //Operation to read Service Tasks
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
            return null;
        }
    }
}
using ASMT.Dataprovider.Implementations;
using ASMT.Dataprovider.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace ASMT.UI
{
    public partial class BookingPage : Page
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
                    Email = email.Text,
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
                    ServiceTasks = ReadServiceTasks(),
                    ServiceInstructions = serviceIns.Text
                };

                string bookingId = bookingService.BookAService(booking, service);

                if (bookingId == string.Empty)
                {
                    throw new Exception();
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booking Id :" + bookingId + " ')", true);
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

        private Dictionary<string, bool> ReadServiceTasks()
        {
            try
            {
                var tasks = new Dictionary<string, bool>();

                if (engineOil.Checked || serviceType.Text == "1st Service(Free)" || serviceType.Text == "3rd Service(Free)")
                    tasks.Add("EngineOilChange", false);

                if (breakOil.Checked || serviceType.Text == "3rd Service(Free)")
                    tasks.Add("BreakOilChange", false);

                if (suspension.Checked)
                    tasks.Add("AdjustSuspension", false);

                if (tyreChange.Checked)
                    tasks.Add("ChangeTyre", false);

                if (chainTight.Checked)
                    tasks.Add("ChainTightening", false);

                tasks.Add("WheelAlignment", false);
                tasks.Add("WaterWash", false);
                tasks.Add("AirCheck", false);

                return tasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
            return null;
        }
    }
}
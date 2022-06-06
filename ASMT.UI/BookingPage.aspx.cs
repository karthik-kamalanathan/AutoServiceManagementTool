using ASMT.Dataprovider.Implementations;
using ASMT.Dataprovider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

                string alertMessage;
                if (!ValidateBookingDetails(out alertMessage))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + alertMessage + "');", true);
                    return;
                }

                Booking booking = new Booking()
                {
                    CreatedDate = DateTime.Now,
                    Name = firstName.Text.Trim() + " " + lastName.Text.Trim(),
                    Phone = phonenum.Text.Trim().Replace(" ", ""),
                    Email = email.Text,
                    Location = location.Text.Trim().Replace(" ", ""),
                    VehicleNumber = vehicleNum.Text.Trim().Replace(" ", ""),
                    VehicleModel = vehicleModel.Text.Trim(),
                    RequestedDate = Convert.ToDateTime(serviceDate.Text)
                };

                AutoService service = new AutoService()
                {
                    RequestedDate = Convert.ToDateTime(serviceDate.Text),
                    VehicleNumber = vehicleNum.Text.Trim().Replace(" ", ""),
                    VehicleModel = vehicleModel.Text.Trim(),
                    ServiceType = serviceType.Text,
                    ServiceTasks = ReadServiceTasks(),
                    ServiceInstructions = ""
                };

                string bookingId = bookingService.BookAService(booking, service);

                if (bookingId == string.Empty)
                {
                    throw new Exception();
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Booking Id : " + bookingId + "');window.location ='IndexPage.aspx';", true);
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

                if (engineOil.Checked || serviceType.Text == "1st Service (Free)" || serviceType.Text == "3rd Service (Free)")
                {
                    if (engineOil.Checked != true)
                        engineOil.Checked = true;

                    tasks.Add("EngineOilChange", false);
                }

                if (breakOil.Checked || serviceType.Text == "3rd Service(Free)")
                {
                    if (breakOil.Checked != true)
                        breakOil.Checked = true;

                    tasks.Add("BreakOilChange", false);
                }

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

        private bool ValidateBookingDetails(out string alertMessage)
        {
            bool isValid = true;
            alertMessage = "";
            try
            {
                alertMessage += "Following Booking Details are Invalid or Wrong : ";

                if (firstName.Text != "" && firstName.Text != null)
                {
                    if (firstName.Text.Length > 15)
                    {
                        isValid = false;
                        alertMessage += "- First Name is more than 15 characters ";
                    }

                    if (!firstName.Text.Trim().All(char.IsLetter))
                    {
                        isValid = false;
                        alertMessage += "- First Name contains invalid characters ";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "- First Name is null or Empty ";
                }

                if (lastName.Text != "" && lastName.Text != null)
                {
                    if (lastName.Text.Length > 15)
                    {
                        isValid = false;
                        alertMessage += "- Last Name is more than 15 characters ";
                    }

                    if (!lastName.Text.Trim().All(char.IsLetter))
                    {
                        isValid = false;
                        alertMessage += "- Last Name contains invalid characters ";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "- Last Name is null or Empty ";
                }

                if (phonenum.Text != "" && phonenum.Text != null)
                {
                    if (phonenum.Text.Length != 10)
                    {
                        isValid = false;
                        alertMessage += "- Phone Number is more than 10 characters ";
                    }

                    if (!phonenum.Text.Trim().All(char.IsDigit))
                    {
                        isValid = false;
                        alertMessage += "- Phone Number contains invalid characters ";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "- Phone Number is null or Empty ";
                }

                if (email.Text != null)
                {

                }

                if (location.Text != "" && location.Text != null)
                {
                    if (location.Text == "Choose...")
                    {
                        isValid = false;
                        alertMessage += "- Location is not choosed ";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "- Location is null or Empty ";
                }

                if (vehicleNum.Text != "" && vehicleNum.Text != null)
                {
                    var arr = vehicleNum.Text.Trim().Replace(" ", "").ToCharArray();
                    if (char.IsLetter(arr[0]) && char.IsLetter(arr[1]) && char.IsDigit(arr[2]) && char.IsDigit(arr[3]) && char.IsLetter(arr[4]) && char.IsDigit(arr[5]))
                    {
                        
                    }
                    else
                    {
                        isValid = false;
                        alertMessage += "- vehicleNum is not valid ";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "- Vehicle Number is null or Empty ";
                }

                if (vehicleModel.Text != "" && vehicleModel.Text != null)
                {

                }
                else
                {
                    isValid = false;
                    alertMessage += "- Vehicle Model is null or Empty ";
                }

                if (serviceType.Text != "" && serviceType.Text != null)
                {
                    if (serviceType.Text == "Choose...")
                    {
                        isValid = false;
                        alertMessage += "- Service Type is not choosed ";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "- Service Type is null or Empty ";
                }

                if (serviceDate.Text != "" && serviceDate.Text != null)
                {
                    DateTime dateToCheck = DateTime.Parse(serviceDate.Text);
                    DateTime startDate = DateTime.Now.AddDays(1);
                    DateTime endDate = startDate.AddDays(30);

                    if (dateToCheck == DateTime.MinValue)
                    {
                        isValid = false;
                        alertMessage += "- Service Date is invalid ";
                    }
                    else
                    {
                        if (!(dateToCheck >= startDate && dateToCheck < endDate))
                        {
                            isValid = false;
                            alertMessage += "- Service Date should be in range " + startDate.ToString("MM/dd/yyyy") + " to " + endDate.ToString("MM/dd/yyyy") + " ";
                        }
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "- Service Date is null or Empty ";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                alertMessage = "Booking Details are Wrong";
                isValid = false;
            }
            return isValid;
        }
    }
}
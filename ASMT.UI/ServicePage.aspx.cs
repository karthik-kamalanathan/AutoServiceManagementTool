using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASMT.Dataprovider.Models;
using ASMT.Dataprovider.Implementations;
using System.Web.UI.HtmlControls;

namespace ASMT.UI
{
    public partial class ServicePage : Page
    {
        Booking bookingData;
        AutoService serviceData;
        TrackStatus statusData;
        DealerService dealerService;
        TrackService trackService;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string bookingId = Request.QueryString["BookingId"];

                trackService = new TrackService();
                dealerService = new DealerService();

                bookingData = trackService.GetBookingData(bookingId);
                statusData = trackService.GetBookingStatus(bookingId);
                serviceData = dealerService.GetServiceData(bookingId);

                PopulateData();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void UpdateService(object sender, EventArgs e)
        {
            try
            {
                var dataFromModal = new Dictionary<string, bool>();

                foreach (var task in serviceData.ServiceTasks)
                {
                    var checkBox = (HtmlInputCheckBox)FindControl("chck" + task.Key.Replace(" ", String.Empty));
                    if (checkBox != null)
                    {
                        dataFromModal.Add(task.Key, checkBox.Checked);
                    }
                }

                var changed = dataFromModal.Where(entry => serviceData.ServiceTasks[entry.Key] != entry.Value).ToDictionary(entry => entry.Key, entry => entry.Value);

                if (changed != null)
                {
                    serviceData.ServiceTasks = dataFromModal;
                    dealerService.UpdateService(serviceData);

                    statusData.TasksDone = serviceData.ServiceTasks.Count(x => x.Value == true);
                    trackService.UpdateTrackingData(statusData);

                    var checkBoxes = GetAllControls(taskListArea).OfType<HtmlInputCheckBox>().ToList();

                    foreach (var check in checkBoxes)
                    {
                        if (check.Checked)
                            check.Disabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void ClearChanges(object sender, EventArgs e)
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

        protected void GoBack(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("DealerPage.aspx?Location=" + bookingData.Location, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void Completed(object sender, EventArgs e)
        {
            try
            {
                var Keys = serviceData.ServiceTasks.Keys.ToList();
                foreach (string key in Keys)
                    serviceData.ServiceTasks[key] = true;
                serviceData.CompletedDate = DateTime.Now;

                bookingData.CompletedDate = DateTime.Now;

                statusData.TasksDone = statusData.TasksTotal;
                statusData.IsCompleted = true;
                statusData.ExpectedDate = DateTime.Now;

                trackService.UpdateTrackingData(statusData);
                dealerService.UpdateBooking(bookingData);
                dealerService.UpdateService(serviceData);

                var checkBoxes = GetAllControls(taskListArea).OfType<HtmlInputCheckBox>().ToList();

                foreach (var check in checkBoxes)
                {
                    check.Checked = true;
                    check.Disabled = true;
                }

                updateBtn.Attributes["class"] += " disabled";                
                completeBtn.Attributes["class"] += " disabled";
                clearBtn.Attributes["class"] += " disabled";

                status.InnerHtml = "<strong>Staus : </strong> Service Completed";
                completedDate.InnerHtml = "<strong>Completed Date: </strong>" + bookingData.CompletedDate.ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        private void PopulateData()
        {
            int percentComplete = (int)Math.Round((double)(100 * statusData.TasksDone) / statusData.TasksTotal);
            progressbar.Style.Add(HtmlTextWriterStyle.Width, percentComplete + "%");
            progressbar.Attributes.Add("aria-valuenow", percentComplete.ToString());
            progressbar.InnerText = percentComplete + "%";

            name.InnerHtml = "<strong>Name : </strong>" + bookingData.Name;
            phone.InnerHtml = "<strong>Phone : </strong>" + bookingData.Phone;
            vehicleModel.InnerHtml = "<strong>Model : </strong>" + bookingData.VehicleModel;
            vehicleNum.InnerHtml = "<strong>Vehicle.No : </strong>" + bookingData.VehicleNumber;
            createdDate.InnerHtml = "<strong>Created Date : </strong>" + bookingData.CreatedDate.ToString("MM/dd/yyyy");
            bookedDate.InnerHtml = "<strong>Service Date: </strong>" + bookingData.RequestedDate.ToString("MM/dd/yyyy");
            if (statusData.IsCompleted)
            {
                status.InnerHtml = "<strong>Staus : </strong> Service Completed";
                completedDate.InnerHtml = "<strong>Completed Date: </strong>" + bookingData.CompletedDate.ToString("MM/dd/yyyy");
                updateBtn.Attributes["class"] += " disabled";
                completeBtn.Attributes["class"] += " disabled";
                clearBtn.Attributes["class"] += " disabled";
            }
            else
            {
                status.InnerHtml = "<strong>Staus : </strong> Service Still in Progress";
                completedDate.InnerHtml = "<strong>Expected Date: </strong>" + statusData.ExpectedDate.ToString("MM/dd/yyyy");
            }


            foreach (var task in serviceData.ServiceTasks)
            {
                var div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "form-check");

                var checkBox = new HtmlInputCheckBox()
                {
                    ID = "chck" + task.Key.Replace(" ", String.Empty),
                };
                checkBox.Attributes.Add("class", "form-check-input");
                checkBox.Attributes.Add("type", "checkbox");
                checkBox.Attributes.Add("runat", "server");
                if (task.Value)
                {
                    checkBox.Checked = true;
                    checkBox.Disabled = true;
                }
                else
                {
                    checkBox.Checked = false;
                }

                div.Controls.Add(checkBox);

                var checkLabel = new HtmlGenericControl("label")
                {
                    InnerText = task.Key
                };
                checkLabel.Attributes.Add("class", "form-check-label");
                checkLabel.Attributes.Add("for", checkBox.ID);
                div.Controls.Add(checkLabel);

                taskListArea.Controls.Add(div);
            }
        }

        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control descendant in GetAllControls(control))
                {
                    yield return descendant;
                }
            }
        }
    }
}
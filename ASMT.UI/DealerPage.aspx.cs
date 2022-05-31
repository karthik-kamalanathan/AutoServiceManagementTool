using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASMT.Dataprovider.Models;
using ASMT.Dataprovider.Implementations;
using System.Web.UI.HtmlControls;

namespace ASMT.UI
{
    public partial class DealerPage : System.Web.UI.Page
    {
        string location;
        DealerService dealerService;
        List<Booking> bookings;
        AutoService autoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                location = Request.QueryString["Location"];
                if (location == null)
                    location = "Kumbakonam";

                dealerService = new DealerService();

                bookings = dealerService.GetBookings(location);

                var sortedBookings = bookings.OrderBy(o => o.RequestedDate).ToList();
                sortedBookings.RemoveAll(r => r.CompletedDate != DateTime.MinValue);

                if (bookings == null || bookings.Count == 0)
                {
                    var serviceElement = new LinkButton();
                    serviceElement.Click += new EventHandler(OnClickListItem);
                    serviceElement.ID = "noservice";
                    serviceElement.Attributes.Add("class", "list-group-item list-group-item-action py-3 lh-tight");
                    serviceElement.Attributes.Add("aria-current", "true");
                    serviceElement.Attributes.Add("runat", "server");

                    var divContent = new HtmlGenericControl("div");
                    divContent.Attributes.Add("class", "d-flex w-100 align-items-center justify-content-between");

                    var heading = new HtmlGenericControl("strong")
                    {
                        InnerText = "No Services Pending Completion" 
                    };
                    heading.Attributes.Add("class", "mb-1");
                    divContent.Controls.Add(heading);
                    serviceElement.Controls.Add(divContent);
                    contentArea.Controls.Add(serviceElement);
                }
                else
                {
                    foreach (var booking in bookings)
                    {
                        var serviceElement = new LinkButton();
                        serviceElement.Click += new EventHandler(OnClickListItem);
                        serviceElement.ID = booking.BookingId.ToString();
                        serviceElement.Attributes.Add("class", "list-group-item list-group-item-action py-3 lh-tight");
                        serviceElement.Attributes.Add("aria-current", "true");
                        serviceElement.Attributes.Add("runat", "server");

                        var divContent = new HtmlGenericControl("div");
                        divContent.Attributes.Add("class", "d-flex w-100 align-items-center justify-content-between");

                        var heading = new HtmlGenericControl("strong")
                        {
                            InnerText = booking.Name + " - " + booking.VehicleModel + " - " + booking.VehicleNumber
                        };
                        heading.Attributes.Add("class", "mb-1");
                        divContent.Controls.Add(heading);

                        var date = new HtmlGenericControl("small")
                        {
                            InnerText = booking.CreatedDate.ToString("MM/dd/yyyy")
                        };
                        date.Attributes.Add("class", "text-muted");
                        divContent.Controls.Add(date);

                        serviceElement.Controls.Add(divContent);

                        var divSubtext = new HtmlGenericControl("div")
                        {
                            InnerText = "Expected to be returned to customer at " + booking.RequestedDate.ToString("MM/dd/yyyy") + "."
                        };
                        divSubtext.Attributes.Add("class", "col-10 mb-1 small");
                        serviceElement.Controls.Add(divSubtext);

                        contentArea.Controls.Add(serviceElement);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void OnClickListItem(object sender, EventArgs e)
        {
            try
            {
                long bookId = Convert.ToInt64(((LinkButton)sender).ID);

                if (bookings != null)
                {
                    var booking = bookings.Where(x => x.BookingId == bookId).FirstOrDefault();
                }

                autoService = dealerService.GetServiceData(bookId);

                //Populate Modal Data

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openSuccessModal();", true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void saveChanges(object sender, EventArgs e)
        {
            try
            {
                TrackService track = new TrackService();
                
                //Get Changes From Web Page

                //Modify Service Data

                //Modify Tracking Data

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                location = Request.QueryString["Location"];

                dealerService = new DealerService();

                List<Booking> bookings = dealerService.GetBookings(location);

                if (bookings == null || bookings.Count == 0)
                {
                    var serviceElement = new HyperLink();
                    serviceElement.Attributes.Add("data-bs-toggle", "modal");
                    serviceElement.Attributes.Add("data-bs-target", "#serviceDetailsModal");
                    serviceElement.Attributes.Add("class", "list-group-item list-group-item-action py-3 lh-tight");
                    serviceElement.Attributes.Add("aria-current", "true");
                    serviceElement.Attributes.Add("id", "noservice");
                    serviceElement.Attributes.Add("runat", "server");
                    serviceElement.Attributes.Add("OnClick", "OnClickListItem");

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
                        var serviceElement = new HyperLink();
                        serviceElement.Attributes.Add("data-bs-toggle", "modal");
                        serviceElement.Attributes.Add("data-bs-target", "#serviceDetailsModal");
                        serviceElement.Attributes.Add("class", "list-group-item list-group-item-action py-3 lh-tight");
                        serviceElement.Attributes.Add("aria-current", "true");
                        serviceElement.Attributes.Add("id", booking.BookingId.ToString());
                        serviceElement.Attributes.Add("runat", "server");
                        serviceElement.Attributes.Add("OnClick", "OnClickListItem");

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

        }


    }
}
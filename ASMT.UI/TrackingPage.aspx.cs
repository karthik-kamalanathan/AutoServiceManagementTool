using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASMT.Dataprovider.Models;
using ASMT.Dataprovider.Implementations;

namespace ASMT.UI
{
    public partial class TrackingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                trackdetails.Visible = false;
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

                if (trackStatus != null)
                {
                    //Populate Data to Div

                    trackdetails.Visible = true;
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
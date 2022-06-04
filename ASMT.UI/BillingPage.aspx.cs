using System;

namespace ASMT.UI
{
    public partial class BillingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var amount = Request.QueryString["BillAmount"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void checkoutClick(object sender, EventArgs e)
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

        protected void goBackClick(object sender, EventArgs e)
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
    }
}
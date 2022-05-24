using System;

namespace ASMT.UI
{
    public partial class IndexPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("Pages/ErrorPage.aspx");
            }
        }

        protected void signinClick(object sender, EventArgs e)
        {
            try
            {
                bool isAuthorized = true;

                //Code to Validate Credentials

                if (isAuthorized)
                {
                    Response.Redirect("Pages/DealerPage.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    //Display Invalid Credentials Error
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Response.Redirect("Pages/ErrorPage.aspx");
            }
        }
    }
}
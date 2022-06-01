using System;
using System.Web.UI;
using ASMT.Dataprovider.Models;
using ASMT.Dataprovider.Implementations;

namespace ASMT.UI
{
    public partial class IndexPage : Page
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

        protected void signinClick(object sender, EventArgs e)
        {
            try
            {
                bool isAuthorized = false;
                DealerService dealerService = new DealerService();

                Credential credential = new Credential()
                {
                    Location = location.Text,
                    UserName = txtUsername.Text,
                    Password = txtPswd.Text
                };

                isAuthorized = dealerService.DealerLogin(credential);

                if (isAuthorized)
                {
                    Response.Redirect("DealerPage.aspx?Location=" + credential.Location, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong Credentials')", true);
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
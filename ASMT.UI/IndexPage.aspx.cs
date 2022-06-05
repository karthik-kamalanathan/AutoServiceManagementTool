using System;
using System.Linq;
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

                string alertMessage;
                if (!ValidateCredentials(credential, out alertMessage))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + alertMessage + "')", true);
                    return;
                }

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

        private bool ValidateCredentials(Credential credential, out string alertMessage)
        {
            bool isValid = true;
            try
            {
                alertMessage = "Following Values are Wrong or Invalid:";

                if (credential.UserName != null && credential.UserName != "")
                {

                    if (credential.UserName.Length > 12)
                    {
                        isValid = false;
                        alertMessage += "\n * Username is more than 12 characters";
                    }

                    if (!credential.UserName.All(char.IsLetter))
                    {
                        isValid = false;
                        alertMessage += "\n * Username contains characters other than Alphabets";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "\n * username is Empty or Null";
                }

                if (credential.Password != null && credential.Password != "")
                {
                    if (credential.Password.Length > 12)
                    {
                        isValid = false;
                        alertMessage += "\n * Password is more than 12 characters";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "\n * password is Empty or Null";
                }

                if (credential.Location != null && credential.Location != "")
                {
                    if (credential.Location == "Choose...")
                    {
                        isValid = false;
                        alertMessage += "\n * Location is not choosed";
                    }
                }
                else
                {
                    isValid = false;
                    alertMessage += "\n * Location is Empty or Null";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                alertMessage = "Wrong Credentials";
                return false;
            }
            return isValid;
        }
    }
}
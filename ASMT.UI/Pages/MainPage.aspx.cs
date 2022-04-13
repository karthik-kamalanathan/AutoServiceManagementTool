using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASMT.UI
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Contents.RemoveAll();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void signin_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void bookService_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void trackStatus_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

    }

}
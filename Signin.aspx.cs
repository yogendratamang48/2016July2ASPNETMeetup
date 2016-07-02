using Demo.Meetup.CustomMembership.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Meetup.CustomMembership
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    // This is an unauthorized, authenticated request...
                    Response.Redirect("PermissionDenied.aspx");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (DBAccess.AuthenticateUser(txtUsername.Text.Trim(), DBAccess.Encryption(txtPassword.Text.Trim())))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Log in Successfully Credentials !')", true);
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, false);


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Invalid Credentials !')", true);
            }
        }
    }
}
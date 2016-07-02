using Demo.Meetup.CustomMembership.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Meetup.CustomMembership
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            tblUser user = new tblUser();
            user.fldUsername = txtUser.Text.Trim();
            user.fldPassword = txtPassword.Text.Trim();
            user.fldRole = txtRole.Text.Trim().ToLower();
            if (!DBAccess.DoesUsernameAlreadyExists(user.fldUsername))
            {
                DBAccess.CreateUser(user);
                lblInfo.Text = "User Created Successfully!";
            }
        }
    }
}
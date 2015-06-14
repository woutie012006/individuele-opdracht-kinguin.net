#region

using System;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
{
    public partial class Login : System.Web.UI.Page
    {
        private Administration administration;

        protected void Page_Load(object sender, EventArgs e)
        {
            administration = Master.administration;
            User c = administration.currentUser;

            if (c != null)
                Response.Redirect("~/");

            LoginForm.UserNameLabelText = "E-mail ";
        }

        protected void LoginForm_OnAuthenticate(object sender, AuthenticateEventArgs e) //different class ??????
        {
            System.Web.UI.WebControls.Login l = (System.Web.UI.WebControls.Login) sender;
            if (administration.Login(l.UserName, l.Password))
            {
                e.Authenticated = true;
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
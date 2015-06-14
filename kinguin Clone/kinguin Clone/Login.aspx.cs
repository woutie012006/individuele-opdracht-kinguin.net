using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kinguin_Clone;
using Kinguin_Clone.classes;
using Oracle.ManagedDataAccess.Client;

namespace Kinguin_Clone
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
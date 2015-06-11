using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ict4Events_WindowsForms;
using kinguin_Clone.classes;
using Microsoft.Ajax.Utilities;
using Oracle.ManagedDataAccess.Client;

namespace kinguin_Clone
{
    public partial class Login : System.Web.UI.Page
    {
        Administration administration = new Administration();


        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["kinguin"];

            if (c != null && !string.IsNullOrEmpty(c.Value))
                        Response.Redirect("~/");
            
            LoginForm.UserNameLabelText = "E-mail ";

        }

        protected void LoginForm_OnAuthenticate(object sender, AuthenticateEventArgs e)//different class ??????
        {
            System.Web.UI.WebControls.Login l = (System.Web.UI.WebControls.Login)sender;
            if (administration.Login(l.UserName, l.Password))
            {
                e.Authenticated = true;
                Response.Redirect("~/Default.aspx");
            }
        }

    }
}
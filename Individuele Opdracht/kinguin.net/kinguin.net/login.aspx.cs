using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kinguin.net
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginForm_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            Login l = (Login) sender;
            if (l.UserName == "admin")
            {
                Response.Cookies["kinguin"]["loggedin"] = "admin";

            }
        }
    }
}
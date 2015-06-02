using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kinguin.net
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Response.Cookies["kinguin.net"]["loggedin"] != null)
            {
                btnLogin.Text = "Log out";
           }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            if (((Button) sender).Text == "login")
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Cookies["kinguin"]["loggedin"] = "";
            }
        }
    }
}
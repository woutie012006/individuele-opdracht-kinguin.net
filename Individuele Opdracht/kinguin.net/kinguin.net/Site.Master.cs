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
            //string k = Request.Cookies["kinguin.net"]["loggedin"];
            //Response.Cookies["kinguin"].Value = "admin";
            //k = Response.Cookies["kinguin"].Value;
            //HttpCookie h = Request.Cookies["kinguin.net"];
            string k = Request.Cookies["kinguin"].Value;
            if (!string.IsNullOrEmpty(k))
            {
                btnLogin.Text = "Log out";
           }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
           // Response.Redirect("login.aspx");

            if (((LinkButton) sender).Text.ToUpper() == "LOGIN")
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Cookies["kinguin"].Value = "";
                Response.Redirect("login.aspx");
            }
        }
    }
}
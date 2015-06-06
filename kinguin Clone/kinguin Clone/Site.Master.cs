using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kinguin_Clone
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["kinguin"];
            if (c!=null && !string.IsNullOrEmpty(c.Value))
            {
                btnLogin.Text = "Log out";
            }
        }
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            // Response.Redirect("login.aspx");

            if (((LinkButton)sender).Text.ToUpper() == "LOGIN")
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
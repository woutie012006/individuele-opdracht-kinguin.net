using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class SiteMaster : MasterPage
    {
        public Administration administration
        {
            get
            {
                Administration a =  (Administration) Session["administration"];
                if (a != null)
                {
                    return a;
                }
                return new Administration();
            }
            set { Session["administration"] = value; }
        }
                
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginLogout.NavigateUrl = "/Default.aspx";

            HttpCookie c = Request.Cookies["kinguin"];
            if (c != null && !string.IsNullOrEmpty(c.Value))
            {
                LoginLogout.Text = "Log out";
                LoginLogout.NavigateUrl = "/Logout.aspx";
            }else
            {
                LoginLogout.NavigateUrl = "/Login.aspx";
            }

        }

        //protected void btnLogin_OnClick(object sender, EventArgs e)
        //{
        //    // Response.Redirect("login.aspx");
        //    string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
        //    if (((LinkButton)sender).Text.ToUpper() == "LOGIN")
        //    {
        //        Response.Redirect("/login.aspx");
        //    }
        //    else
        //    {
        //        Response.Cookies["kinguin"].Value = "";
        //        Response.Redirect("login.aspx");
        //    }
        //}

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {

            string searchterm = tbSearch.Text;//.Replace(" ", "?");
          
            Response.Redirect("GamesPage.aspx/search/" + searchterm);

        }
    }
}
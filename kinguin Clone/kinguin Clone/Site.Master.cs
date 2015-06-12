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

            //HttpCookie c = Request.Cookies["kinguin"];
            User c = administration.currentUser;

            if (c != null)
            {
                LoginLogout.Text = "Log out";
                LoginLogout.NavigateUrl = "/Logout.aspx";
            }else
            {
                LoginLogout.NavigateUrl = "/Login.aspx";
            }

        }
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {

            string searchterm = tbSearch.Text;//.Replace(" ", "?");
          
            Response.Redirect("GamesPage.aspx/search/" + searchterm);

        }
    }
}
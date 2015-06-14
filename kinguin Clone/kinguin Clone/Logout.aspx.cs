﻿#region

using System;
using System.Web.UI.WebControls;

#endregion

namespace kinguin_Clone
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.administration.currentUser = null;
            Session["administration"] = Master.administration;
            lblLogout.Text = "You have been successfully logged out";
            HyperLink h = (HyperLink) Master.FindControl("LoginLogout");
            h.Text = "Login";
            h.NavigateUrl = "Login.aspx";
        }
    }
}
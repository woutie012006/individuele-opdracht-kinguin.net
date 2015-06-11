﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kinguin_Clone
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["kinguin"].Value = "";
            lblLogout.Text = "You have been successfully logged out";
            HyperLink h = (HyperLink)Master.FindControl("LoginLogout");
            h.Text = "Login";
            h.NavigateUrl = "Login.aspx";
        }
    }
}
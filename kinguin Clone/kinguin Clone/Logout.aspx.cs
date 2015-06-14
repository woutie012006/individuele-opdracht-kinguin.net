// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logout.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The logout.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Web.UI.WebControls;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The logout.
    /// </summary>
    public partial class Logout : System.Web.UI.Page
    {
        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.administration.CurrentUser = null;
            this.Session["administration"] = Master.administration;
            this.lblLogout.Text = "You have been successfully logged out";
            HyperLink h = (HyperLink)Master.FindControl("LoginLogout");
            h.Text = "Login";
            h.NavigateUrl = "Login.aspx";
        }
    }
}
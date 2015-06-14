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
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.administration.CurrentUser = null;
            this.Session["administration"] = this.Master.administration;
            this.lblLogout.Text = "You have been successfully logged out";
            HyperLink h = (HyperLink)this.Master.FindControl("LoginLogout");
            h.Text = "Login";
            h.NavigateUrl = "Login.aspx";
        }
    }
}
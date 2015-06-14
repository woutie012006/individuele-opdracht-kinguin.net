// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Site.Master.cs" company="">
//   
// </copyright>
// <summary>
//   The site master.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Web.UI;

using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The site master.
    /// </summary>
    public partial class SiteMaster : MasterPage
    {
        /// <summary>
        /// Gets or sets the administration.
        /// </summary>
        public Administration administration
        {
            get
            {
                Administration a = (Administration)this.Session["administration"];
                if (a != null)
                {
                    return a;
                }

                return new Administration();
            }

            set
            {
                this.Session["administration"] = value;
            }
        }

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
            this.LoginLogout.NavigateUrl = "/Default.aspx";

            // HttpCookie c = Request.Cookies["kinguin"];
            User c = this.administration.CurrentUser;
            if (c != null)
            {
                this.LoginLogout.Text = "Log out";
                this.LoginLogout.NavigateUrl = "/Logout.aspx";
                this.hlUserPage.Visible = true;
            }
            else
            {
                this.LoginLogout.NavigateUrl = "/Login.aspx";
            }
        }

        /// <summary>
        /// The btn search_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            string searchterm = this.tbSearch.Text; // .Replace(" ", "?");

            this.Response.Redirect("GamesPage.aspx/search/" + searchterm);
        }
    }
}
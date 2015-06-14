// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPage.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The user page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;

using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The user page.
    /// </summary>
    public partial class UserPage : System.Web.UI.Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private Administration administration;

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
            this.administration = Master.administration;

            if (this.administration == null || this.administration.CurrentUser == null)
            {
                this.Response.Redirect("~/Default.aspx");
            }

            this.lblName.Text = "Name : " + this.administration.CurrentUser.Name;
            this.lblAdres.Text = "Adres : " + this.administration.CurrentUser.Adres;
            this.lblPhonenr.Text = "Phone number : " + this.administration.CurrentUser.Name;
            this.lblKinguinBalance.Text = "Kinguin Balance : " + this.administration.CurrentUser.KinguinBalance;

            if (this.Master.administration.CurrentUser is Admin)
            {
                this.hlAddGame.Visible = true;
                this.hlAdminUserinfo.Visible = true;
            }
            else if (Master.administration.CurrentUser is Seller)
            {
                this.hlChangeUserinfo.Visible = true;
                this.hlAddObject.Visible = true;
            }
            else if (Master.administration.CurrentUser is Buyer)
            {
                this.hlChangeUserinfo.Visible = true;
            }
        }
    }
}
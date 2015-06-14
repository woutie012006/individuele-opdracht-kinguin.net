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
            this.administration = this.Master.administration;

            if (this.administration == null || this.administration.currentUser == null)
            {
                this.Response.Redirect("~/Default.aspx");
            }

            this.lblName.Text = "Name : " + this.administration.currentUser.Name;
            this.lblAdres.Text = "Adres : " + this.administration.currentUser.Adres;
            this.lblPhonenr.Text = "Phone number : " + this.administration.currentUser.Name;
            this.lblKinguinBalance.Text = "Kinguin Balance : " + this.administration.currentUser.KinguinBalance;

            if (this.Master.administration.currentUser is Admin)
            {
                this.hlAddGame.Visible = true;
            }
            else if (this.Master.administration.currentUser is Seller)
            {
                this.hlChangeUserinfo.Visible = true;
                this.hlAddObject.Visible = true;
            }
            else if (this.Master.administration.currentUser is Buyer)
            {
                this.hlChangeUserinfo.Visible = true;
            }
        }
    }
}
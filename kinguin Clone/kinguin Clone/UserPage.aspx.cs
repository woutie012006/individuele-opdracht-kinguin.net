﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPage.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The user page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;

using Kinguin_Clone.classes;

#endregion

namespace Kinguin_Clone
{
    using Kinguin_Clone.classes;

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
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.administration = this.Master.administration;

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
            }
            else if (this.Master.administration.CurrentUser is Seller)
            {
                this.hlChangeUserinfo.Visible = true;
                this.hlAddObject.Visible = true;
            }
            else if (this.Master.administration.CurrentUser is Buyer)
            {
                this.hlChangeUserinfo.Visible = true;
            }
        }
    }
}
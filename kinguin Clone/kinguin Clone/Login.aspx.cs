﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Login.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The login.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Web.UI.WebControls;

using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The login.
    /// </summary>
    public partial class Login : System.Web.UI.Page
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
            User c = this.administration.CurrentUser;

            if (c != null)
            {
                this.Response.Redirect("~/");
            }

            this.LoginForm.UserNameLabelText = "E-mail ";
        }

        /// <summary>
        /// The login form_ on authenticate.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void LoginForm_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            
            System.Web.UI.WebControls.Login l = (System.Web.UI.WebControls.Login)sender;
            if (this.administration.Login(l.UserName.ToLower(), l.Password))
            {
                e.Authenticated = true;
                this.Response.Redirect("~/Default.aspx");
            }
        }
    }
}
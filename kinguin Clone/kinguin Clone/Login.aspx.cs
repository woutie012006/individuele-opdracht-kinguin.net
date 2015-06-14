// --------------------------------------------------------------------------------------------------------------------
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

using Kinguin_Clone.classes;

#endregion

namespace Kinguin_Clone
{
    using Kinguin_Clone.classes;

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
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.administration = this.Master.administration;
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
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void LoginForm_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            // different class ??????
            System.Web.UI.WebControls.Login l = (System.Web.UI.WebControls.Login)sender;
            if (this.administration.Login(l.UserName, l.Password))
            {
                e.Authenticated = true;
                this.Response.Redirect("~/Default.aspx");
            }
        }
    }
}
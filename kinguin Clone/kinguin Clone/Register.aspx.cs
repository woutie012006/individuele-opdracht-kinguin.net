// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Register.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The register.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The register.
    /// </summary>
    public partial class Register : System.Web.UI.Page
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
        }

        /// <summary>
        /// The btn submit_ on click.
        /// </summary>
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                bool succes = this.Master.administration.Register(
                    this.tbName.Text, 
                    this.tbAdres.Text, 
                    this.tbTelNr.Text, 
                    this.tbEmail.Text, 
                    this.tbPassword1.Text, 
                    this.tbNickname.Text);
                if (succes)
                {
                    this.Response.Redirect("Login.aspx");
                }
                else
                {
                    this.Response.Redirect("#");
                }
            }
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeUserInfo.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The change user info.
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
    /// The change user info.
    /// </summary>
    public partial class ChangeUserInfo : System.Web.UI.Page
    {
        /// <summary>
        /// The c user.
        /// </summary>
        private User cUser;

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
            if (this.Master.administration == null || this.Master.administration.CurrentUser == null)
            {
                this.Response.Redirect("Default.aspx");
            }

            this.cUser = this.Master.administration.CurrentUser;

            this.tbName.Text = this.cUser.Name;
            this.tbAdres.Text = this.cUser.Adres;
            this.tbTelNr.Text = this.cUser.PhoneNr;
            this.tbEmail.Text = this.cUser.Email;
            this.tbNickname.Text = ((Buyer)this.cUser).Nickname;

            // for now you can;t change your password
            if (this.cUser is Seller)
            {
                this.lblSellerName.Visible = true;
                this.tbSellerName.Visible = true;
                this.tbSellerNameVal.Enabled = true;

                this.tbSellerName.Text = ((Seller)this.cUser).SellerName;

                this.lblBankAccount.Visible = true;
                this.tbBankAccount.Visible = true;
                this.tbBankAccountVal.Enabled = true;

                this.tbBankAccount.Text = ((Seller)this.cUser).BankAccount;
            }
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
            if (this.tbName.Text != this.cUser.Name)
            {
                this.cUser.ChangeName(this.tbName.Text);
            }

            if (this.tbAdres.Text != this.cUser.Adres)
            {
                this.cUser.ChangeAdres(this.tbAdres.Text);
            }

            if (this.tbTelNr.Text != this.cUser.PhoneNr)
            {
                this.cUser.ChangePhoneNr(this.tbTelNr.Text);
            }

            if (this.tbEmail.Text != this.cUser.Email)
            {
                this.cUser.ChangeEmail(this.tbEmail.Text);
            }

            if (this.tbNickname.Text != ((Buyer)this.cUser).Nickname)
            {
                ((Buyer)this.cUser).ChangeNickname(this.tbNickname.Text);
            }

            if (this.cUser is Seller)
            {
                Seller sUser = this.cUser as Seller;
                if (this.tbSellerName.Text != sUser.SellerName)
                {
                    sUser.ChangeSellerName(this.tbSellerName.Text);
                }

                if (this.tbBankAccount.Text != sUser.SellerName)
                {
                    sUser.ChangeBankAccount(this.tbBankAccount.Text);
                }
            }
        }
    }
}
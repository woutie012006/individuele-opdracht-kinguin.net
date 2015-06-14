using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kinguin_Clone.classes;

namespace Kinguin_Clone
{
    public partial class ChangeUserInfo : System.Web.UI.Page
    {
        private User cUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Master.administration == null || Master.administration.currentUser == null)
            {
                Response.Redirect("Default.aspx");
            }
            cUser = Master.administration.currentUser;

            tbName.Text = cUser.Name;
            tbAdres.Text = cUser.Adres;
            tbTelNr.Text = cUser.PhoneNr;
            tbEmail.Text = cUser.Email;
            tbNickname.Text = ((Buyer) cUser).Nickname;
            //for now you can;t change your password
            if (cUser is Seller)
            {
                lblSellerName.Visible = true;
                tbSellerName.Visible = true;
                tbSellerNameVal.Enabled = true;

                tbSellerName.Text = ((Seller) cUser).SellerName;

                lblBankAccount.Visible = true;
                tbBankAccount.Visible = true;
                tbBankAccountVal.Enabled = true;

                tbBankAccount.Text = ((Seller) cUser).BankAccount;
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (tbName.Text != cUser.Name)
            {
                cUser.ChangeName(tbName.Text);
            }

            if (tbAdres.Text != cUser.Adres)
            {
                cUser.ChangeAdres(tbAdres.Text);
            }

            if (tbTelNr.Text != cUser.PhoneNr)
            {
                cUser.ChangePhoneNr(tbTelNr.Text);
            }

            if (tbEmail.Text != cUser.Email)
            {
                cUser.ChangeEmail(tbEmail.Text);
            }

            if (tbNickname.Text != ((Buyer) cUser).Nickname)
            {
                ((Buyer) cUser).ChangeNickname(tbNickname.Text);
            }

            if (cUser is Seller)
            {
                Seller sUser = cUser as Seller;
                if (tbSellerName.Text != sUser.SellerName)
                {
                    sUser.ChangeSellerName(tbSellerName.Text);
                }

                if (tbBankAccount.Text != sUser.SellerName)
                {
                    sUser.ChangeBankAccount(tbBankAccount.Text);
                }

            }

        }
    }
}
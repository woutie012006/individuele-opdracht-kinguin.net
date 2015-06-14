using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kinguin_Clone
{
    using kinguin_Clone.classes;

    /// <summary>
    /// The become seller.
    /// </summary>
    public partial class BecomeSeller : System.Web.UI.Page
    {
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
            if (!(this.Master.administration.CurrentUser is Admin))
            {
                Response.Redirect("Default.aspx");
            }
        }

        /// <summary>
        /// The btn submit_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BtnSubmit_OnClick(object sender, EventArgs e)
        {

            if ((this.Master.administration.CurrentUser as Buyer).BecomeSeller(tbSellername.Text, tbBankaccount.Text))
            {
                this.ClientScript.RegisterStartupScript(
                       this.GetType(),
                       "Game alert",
                       "alert('" + "You succesfully became a seller !." + "');",
                       true);
                Response.Redirect("UserPage.aspx");
            }

        }
    }
}
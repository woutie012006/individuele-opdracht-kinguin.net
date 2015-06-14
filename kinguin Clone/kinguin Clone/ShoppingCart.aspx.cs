// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShoppingCart.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The shopping cart.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The shopping cart.
    /// </summary>
    public partial class ShoppingCart : System.Web.UI.Page
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
            if (this.administration.CurrentUser != null)
            {
                // url redirection check
                string sellingobject = this.Request.QueryString["GameCopyID"];

                if (this.administration.CurrentUser != null && this.administration.CurrentUser is Seller)
                {
                    if (!string.IsNullOrEmpty(sellingobject))
                    {
                        (this.administration.CurrentUser as Seller).cart.AddCopyByID(
                            Convert.ToInt32(sellingobject), 
                            this.administration.CurrentUser);
                    }

                    List<GameCopy> data = ((Seller)this.administration.CurrentUser).cart.Owned;
                    this.ItemView.DataSource = data;
                }
                else if (this.administration.CurrentUser != null && this.administration.CurrentUser is Buyer)
                {
                    if (!string.IsNullOrEmpty(sellingobject))
                    {
                        (this.administration.CurrentUser as Buyer).cart.AddCopyByID(
                            Convert.ToInt32(sellingobject), 
                            this.administration.CurrentUser);
                    }

                    List<GameCopy> data = ((Buyer)this.administration.CurrentUser).cart.Owned;
                    this.ItemView.DataSource = data;
                }
            }
        }

        /// <summary>
        /// The page_ pre render.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.ItemView.DataBind();
        }

        /// <summary>
        /// The item view_ on item data bound view_ item data bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ItemView_OnItemDataBoundView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // throw new NotImplementedException();
        }
    }
}
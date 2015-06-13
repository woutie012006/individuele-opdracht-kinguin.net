using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        private Administration administration;

        protected void Page_Load(object sender, EventArgs e)
        {
            administration = Master.administration;
            if (administration.currentUser != null)
            {
                //url redirection check
                string sellingobject = Request.QueryString["GameCopyID"] ;
                


                if (administration.currentUser != null && administration.currentUser is Seller)
                {
                    if (!string.IsNullOrEmpty(sellingobject))
                    {
                        (administration.currentUser as Seller).cart.AddCopyByID(Convert.ToInt32(sellingobject), administration.currentUser);
                    }
                    List<GameCopy> data = ((Seller)administration.currentUser).cart.owned;
                    ItemView.DataSource = data;
                }
                else if (administration.currentUser != null && administration.currentUser is Buyer)
                {
                    
                    if (!string.IsNullOrEmpty(sellingobject))
                    {
                        (administration.currentUser as Buyer).cart.AddCopyByID(Convert.ToInt32(sellingobject), administration.currentUser);
                    }
                    List<GameCopy> data = ((Buyer)administration.currentUser).cart.owned;
                    ItemView.DataSource = data;
                }
            }





        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ItemView.DataBind();
        }
        protected void ItemView_OnItemDataBoundView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        Administration administration = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<GameCopy> data = administration.GetCartCopies();
            ItemView.DataSource = data;
        }

        protected void ItemView_OnItemDataBoundView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
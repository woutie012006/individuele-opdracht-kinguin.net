using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class GamesPage : System.Web.UI.Page
    {
        Administration administration = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Game> data = administration.GetallGames();
            GamesView.DataSource = data;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            GamesView.DataBind();
        }

        protected void GamesView_OnItemDataBound_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Game game = e.Item.DataItem as Game;
            Image image = e.Item.FindControl("IMGGame") as Image;
            image.ImageUrl = game.picture;

            HyperLink btnbuyNow = e.Item.FindControl("btnBuyNow") as HyperLink;
            btnbuyNow.NavigateUrl = "~/ShoppingCart.aspx/" + game.gameNr;

            HyperLink btnMoreInfo = e.Item.FindControl("btnMoreInfo") as HyperLink;
            btnbuyNow.NavigateUrl = "~/GameInfo.aspx/" + game.gameNr;
        }
      
    }
}
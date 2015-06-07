using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class GameInfo : System.Web.UI.Page
    {
        Administration administration = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Game> data = new List<Game>();
            data.Add(administration.getGameByID(1));//will need id from url
            GameView.DataSource = data;
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            GameView.DataBind();
        }

        protected void GamesView_OnItemDataBound_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Game game = e.Item.DataItem as Game;
            Image image = e.Item.FindControl("imgGame") as Image;
            image.ImageUrl = game.picture;
        }
    }
}
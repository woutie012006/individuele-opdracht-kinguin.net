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
        private Administration administration = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] url = Request.RawUrl.Split('/');


            if (Request.RawUrl.EndsWith("Page"))
            {
                List<Game> data = administration.GetallGames();
                GamesView.DataSource = data;
            }
            else if (url[url.Length - 2].ToUpper() == "GENRE") //check if it needs to look for genre.
            {
                try
                {
                    string requested = url[url.Length - 1];
                    List<Game> data = administration.GetGamesByCategory(requested);
                    GamesView.DataSource = data;
                }
                catch (Exception exception)
                {
                    this.Controls.Add(new Label()
                    {
                        Text = "Games Not found, the following error occured : " + exception.Message
                    });
                }
            }
            else if (url[url.Length - 2].ToUpper() == "PLATFORM") //check if it needs to look for platform.
            {
                try
                {
                    string requested = url[url.Length - 1];
                    List<Game> data = administration.GetGamesByPlatform(requested);
                    GamesView.DataSource = data;
                }
                catch (Exception exception)
                {
                    this.Controls.Add(new Label()
                    {
                        Text = "Game Not found, the following error occured : " + exception.Message
                    });
                }
            }
            else if (url[url.Length - 2].ToUpper() == "SEARCH") //check if it needs to look for platform.
            {
                try
                {
                    string requested = url[url.Length - 1]; // Request.RawUrl.Replace(url[1],"");
                    requested = "%" + requested + "%";
                    requested = requested.Replace(" ", "%");
                    List<Game> data = administration.GetGamesByName(requested);
                    GamesView.DataSource = data;
                }
                catch (Exception exception)
                {
                    this.Controls.Add(new Label()
                    {
                        Text = "Game Not found, the following error occured : " + exception.Message
                    });
                }
            }
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

            //HyperLink btnbuyNow = e.Item.FindControl("btnBuyNow") as HyperLink;
            //btnbuyNow.NavigateUrl = "~/ShoppingCart.aspx/" + game.gameNr;

            HyperLink btnMoreInfo = e.Item.FindControl("btnMoreInfo") as HyperLink;
            btnMoreInfo.NavigateUrl = "~/GameInfo.aspx/" + game.gameNr;
        }
    }
}
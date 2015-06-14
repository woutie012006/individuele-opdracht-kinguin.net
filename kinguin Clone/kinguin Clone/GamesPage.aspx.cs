// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GamesPage.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The games page.
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
    /// The games page.
    /// </summary>
    public partial class GamesPage : System.Web.UI.Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private Administration administration = new Administration();

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
            string[] url = this.Request.RawUrl.Split('/');

            if (this.Request.RawUrl.EndsWith("Page"))
            {
                List<Game> data = this.administration.GetallGames();
                this.GamesView.DataSource = data;
            }
            else if (url[url.Length - 2].ToUpper() == "GENRE")
            {
                // check if it needs to look for genre.
                try
                {
                    string requested = url[url.Length - 1];
                    List<Game> data = this.administration.GetGamesByCategory(requested);
                    this.GamesView.DataSource = data;
                }
                catch (Exception exception)
                {
                    this.Controls.Add(
                        new Label() { Text = "Games Not found, the following error occured : " + exception.Message });
                }
            }
            else if (url[url.Length - 2].ToUpper() == "PLATFORM")
            {
                // check if it needs to look for platform.
                try
                {
                    string requested = url[url.Length - 1];
                    List<Game> data = this.administration.GetGamesByPlatform(requested);
                    this.GamesView.DataSource = data;
                }
                catch (Exception exception)
                {
                    this.Controls.Add(
                        new Label() { Text = "Game Not found, the following error occured : " + exception.Message });
                }
            }
            else if (url[url.Length - 2].ToUpper() == "SEARCH")
            {
                // check if it needs to look for platform.
                try
                {
                    string requested = url[url.Length - 1]; // Request.RawUrl.Replace(url[1],"");
                    requested = "%" + requested + "%";
                    requested = requested.Replace(" ", "%");
                    List<Game> data = this.administration.GetGamesByName(requested);
                    this.GamesView.DataSource = data;
                }
                catch (Exception exception)
                {
                    this.Controls.Add(
                        new Label() { Text = "Game Not found, the following error occured : " + exception.Message });
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
            this.GamesView.DataBind();
        }

        /// <summary>
        /// The games view_ on item data bound_ item data bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void GamesView_OnItemDataBound_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Game game = e.Item.DataItem as Game;
            Image image = e.Item.FindControl("IMGGame") as Image;
            image.ImageUrl = game.Picture;

            // HyperLink btnbuyNow = e.Item.FindControl("btnBuyNow") as HyperLink;
            // btnbuyNow.NavigateUrl = "~/ShoppingCart.aspx/" + game.GameNr;
            HyperLink btnMoreInfo = e.Item.FindControl("btnMoreInfo") as HyperLink;
            btnMoreInfo.NavigateUrl = "~/GameInfo.aspx/" + game.GameNr;
        }
    }
}
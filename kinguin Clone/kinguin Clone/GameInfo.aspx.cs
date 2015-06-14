// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameInfo.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The game info.
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
    using kinguin_Clone.classes;

    /// <summary>
    /// The game info.
    /// </summary>
    public partial class GameInfo : System.Web.UI.Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private Administration administration = new Administration();

        /// <summary>
        /// The current game.
        /// </summary>
        private Game currentGame;

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
            if (!this.Request.RawUrl.EndsWith("info"))
            {
                try
                {
                    string k = this.Request.Url.AbsolutePath;
                    string[] s = k.Split('/');
                    int id = Convert.ToInt32(s[s.Length - 1]);
                    List<Game> data = new List<Game>();
                    data.Add(this.administration.GetGameByID(id));
                    this.GameView.DataSource = data;

                    this.currentGame = data[0];
                    this.ObjectView.DataSource = this.currentGame.GetAllCopies();
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
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.GameView.DataBind();
            this.ObjectView.DataBind();
        }

        /// <summary>
        /// The games view_ on item data bound_ item data bound.
        /// </summary>
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void GamesView_OnItemDataBound_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Game game = e.Item.DataItem as Game;
            Image image = e.Item.FindControl("imgGame") as Image;
            image.ImageUrl = game.Picture;
        }

        /// <summary>
        /// The object view_ on item data bound.
        /// </summary>
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void ObjectView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            GameCopy game = e.Item.DataItem as GameCopy;
            HyperLink btn = e.Item.FindControl("btnPutInCart") as HyperLink;
            btn.NavigateUrl = "/ShoppingCart.aspx?GameCopyID=" + game.CopyNr;
        }
    }
}
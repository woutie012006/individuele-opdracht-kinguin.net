﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;
using Microsoft.Ajax.Utilities;

namespace kinguin_Clone
{
    public partial class GameInfo : System.Web.UI.Page
    {
        Administration administration = new Administration();
        private Game currentGame;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Request.RawUrl.EndsWith("info"))
            {
                try
                {
                    string k = Request.Url.AbsolutePath;
                    string[] s = k.Split('/');
                    int id = Convert.ToInt32(s[s.Length - 1]);
                    List<Game> data = new List<Game>();
                    data.Add(administration.getGameByID(id)); 
                    GameView.DataSource = data;

                    this.currentGame = data[0];
                    ObjectView.DataSource = currentGame.GetAllCopies();

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
            GameView.DataBind();
            ObjectView.DataBind();
        }

        protected void GamesView_OnItemDataBound_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Game game = e.Item.DataItem as Game;
            Image image = e.Item.FindControl("imgGame") as Image;
            image.ImageUrl = game.picture;
        }

        protected void ObjectView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            GameCopy game = e.Item.DataItem as GameCopy;
            HyperLink btn = e.Item.FindControl("btnPutInCart") as HyperLink;
            btn.NavigateUrl = "/ShoppingCart.aspx?GameCopyID=" + game.copyNr;
        }
    }
}
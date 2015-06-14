// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddObject.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The add object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;

using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The add object.
    /// </summary>
    public partial class AddObject : System.Web.UI.Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private Administration administration;

        /// <summary>
        /// The games.
        /// </summary>
        private List<Game> games;

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
            this.administration = Master.administration;
            if (!(this.administration.CurrentUser is Seller))
            {
                this.Response.Redirect("Default.aspx");
            }

            this.games = this.administration.GetallGames();

            for (int i = 0; i < this.games.Count; i++)
            {
                this.ddlGame.Items.Add(this.games[i].Name);
            }

            // for (int i = 0; i < 100; i++)
            // {
            // ddlCount.Items.Add(i.ToString());
            // }
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
            Game g = this.games.Find(f => f.Name == this.ddlGame.Text);

            if (g != null)
            {

                (Master.administration.CurrentUser as Seller).AddGameCopy(
                    new GameCopy(g, -1, int.Parse(this.tbPrice.Text), new DateTime(1900, 1, 1), this.tbCode.Text));

                this.ClientScript.RegisterStartupScript(
                       this.GetType(),
                       "Game alert",
                       "alert('" + "You succesfully added a object with game " + g.Name + "');",
                       true);

            }
        }

    }
}
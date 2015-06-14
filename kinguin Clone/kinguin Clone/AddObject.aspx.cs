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
            this.administration = this.Master.administration;
            if (!(this.administration.currentUser is Seller))
            {
                this.Response.Redirect("Default.aspx");
            }

            this.games = this.administration.GetallGames();

            for (int i = 0; i < this.games.Count; i++)
            {
                this.ddlGame.Items.Add(this.games[i].name);
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
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            Game g = this.games.Find(f => f.name == this.ddlGame.Text);
            (this.Master.administration.currentUser as Seller).AddGameCopy(
                new GameCopy(g, -1, int.Parse(this.tbPrice.Text), new DateTime(0, 0, 1900), this.tbCode.Text));
        }
    }
}
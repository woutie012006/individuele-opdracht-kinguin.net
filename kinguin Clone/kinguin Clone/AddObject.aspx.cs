using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class AddObject : System.Web.UI.Page
    {
        private Administration administration;
        private List<Game> games;

        protected void Page_Load(object sender, EventArgs e)
        {
            administration = Master.administration;
            if (!(administration.currentUser is Seller))
            {
                Response.Redirect("Default.aspx");
            }
            games = administration.GetallGames();

            for (int i = 0; i < games.Count; i++)
            {
                ddlGame.Items.Add(games[i].name);
            }
            //for (int i = 0; i < 100; i++)
            //{
            //    ddlCount.Items.Add(i.ToString());
            //}
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            Game g = games.Find(f => f.name == ddlGame.Text);
            (Master.administration.currentUser as Seller).AddGameCopy(new GameCopy(g, -1, Int32.Parse(tbPrice.Text),
                new DateTime(0, 0, 1900), tbCode.Text));
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddGame.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The add game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.IO;
using System.Web;

using Kinguin_Clone.classes;

#endregion

namespace Kinguin_Clone
{
    using Kinguin_Clone.classes;

    /// <summary>
    /// The add game.
    /// </summary>
    public partial class AddGame : System.Web.UI.Page
    {
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
            if (!(this.Master.administration.CurrentUser is Admin))
            {
                this.Response.Redirect("Default.aspx");
            }

            this.clDate.SelectedDate = DateTime.Now;

            string[] platform = { "PS", "XBOX", "PC" };
            string[] category = { "MURDER", "RPG", "RACING" };
            for (int i = 0; i <= 2; i++)
            {
                this.ddPlatform.Items.Add(platform[i]);
                this.ddCategory.Items.Add(category[i]);
            }
        }

        /// <summary>
        /// The btn add game_ on click.
        /// </summary>
        /// <param Name="sender">
        /// The sender.
        /// </param>
        /// <param Name="e">
        /// The e.
        /// </param>
        protected void btnAddGame_OnClick(object sender, EventArgs e)
        {
            // saves it in the first drive it finds under 
            HttpPostedFile picture = this.fuPicture.PostedFile;

            // DriveInfo[] drives = DriveInfo.GetDrives();
            // string directory =  drives[0].Name;
            string filePath = this.Server.MapPath("~") + "/IMG/" + this.tbName.Text
                              + Path.GetExtension(picture.FileName);
            string file = "/IMG/" + this.tbName.Text + "." + Path.GetExtension(picture.FileName);

            if (!Directory.Exists(this.Server.MapPath("~") + "/IMG/"))
            {
                Directory.CreateDirectory(this.Server.MapPath("~") + "/IMG/");
            }

            picture.SaveAs(filePath);

            Game game = new Game(
                -1, 
                this.tbName.Text, 
                this.ddCategory.Text, 
                this.clDate.SelectedDate, 
                file, 
                this.tbSpecifications.InnerText, 
                this.ddPlatform.Text, 
                this.tbDescription.InnerText);
            if (this.Master.administration.CurrentUser is Admin)
            {
                if ((this.Master.administration.CurrentUser as Admin).AddGame(game))
                {
                    this.ClientScript.RegisterStartupScript(
                        this.GetType(), 
                        "Game alert", 
                        "alert('" + "You succesfully added a game." + "');", 
                        true);
                }
            }
            else
            {
                this.Response.Redirect("Default.aspx");
            }
        }
    }
}
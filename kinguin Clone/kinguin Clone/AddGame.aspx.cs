using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class AddGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Master.administration.currentUser is Admin))
            {
                Response.Redirect("Default.aspx");
            }
            clDate.SelectedDate = System.DateTime.Now;
            
            string[] platform = {"PS","XBOX", "PC"};
            string[] category = { "MURDER", "RPG", "RACING" };
            for (int i = 0; i <= 2; i++)
            {
                ddPlatform.Items.Add(platform[i]);
                ddCategory.Items.Add(category[i]);

            }

        }

        protected void btnAddGame_OnClick(object sender, EventArgs e)
        {
            //saves it in the first drive it finds under 
            HttpPostedFile picture = fuPicture.PostedFile;
            //DriveInfo[] drives = DriveInfo.GetDrives();
            //string directory =  drives[0].Name;
            string filePath = Server.MapPath("~") + "/IMG/" + tbName.Text + Path.GetExtension(picture.FileName);
            string file = "/IMG/" + tbName.Text + "." + Path.GetExtension(picture.FileName);

            if (!Directory.Exists(Server.MapPath("~") + "/IMG/"))
            {
                Directory.CreateDirectory(Server.MapPath("~") + "/IMG/");
            }

            picture.SaveAs(filePath);

            Game game = new Game(-1,tbName.Text,ddCategory.Text,clDate.SelectedDate,file,tbSpecifications.InnerText , ddPlatform.Text,tbDescription.InnerText );
            if (Master.administration.currentUser is Admin)
            {
                if ((Master.administration.currentUser as Admin).AddGame(game))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Game alert", "alert('" + "You succesfully added a game." + "');", true);



                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}

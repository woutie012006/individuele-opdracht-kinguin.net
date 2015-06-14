using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kinguin_Clone.classes;

namespace Kinguin_Clone
{
    public partial class UserPage : System.Web.UI.Page
    {
        private Administration administration;

        protected void Page_Load(object sender, EventArgs e)
        {
            administration = Master.administration;

            if (administration == null || administration.currentUser == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            lblName.Text = "Name : " + administration.currentUser.Name;
            lblAdres.Text = "Adres : " + administration.currentUser.Adres;
            lblPhonenr.Text = "Phone number : " + administration.currentUser.Name;
            lblKinguinBalance.Text = "Kinguin Balance : " + administration.currentUser.KinguinBalance;

            if (Master.administration.currentUser is Admin)
            {
                hlAddGame.Visible = true;
            }
            else if (Master.administration.currentUser is Seller)
            {
                hlChangeUserinfo.Visible = true;
                hlAddObject.Visible = true;
            }
            else if (Master.administration.currentUser is Buyer)
            {
                hlChangeUserinfo.Visible = true;
            }
        }
    }
}
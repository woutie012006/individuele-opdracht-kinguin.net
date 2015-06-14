#region

using System;
using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
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
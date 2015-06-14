

namespace kinguin_Clone
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using kinguin_Clone.classes;

    public partial class AdminUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(this.Master.administration.CurrentUser is Admin))
            {
            }
            List<User> data = ((Admin)this.Master.administration.CurrentUser).GetAllUsers();
            this.UserView.DataSource = data;
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
            this.UserView.DataBind();
        }

        /// <summary>
        /// The user view_ on item data bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void UserView_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // throw new NotImplementedException();
        }
    }
}
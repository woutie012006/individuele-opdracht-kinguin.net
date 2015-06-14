// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The _ default.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Web.UI;

using kinguin_Clone.classes;

#endregion

namespace kinguin_Clone
{
    /// <summary>
    /// The _ default.
    /// </summary>
    public partial class _Default : Page
    {
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
            this.imgJumbotron.ImageUrl = new Administration().GetAdds()[1].picture;

            // jumbotron.Style["background-image"] = new Administration().GetAdds()[1].picture;
            // dimage.ImageUrl = new Administration().GetAdds()[1].picture;
        }
    }
}
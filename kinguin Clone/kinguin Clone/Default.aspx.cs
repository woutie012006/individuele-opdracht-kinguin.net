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

using Kinguin_Clone.classes;

#endregion

namespace Kinguin_Clone
{
    using Kinguin_Clone.classes;

    /// <summary>
    /// The _ default.
    /// </summary>
    public partial class _Default : Page
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
            this.imgJumbotron.ImageUrl = new Administration().GetAdds()[1].Picture;

            // jumbotron.Style["background-image"] = new Administration().GetAdds()[1].Picture;
            // dimage.ImageUrl = new Administration().GetAdds()[1].Picture;
        }
    }
}
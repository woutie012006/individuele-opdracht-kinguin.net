using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Kinguin_Clone.classes;

namespace Kinguin_Clone
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgJumbotron.ImageUrl = new Administration().GetAdds()[1].Picture;
            //jumbotron.Style["background-image"] = new Administration().GetAdds()[1].Picture;
            //dimage.ImageUrl = new Administration().GetAdds()[1].Picture;
        }
    }
}
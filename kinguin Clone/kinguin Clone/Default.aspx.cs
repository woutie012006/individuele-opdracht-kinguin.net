using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kinguin_Clone.classes;

namespace kinguin_Clone
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgJumbotron.ImageUrl = new Administration().GetAdds()[1].picture;
            //jumbotron.Style["background-image"] = new Administration().GetAdds()[1].picture;
            //dimage.ImageUrl = new Administration().GetAdds()[1].picture;
        }
    }
}
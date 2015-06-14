using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kinguin_Clone
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                bool succes = Master.administration.Register(tbName.Text, tbAdres.Text, tbTelNr.Text, tbEmail.Text,
                    tbPassword1.Text, tbNickname.Text);
                if (succes)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Redirect("#");
                }
            }
        }
    }
}
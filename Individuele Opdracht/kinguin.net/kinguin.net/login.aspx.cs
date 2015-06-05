using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ict4Events_WindowsForms;
using Oracle.ManagedDataAccess.Client;

namespace kinguin.net
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginForm_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            Login l = (Login)sender;

            DatabaseConnection d = new DatabaseConnection();
            string query = "select count(*) from lid where ";

            string sql = "SELECT count(*) FROM lid WHERE name=:un AND password=:pw";
            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);
            oc.Parameters.Add("un", l.UserName);
            oc.Parameters.Add("pw", l.Password);

            OracleDataReader dr = db.ExecuteReadQuery(query);
            int valid = dr.GetInt32(0);

            if (valid == 1)
            {
                string k = Session.SessionID;
                Response.Cookies["kinguin"].Value = "admin";
                e.Authenticated = true;
            }
        }
    }
}
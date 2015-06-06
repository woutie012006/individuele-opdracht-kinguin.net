using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ict4Events_WindowsForms;
using Oracle.ManagedDataAccess.Client;

namespace kinguin_Clone.classes
{
    public class Administration
    {
        private User currentUser { get; set; }
        private List<Game> games { get; set; }


        public bool Login(string email, string password)
        {
            DatabaseConnection db = new DatabaseConnection();
            string query = "select count(*) from lid where email='" + email + "' and password = '" + password + "'";

            //string sql = "SELECT count(*) FROM lid WHERE name=:un AND password=:pw";
            //OracleCommand oc = new OracleCommand(sql, db.oracleConnection);
            //oc.Parameters.Add("un", email);
            //oc.Parameters.Add("pw",password);

            OracleDataReader dr = db.ExecuteReadQuery(query);
            int valid = -1;
            try
            {
                dr.Read();
                valid = dr.GetInt32(0);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                return false;
            }
            HttpContext.Current.Response.Cookies["kinguin"].Value = email;

            return Convert.ToBoolean(valid);
        }
        public List<Game> getGamesByName(string[] searchStrings)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();
            string query = null;

            foreach (var s in searchStrings)
            {
                query = "%" + query;
            }
            query = query + "%";
            query = "select gamenr,naam, categie, datum,foto,specificatie,platform from game where naam like '" + query + "'";


            OracleDataReader dr = db.ExecuteReadQuery(query);

            while (dr.Read())
            {
                int gamenr = dr.GetInt32(0);
                string name = dr.GetString(1);
                string category = dr.GetString(2);
                DateTime date = dr.GetDateTime(3);
                string picture = dr.GetString(4);
                string specificatie = dr.GetString(5);
                string platform = dr.GetString(6);

                games.Add(new Game(gamenr, name,category, date, picture, specificatie, platform));
            }
            return games;
        }
        public List<Game> getGamesByCategory(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();
            
            string query = "select gamenr,naam,datum,foto,specificatie,platform from game where upper(categorie)= upper('" + searchterm + "')";


            OracleDataReader dr = db.ExecuteReadQuery(query);

            while (dr.Read())
            {
                int gamenr = dr.GetInt32(0);
                string name = dr.GetString(1);
                string category = dr.GetString(2);
                DateTime date = dr.GetDateTime(3);
                string picture = dr.GetString(4);
                string specificatie = dr.GetString(5);
                string platform = dr.GetString(6);

                games.Add(new Game(gamenr, name, category, date, picture, specificatie, platform));
            }
            return games;
        }
        public List<Game> GetGamesByPlatform(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();

            string query = "select gamenr,naam,datum,foto,specificatie,platform from game where upper(platform)= upper('" + searchterm + "')";


            OracleDataReader dr = db.ExecuteReadQuery(query);

            while (dr.Read())
            {
                int gamenr = dr.GetInt32(0);
                string name = dr.GetString(1);
                string category = dr.GetString(2);
                DateTime date = dr.GetDateTime(3);
                string picture = dr.GetString(4);
                string specificatie = dr.GetString(5);
                string platform = dr.GetString(6);

                games.Add(new Game(gamenr, name, category, date, picture, specificatie, platform));
            }
            return games;
        }
    }
}
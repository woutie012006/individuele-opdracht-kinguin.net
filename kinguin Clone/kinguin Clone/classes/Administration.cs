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
        public List<Game> getGamesByName(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();
            string query = null;
            searchterm = searchterm.Replace("?", "%");
            query = "select gamenr,naam, categorie, datum,foto,specificatie,platform,beschrijving from game where naam like '" + searchterm + "'";


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
                string beschrijving = dr.GetString(7);

                games.Add(new Game(gamenr, name, category, date, picture, specificatie, platform, beschrijving));
            }
            return games;
        }
        public List<Game> getGamesByCategory(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();

            string query = "select gamenr,naam,categorie, datum,foto,specificatie,platform, beschrijving from game where upper(categorie)= upper('" + searchterm + "')";


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
                string beschrijving = dr.GetString(7);

                games.Add(new Game(gamenr, name, category, date, picture, specificatie, platform, beschrijving));
            }
            return games;
        }
        public List<Game> GetGamesByPlatform(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();

            string query = "select gamenr,naam, categorie, datum,foto,specificatie,platform,beschrijving from game where upper(platform)= upper('" + searchterm + "')";


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
                string beschrijving = dr.GetString(7);

                games.Add(new Game(gamenr, name, category, date, picture, specificatie, platform, beschrijving));
            }
            return games;
        }
        public List<Game> GetallGames()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();

            string query = "select gamenr,naam, categorie, datum,foto,specificatie,platform,beschrijving from game";


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
                string beschrijving = dr.GetString(7);

                games.Add(new Game(gamenr, name, category, date, picture, specificatie, platform, beschrijving));
            }
            return games;
        }

        public Game getGameByID(int id)
        {
            Game g;


            DatabaseConnection db = new DatabaseConnection();

            string query = "select gamenr,naam, categorie, datum,foto,specificatie,platform,beschrijving from game where rownum=1 and GameNr = " + id;


            OracleDataReader dr = db.ExecuteReadQuery(query);

            dr.Read();

            int gamenr = dr.GetInt32(0);
            string name = dr.GetString(1);
            string category = dr.GetString(2);
            DateTime date = dr.GetDateTime(3);
            string picture = dr.GetString(4);
            string specificatie = dr.GetString(5);
            string platform = dr.GetString(6);
            string beschrijving = dr.GetString(7);

            g = new Game(gamenr, name, category, date, picture, specificatie, platform, beschrijving);

            return g;
        }

        //public List<Game> GetGamesBestSold()
        //{
        //}
    }
}
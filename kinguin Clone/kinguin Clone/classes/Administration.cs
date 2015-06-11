using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ict4Events_WindowsForms;
using Oracle.ManagedDataAccess.Client;
using WebGrease.Css.Ast.Selectors;

namespace kinguin_Clone.classes
{
    public class Administration
    {
        private User currentUser { get; set; }
        private List<Game> games { get; set; }


        public bool Login(string email, string password)
        {
            int valid = -1;
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                string sql = "SELECT count(*) FROM lid WHERE email=:un AND password=:pw";
                OracleCommand oc = new OracleCommand(sql, db.oracleConnection);

                oc.Parameters.Add("un", email);
                oc.Parameters.Add("pw", password);

                oc.Connection.Open();

                OracleDataReader oddr = oc.ExecuteReader();
                if (oddr.Read())
                {
                    valid = oddr.GetInt32(0);
                }
                if (valid == 1)
                {
                    HttpContext.Current.Response.Cookies["kinguin"].Value = email;
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                return false;
            }

            return false;


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

        public List<GameCopy> GetCartCopies()
        {
            List<GameCopy> copies = new List<GameCopy>();
            if (currentUser == null)
            {
                return copies; //zo crasht het programma niet en wordt er niet toegevoegd.
            }

            DatabaseConnection db = new DatabaseConnection();
            List<GameCopy> games = new List<GameCopy>();

            string query = "select g.gamenr,g.naam,g.categorie,g.datum," +
                           " g.foto,g.specificatie,g.platform, g.beschrijving, " +
                           "O.Objectnr, o.prijs,O.Verkoopsdatum,O.Code " +

                           "from mandje m , verkoopobject o, game g " +

                           "where M.Relevant= 'Y' " +
                           "and M.Verkoopobject = O.Objectnr " +
                           "and O.Gamenr = G.Gamenr" +
                           "and m.lidnr = " + currentUser.UserNr;


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
                int objectnt = dr.GetInt32(8);
                float price = dr.GetFloat(9);
                DateTime datum = dr.GetDateTime(10);
                string code = dr.GetString(11);

                // games.Add(new Game(gamenr, name, category, date, picture, specificatie, platform, beschrijving));
            }
            return games;


        }

        public List<Advert> getAdds()
        {
            List<Advert> ads = new List<Advert>();

            DatabaseConnection db = new DatabaseConnection();
            string sql = "SELECT id, foto, url, description FROM Advertentie ORDER BY dbms_random.value";


            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);
            oc.Connection.Open();
            OracleDataReader odr = oc.ExecuteReader();
            while (odr.Read())
            {
                ads.Add(new Advert(odr.GetInt32(0), odr.GetString(1), odr.GetString(2), odr.GetString(3)));
            }
            oc.Connection.Close();
            return ads;

        }

        //public List<Game> GetGamesBestSold()
        //{
        //}
    }
}
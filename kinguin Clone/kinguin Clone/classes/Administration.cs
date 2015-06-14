// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Administration.cs" company="">
//   
// </copyright>
// <summary>
//   The administration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

using Ict4Events_WindowsForms;

using Oracle.ManagedDataAccess.Client;

#endregion

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The administration.
    /// </summary>
    public class Administration
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public User CurrentUser { get; set; }

        // private List<Game> games { get; set; }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param Name="email">
        /// The email.
        /// </param>
        /// <param Name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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

                oddr.Close();
                if (valid == 1)
                {
                    sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE," + "K.NICKNAME,"
                          + "V.VERKOPERNAAM,V.BANKREKING " + "FROM lid l, klant k, verkoper v  "
                          + "WHERE L.email=:un AND L.password=:pw "
                          + "and (l.lidnr = K.Lidnr or L.Lidnr = V.Lidnr or (l.lidnr not in (select lidnr from verkoper) AND L.LIDNR NOT IN (SELECT LIDNR FROM KLANT)))";

                    OracleCommand oc2 = new OracleCommand(sql, db.oracleConnection);

                    oc2.Parameters.Add("un", email);
                    oc2.Parameters.Add("pw", password);

                    oddr = oc2.ExecuteReader();
                    if (oddr.Read())
                    {
                        string type = oddr.GetString(0);
                        int usernr = oddr.GetInt32(1);
                        string naam = oddr.GetString(2);
                        string adres = oddr.GetString(3);
                        string telNr = oddr.GetString(4);
                        float kinguinbalance = oddr.GetFloat(5);

                        // email is already available
                        string nickname = oddr.GetString(6);

                        switch (type)
                        {
                            case "ADMIN":
                                this.CurrentUser = new Admin(usernr, naam, adres, telNr, kinguinbalance, email);
                                break;
                            case "KLANT":
                                this.CurrentUser = new Buyer(
                                    usernr, 
                                    naam, 
                                    adres, 
                                    telNr, 
                                    kinguinbalance, 
                                    nickname, 
                                    email);
                                break;
                            case "VERKOPER":
                                string verkopernaam = oddr.GetString(7);
                                string bankreking = oddr.GetString(8);
                                this.CurrentUser = new Seller(
                                    usernr, 
                                    naam, 
                                    adres, 
                                    telNr, 
                                    kinguinbalance, 
                                    nickname, 
                                    verkopernaam, 
                                    bankreking, 
                                    email);
                                break;
                        }
                    }

                    HttpContext.Current.Session["administration"] = this;
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

        /// <summary>
        /// The register.
        /// </summary>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <param Name="adres">
        /// The adres.
        /// </param>
        /// <param Name="telNr">
        /// The tel nr.
        /// </param>
        /// <param Name="email">
        /// The email.
        /// </param>
        /// <param Name="Password">
        /// The password.
        /// </param>
        /// <param Name="nickname">
        /// The nickname.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Register(string name, string adres, string telNr, string email, string Password, string nickname)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string sql = "insert into Lid (LIDNR,NAAM,ADRES,TELEFOONNR,SOORT,KINGUINBALANCE,EMAIL,PASSWORD)"
                             + " values " + "(seq_LID.nextval, " + " '" + name + "' , " + " '" + adres + "', " + "'"
                             + telNr + "', " + " 'KLANT'," + " (0)," + " '" + email + "', " + "'" + Password + "')";

                OracleCommand oc = new OracleCommand(sql, db.oracleConnection);
                oc.Connection.Open();
                oc.ExecuteNonQuery();
                oc.Connection.Close();

                sql = "insert into KLANT (LIDNR, NICKNAME)" + " values " + "(seq_LID.currval,'" + nickname + "')";

                oc = new OracleCommand(sql, db.oracleConnection);
                oc.Connection.Open();
                oc.ExecuteNonQuery();
                oc.Connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return false;
        }

        /// <summary>
        /// The get games by Name.
        /// </summary>
        /// <param Name="searchterm">
        /// The searchterm.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<Game> GetGamesByName(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();
            string query = null;
            searchterm = searchterm.Replace("?", "%");
            query =
                "select gamenr,naam, categorie, datum,foto,Specificatie,Platform,beschrijving from game where naam like '"
                + searchterm + "'";

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

        /// <summary>
        /// The get games by Category.
        /// </summary>
        /// <param Name="searchterm">
        /// The searchterm.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<Game> GetGamesByCategory(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();

            string query =
                "select gamenr,naam,categorie, datum,foto,Specificatie,Platform, beschrijving from game where upper(categorie)= upper('"
                + searchterm + "')";

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

        /// <summary>
        /// The get games by Platform.
        /// </summary>
        /// <param Name="searchterm">
        /// The searchterm.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<Game> GetGamesByPlatform(string searchterm)
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();

            string query =
                "select gamenr,naam, categorie, datum,foto,Specificatie,Platform,beschrijving from game where upper(Platform)= upper('"
                + searchterm + "')";

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

        /// <summary>
        /// The getall games.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<Game> GetallGames()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<Game> games = new List<Game>();

            string query = "select gamenr,naam, categorie, datum,foto,Specificatie,Platform,beschrijving from game";

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

        /// <summary>
        /// The get game by id.
        /// </summary>
        /// <param Name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Game"/>.
        /// </returns>
        public Game GetGameByID(int id)
        {
            Game g;

            DatabaseConnection db = new DatabaseConnection();

            string query =
                "select gamenr,naam, categorie, datum,foto,Specificatie,Platform,beschrijving from game where rownum=1 and GameNr = "
                + id;

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

        /// <summary>
        /// The get adds.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<Advert> GetAdds()
        {
            List<Advert> ads = new List<Advert>();

            DatabaseConnection db = new DatabaseConnection();
            string sql = "SELECT id, foto, url, Description FROM Advertentie ORDER BY dbms_random.value";

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

        #region

        // public List<GameCopy> GetCartCopies()
        // {
        // List<GameCopy> copies = new List<GameCopy>();
        // if (CurrentUser == null)
        // {
        // return copies; //zo crasht het programma niet en wordt er niet toegevoegd.
        // }

        // DatabaseConnection db = new DatabaseConnection();
        // List<GameCopy> games = new List<GameCopy>();

        // string query = "select g.gamenr,g.naam,g.categorie,g.datum," +
        // " g.foto,g.Specificatie,g.Platform, g.beschrijving, " +
        // "O.Objectnr, o.prijs,O.Verkoopsdatum,O.Code " +

        // "from mandje m , verkoopobject o, game g " +

        // "where M.Relevant= 'Y' " +
        // "and M.Verkoopobject = O.Objectnr " +
        // "and O.Gamenr = G.Gamenr" +
        // "and m.lidnr = " + CurrentUser.UserNr;

        // OracleDataReader dr = db.ExecuteReadQuery(query);

        // while (dr.Read())
        // {
        // int gamenr = dr.GetInt32(0);
        // string Name = dr.GetString(1);
        // string Category = dr.GetString(2);
        // DateTime Date = dr.GetDateTime(3);
        // string Picture = dr.GetString(4);
        // string Specificatie = dr.GetString(5);
        // string Platform = dr.GetString(6);
        // string beschrijving = dr.GetString(7);
        // int objectnr = dr.GetInt32(8);
        // float Price = dr.GetFloat(9);
        // DateTime datum = dr.GetDateTime(10);
        // string Code = dr.GetString(11);

        // copies.Add(new GameCopy(gamenr, Name, Category, Date, Picture, Specificatie, Platform, objectnr,Price,datum,Code,beschrijving));
        // }
        // return games;

        // }
        #endregion
    }
}
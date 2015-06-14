// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Admin.cs" company="">
//   
// </copyright>
// <summary>
//   The admin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Ict4Events_WindowsForms;

using Oracle.ManagedDataAccess.Client;

#endregion

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The admin.
    /// </summary>
    public class Admin : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Admin"/> class.
        /// </summary>
        /// <param Name="Usernr">
        /// The usernr.
        /// </param>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <param name="adres">
        /// The adres.
        /// </param>
        /// <param Name="phonent">
        /// The phonent.
        /// </param>
        /// <param Name="kinguinBalance">
        /// The kinguin balance.
        /// </param>
        /// <param Name="email">
        /// The email.
        /// </param>
        public Admin(int Usernr, string name, string adres, string phonent, float kinguinBalance, string email)
            : base(Usernr, name, adres, phonent, kinguinBalance, email)
        {
        }

        /// <summary>
        /// The get all users.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<User> GetAllUsers()
        {
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader oddr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE," + "K.NICKNAME,"
                         + "V.VERKOPERNAAM,V.BANKREKING, l.EMAIL " + "FROM lid l, klant k, verkoper v  "
                         + "WHERE (l.lidnr = K.Lidnr or L.Lidnr = V.Lidnr or (l.lidnr not in (select lidnr from verkoper) AND L.LIDNR NOT IN (SELECT LIDNR FROM KLANT)))";

            OracleCommand oc2 = new OracleCommand(sql, db.oracleConnection);

            oddr = oc2.ExecuteReader();
            while (oddr.Read())
            {
                string type = oddr.GetString(0);
                int usernr = oddr.GetInt32(1);
                string naam = oddr.GetString(2);
                string adres = oddr.GetString(3);
                string telNr = oddr.GetString(4);
                float kinguinbalance = oddr.GetFloat(5);

                // email is already available
                string nickname = oddr.GetString(6);
                string email = oddr.GetString(9);

                switch (type)
                {
                    case "ADMIN":
                        users.Add(new Admin(usernr, naam, adres, telNr, kinguinbalance, email));
                        break;
                    case "KLANT":
                        users.Add(new Buyer(usernr, naam, adres, telNr, kinguinbalance, nickname, email));
                        break;
                    case "VERKOPER":
                        string verkopernaam = oddr.GetString(7);
                        string bankreking = oddr.GetString(8);
                        users.Add(
                            new Seller(
                                usernr, 
                                naam, 
                                adres, 
                                telNr, 
                                kinguinbalance, 
                                nickname, 
                                verkopernaam, 
                                bankreking, 
                                email));
                        break;
                }
            }

            return users;
        }

        /// <summary>
        /// The get buyers by Name.
        /// </summary>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<User> GetBuyersByName(string name)
        {
            name = "'%" + name.Replace(" ", "%") + "%'";
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader odr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE,"
                         + "K.NICKNAME,l.EMAIL" + "FROM lid l, klant k, verkoper v  " + "WHERE l.lidnr = K.Lidnr"
                         + " and l.NAAM like " + name;

            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);

            odr = oc.ExecuteReader();
            while (odr.Read())
            {
                string type = odr.GetString(0);
                int usernr = odr.GetInt32(1);
                string naam = odr.GetString(2);
                string adres = odr.GetString(3);
                string telNr = odr.GetString(4);
                float kinguinbalance = odr.GetFloat(5);
                string nickname = odr.GetString(6);
                string email = odr.GetString(7);

                switch (type)
                {
                    case "KLANT":
                        users.Add(new Buyer(usernr, naam, adres, telNr, kinguinbalance, nickname, email));
                        break;
                }
            }

            return users;
        }

        /// <summary>
        /// The get buyers by nickname.
        /// </summary>
        /// <param Name="nickname">
        /// The nickname.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<User> GetBuyersByNickname(string nickname)
        {
            nickname = "'%" + nickname.Replace(" ", "%") + "%'";
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader odr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE,"
                         + "K.NICKNAME,l.EMAIL" + "FROM lid l, klant k, verkoper v  " + "WHERE l.lidnr = K.Lidnr"
                         + " and k.NICKNAME like " + nickname;

            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);

            odr = oc.ExecuteReader();
            while (odr.Read())
            {
                string type = odr.GetString(0);
                int usernr = odr.GetInt32(1);
                string naam = odr.GetString(2);
                string adres = odr.GetString(3);
                string telNr = odr.GetString(4);
                float kinguinbalance = odr.GetFloat(5);

                // string nickname = odr.GetString(6);
                string email = odr.GetString(7);

                switch (type)
                {
                    case "KLANT":
                        users.Add(new Buyer(usernr, naam, adres, telNr, kinguinbalance, nickname, email));
                        break;
                }
            }

            return users;
        }

        /// <summary>
        /// The get buyers by user id.
        /// </summary>
        /// <param Name="userID">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<User> GetBuyersByUserID(int userID)
        {
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader odr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE,"
                         + "K.NICKNAME,l.EMAIL" + "FROM lid l, klant k, verkoper v  " + "WHERE l.lidnr = K.Lidnr"
                         + " and l.LIDNR =" + userID;

            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);

            odr = oc.ExecuteReader();
            while (odr.Read())
            {
                string type = odr.GetString(0);
                int usernr = odr.GetInt32(1);
                string naam = odr.GetString(2);
                string adres = odr.GetString(3);
                string telNr = odr.GetString(4);
                float kinguinbalance = odr.GetFloat(5);
                string nickname = odr.GetString(6);
                string email = odr.GetString(7);

                switch (type)
                {
                    case "KLANT":
                        users.Add(new Buyer(usernr, naam, adres, telNr, kinguinbalance, nickname, email));
                        break;
                }
            }

            return users;
        }

        /// <summary>
        /// The get sellers by Name.
        /// </summary>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<User> GetSellersByName(string name)
        {
            name = "'%" + name.Replace(" ", "%") + "%'";
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader odr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE,"
                         + "K.NICKNAME,l.EMAIL" + "V.VERKOPERNAAM,V.BANKREKING " + "FROM lid l, klant k, verkoper v  "
                         + "WHERE L.Lidnr = V.Lidnr" + " and l.NAAM like " + name;

            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);

            odr = oc.ExecuteReader();
            while (odr.Read())
            {
                string type = odr.GetString(0);
                int usernr = odr.GetInt32(1);
                string naam = odr.GetString(2);
                string adres = odr.GetString(3);
                string telNr = odr.GetString(4);
                float kinguinbalance = odr.GetFloat(5);
                string nickname = odr.GetString(6);
                string email = odr.GetString(7);
                string sellername = odr.GetString(8);
                string bankreking = odr.GetString(9);

                switch (type)
                {
                    case "VERKOPER":
                        users.Add(
                            new Seller(
                                usernr, 
                                naam, 
                                adres, 
                                telNr, 
                                kinguinbalance, 
                                nickname, 
                                sellername, 
                                bankreking, 
                                email));
                        break;
                }
            }

            return users;
        }

        /// <summary>
        /// The get sellers by sellers Name.
        /// </summary>
        /// <param Name="sellerName">
        /// The seller Name.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<User> GetSellersBySellersName(string sellerName)
        {
            sellerName = "'%" + sellerName.Replace(" ", "%") + "%'";
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader odr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE,"
                         + "K.NICKNAME,l.EMAIL" + "V.VERKOPERNAAM,V.BANKREKING " + "FROM lid l, klant k, verkoper v  "
                         + "WHERE L.Lidnr = V.Lidnr" + " and v.VERKOPERNAAM like " + sellerName;

            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);

            odr = oc.ExecuteReader();
            while (odr.Read())
            {
                string type = odr.GetString(0);
                int usernr = odr.GetInt32(1);
                string naam = odr.GetString(2);
                string adres = odr.GetString(3);
                string telNr = odr.GetString(4);
                float kinguinbalance = odr.GetFloat(5);
                string nickname = odr.GetString(6);
                string email = odr.GetString(7);
                string sellername = odr.GetString(8);
                string bankreking = odr.GetString(9);

                switch (type)
                {
                    case "VERKOPER":
                        users.Add(
                            new Seller(
                                usernr, 
                                naam, 
                                adres, 
                                telNr, 
                                kinguinbalance, 
                                nickname, 
                                sellername, 
                                bankreking, 
                                email));
                        break;
                }
            }

            return users;
        }

        /// <summary>
        /// The get sellers by user id.
        /// </summary>
        /// <param Name="userID">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<User> GetSellersByUserID(int userID)
        {
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader odr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE,"
                         + "K.NICKNAME,l.EMAIL" + "V.VERKOPERNAAM,V.BANKREKING " + "FROM lid l, klant k, verkoper v  "
                         + "WHERE L.Lidnr = V.Lidnr" + " and l.LIDNR = " + userID;

            OracleCommand oc = new OracleCommand(sql, db.oracleConnection);

            odr = oc.ExecuteReader();
            while (odr.Read())
            {
                string type = odr.GetString(0);
                int usernr = odr.GetInt32(1);
                string naam = odr.GetString(2);
                string adres = odr.GetString(3);
                string telNr = odr.GetString(4);
                float kinguinbalance = odr.GetFloat(5);
                string nickname = odr.GetString(6);
                string email = odr.GetString(7);
                string sellername = odr.GetString(8);
                string bankreking = odr.GetString(9);

                switch (type)
                {
                    case "VERKOPER":
                        users.Add(
                            new Seller(
                                usernr, 
                                naam, 
                                adres, 
                                telNr, 
                                kinguinbalance, 
                                nickname, 
                                sellername, 
                                bankreking, 
                                email));
                        break;
                }
            }

            return users;
        }

        /// <summary>
        /// The add game.
        /// </summary>
        /// <param Name="game">
        /// The game.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddGame(Game game)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string sql = "insert into game"
                             + " (GAMENR,NAAM,BESCHRIJVING,DATUM,FOTO,SPECIFICATIE,PLATFORM,CATEGORIE)" + " values "
                             + "(seq_game.nextval, " + " '" + game.Name + "' , " + " '" + game.Description + "', "
                             + "to_date('" + game.Date + "','DD-MM-YYYY HH24:MI:SS')" +

                             // might not work so needs to be checked
                             ",'" + game.Picture + "', " + " '" + game.Specificatie + "'," + " '" + game.Platform + "',"
                             + " '" + game.Category + "')";

                OracleCommand oc = new OracleCommand(sql, db.oracleConnection);
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
        /// The remove game.
        /// </summary>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool RemoveGame(string name)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string sql = "DELETE FROM Game WHERE naam = '" + name + "'";

                OracleCommand oc = new OracleCommand(sql, db.oracleConnection);
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
        /// The change game Name.
        /// </summary>
        /// <param Name="from">
        /// The from.
        /// </param>
        /// <param Name="to">
        /// The to.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangeGameName(string from, string to)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string sql = "UPDATE Game SET naam = '" + to + "' WHERE naam = '" + from + "'";

                OracleCommand oc = new OracleCommand(sql, db.oracleConnection);
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
    }
}
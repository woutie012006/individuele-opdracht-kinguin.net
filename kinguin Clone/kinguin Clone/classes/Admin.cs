﻿// --------------------------------------------------------------------------------------------------------------------
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
        /// <param name="Usernr">
        /// The usernr.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="adres">
        /// The adres.
        /// </param>
        /// <param name="phonent">
        /// The phonent.
        /// </param>
        /// <param name="kinguinBalance">
        /// The kinguin balance.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        public Admin(int userNr, string name, string adres, string phoneNr, float kinguinBalance, string email)
            : base(userNr, name, adres, phoneNr, kinguinBalance, email)
        {
        }

        /// <summary>
        /// The get all users.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<User> GetAllUsers()
        {
            DatabaseConnection db = new DatabaseConnection();
            OracleDataReader oddr;
            List<User> users = new List<User>();
            string sql = "SELECT L.SOORT,L.LIDNR,L.NAAM,L.ADRES,L.TELEFOONNR," + "L.KINGUINBALANCE," + "K.NICKNAME,"
                         + "V.VERKOPERNAAM,V.BANKREKING, l.EMAIL " + "FROM lid l, klant k, verkoper v  "
                         + "WHERE (l.soort = 'KLANT' and l.lidnr = K.Lidnr) or "
                         + "(l.SOORT ='VERKOPER' and L.Lidnr = V.Lidnr  and l.lidnr = k.lidnr) or "
                         + "(l.soort ='ADMIN' and l.lidnr = k.lidnr)";

            OracleCommand oc2 = new OracleCommand(sql, db.oracleConnection);
            oc2.Connection.Open();
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
            oc2.Connection.Close();
            return users;
        }

        /// <summary>
        /// The get buyers by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
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
            oc.Connection.Open();
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
            oc.Connection.Close();

            return users;
        }

        /// <summary>
        /// The get buyers by nickname.
        /// </summary>
        /// <param name="nickname">
        /// The nickname.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
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
            oc.Connection.Open();
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
            oc.Connection.Close();
            return users;
        }

        /// <summary>
        /// The get buyers by user id.
        /// </summary>
        /// <param name="userID">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
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
            oc.Connection.Open();
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
            oc.Connection.Close();
            return users;
        }

        /// <summary>
        /// The get sellers by name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
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
            oc.Connection.Open();
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
            oc.Connection.Close();
            return users;
        }

        /// <summary>
        /// The get sellers by sellers name.
        /// </summary>
        /// <param name="sellerName">
        /// The seller name.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
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
            oc.Connection.Open();
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
            oc.Connection.Close();
            return users;
        }

        /// <summary>
        /// The get sellers by user id.
        /// </summary>
        /// <param name="userID">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
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
            oc.Connection.Open();
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
            oc.Connection.Close();
            return users;
        }

        /// <summary>
        /// The add game.
        /// </summary>
        /// <param name="game">
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
        /// <param name="name">
        /// The name.
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
        /// The change game name.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
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
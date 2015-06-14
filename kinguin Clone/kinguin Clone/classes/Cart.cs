// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cart.cs" company="">
//   
// </copyright>
// <summary>
//   The cart.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;

using Ict4Events_WindowsForms;

using Oracle.ManagedDataAccess.Client;

#endregion

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The cart.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        /// <param name="currentUser">
        /// The current user.
        /// </param>
        public Cart(User currentUser)
        {
            this.owned = this.GetUserCopies(currentUser);
        }

        /// <summary>
        /// Gets or sets the owned.
        /// </summary>
        public List<GameCopy> owned { get; set; }

        /// <summary>
        /// The add game.
        /// </summary>
        /// <param name="game">
        /// The game.
        /// </param>
        /// <param name="currentUser">
        /// The current user.
        /// </param>
        public void AddGame(GameCopy game, User currentUser)
        {
            DatabaseConnection db = new DatabaseConnection();
            string query = "INSERT INTO mandje (verkoopobject, lidnr) VALUES (" + game.copyNr + ", "
                           + currentUser.UserNr + ")";
            db.OpenConnection();
            db.ExecuteQuery(query);
            db.CloseConnection();
            this.owned.Add(game);
        }

        /// <summary>
        /// The remove game.
        /// </summary>
        /// <param name="game">
        /// The game.
        /// </param>
        /// <param name="currentUser">
        /// The current user.
        /// </param>
        public void RemoveGame(GameCopy game, User currentUser)
        {
            DatabaseConnection db = new DatabaseConnection();
            string query = "UPDATE mandje  SET relevant = 'N' " + "WHERE lidnr=" + currentUser.UserNr
                           + " and verkoopobject=" + game.copyNr;
            db.OpenConnection();
            db.ExecuteQuery(query);
            db.CloseConnection();
            this.owned.Remove(game);
        }

        /// <summary>
        /// The buycart.
        /// </summary>
        /// <param name="currentUser">
        /// The current user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Buycart(User currentUser)
        {
            // todo implement Cart.BuyCart()
            return false;
        }

        /// <summary>
        /// The get user copies.
        /// </summary>
        /// <param name="currentUser">
        /// The current user.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<GameCopy> GetUserCopies(User currentUser)
        {
            List<GameCopy> copies = new List<GameCopy>();
            if (currentUser == null)
            {
                return copies; // zo crasht het programma niet en wordt er niet toegevoegd.
            }

            DatabaseConnection db = new DatabaseConnection();

            string query = "select g.gamenr,g.naam,g.categorie,g.datum,"
                           + " g.foto,g.specificatie,g.platform, g.beschrijving, "
                           + "O.Objectnr, o.prijs,O.Verkoopsdatum,O.Code , o.eigenaar_lidnr"
                           + "from mandje m , verkoopobject o, game g " + "where M.Relevant= 'Y' "
                           + "and M.Verkoopobject = O.Objectnr " + "and O.Gamenr = G.Gamenr " + "and m.lidnr = "
                           + currentUser.UserNr;

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
                int objectnr = dr.GetInt32(8);
                float price = dr.GetFloat(9);
                DateTime datum = dr.GetDateTime(10);
                string code = dr.GetString(11);
                int eigenaar = dr.GetInt32(12);

                copies.Add(
                    new GameCopy(
                        gamenr, 
                        name, 
                        category, 
                        date, 
                        picture, 
                        specificatie, 
                        platform, 
                        objectnr, 
                        price, 
                        datum, 
                        code, 
                        beschrijving, 
                        eigenaar));
            }

            return copies;
        }

        /// <summary>
        /// The add copy by id.
        /// </summary>
        /// <param name="copyid">
        /// The copyid.
        /// </param>
        /// <param name="currentUser">
        /// The current user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddCopyByID(int copyid, User currentUser)
        {
            try
            {
                if (currentUser == null)
                {
                    return false;
                }

                DatabaseConnection db = new DatabaseConnection();

                string query = "insert into mandje (verkoopobject,lidnr,relevant) values(" + copyid + ","
                               + currentUser.UserNr + ",'Y')";
                db.OpenConnection();
                db.ExecuteQuery(query);
                db.CloseConnection();
                this.owned = this.GetUserCopies(currentUser);
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }
    }
}
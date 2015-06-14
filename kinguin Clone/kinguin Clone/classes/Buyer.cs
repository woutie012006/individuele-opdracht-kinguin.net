// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Buyer.cs" company="">
//   
// </copyright>
// <summary>
//   The buyer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Ict4Events_WindowsForms;

#endregion

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The buyer.
    /// </summary>
    public class Buyer : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Buyer"/> class.
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
        /// <param name="phonenr">
        /// The phonenr.
        /// </param>
        /// <param name="kinguinBalance">
        /// The kinguin balance.
        /// </param>
        /// <param name="nickname">
        /// The nickname.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        public Buyer(
            int Usernr, 
            string name, 
            string adres, 
            string phonenr, 
            float kinguinBalance, 
            string nickname, 
            string email)
            : base(Usernr, name, adres, phonenr, kinguinBalance, email)
        {
            this.Nickname = nickname;
            this.cart = new Cart(this);
        }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the games Owned.
        /// </summary>
        public List<GameCopy> GamesOwned { get; set; }

        /// <summary>
        /// Gets or sets the cart.
        /// </summary>
        public Cart cart { get; set; }

        /// <summary>
        /// The get user copies.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<GameCopy> GetUserCopies()
        {
            // todo implement Buyer.GetUserCopies()
            return this.cart.Owned;
        }

        /// <summary>
        /// The add game to cart.
        /// </summary>
        /// <param name="game">
        /// The game.
        /// </param>
        public void AddGameToCart(GameCopy game)
        {
            this.cart.AddGame(game, this);
        }

        /// <summary>
        /// The remove game to cart.
        /// </summary>
        /// <param name="game">
        /// The game.
        /// </param>
        public void RemoveGameToCart(GameCopy game)
        {
            this.cart.RemoveGame(game, this);
        }

        /// <summary>
        /// The buy cart.
        /// </summary>
        public void BuyCart()
        {
            // todo database implementation Buyer.BuyCart
        }

        /// <summary>
        /// The change nickname.
        /// </summary>
        /// <param name="nickname">
        /// The nickname.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangeNickname(string nickname)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE KLant  SET nickname='" + nickname + "' where lidnr = " + this.UserNr;
                db.OpenConnection();
                db.ExecuteQuery(query);
                db.CloseConnection();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return false;
        }

        /// <summary>
        /// The become seller.
        /// </summary>
        /// <param name="sellerName">
        /// The sellerName.
        /// </param>
        /// <param name="bankaccount">
        /// The bankaccount.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool BecomeSeller(string sellerName, string bankaccount)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE LID  SET SOORT='VERKOPER'";
                db.OpenConnection();
                db.ExecuteQuery(query);
                db.CloseConnection();
                
                query = "Insert into VERKOPER (verkopernaam,bankrekening, lidnr) values('" + sellerName + "','" + bankaccount+ "'," + this.UserNr + ")";
                db.OpenConnection();
                db.ExecuteQuery(query);
                db.CloseConnection();

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
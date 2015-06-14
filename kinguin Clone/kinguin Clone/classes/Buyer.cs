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

namespace Kinguin_Clone.classes
{
    /// <summary>
    /// The buyer.
    /// </summary>
    public class Buyer : User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Buyer"/> class.
        /// </summary>
        /// <param Name="Usernr">
        /// The usernr.
        /// </param>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <param Name="adres">
        /// The adres.
        /// </param>
        /// <param Name="phonenr">
        /// The phonenr.
        /// </param>
        /// <param Name="kinguinBalance">
        /// The kinguin balance.
        /// </param>
        /// <param Name="nickname">
        /// The nickname.
        /// </param>
        /// <param Name="email">
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
            this.Cart = new Cart(this);
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
        /// Gets or sets the Cart.
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// The get user copies.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<GameCopy> GetUserCopies()
        {
            // todo implement Buyer.GetUserCopies()
            return this.Cart.Owned;
        }

        /// <summary>
        /// The add game to Cart.
        /// </summary>
        /// <param Name="game">
        /// The game.
        /// </param>
        public void AddGameToCart(GameCopy game)
        {
            this.Cart.AddGame(game, this);
        }

        /// <summary>
        /// The remove game to Cart.
        /// </summary>
        /// <param Name="game">
        /// The game.
        /// </param>
        public void RemoveGameToCart(GameCopy game)
        {
            this.Cart.RemoveGame(game, this);
        }

        /// <summary>
        /// The buy Cart.
        /// </summary>
        public void BuyCart()
        {
            // todo database implementation Buyer.BuyCart
        }

        /// <summary>
        /// The change nickname.
        /// </summary>
        /// <param Name="nickname">
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
    }
}
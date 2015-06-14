using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Kinguin_Clone;

namespace Kinguin_Clone.classes
{
    public class Buyer : User
    {
        public string Nickname { get; set; }
        public List<GameCopy> GamesOwned { get; set; }
        public Cart Cart { get; set; }

        public Buyer(int Usernr, string name, string adres, string phonenr, float kinguinBalance, string nickname,
            string email)
            : base(Usernr, name, adres, phonenr, kinguinBalance, email)
        {
            this.Nickname = nickname;
            Cart = new Cart(this);
        }

        public List<GameCopy> GetUserCopies()
        {
            //todo implement Buyer.GetUserCopies()

            return Cart.Owned;
        }

        public void AddGameToCart(GameCopy game)
        {
            Cart.AddGame(game, this);
        }

        public void RemoveGameToCart(GameCopy game)
        {
            Cart.RemoveGame(game, this);
        }

        public void BuyCart()
        {
            //todo database implementation Buyer.BuyCart
        }

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
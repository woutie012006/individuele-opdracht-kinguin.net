using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ict4Events_WindowsForms;

namespace kinguin_Clone.classes
{
    public class Buyer : User
    {
        public string Nickname { get; set; }
        public List<GameCopy> gamesOwned { get; set; }
        public Cart cart { get; set; }

        public Buyer(int Usernr, string name, string adres, string phonenr, float kinguinBalance, string nickname,
            string email)
            : base(Usernr, name, adres, phonenr, kinguinBalance, email)
        {
            this.Nickname = nickname;
            cart = new Cart(this);
        }

        public List<GameCopy> GetUserCopies()
        {
            //todo implement Buyer.GetUserCopies()

            return cart.owned;
        }

        public void AddGameToCart(GameCopy game)
        {
            cart.AddGame(game, this);
        }

        public void RemoveGameToCart(GameCopy game)
        {
            cart.RemoveGame(game, this);
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
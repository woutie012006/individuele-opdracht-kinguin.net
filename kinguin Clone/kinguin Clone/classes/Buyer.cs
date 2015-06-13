using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kinguin_Clone.classes
{
    public class Buyer:User
    {
        private string Nickname { get; set; }
        public List<GameCopy> gamesOwned { get; set; }
        public Cart cart { get; set; }

        public Buyer(int Usernr, string name, string adres, string phonenr, float kinguinBalance, string nickname, string email)
            : base(Usernr, name,adres,phonenr,kinguinBalance, email)
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
    }
}
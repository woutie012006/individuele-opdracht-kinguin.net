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

        public Buyer(int Usernr, string name, string adres, string phonenr, float kinguinBalance, string nickname)
            : base(Usernr, name,adres,phonenr,kinguinBalance)
        {
            this.Nickname = nickname;
            cart = new Cart(this);

        }
        public List<GameCopy> GetUserCopies()
        {
            //todo implement Buyer.GetUserCopies()

            return cart.owned;
        }
        public void addGameToCart(GameCopy game)
        {
            cart.AddGame(game, this);
        }

        public void removeGameToCart(GameCopy game)
        {
            cart.RemoveGame(game, this);
        }

        public void buyCart()
        {
            //todo database implementation Buyer.BuyCart
        }
    }
}
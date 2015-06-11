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

        public Buyer(int Usernr, string name, string adres, string phonenr, float kinguinBalance)
            : base(Usernr, name,adres,phonenr,kinguinBalance)
        {
            cart = new Cart() {owned = GetUserCopies()};

        }
        public List<GameCopy> GetUserCopies()
        {
            //todo implement
            return new List<GameCopy>();
        }
        public void addGameToCart(GameCopy game)
        {
            cart.AddGame(game);
        }

        public void removeGameToCart(GameCopy game)
        {
            cart.RemoveGame(game);
        }

        public void buyCart()
        {
            //todo database implementation.
        }
    }
}
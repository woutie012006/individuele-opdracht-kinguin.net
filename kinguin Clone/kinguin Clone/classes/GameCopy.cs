using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kinguin_Clone.classes
{
    public class GameCopy : Game
    {
        public int CopyNr { get; set; }
        public float Price { get; set; }
        public DateTime SellingDate { get; set; }
        public string Code { get; set; }
        public int Owner { get; set; }

        public GameCopy(int gameNr, string name, string category, DateTime date, string picture, string specificatie,
            string platform, int CopyNr, float price, DateTime sellingDate, string code, string description, int owner)
            : base(gameNr, name, category, date, picture, specificatie, platform, description)
        {
            this.CopyNr = CopyNr;
            this.Price = price;
            this.SellingDate = sellingDate;
            this.Code = code;
            this.Owner = owner;
        }

        /// <summary>
        /// intended for when someone might look at their gamecopy. it then needs to 
        /// </summary>
        /// <returns></returns>
        public GameCopy(Game g, int CopyNr, float price, DateTime SellingDate, string code)
            : base(g.GameNr, g.Name, g.Category, g.Date, g.Picture, g.Specificatie, g.Platform, g.Description)
        {
            this.CopyNr = CopyNr;
            this.Price = price;
            this.SellingDate = SellingDate;
            this.Code = code;
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////BNORT IMPLEMENTED YET
        /// </summary>
        /// <returns></returns>
        public bool Sell()
        {
            return false;
        }

        //public Game getGame()
        //{
        //}
    }
}
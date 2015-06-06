using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kinguin_Clone.classes
{
    public class GameCopy : Game
    {
        public int copyNr { get; set; }
        public float price { get; set; }
        public DateTime sellingDate { get; set; }
        public string code { get; set; }


        public GameCopy(int gameNr, string name, string category, DateTime date, string picture, string specificatie, string platform, int CopyNr, float price, DateTime SellingDate, string code, string description)
            : base(gameNr, name, category, date, picture, specificatie, platform, description)
        {
            this.copyNr = CopyNr;
            this.price = price;
            this.sellingDate = SellingDate;
            this.code = code;
        }

        /// <summary>
        /// intended for when someone might look at their gamecopy. it then needs to 
        /// </summary>
        /// <returns></returns>
        public GameCopy(Game g, int CopyNr, float price, DateTime SellingDate, string code)
            : base(g.gameNr, g.name, g.category, g.date, g.picture, g.specificatie, g.platform, g.description)
        {
            this.copyNr = CopyNr;
            this.price = price;
            this.sellingDate = SellingDate;
            this.code = code;
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////BNORT IMPLEMENTED YET
        /// </summary>
        /// <returns></returns>
        public bool sell()
        {
            return false;
        }

        //public Game getGame()
        //{
        //}
    }
}
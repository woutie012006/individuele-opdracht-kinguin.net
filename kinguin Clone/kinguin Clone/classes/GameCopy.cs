﻿#region

using System;

#endregion

namespace kinguin_Clone.classes
{
    public class GameCopy : Game
    {
        public GameCopy(int gameNr, string name, string category, DateTime date, string picture, string specificatie,
            string platform, int CopyNr, float price, DateTime SellingDate, string code, string description, int owner)
            : base(gameNr, name, category, date, picture, specificatie, platform, description)
        {
            this.copyNr = CopyNr;
            this.price = price;
            this.sellingDate = SellingDate;
            this.code = code;
            this.Owner = owner;
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

        public int copyNr { get; set; }
        public float price { get; set; }
        public DateTime sellingDate { get; set; }
        public string code { get; set; }
        public int Owner { get; set; }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////BNORT IMPLEMENTED YET
        /// </summary>
        /// <returns></returns>
        public bool Sell()
        {
            return false;
        }
    }
}
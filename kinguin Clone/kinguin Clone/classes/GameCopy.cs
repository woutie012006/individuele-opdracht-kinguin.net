// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GameCopy.cs" company="">
//   
// </copyright>
// <summary>
//   The game copy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;

#endregion

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The game copy.
    /// </summary>
    public class GameCopy : Game
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameCopy"/> class.
        /// </summary>
        /// <param name="gameNr">
        /// The game nr.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="category">
        /// The category.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="picture">
        /// The picture.
        /// </param>
        /// <param name="specificatie">
        /// The specificatie.
        /// </param>
        /// <param name="platform">
        /// The platform.
        /// </param>
        /// <param name="CopyNr">
        /// The copy nr.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        /// <param name="SellingDate">
        /// The selling date.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="owner">
        /// The owner.
        /// </param>
        public GameCopy(
            int gameNr, 
            string name, 
            string category, 
            DateTime date, 
            string picture, 
            string specificatie, 
            string platform, 
            int CopyNr, 
            float price, 
            DateTime SellingDate, 
            string code, 
            string description, 
            int owner)
            : base(gameNr, name, category, date, picture, specificatie, platform, description)
        {
            this.copyNr = CopyNr;
            this.price = price;
            this.sellingDate = SellingDate;
            this.code = code;
            this.Owner = owner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCopy"/> class. 
        /// intended for when someone might look at their gamecopy. it then needs to 
        /// </summary>
        /// <param name="g">
        /// The g.
        /// </param>
        /// <param name="CopyNr">
        /// The Copy Nr.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        /// <param name="SellingDate">
        /// The Selling Date.
        /// </param>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        public GameCopy(Game g, int CopyNr, float price, DateTime SellingDate, string code)
            : base(g.gameNr, g.name, g.category, g.date, g.picture, g.specificatie, g.platform, g.description)
        {
            this.copyNr = CopyNr;
            this.price = price;
            this.sellingDate = SellingDate;
            this.code = code;
        }

        /// <summary>
        /// Gets or sets the copy nr.
        /// </summary>
        public int copyNr { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public float price { get; set; }

        /// <summary>
        /// Gets or sets the selling date.
        /// </summary>
        public DateTime sellingDate { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        public int Owner { get; set; }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////BNORT IMPLEMENTED YET
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Sell()
        {
            return false;
        }
    }
}
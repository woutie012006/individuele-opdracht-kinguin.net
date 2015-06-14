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
        /// <param Name="gameNr">
        /// The game nr.
        /// </param>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <param name="category">
        /// The Category.
        /// </param>
        /// <param Name="Date">
        /// The Date.
        /// </param>
        /// <param Name="Picture">
        /// The Picture.
        /// </param>
        /// <param Name="Specificatie">
        /// The Specificatie.
        /// </param>
        /// <param Name="Platform">
        /// The Platform.
        /// </param>
        /// <param Name="CopyNr">
        /// The copy nr.
        /// </param>
        /// <param Name="Price">
        /// The Price.
        /// </param>
        /// <param Name="SellingDate">
        /// The selling Date.
        /// </param>
        /// <param Name="Code">
        /// The Code.
        /// </param>
        /// <param Name="Description">
        /// The Description.
        /// </param>
        /// <param Name="owner">
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
            int copyNr, 
            float price, 
            DateTime sellingDate, 
            string code, 
            string description, 
            int owner)
            : base(gameNr, name, category, date, picture, specificatie, platform, description)
        {
            this.CopyNr = copyNr;
            this.Price = price;
            this.SellingDate = sellingDate;
            this.Code = code;
            this.Owner = owner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameCopy"/> class. 
        /// intended for when someone might look at their gamecopy. it then needs to 
        /// </summary>
        /// <param Name="g">
        /// The g.
        /// </param>
        /// <param Name="CopyNr">
        /// The Copy Nr.
        /// </param>
        /// <param Name="Price">
        /// The Price.
        /// </param>
        /// <param Name="SellingDate">
        /// The Selling Date.
        /// </param>
        /// <param Name="Code">
        /// The Code.
        /// </param>
        /// <returns>
        /// </returns>
        public GameCopy(Game g, int CopyNr, float price, DateTime SellingDate, string code)
            : base(g.GameNr, g.Name, g.Category, g.Date, g.Picture, g.Specificatie, g.Platform, g.Description)
        {
            this.CopyNr = CopyNr;
            this.Price = price;
            this.SellingDate = SellingDate;
            this.Code = code;
        }

        /// <summary>
        /// Gets or sets the copy nr.
        /// </summary>
        public int CopyNr { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Gets or sets the selling Date.
        /// </summary>
        public DateTime SellingDate { get; set; }

        /// <summary>
        /// Gets or sets the Code.
        /// </summary>
        public string Code { get; set; }

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
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Game.cs" company="">
//   
// </copyright>
// <summary>
//   The game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;

using Ict4Events_WindowsForms;

using Oracle.ManagedDataAccess.Client;

#endregion

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param Name="gameNr">
        /// The game nr.
        /// </param>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <param Name="Category">
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
        /// <param Name="Description">
        /// The Description.
        /// </param>
        public Game(
            int gameNr, 
            string name, 
            string category, 
            DateTime date, 
            string picture, 
            string specificatie, 
            string platform, 
            string description)
        {
            this.GameNr = gameNr;
            this.Name = name;
            this.Category = category;
            this.Date = date;
            this.Picture = picture;
            this.Specificatie = specificatie;
            this.Platform = platform;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the game nr.
        /// </summary>
        public int GameNr { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the Picture.
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the Specificatie.
        /// </summary>
        public string Specificatie { get; set; }

        /// <summary>
        /// Gets or sets the Platform.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The get all copies.
        /// </summary>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        public List<GameCopy> GetAllCopies()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<GameCopy> copies = new List<GameCopy>();

            string query = "select objectnr,prijs,Code from verkoopobject where gamenr = " + this.GameNr
                           + " and verkoopsdatum <to_date('01/01/1901','DD/MM/YYYY')";

            OracleDataReader dr = db.ExecuteReadQuery(query);

            while (dr.Read())
            {
                int objectNr = dr.GetInt32(0);
                float price = dr.GetFloat(1);
                string code = dr.GetString(2);

                // datetime = minval because unsold games don't have a sellingdate.
                copies.Add(new GameCopy(this, objectNr, price, DateTime.MinValue, code));
            }

            return copies;
        }
    }
}
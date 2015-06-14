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
        /// The Date.
        /// </param>
        /// <param name="picture">
        /// The Picture.
        /// </param>
        /// <param name="specificatie">
        /// The specificatie.
        /// </param>
        /// <param name="platform">
        /// The platform.
        /// </param>
        /// <param name="description">
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
        /// Gets or sets the name.
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
        /// Gets or sets the specificatie.
        /// </summary>
        public string Specificatie { get; set; }

        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The get all copies.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<GameCopy> GetAllCopies()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<GameCopy> copies = new List<GameCopy>();

            string query = "select objectnr,prijs,code from verkoopobject where gamenr = " + this.GameNr
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
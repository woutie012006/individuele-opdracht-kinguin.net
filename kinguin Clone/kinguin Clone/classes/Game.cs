using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kinguin_Clone;
using Oracle.ManagedDataAccess.Client;

namespace Kinguin_Clone.classes
{
    public class Game
    {
        public int GameNr { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Picture { get; set; }
        public string Specificatie { get; set; }
        public string Platform { get; set; }
        public string Category { get; set; }

        public Game(int gameNr, string name, string category, DateTime date, string picture, string specificatie,
            string platform, string description)
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

        public List<GameCopy> GetAllCopies()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<GameCopy> copies = new List<GameCopy>();

            string query = "select objectnr,prijs,Code from verkoopobject where gamenr = " + GameNr +
                           " and verkoopsdatum <to_date('01/01/1901','DD/MM/YYYY')";


            OracleDataReader dr = db.ExecuteReadQuery(query);

            while (dr.Read())
            {
                int objectNr = dr.GetInt32(0);
                float price = dr.GetFloat(1);
                string code = dr.GetString(2);
                //datetime = minval because unsold games don't have a sellingdate.
                copies.Add(new GameCopy(this, objectNr, price, DateTime.MinValue, code));
            }
            return copies;
        }
    }
}
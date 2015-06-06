using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ict4Events_WindowsForms;
using Oracle.ManagedDataAccess.Client;

namespace kinguin_Clone.classes
{
    public class Game
    {
        public int gameNr { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public string picture { get; set; }
        public string specificatie { get; set; }
        public string platform { get; set; }
        public string category { get; set; }

        public Game(int gameNr, string name, string category, DateTime date, string picture, string specificatie, string platform, string description)
        {
            this.gameNr = gameNr;
            this.name = name;
            this.category = category;
            this.date = date;
            this.picture = picture;
            this.specificatie = specificatie;
            this.platform = platform;
            this.description = description;
        }

        public List<GameCopy> GetAllCopies()
        {
            DatabaseConnection db = new DatabaseConnection();
            List<GameCopy> copies = new List<GameCopy>();

            string query = "select objectnr,prijs,code from verkoopobject where verkoopsdatum is null";


            OracleDataReader dr = db.ExecuteReadQuery(query);

            while (dr.Read())
            {
                int objectNr = dr.GetInt32(0);
                float price = dr.GetFloat(1);
                string code = dr.GetString(2);
                //datetime = minval because unsold games don't have a sellingdate.
                copies.Add(new GameCopy(this, objectNr, price, DateTime.MinValue,code ));
            }
            return copies;
        }


    }
}
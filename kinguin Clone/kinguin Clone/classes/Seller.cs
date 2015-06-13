using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Ict4Events_WindowsForms;

namespace kinguin_Clone.classes
{
    public class Seller:Buyer
    {
        public string SellerName { get; set; }
        public string BankAccount { get; set; }
        
        public Seller(int Usernr, string name, string adres, string phonenr, float kinguinBalance, string nickname, string SellerName,string bankaccount, string email ) 
            : base(Usernr, name, adres, phonenr, kinguinBalance, nickname, email )
        {
            this.SellerName = SellerName;
            this.BankAccount = bankaccount;
        }

        public bool ChangeSellerName(string name)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE verkoper  SET verkopersnaam='"+ name+ "' where lidnr = " + this.UserNr;
                db.OpenConnection();
                db.ExecuteQuery(query);
                db.CloseConnection();

                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        public bool ChangeBankAccount(string bankAccount)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE verkoper  SET bankrekening='" + bankAccount + "' where lidnr = " + this.UserNr;
                db.OpenConnection();
                db.ExecuteQuery(query);
                db.CloseConnection();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }

        public bool AddGameCopy(GameCopy gameCopy)
        {
            try
            {
                
                DatabaseConnection db = new DatabaseConnection();
                string query = "insert into verkoopobject (objectnr,gamenr,prijs, verkoopsdatum,code,eigenaar_lidnr) " +
                               " values (seq_verkoopobject.nextval," + gameCopy.gameNr + ",( " + gameCopy.price + "),to_date('" + gameCopy.sellingDate + "','DD-MM-YYYY HH24:MI:SS')  " +
                               "  ,'" + gameCopy.code + "'," + gameCopy.Owner + ")";
                db.OpenConnection();
                db.ExecuteQuery(query);
                db.CloseConnection();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return false;
        }
    }
}
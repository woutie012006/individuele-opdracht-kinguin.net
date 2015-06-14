using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
//using Ict4Events_WindowsForms;

namespace Kinguin_Clone.classes
{
    public class Seller : Buyer
    {
        public string SellerName { get; set; }
        public string BankAccount { get; set; }

        public Seller(int Usernr, string name, string adres, string phonenr, float kinguinBalance, string nickname,
            string sellerName, string bankaccount, string email)
            : base(Usernr, name, adres, phonenr, kinguinBalance, nickname, email)
        {
            this.SellerName = sellerName;
            this.BankAccount = bankaccount;
        }

        public bool ChangeSellerName(string name)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE verkoper  SET verkopersnaam='" + name + "' where lidnr = " + this.UserNr;
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
                string query = "insert into verkoopobject (objectnr,gamenr,prijs, verkoopsdatum,Code,eigenaar_lidnr) " +
                               " values (seq_verkoopobject.nextval," + gameCopy.GameNr + ",( " + gameCopy.Price +
                               "),to_date('" + gameCopy.SellingDate + "','DD-MM-YYYY HH24:MI:SS')  " +
                               "  ,'" + gameCopy.Code + "'," + gameCopy.Owner + ")";
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
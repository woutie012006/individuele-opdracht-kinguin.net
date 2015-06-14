// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Seller.cs" company="">
//   
// </copyright>
// <summary>
//   The seller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Diagnostics;

using Ict4Events_WindowsForms;

#endregion

namespace kinguin_Clone.classes
{
    /// <summary>
    /// The seller.
    /// </summary>
    public class Seller : Buyer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Seller"/> class.
        /// </summary>
        /// <param name="Usernr">
        /// The usernr.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="adres">
        /// The adres.
        /// </param>
        /// <param name="phonenr">
        /// The phonenr.
        /// </param>
        /// <param name="kinguinBalance">
        /// The kinguin balance.
        /// </param>
        /// <param name="nickname">
        /// The nickname.
        /// </param>
        /// <param name="SellerName">
        /// The seller name.
        /// </param>
        /// <param name="bankaccount">
        /// The bankaccount.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        public Seller(
            int Usernr, 
            string name, 
            string adres, 
            string phonenr, 
            float kinguinBalance, 
            string nickname, 
            string SellerName, 
            string bankaccount, 
            string email)
            : base(Usernr, name, adres, phonenr, kinguinBalance, nickname, email)
        {
            this.SellerName = SellerName;
            this.BankAccount = bankaccount;
        }

        /// <summary>
        /// Gets or sets the seller name.
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// The change seller name.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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

        /// <summary>
        /// The change bank account.
        /// </summary>
        /// <param name="bankAccount">
        /// The bank account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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

        /// <summary>
        /// The add game copy.
        /// </summary>
        /// <param name="gameCopy">
        /// The game copy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AddGameCopy(GameCopy gameCopy)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "insert into verkoopobject (objectnr,gamenr,prijs, verkoopsdatum,code,eigenaar_lidnr) "
                               + " values (seq_verkoopobject.nextval," + gameCopy.GameNr + ",( " + gameCopy.Price
                               + "),to_date('" + gameCopy.SellingDate + "','DD-MM-YYYY HH24:MI:SS')  " + "  ,'"
                               + gameCopy.Code + "'," + gameCopy.Owner + ")";
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
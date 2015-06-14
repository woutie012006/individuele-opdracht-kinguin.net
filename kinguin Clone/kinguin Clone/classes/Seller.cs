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
        /// <param Name="Usernr">
        /// The usernr.
        /// </param>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <param Name="adres">
        /// The adres.
        /// </param>
        /// <param Name="phonenr">
        /// The phonenr.
        /// </param>
        /// <param Name="kinguinBalance">
        /// The kinguin balance.
        /// </param>
        /// <param Name="nickname">
        /// The nickname.
        /// </param>
        /// <param Name="SellerName">
        /// The seller Name.
        /// </param>
        /// <param Name="bankaccount">
        /// The bankaccount.
        /// </param>
        /// <param Name="email">
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
        /// Gets or sets the seller Name.
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// The change seller Name.
        /// </summary>
        /// <param Name="name">
        /// The Name.
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
        /// <param Name="bankAccount">
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
        /// <param Name="gameCopy">
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
                string query = "insert into verkoopobject (objectnr,gamenr,prijs, verkoopsdatum,Code,eigenaar_lidnr) "
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
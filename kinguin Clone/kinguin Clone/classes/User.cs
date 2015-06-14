// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region

using System;
using System.Diagnostics;

using Ict4Events_WindowsForms;

#endregion

namespace Kinguin_Clone.classes
{
    /// <summary>
    /// The user.
    /// </summary>
    public abstract class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
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
        /// <param Name="email">
        /// The email.
        /// </param>
        protected User(int Usernr, string name, string adres, string phonenr, float kinguinBalance, string email)
        {
            this.UserNr = Usernr;
            this.Name = name;
            this.Adres = adres;
            this.PhoneNr = phonenr;
            this.KinguinBalance = kinguinBalance;
            this.Email = email;
        }

        /// <summary>
        /// Gets or sets the user nr.
        /// </summary>
        public int UserNr { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the adres.
        /// </summary>
        public string Adres { get; set; }

        /// <summary>
        /// Gets or sets the phone nr.
        /// </summary>
        public string PhoneNr { get; set; }

        /// <summary>
        /// Gets or sets the kinguin balance.
        /// </summary>
        public float KinguinBalance { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The change Name.
        /// </summary>
        /// <param Name="name">
        /// The Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangeName(string name)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE LID  SET naam='" + name + "' where lidnr = " + this.UserNr;
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
        /// The change adres.
        /// </summary>
        /// <param Name="adres">
        /// The adres.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangeAdres(string adres)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE LID  SET adres='" + adres + "' where lidnr = " + this.UserNr;
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
        /// The change phone nr.
        /// </summary>
        /// <param Name="phonenr">
        /// The phonenr.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangePhoneNr(string phonenr)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE LID  SET telefoonnr='" + phonenr + "' where lidnr = " + this.UserNr;
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
        /// The change email.
        /// </summary>
        /// <param Name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangeEmail(string email)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE LID  SET email='" + email + "' where lidnr = " + this.UserNr;
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
        /// what to do can be either *,+,-, / this is used to know what needs to be done
        /// </summary>
        /// <param Name="change">
        /// </param>
        /// <param Name="whattodo">
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ChangeKinguinBalance(float change, string whattodo)
        {
            try
            {
                if (whattodo != "*" && whattodo != "+" && whattodo != "-" && whattodo != "/")
                {
                    throw new Exception("invalid whattodo");
                }
                
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE LID  SET kinguinbalance= ((select kinguinbalance from lid where lidnr = "
                               + this.UserNr + " and rownum =1)" + whattodo + change + ") where lidnr =" + this.UserNr;
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
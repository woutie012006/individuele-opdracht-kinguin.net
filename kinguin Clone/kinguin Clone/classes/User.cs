using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Web;
using Ict4Events_WindowsForms;

namespace kinguin_Clone.classes
{
    public abstract class User
    {
        public int UserNr { get; set; }
        public string Name { get; set; }
        public string Adres { get; set; }
        public string PhoneNr { get; set; }
        public float KinguinBalance { get; set; }
        public string Email { get; set; }

        protected User(int Usernr,string name, string adres, string phonenr, float kinguinBalance, string email)
        {
            this.UserNr = Usernr;
            this.Name = name;
            this.Adres = adres;
            this.PhoneNr = phonenr;
            this.KinguinBalance = kinguinBalance;
            this.Email = email;
        }

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
        /// what to do can be either *,+,-, / this is used to know what needs to be done
        /// </summary>
        /// <param name="change"></param>
        /// <param name="whattodo"></param>
        /// <returns></returns>
        public bool ChangeKinguinBalance(float change, string whattodo)
        {
            try
            {
                if(whattodo!="*" && whattodo!="+" && whattodo!="-" && whattodo!="/")
                {
                    throw new Exception("invalid whattodo") ;
                };
                
            
                DatabaseConnection db = new DatabaseConnection();
                string query = "UPDATE LID  SET kinguinbalance= ((select kinguinbalance from lid where lidnr = "+ this.UserNr +" and rownum =1)"+ whattodo+change +") where lidnr =" + UserNr;
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
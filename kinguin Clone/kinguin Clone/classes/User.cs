using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace kinguin_Clone.classes
{
    public abstract class User
    {
        public int UserNr { get; set; }
        public string Name { get; set; }
        public string Adres { get; set; }
        public string PhoneNr { get; set; }
        public float KinguinBalance { get; set; }
        
        //todo everything

        protected User(int Usernr,string name, string adres, string phonent, float kinguinBalance)
        {


        }

        public bool changeName(string name)
        {
            return false;
        }

        public bool changeAdres(string adres)
        {
            return false;
        }

        public bool changePhoneNr(string phonenr)
        {
            return false;
        }

        public bool changeKinguinBalance()
        {
            return false;
        }

    }
}
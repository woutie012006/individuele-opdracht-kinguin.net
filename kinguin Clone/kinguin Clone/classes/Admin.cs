using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kinguin_Clone.classes
{
    public class Admin:User
    {
        public Admin(int Usernr, string name, string adres, string phonent, float kinguinBalance) : base(Usernr, name, adres, phonent, kinguinBalance)
        {
            //todo implement Admin
        }
    }
}
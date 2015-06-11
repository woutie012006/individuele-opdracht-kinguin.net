using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kinguin_Clone.classes
{
    public class Seller:Buyer
    {
        public Seller(int Usernr, string name, string adres, string phonenr, float kinguinBalance) : base(Usernr, name, adres, phonenr, kinguinBalance)
        {
        }
    }
}
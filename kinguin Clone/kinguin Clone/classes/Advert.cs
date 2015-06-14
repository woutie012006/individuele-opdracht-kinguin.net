using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kinguin_Clone.classes
{
    public class Advert
    {
        public int ID { get; set; }
        public string picture { get; set; }
        public string Url { get; set; }
        public string description { get; set; }


        public Advert(int id, string picture, string Url, string description)
        {
            this.ID = id;
            this.picture = picture;
            this.Url = Url;
            this.description = description;
        }
    }
}
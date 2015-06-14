using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kinguin_Clone.classes
{
    public class Advert
    {
        public int ID { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }


        public Advert(int id, string picture, string Url, string description)
        {
            this.ID = id;
            this.Picture = picture;
            this.Url = Url;
            this.Description = description;
        }
    }
}
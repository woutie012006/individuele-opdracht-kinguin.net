using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kinguin_Clone.classes
{
    public class Cart
    {
        public List<GameCopy> owned { get; set; }

        public void AddGame(GameCopy game)
        {
            //todo database implementation
        }

        public void RemoveGame(GameCopy game)
        {
            //todo database implementation
        }
    }
}
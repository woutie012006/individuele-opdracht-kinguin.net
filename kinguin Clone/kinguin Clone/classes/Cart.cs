using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ict4Events_WindowsForms;
using Oracle.ManagedDataAccess.Client;

namespace kinguin_Clone.classes
{
    public class Cart
    {
        public List<GameCopy> owned { get; set; }

        public void AddGame(GameCopy game, User currentUser)
        {
            DatabaseConnection db = new DatabaseConnection();
            string query = "INSERT INTO mandje (verkoopobject, lidnr) VALUES (" +game.copyNr+", "+ currentUser.UserNr+")";
            db.OpenConnection();
            db.ExecuteQuery(query);
            db.CloseConnection();
            owned.Add(game);
        }

        public void RemoveGame(GameCopy game, User currentUser)
        {
            DatabaseConnection db = new DatabaseConnection();
            string query = "UPDATE mandje  SET relevant = 'N' " +
                           "WHERE lidnr=" + currentUser.UserNr + " and verkoopobject=" + game.copyNr;
            db.OpenConnection();
            db.ExecuteQuery(query);
            db.CloseConnection();
            owned.Remove(game);
        }
    }
}
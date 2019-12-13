using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace InventoryApplication
{
    class DBHandler
    {

        private static SQLiteConnection _conn;
        private string _connString;
        
        public DBHandler()
        {
            _conn = new SQLiteConnection(_connString);
            _conn.Open();
            Console.WriteLine("Connection Open");
        }

        public static void AddUser(int userID, string firstName, string lastName, string email, int mobile)
        {

        }

        private void RemoveUser(int userID)
        {

        }

        private void AddItem(int itemID, string type, string name, string storageLocation)
        {

        }

        private void CheckOutItem(int itemID, int userID)
        {

        }

        private void ReturnItem(int itemID)
        {

        }

        private void SearchItems(string itemType)
        {
            SQLiteDataReader sqlReader;
            using (SQLiteCommand sqlcmd = _conn.CreateCommand())
            {
                sqlcmd.CommandText = "SELECT * FROM Items";

                sqlReader = sqlcmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    Console.WriteLine(sqlReader.GetString(0));
                }
            }
        }

        private void SearchUser(string searchString, string searchType)
        {

        }
    }
}

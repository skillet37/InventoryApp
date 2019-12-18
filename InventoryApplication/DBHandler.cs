using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Threading;

namespace InventoryApplication
{
    class DBHandler : IDisposable
    {

        private readonly SQLiteConnection _conn;
        private static string _connString;
        
        public DBHandler()
        {
            _connString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\ims.db3";
            _conn = new SQLiteConnection(_connString);
            _conn.Open();
            Console.WriteLine("Database Connection Open");
        }

        public void AddUser(int userID, string firstName, string lastName, string email, int mobile)
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

        public SQLiteDataReader fillUsers()
        {
            SQLiteDataReader sqlReader;
            using (SQLiteCommand sqlcmd = _conn.CreateCommand())
            {
                sqlcmd.CommandText = "SELECT id, rank, name FROM User";

                return sqlReader = sqlcmd.ExecuteReader();
            }
        }

        public SQLiteDataReader fillInventory()
        {
                SQLiteDataReader sqlReader;
                using (SQLiteCommand sqlcmd = _conn.CreateCommand())
                {
                    sqlcmd.CommandText = "SELECT barcode, name, type, storageLocation FROM Item";
               
                    return sqlReader = sqlcmd.ExecuteReader();
                }
        }

        private void SearchUser(string searchString, string searchType)
        {

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    if (_conn != null)
                    {
                        _conn.Dispose();
                        Console.WriteLine("Database Connection Closed");
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DBHandler()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

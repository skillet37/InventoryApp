using System;
using System.Data.SQLite;

namespace InventoryApplication
{
    /// <summary>
    /// Handles transactions with the SQL Database. Implements IDisposable to allow
    /// automatic disposal of the connection when the using statement is utilised.
    /// </summary>
    class DBHandler : IDisposable
    {
        private readonly SQLiteConnection _conn;
        private static string _connString;
        
        /// <summary>
        /// Constructor opens the connection
        /// </summary>
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

        // TODO: Change to incorporate search function
        /// <summary>
        /// Returns a list of all users in the database.
        /// </summary>
        /// <returns>SQLiteDataReader containing all users in database</returns>
        public SQLiteDataReader fillUsers()
        {
            SQLiteDataReader sqlReader;
            using (SQLiteCommand sqlcmd = _conn.CreateCommand())
            {
                sqlcmd.CommandText = "SELECT id, rank, name FROM User";

                return sqlReader = sqlcmd.ExecuteReader();
            }
        }

        // TODO: Change to incorporate search function
        /// <summary>
        /// Returns a list of all items in the inventory
        /// </summary>
        /// <returns>SQLiteDataReader containing all items in the database</returns>
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
        /// <summary>
        /// Auto generated dispose function for IDisposal use.
        /// </summary>
        /// <param name="disposing"></param>
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

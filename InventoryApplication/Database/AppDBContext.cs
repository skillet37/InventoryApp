using SQLite.CodeFirst;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Data.SQLite.EF6;


namespace InventoryApplication
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base (new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder {DataSource = "AppDB.db", ForeignKeys = true }.ConnectionString
        }, true)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<AppDBContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }

    public class DbConfig : DbConfiguration
    {
        public DbConfig()
        {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
            SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
        }
    }

}

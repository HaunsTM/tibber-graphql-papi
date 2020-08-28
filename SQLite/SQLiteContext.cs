using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace SQLite
{
    internal class SQLiteContext : DbContext
    {
        public DbSet<Home> Homes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceInfo> PriceInfos { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Viewer> Viewers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            SqliteDbContextOptionsBuilderExtensions.UseSqlite(options, "Data Source=viewers.db");
        }
    }
}

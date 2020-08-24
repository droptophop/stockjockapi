using Microsoft.EntityFrameworkCore;
using StockJockAPI.Domain.Models;

namespace StockJockAPI.Storing
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options){} //dependency injection

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stock>().HasKey(e => e.Id);
            builder.Entity<User>().HasKey(e => e.Id);
            builder.Entity<User>().HasIndex(e => e.Username).IsUnique();
        }
    }
}
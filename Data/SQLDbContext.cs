using Microsoft.EntityFrameworkCore;
using ABC_Retail_CloudApp.Models;

namespace ABC_Retail_CloudApp.Data
{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
        {
        }

        public DbSet<ProductSQL> ProductsSQL { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSQL>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

    }
}
 
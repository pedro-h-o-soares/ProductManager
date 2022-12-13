using Microsoft.EntityFrameworkCore;
using ProductManager.Domain.Models;

namespace ProductManager.Infraestructure.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                    .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                    .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProviderDescription)
                    .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Active)
                    .HasDefaultValue(true);

        }

    }
}

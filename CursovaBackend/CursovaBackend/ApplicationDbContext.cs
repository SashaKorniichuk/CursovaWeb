using CursovaBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursovaBackend
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCart> ProductsCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCart>()
                .HasKey(cp => new { cp.CartId, cp.ProductId });

            modelBuilder.Entity<ProductCart>()
                .HasOne(cp => cp.Cart)
                .WithMany(c => c.ProductCarts)
                .HasForeignKey(cp => cp.CartId);

            modelBuilder.Entity<ProductCart>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.ProductCarts)
                .HasForeignKey(cp => cp.ProductId);
        }
    }
}

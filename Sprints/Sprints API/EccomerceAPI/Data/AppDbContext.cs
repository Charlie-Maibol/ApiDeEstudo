using EccomerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EccomerceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)   
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DistributionCenter> DistributionCenters { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartWithProduct> CartWithProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubCategory>()
                .HasOne(sub => sub.Category)
                .WithMany(category => category.SubCategories)
                .HasForeignKey(sub => sub.CategoryId);

            builder.Entity<Product>()
                .HasOne(prod => prod.SubCategory)
                .WithMany(sub => sub.Products)
                .HasForeignKey(sub => sub.subCategoryId);

            builder.Entity<Product>()
                .HasOne(prod => prod.DistributionCenters)
                .WithMany(center => center.Products)
                .HasForeignKey(center => center.distribuitonCenterId);

            builder.Entity<DistributionCenter>()
                .HasIndex(center => center.Name)
                .IsUnique();

            builder.Entity<CartWithProduct>()
                .HasOne(Cartp => Cartp.Carts)
                .WithMany(cart => cart.CartWithProducts)
                .HasForeignKey(cart => cart.CartId);
        }
        

    }
}

using EccomerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EccomerceAPI.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> opt) : base(opt)   
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubCategory>()
                .HasOne(sub => sub.Category)
                .WithMany(category => category.SubCategories)
                .HasForeignKey(sub => sub.CategoryId);

            
        }
        

    }
}

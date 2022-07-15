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

    }
}

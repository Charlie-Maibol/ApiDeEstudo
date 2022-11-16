using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UserAPI.Models;

namespace UserAPI.Data
{
    public class UserDBContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UserDBContext(DbContextOptions<UserDBContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CustomIdentityUser>()
                .HasIndex(b => b.CPF)
                .IsUnique();
            builder.Entity<CustomIdentityUser>()
                .HasIndex(b => b.Email)
                .IsUnique();

            CustomIdentityUser admin = new CustomIdentityUser()
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999,
                CPF = "123456789",
                CriatonDate = DateTime.Now,
                BirthDay = DateTime.Now,
                Status = true,
                
            };

            PasswordHasher<CustomIdentityUser> passwordHasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123!");

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 99999,
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 99998,
                Name = "regular",
                NormalizedName = "REGULAR"
            });

           builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 99999,
                UserId = 99999
            });
        }
    }
}

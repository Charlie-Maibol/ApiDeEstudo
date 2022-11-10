using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models;

namespace UserAPI.Data
{
    public class UserDBContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        public UserDBContext(DbContextOptions<UserDBContext> opt) : base(opt)
        {

        }
    }
}

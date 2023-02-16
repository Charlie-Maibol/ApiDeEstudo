using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Data
{
    public class UserDBContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDBContext(DbContextOptions<UserDBContext> opt) : base(opt)
        {

        }
    }
}

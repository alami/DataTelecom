using Data.Services.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Identity.DbContext
{
    public class ApplicationDdContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDdContext(DbContextOptions<ApplicationDdContext> options) : base(options)
        {

        }
    }
}

using Data.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.ProductAPI.DdContexts
{
    public class ApplicationDdContext : DbContext
    {
        public ApplicationDdContext(DbContextOptions<ApplicationDdContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}

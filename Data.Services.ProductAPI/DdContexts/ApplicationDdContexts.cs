using Data.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.ProductAPI.DdContexts
{
    public class ApplicationDdContexts : DbContext
    {
        public ApplicationDdContexts(DbContextOptions<ApplicationDdContexts> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}

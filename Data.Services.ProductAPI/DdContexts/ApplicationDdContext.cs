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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "CPU",
                Price = 15,
                Description = "Processor quantity (Количество процессоров) ",
                ImageUrl = "",
                CategoryName = "Processors"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Memory",
                Price = 13.99,
                Description = "Total memory (Gb) / Общее количество памяти ",
                ImageUrl = "",
                CategoryName = "Memory"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "HD",
                Price = 10.99,
                Description = "Hard disk memory (Tb) / Память на жестких дисках",
                ImageUrl = "",
                CategoryName = "Disks"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "SSD",
                Price = 15,
                Description = "SSD memory  (Tb) / Память на SSD",
                ImageUrl = "",
                CategoryName = "Disks"
            });
        }
    }
}

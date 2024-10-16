using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Lahmacun",
                Price = 25,
                Description = "İnce hamurun üzerine sıcak baharatlarla harmanlanmış kıyma, domates ve soğan konularak pişirilen geleneksel Türk lezzeti.",
                ImageUrl = "https://placehold.co/603x403",
                CategoryName = "Fast Food"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Künefe",
                Price = 35,
                Description = "İnce tel kadayıfın içine peynir konularak pişirilir ve üzerine şerbet dökülür. Türkiye'nin en sevilen tatlılarından biri.",
                ImageUrl = "https://placehold.co/602x402",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "İskender Kebap",
                Price = 50,
                Description = "İnce dilimlenmiş dana eti, tava da pişirilir ve pide ekmeği üzerine dökülür. Üzerine yoğurt ve domates sosu dökülür.",
                ImageUrl = "https://placehold.co/601x401",
                CategoryName = "Main Course"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Baklava",
                Price = 40,
                Description = "İnce yufkalar arasına fıstık konularak yapılan ve şerbet ile tatlandırılan geleneksel Türk tatlısı.",
                ImageUrl = "https://placehold.co/600x400",
                CategoryName = "Dessert"
            });
        }
    }
}
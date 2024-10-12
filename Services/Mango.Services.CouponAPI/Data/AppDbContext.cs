using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DateTime seedDate = new DateTime(2024, 10, 12, 0, 0, 0, DateTimeKind.Utc);

            for (int i = 1; i <= 7; i++)
            {
                modelBuilder.Entity<Coupon>().HasData(new Coupon
                {
                    CouponId = i,
                    CouponCode = $"{i * 10}OFF",
                    DiscountAmount = i * 10,
                    MinAmount = i * 20,
                    CraetedDate = seedDate,
                    LastUpdated = null,
                });
            }
        }
    }
}
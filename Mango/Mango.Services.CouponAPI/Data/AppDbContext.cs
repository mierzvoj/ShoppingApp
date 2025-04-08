using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data;

public class AppDbContext : DbContext
{
    Coupon[] coupons = new Coupon[15]
    {
        new Coupon { CouponId = 1, CouponCode = "SAVE10", DiscountAmount = 10.0, MinAmount = 50 },
        new Coupon { CouponId = 2, CouponCode = "WELCOME20", DiscountAmount = 20.0, MinAmount = 100 },
        new Coupon { CouponId = 3, CouponCode = "FLASH30", DiscountAmount = 30.0, MinAmount = 150 },
        new Coupon { CouponId = 4, CouponCode = "SUMMER15", DiscountAmount = 15.0, MinAmount = 75 },
        new Coupon { CouponId = 5, CouponCode = "WINTER25", DiscountAmount = 25.0, MinAmount = 120 },
        new Coupon { CouponId = 6, CouponCode = "LOYAL50", DiscountAmount = 50.0, MinAmount = 200 },
        new Coupon { CouponId = 7, CouponCode = "NEWUSER5", DiscountAmount = 5.0, MinAmount = 25 },
        new Coupon { CouponId = 8, CouponCode = "HOLIDAY40", DiscountAmount = 40.0, MinAmount = 180 },
        new Coupon { CouponId = 9, CouponCode = "SPECIAL15", DiscountAmount = 15.0, MinAmount = 60 },
        new Coupon { CouponId = 10, CouponCode = "RETURN10", DiscountAmount = 10.0, MinAmount = 40 },
        new Coupon { CouponId = 11, CouponCode = "AUTUMN20", DiscountAmount = 20.0, MinAmount = 90 },
        new Coupon { CouponId = 12, CouponCode = "SPRING25", DiscountAmount = 25.0, MinAmount = 125 },
        new Coupon { CouponId = 13, CouponCode = "WEEKEND15", DiscountAmount = 15.0, MinAmount = 65 },
        new Coupon { CouponId = 14, CouponCode = "SALE30", DiscountAmount = 30.0, MinAmount = 140 },
        new Coupon { CouponId = 15, CouponCode = "VIP20", DiscountAmount = 20.0, MinAmount = 80 }
    };
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Coupon> Coupons { get; set; }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Coupon>().HasData(coupons);
    }
}
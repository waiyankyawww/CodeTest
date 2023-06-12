using System;
using FarmFresh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FarmFresh.DAL
{
    public class FarmFreshContext : DbContext
    {
        public FarmFreshContext(DbContextOptions<FarmFreshContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            //modelBuilder.Entity<Product>().Property(t => t.ProductName).IsRequired(); // Product Name required
            base.OnModelCreating(modelBuilder);
            // seeding data to test
            //modelBuilder.Entity<Product>().HasData(
            //    new Product
            //    {
            //        ProductName = "product",
            //        ProductPhoto = "image1",
            //        ProductType = "prodcut type",
            //        PackingType = "prodcut type",
            //        OnSale = false,
            //        ShopByStore = true,
            //        CreatedDate = "32423",
            //    },
            //    new Product
            //    {
            //        ProductName = "product",
            //        ProductPhoto = "image2",
            //        ProductType = "prodcut type",
            //        PackingType = "prodcut type",
            //        OnSale = false,
            //        ShopByStore = true,
            //        CreatedDate = "32423",
            //    },
            //     new Product
            //     {
            //         ProductName = "product",
            //         ProductPhoto = "image3",
            //         ProductType = "prodcut type",
            //         PackingType = "prodcut type",
            //         OnSale = false,
            //         ShopByStore = true,
            //         CreatedDate = "32423",
            //     }
            //);
        }

        //public class FarmFreshDbContextFactory : IDesignTimeDbContextFactory<FarmFreshContext>
        //{
        //    public FarmFreshContext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<FarmFreshContext>();
        //        optionsBuilder.UseSqlServer("DefaultConnection");

        //        return new FarmFreshContext(optionsBuilder.Options);
        //    }
        //}
    }
}

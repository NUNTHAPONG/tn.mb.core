using Microsoft.EntityFrameworkCore;
using Web.Models.Configurations;
using Web.Models.Entites;

namespace Web.Models
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandsConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new StaffsConfiguration());
            modelBuilder.ApplyConfiguration(new StocksConfiguration());
            modelBuilder.ApplyConfiguration(new StoresConfiguration());
        }

        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Staffs> Staffs { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Stores> Stores { get; set; }

    }
}

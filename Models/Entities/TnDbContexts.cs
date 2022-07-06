using Microsoft.EntityFrameworkCore;
using Web.Models.Configurations;

using Web.Models.Entities;

namespace Web.Models
{
    public partial class CleanDbContext : DbContext
    {
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Staffs> Staffs { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Stores> Stores { get; set; }

    }
}

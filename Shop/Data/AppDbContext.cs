using Microsoft.EntityFrameworkCore;
using Shop.Data.Configuration;
using Shop.Model;

namespace Shop.Data
{
    public class AppDbContext : DbContext 
    {

        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<BalanceHistory> BalanceHistory { get; set; }


        private readonly  IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DataBase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

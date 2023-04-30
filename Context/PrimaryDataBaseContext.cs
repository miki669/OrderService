using Microsoft.EntityFrameworkCore;

namespace OrderService.Context;

public class PrimaryDataBaseContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public PrimaryDataBaseContext(DbContextOptions<PrimaryDataBaseContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(p => p.OrderProducts)
            .WithOne(p => p.Order);
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderProducts)
            .WithOne(p => p.Product);
        //     
        //     modelBuilder.Entity<OrderProduct>()
        //         .Property(p=> p.Product)
        //         .IsRequired(true);
        //     modelBuilder.Entity<OrderProduct>()
        //         .Property(p=> p.Order)
        //         .IsRequired(true);
    }
}
using Microsoft.EntityFrameworkCore;

namespace FELFEL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Batch> Batch { get; set; }
        public DbSet<BatchState> BatchState { get; set; }
        public DbSet<InventoryHistory> InventoryHistory { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
                .HasIndex(p => new { p.ExpirationDate })
                .IsUnique(true);

            modelBuilder.Entity<BatchState>().HasData(
                            new BatchState { Id = 1, Description = "Fresh" },
                            new BatchState { Id = 2, Description = "ExpiringToday" },
                            new BatchState { Id = 3, Description = "Expired" }
            );

            modelBuilder.Entity<OrderState>().HasData(
                            new OrderState { Id = 1, Description = "Pending" },
                            new OrderState { Id = 2, Description = "On Going" },
                            new OrderState { Id = 3, Description = "Received" }
            );

            modelBuilder.Entity<Customer>().HasData(
                            new Customer { Id = 1, Name = "Customer1" },
                            new Customer { Id = 2, Name = "Customer2" },
                            new Customer { Id = 3, Name = "Customer3" },
                            new Customer { Id = 4, Name = "Customer4" },
                            new Customer { Id = 5, Name = "Customer5" }
            );

            modelBuilder.Entity<Supplier>().HasData(
                            new Supplier { Id = 1, Name = "Supplier1" },
                            new Supplier { Id = 2, Name = "Supplier2" },
                            new Supplier { Id = 3, Name = "Supplier3" },
                            new Supplier { Id = 4, Name = "Supplier4" },
                            new Supplier { Id = 5, Name = "Supplier5" }
            );

            modelBuilder.Entity<Product>().HasData(
                            new Product { Id = 1, Name = "Pasta" },
                            new Product { Id = 2, Name = "Bread" },
                            new Product { Id = 3, Name = "Chicken Meat" },
                            new Product { Id = 4, Name = "Broccoli" },
                            new Product { Id = 5, Name = "Apples" },
                            new Product { Id = 6, Name = "Avocados" },
                            new Product { Id = 7, Name = "Eggs" },
                            new Product { Id = 8, Name = "Asparagus" },
                            new Product { Id = 9, Name = "Onions" },
                            new Product { Id = 10, Name = "Tomatoes" },
                            new Product { Id = 11, Name = "Shrimp" },
                            new Product { Id = 12, Name = "Sardines" },
                            new Product { Id = 13, Name = "Tuna" }
            );
        }

    }
}
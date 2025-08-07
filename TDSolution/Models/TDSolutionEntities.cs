using Microsoft.EntityFrameworkCore;

namespace TDSolution.Models
{
    public class TDSolutionEntities : DbContext
    {
        public TDSolutionEntities(DbContextOptions<TDSolutionEntities> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed data

            ///Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FullName = "Cust_01", Email = "mailcus1@gmail.com", PhoneNumber = "090099999" },
                new Customer { CustomerID = 2, FullName = "Cust_02", Email = "mailcus2@gmail.com", PhoneNumber = "080099999" }
                );

            ///Product
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "PRD_01", Price = 100 },
                new Product { ProductID = 2, Name = "PRD_02", Price = 100.5 },
                new Product { ProductID = 3, Name = "PRD_03", Price = 101 },
                new Product { ProductID = 4, Name = "PRD_04", Price = 256.5 }
                );

            #endregion Seed data
        }
    }
}
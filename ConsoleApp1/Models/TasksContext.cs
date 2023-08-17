using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class TasksContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<ProductDetails> Details { get; set; } = null!;
        public DbSet<ProductOrder> productOrders { get; set; } = null!;
        public DbSet<NewCustomer> newCustomer { get; set; }
        public DbSet<FeaturedProducts> features { get; set; }
        public DbSet<BestSellerProducts> bestSellerProducts { get; set; }
        public DbSet<CancelledOrders> cancelledOrders { get; set; }
        public DbSet<CallDetails> callDetails { get; set; }
        
        public DbSet<Custom> Customs { get; set; } = null!;

        //public IQueryable<Customer> GetAge(DateTime dateOfBirth) => FromExpression(() => GetAge(dateOfBirth));
        //task 6
        //public IQueryable<Order> SpecificOrders(int param) => FromExpression(() => SpecificOrders(param));
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasOne(o => o.Customer).WithMany(o => o.orders).HasForeignKey(o => o.CustomerId);
            builder.Entity<ProductDetails>().HasOne(e => e.product)
                .WithOne(p => p.Details)
                .HasForeignKey<ProductDetails>(e => e.ProductId)
                .IsRequired();
            builder.Entity<Customer>().HasAlternateKey(c => c.Email);//unique Task 6
            builder.Entity<NewCustomer>().HasAlternateKey(c => c.Email);
            builder.Entity<Product>().HasCheckConstraint("CK_Product_Quantity", "[StockQuantity]>0");
            //builder.Entity<Product>().ToTable(p => p.HasCheckConstraint("CK_Product_Quantity", "[StockQuantity]>0"));//Task 7
            builder.Entity<Order>().HasIndex(o => o.Date).HasDatabaseName("IX_date");//Task 8
            builder.Entity<Order>().HasIndex(o => new { o.CustomerId, o.Status }).HasDatabaseName("IX_Customer_Status");// Anonim type Task 9
            //ProductOrder table
            builder.Entity<ProductOrder>().HasKey(c => new { c.OrderId, c.ProductId });
            builder.Entity<ProductOrder>().HasOne(c => c.order)
                                            .WithMany(s => s.productOrders)
                                            .HasForeignKey(c => c.OrderId);
            builder.Entity<ProductOrder>().HasOne(c => c.product)
                                            .WithMany(s => s.productOrders)
                                            .HasForeignKey(c => c.ProductId);
            //canceld orders
            builder.Entity<CancelledOrders>().HasOne(p => p.Order)
                .WithOne(p => p.CancelledOrders)
                .HasForeignKey<CancelledOrders>(e => e.OrderId);
            //Task21
            builder.Entity<Customer>().HasQueryFilter(c => c.IsDeleted == false);
            builder.Entity<CustomerAge>().HasNoKey();
            builder.Entity<CallDetails>().HasOne(p => p.Customer)
                                          .WithMany(c => c.callDetails)
                                          .HasForeignKey(d => d.customerId);
            //builder.HasDbFunction(() => GetAge(default));
            //builder.HasDbFunction(() => SpecificOrders(default));

            //Task9
            builder.Entity<Customer>().Property(p => p.Timestamp).IsRowVersion();

            //task12
            builder.Entity<Custom>(p =>
            {
                p.HasNoKey();
                p.ToView("View_CustomerOrders");
            });

            //Task13...nuyny customeri vra
            builder.Entity<Customer>().ToTable("Customers", t => t.IsTemporal());
        }
        public TasksContext()
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //DESKTOP-1I2AAN9\MSSQLSERVER2022
            optionsBuilder.UseSqlServer(@"Server= DESKTOP-1I2AAN9\MSSQLSERVER2022;Database=TasksNewest;Trusted_Connection=True;TrustServerCertificate=true");
            //sql code
            //optionsBuilder.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }

        
    
}

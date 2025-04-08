using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Singular_Systems_SelfKiosk_Software.Models;
using SingularKiosk.Controllers;
using SingularSystems_SelfKiosk_Software.Models;
using System.Collections.Generic;



namespace SingularSystems_SelfKiosk_Software.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CustomerTransaction> CustomerTransactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
            // User ↔ UserRole (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole)
                .WithOne(ur => ur.User) // Make sure UserRole has a User property
                .HasForeignKey<UserRole>(ur => ur.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User ↔ Wallet (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User) // Make sure Wallet has a User property
                .HasForeignKey<Wallet>(w => w.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User ↔ Orders (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Order ↔ OrderItems (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems) // Make sure Order has an OrderItems property
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Order ↔ Transaction (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.CustomerTransactions) // Make sure Order has a Transactions property
                .WithOne(t => t.Order)
                .HasForeignKey(t => t.OrderId);


                 modelBuilder.Entity<Product>()
                 .Property(p => p.Price)
                 .HasColumnType("decimal(18,2)");  // Precision of 18 and scale of 2
            // Product ↔ OrderItems (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems) // Make sure Product has an OrderItems property
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Category ↔ Products (One-to-Many)
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products) // Make sure Category has a Products property
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Supplier ↔ Products (One-to-Many)
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Products) // Make sure Supplier has a Products property
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // Wallet ↔ Transactions (One-to-Many)
            modelBuilder.Entity<Wallet>()
                .HasMany(w => w.CustomerTransactions) // Make sure Wallet has a Transactions property
                .WithOne(t => t.Wallet)
                .HasForeignKey(t => t.WalletId);

            // Transaction ↔ Wallet (Many-to-One)
            modelBuilder.Entity<CustomerTransaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.CustomerTransactions) // A Wallet can have many Transactions
                .HasForeignKey(t => t.WalletId) // Foreign key in Transaction
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Transaction ↔ Order (Many-to-One)
            modelBuilder.Entity<CustomerTransaction>()
                .HasOne(t => t.Order)
                .WithMany(o => o.CustomerTransactions) // An Order can have many Transactions
                .HasForeignKey(t => t.OrderId) // Foreign key in Transaction
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


            
        }








    }
}



using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NewShop.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBContextNew")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingDetails> BookingDetails { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerWallet> CustomerWallet { get; set; }
        public virtual DbSet<Gift> Gift { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<RelatedArticles> RelatedArticles { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Saler> Saler { get; set; }
        public virtual DbSet<SalerWallet> SalerWallet { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerWallet)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerWallet>()
                .Property(e => e.Balance)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Saler>()
                .HasMany(e => e.SalerWallet)
                .WithRequired(e => e.Saler)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalerWallet>()
                .Property(e => e.Balance)
                .HasPrecision(10, 2);
        }
    }
}

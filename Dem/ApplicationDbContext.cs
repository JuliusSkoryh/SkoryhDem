using Dem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-CQ9RL69;Database=YourDatabaseName;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Material>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Materials);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Materials)
                .WithOne(e => e.Supplier);

            modelBuilder.Entity<Partner>()
                .HasMany(e => e.Requests)
                .WithOne(e => e.Partner);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Requests)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Material>()
                .Property(m => m.Cost)
                .HasPrecision(18, 2); 

            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Request>()
                .Property(r => r.Price)
                .HasPrecision(18, 2);
        }
    }
}

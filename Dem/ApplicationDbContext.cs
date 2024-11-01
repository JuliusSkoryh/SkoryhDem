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
        //Host=localhost;Port=5432;Database=Check;Username=postgres;Password=password
        //dotnet ef migrations add PgInit --context ApplicationDbContext -s "D:\Pr\IHopeItsLastTime\IHopeItsLastTime" -o "Data\Migrations"
        //IdentityUser
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<DeliveryHistory> DeliveryHistories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialHistory> MaterialHistories { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PassportInfo> PassportInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PassportInfo)
                .WithOne(e => e.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.BankDetails)
                .WithOne(e => e.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.MaterialHistories)
                .WithOne(e => e.Material);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.DeliveryHistories)
                .WithOne(e => e.Material);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Materials);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.DeliveryHistories)
                .WithOne(e => e.Supplier);

            modelBuilder.Entity<Partner>()
                .HasMany(e => e.ProductHistories)
                .WithOne(e => e.Partner);

            modelBuilder.Entity<Partner>()
                .HasMany(e => e.Requests)
                .WithOne(e => e.Partner);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Requests)
                .WithOne(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductHistories)
                .WithOne(e => e.Product);


            //modelBuilder.Entity<Employee>()
            //    .Property<byte[]>("EmployeePhoto")
            //    .HasColumnType("bytea");


            //var greenAccessLevelId = Guid.NewGuid();
            //var yellowAccessLevelId = Guid.NewGuid();
            //var redAccessLevelId = Guid.NewGuid();

            //var accessLevels = new AccessLevel[]
            //{
            //    new AccessLevel(greenAccessLevelId, "Green"),
            //    new AccessLevel(yellowAccessLevelId, "Yellow"),
            //    new AccessLevel(redAccessLevelId, "Red")
            //};
            //modelBuilder.Entity<AccessLevel>().HasData(accessLevels);



            //modelBuilder.Entity("EmployeeRole").HasData(employeeRoles);
        }
    }
}

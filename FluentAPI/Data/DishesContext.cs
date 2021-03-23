using FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Data
{
    public class DishesContext : DbContext
    {
        public DishesContext()
        {
            Database.Migrate();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = FluentAPI; Trusted_Connection = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("products")
                .Property(product => product.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);
               
            modelBuilder.Entity<Product>()
                .Property(product => product.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(product => product.DishId)
               .HasColumnName("dishId");

            modelBuilder.Entity<Product>()
                .HasOne(product => product.Dish)
                .WithMany(dish => dish.Products);

            modelBuilder.Entity<Dish>()
               .ToTable("dishes")
               .Property(dish => dish.Id)
               .HasColumnName("ID");

            modelBuilder.Entity<Dish>()
                .HasKey(dish => dish.Id);

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}

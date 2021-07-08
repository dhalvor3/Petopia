using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace App
{
    public class DataContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=app.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var dogs = new Dog[] {
                new Dog { Id = 1, Name = "Lassy"},
                new Dog { Id = 2, Name = "Molly"},
                new Dog { Id = 3, Name = "Frank"},
            };
            modelBuilder.Entity<Dog>().HasData(dogs);

            var owners = new Owner[] {
                new Owner { Id = 1, FirstName = "Don"},
                new Owner { Id = 2, FirstName = "Jackie"},
                new Owner { Id = 3, FirstName = "Sara"},
            };
            modelBuilder.Entity<Owner>().HasData(owners);

            base.OnModelCreating(modelBuilder);
        }
    }
}
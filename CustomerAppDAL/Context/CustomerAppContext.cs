using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CustomerAppDAL.Context
{
    class CustomerAppContext : DbContext
    {
        static DbContextOptions<CustomerAppContext> options =
            new DbContextOptionsBuilder<CustomerAppContext>()
                         .UseInMemoryDatabase("TheDB")
                         .Options;

        //Options That we want in Memory
        /*public CustomerAppContext() : base(options)
        {

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                String FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/CSharpRestAPI";
                string text = System.IO.File.ReadAllText(FilePath + "/DBstring.txt");

                optionsBuilder.UseSqlServer(text);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(ca => new {AddressID = ca.AddressID, ca.CustomerID });

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Address)
                .WithMany(a => a.Customers)
                .HasForeignKey(ca => ca.AddressID);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(ca => ca.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(ca => ca.CustomerID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}

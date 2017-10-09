using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CustomerAppDAL.Context
{
    public class CustomerAppContext : DbContext
    {
        //public static readonly string DBConnectionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DBstring.txt");
        //public static readonly string ConnectionString = File.ReadAllText(DBConnectionPath);

        public static string ConnectionString = "";
        //static DbContextOptions<CustomerAppContext> options =
        //    new DbContextOptionsBuilder<CustomerAppContext>()
        //                 .UseInMemoryDatabase("TheDB")
        //                 .Options;

        public CustomerAppContext()
        {
            Database.EnsureCreated();
        }

        //Options That we want in Memory
        /*public CustomerAppContext() : base(options)
        {

        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
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

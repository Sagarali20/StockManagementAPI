﻿using Microsoft.EntityFrameworkCore;
using Inventory.EntityModels;
using Inventory.EntityModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-5TQKBFB\\SQLEXPRESS;Database=TestDb;Trusted_Connection=True");
        //    }
        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get;set; }
		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<InventoryWarehouse> InventoryWarehouses { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<InvoiceDetails> InvoiceDetails { get; set; }

	}
}

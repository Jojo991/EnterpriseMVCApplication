using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCAbstraction.Domain;



namespace MVCAbstraction.Services
{
    public class GroceryDbContext : DbContext
    {
        //public GroceryDbContext()
        //    : base("name=GroceryDbContext")
        //{
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
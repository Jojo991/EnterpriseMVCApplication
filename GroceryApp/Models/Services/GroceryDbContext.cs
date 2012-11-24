using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GroceryApp.Models.Domain;




namespace GroceryApp.Models.Services
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext()
         //  :// base("name=GroceryDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseTables());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Parish> Parish { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
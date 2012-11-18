using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryApp.Models.Domain;
using System.Data;

namespace GroceryApp.Models.Services
{
    public class SupplierSvcADOImpl:ISupplierSvc
    {
        //EF context for database access
        GroceryDbContext db = new GroceryDbContext();


        //service for adding Supplierinformation
        public void AddSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();

        }//end of method 



        //method for searching for product
        public Supplier SearchSupplier(string supplierCode)
        {
            Supplier supplier=  db.Suppliers.Find(supplierCode);
            return supplier;

        }


        //method for updating a product
        public void UpdateSupplier(Supplier supplier)
        {

            db.Entry(supplier).State = EntityState.Modified;
            db.SaveChanges();
        }


        //method for updating a product
        public void RemoveSupplier(string supplierCode)
        {
            Supplier supplier = db.Suppliers.Find(supplierCode);
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using log4net;
using log4net.Config;
using GroceryApp.Models.Domain;
using System.Data;


namespace GroceryApp.Models.Services
{
    /*
    * Author: Kedrian James
    * Implementation for Interface 
    * product services
    */ 
   public class ProductSvcADOImpl: IProductSvc
    {
        //linq context for database access
       GroceryDbContext db = new GroceryDbContext();

        //Here is the once-per-class call to initialize the log object
        //private static readonly log4net.ILog log = 
        //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        
        //service for adding product information
        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();      
           
        }//end of method 



       //method for searching for product
        public Product SearchProduct(string productCode)
        {
            Product product = db.Products.Find(productCode);
            return product;
           
        }


       //method for updating a product
        public void UpdateProduct(Product product)
        {

            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();         
        }


     
    }
}

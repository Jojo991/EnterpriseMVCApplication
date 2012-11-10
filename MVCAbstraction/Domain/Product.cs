using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVCAbstraction.Domain
{
    /*
     * Author: Kedrian James
     * Product Class
     * Represents a product
     * in the grocery store
     */
    
    //[Serializable]
    public class Product
    {
        [Key]
        [StringLength(10)]
        public string ProductID { get; set; } //unique Identifier for the product


        [Required]
        [StringLength(40)]
        public string ProductName { get; set; } //name of the product

        public double UnitPrice { get; set; } //unit price of product

        public string Unit { get; set; } //description of product

        public double QuantityReceived { get; set; } //quantity recieved

       public int CategoryID { get; set; } //categoryID of product

       public string SupplierCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; } //description of product

        //[ForeignKey("SupplierCode")]
        //public Supplier supplier { get; set; }

        //[Required]
        //public string SupplierCode {get; set;}



        //[ForeignKey("CategoryID")]
        //public Category category { get; set; }

        //[Required]
        //public int CategoryID { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Category Category {get; set;}




        ////constructor
        //public Product()
        //{
        //    ProductID = null;
        //    ProductName = null;
        //    UnitPrice = 0.0;
        //    Unit = null;
        //    QuantityReceived = 0;
        //    Category = null;
        //    Description = null;
        //}

       }

}
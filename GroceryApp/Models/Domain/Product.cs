using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroceryApp.Models.Domain
{
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "Product Code")]
        public string ProductID { get; set; } //unique Identifier for the product


        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } //name of the product

        [Required]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; } //unit price of product

       
        [Required]
        [Display(Name = "Quantity Received")]
        public double QuantityReceived { get; set; } //quantity recieved

        public int CategoryID { get; set; } //categoryID of product

        public string SupplierCode { get; set; }

        public int UnitID { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; } //description of product


        public virtual Category Category { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
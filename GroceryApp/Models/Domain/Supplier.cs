using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroceryApp.Models.Domain
{
    public class Supplier
    {
        /*unique identifier for the supplier*/
        [Key]
        [Required]
        [Display(Name = "Supplier Code")]
        public string SupplierCode { get; set; }

        /*name of supplier*/
        [Required]
        [Display(Name = "Company Name")]
        public string SupplierName { get; set; }


        /*street address for supplier*/
        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }


        /*parish adress for supplier*/
        public int ParishID { get; set; }
        public virtual Parish Parish { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroceryApp.Models.Domain
{
    /** Domain Object that represents a category
     * */
    public class Category
    {
        
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
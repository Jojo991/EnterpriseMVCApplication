using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroceryApp.Models.Domain
{
    public class Unit
    {
        public int UnitID { get; set; }

        [Required]
        [Display(Name = "Unit Name")]
        public string name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
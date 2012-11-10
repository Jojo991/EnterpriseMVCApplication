using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVCAbstraction.Domain
{
   public class Category
    {
    
        public int CategoryID { get; set; }

        public string name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

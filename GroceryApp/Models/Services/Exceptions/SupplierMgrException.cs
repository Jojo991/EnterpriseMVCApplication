using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryApp.Models.Services.Exceptions
{
    public class SupplierMgrException:Exception
    {
        public SupplierMgrException(String s)
            : base(s)
        {

        }
    }
}
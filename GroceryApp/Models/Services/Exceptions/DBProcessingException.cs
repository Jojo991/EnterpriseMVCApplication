using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryApp.Models.Services.Exceptions
{
    /**
    * Author: Kedrian James
    * Database Processing Exception
    * Thrown when a errors occurs when updating
     * Inserting or deleting a record
    * */
    public class DBProcessingException: Exception
    {
        public DBProcessingException(String s)
            : base(s)
        {

        }
    
    }
}

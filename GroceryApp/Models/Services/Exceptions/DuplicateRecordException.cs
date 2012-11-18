using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryApp.Models.Services.Exceptions
{
    /**
     * Author: Kedrian James
     * Duplicate Record Processing Exception
     * Thrown when an attempt is made to insert a duplicate
     * */
    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException(String s)
            : base(s)
        {

        }
    }
}

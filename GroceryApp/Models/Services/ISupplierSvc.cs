using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryApp.Models.Domain;

namespace GroceryApp.Models.Services
{
    /**supplier service**/
    public interface ISupplierSvc:IService
    {

        /*method for adding Supplier*/
        void AddSupplier(Supplier supplier);

        /*method for searching for Supplier*/
        Supplier SearchSupplier(string supplierCode);

        //update Supplier
        void UpdateSupplier(Supplier supplier);

        //update Supplier
        void RemoveSupplier(string supplierCode);
    }
}
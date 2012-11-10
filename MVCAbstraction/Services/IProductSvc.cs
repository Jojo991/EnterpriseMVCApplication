using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCAbstraction.Domain;
using MVCAbstraction.Services;

namespace MVCAbstractione.Services
{
    /*
     * Author: Kedrian James
     * Interface for 
     * product services
     */
    public interface IProductSvc : IService
    {

        /*method for adding product*/
        void AddProduct(Product product, bool isNewSupplier);

        /*method for searching for product*/
        Product SearchProduct(string productCode);

        //update product
        void UpdateProduct(Product product);
    }
}

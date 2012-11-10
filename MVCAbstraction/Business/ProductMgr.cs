using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCAbstraction.Domain;
using MVCAbstractione.Services;
using MVCAbstraction.Services.Exceptions;


namespace GroceryStore.Business
{
    /**
     * Product Mgr 
     * class which will be a facade to the presentation
     * layer
     * */
    class ProductMgr :  Manager
    {

        public void AddProduct(Product product, bool isNewSupplier)
        {
           
            try
            {
                IProductSvc productSvc = (IProductSvc)GetService(typeof(IProductSvc).Name);
                productSvc.AddProduct(product, isNewSupplier);
            }
            catch (ServiceLoadException e)
            {
                throw new ProductMgrException(e.Message);
            }
            catch (DuplicateRecordException e)
            {
                throw new ProductMgrException(e.Message);
            }
            catch (DBProcessingException e)
            {
                throw new ProductMgrException(e.Message);
            }
        }




        public Product SearchProduct(string productCode)
        {
            Product product = new Product();
            try
            {
                IProductSvc productSvc = (IProductSvc)GetService(typeof(IProductSvc).Name);
               product =  productSvc.SearchProduct(productCode);
            }
            catch (ServiceLoadException e)
            {
                throw new ProductMgrException(e.Message);
            }
             catch (DBProcessingException e)
            {
                throw new ProductMgrException(e.Message);
            }


            return product;
        }




        public void UpdateProduct(Product product)
        {
       
            try
            {
                IProductSvc productSvc = (IProductSvc)GetService(typeof(IProductSvc).Name);
                productSvc.UpdateProduct(product);
            }
            catch (ServiceLoadException e)
            {
                throw new ProductMgrException(e.Message);
            }
            catch (DBProcessingException e)
            {
                throw new ProductMgrException(e.Message);
            }           
        }
    }





}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryApp.Models.Services.Exceptions;
using GroceryApp.Models.Services;
using GroceryApp.Models.Domain;

namespace GroceryApp.Models.Business
{
    //supplier manager class
    public class SupplierMgr : Manager
    {
        //adds a supplier
        public void AddSupplier(Supplier supplier)
        {

            try
            {
                ISupplierSvc supplierSvc = (ISupplierSvc)GetService(typeof(ISupplierSvc).Name);
                supplierSvc.AddSupplier(supplier);
            }
            catch (ServiceLoadException e)
            {
                throw new SupplierMgrException(e.Message);
            }
            catch (DuplicateRecordException e)
            {
                throw new SupplierMgrException(e.Message);
            }
            catch (DBProcessingException e)
            {
                throw new SupplierMgrException(e.Message);
            }
        }



        //searches for a supplier via supplier code
        public Supplier SearchSupplier(string supplierCode)
        {
            Supplier supplier = new Supplier();
            try
            {
                ISupplierSvc supplierSvc = (ISupplierSvc)GetService(typeof(ISupplierSvc).Name);
                supplier = supplierSvc.SearchSupplier(supplierCode);
            }
            catch (ServiceLoadException e)
            {
                throw new SupplierMgrException(e.Message);
            }
            catch (DBProcessingException e)
            {
                throw new SupplierMgrException(e.Message);
            }


            return supplier;
        }



        //updates a supplier
        public void UpdateSupplier(Supplier supplier)
        {

            try
            {
                ISupplierSvc supplierSvc = (ISupplierSvc)GetService(typeof(ISupplierSvc).Name);
                supplierSvc.UpdateSupplier(supplier);
            }
            catch (ServiceLoadException e)
            {
                throw new SupplierMgrException(e.Message);
            }
            catch (DBProcessingException e)
            {
                throw new SupplierMgrException(e.Message);
            }
        }



        //removes a supplier
        public void RemoveSupplier(string supplierCode)
        {

            try
            {
                ISupplierSvc supplierSvc = (ISupplierSvc)GetService(typeof(ISupplierSvc).Name);
                supplierSvc.RemoveSupplier(supplierCode);
            }
            catch (ServiceLoadException e)
            {
                throw new SupplierMgrException(e.Message);
            }
            catch (DBProcessingException e)
            {
                throw new SupplierMgrException(e.Message);
            }
        }
    }
}
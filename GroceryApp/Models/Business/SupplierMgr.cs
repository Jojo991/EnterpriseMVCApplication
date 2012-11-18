using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryApp.Models.Services.Exceptions;
using GroceryApp.Models.Services;
using GroceryApp.Models.Domain;

namespace GroceryApp.Models.Business
{
    public class SupplierMgr : Manager
    {
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
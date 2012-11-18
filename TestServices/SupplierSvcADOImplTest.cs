using GroceryApp.Models.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using GroceryApp.Models.Domain;

namespace TestServices
{
    
    
    /// <summary>
    ///This is a test class for SupplierSvcADOImplTest and is intended
    ///to contain all SupplierSvcADOImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SupplierSvcADOImplTest
    {


        private TestContext testContextInstance;
        

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AddSupplier
        ///</summary>
        [TestMethod()]
        public void AddSupplierTest()
        {
            Factory factory = Factory.GetInstance();
            Supplier supplier = new Supplier(); // TODO: Initialize to an appropriate value

            supplier.SupplierCode = "RIB-100";
            supplier.SupplierName = "Richels's Juices";
            supplier.StreetAddress = "22 Hope Road Kingston";
            supplier.ParishID = 1;

            try
            {
               // ISupplierSvc supplierSvc = (ISupplierSvc)factory.GetService(typeof(ISupplierSvc).Name);
               // supplierSvc.AddSupplier(supplier);//adds product

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());//force fail of test
            }
           
        }

        /// <summary>
        ///A test for RemoveSupplier
        ///</summary>
        [TestMethod()]
        public void RemoveSupplierTest()
        {
            Factory factory = Factory.GetInstance();
            string supplierCode = "RIB-100"; // TODO: Initialize to an appropriate value
            try
            {
            //    ISupplierSvc supplierSvc = (ISupplierSvc)factory.GetService(typeof(ISupplierSvc).Name);
              //  supplierSvc.RemoveSupplier(supplierCode);//adds product

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());//force fail of test
            }
           
        } 

        /// <summary>
        ///A test for SearchSupplier
        ///</summary>
        [TestMethod()]
        public void SearchSupplierTest()
        {
            Factory factory = Factory.GetInstance();
           string supplierCode = "RIB-100"; // TODO: Initialize to an appropriate value
            
            try
            {
              //  ISupplierSvc supplierSvc = (ISupplierSvc)factory.GetService(typeof(ISupplierSvc).Name);
              //  supplierSvc.SearchSupplier(supplierCode);//adds product

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());//force fail of test
            }
        }

        /// <summary>
        ///A test for UpdateSupplier
        ///</summary>
        [TestMethod()]
        public void UpdateSupplierTest()
        {
            Factory factory = Factory.GetInstance();
            Supplier supplier = new Supplier(); // TODO: Initialize to an appropriate value

            supplier.SupplierCode = "RIB-100";
            supplier.SupplierName = "Richels's Juices & Fruits";
            supplier.StreetAddress = "22 Hope Road Kingston";
            supplier.ParishID = 1;

            try
            {
              //  ISupplierSvc supplierSvc = (ISupplierSvc)factory.GetService(typeof(ISupplierSvc).Name);
               // supplierSvc.UpdateSupplier(supplier);//adds product

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());//force fail of test
            }
        }
    }
}

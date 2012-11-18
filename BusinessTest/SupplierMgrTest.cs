using GroceryApp.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using GroceryApp.Models.Domain;
using GroceryApp.Models.Services.Exceptions;

namespace BusinessTest
{
    
    
    /// <summary>
    ///This is a test class for SupplierMgrTest and is intended
    ///to contain all SupplierMgrTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SupplierMgrTest
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
            SupplierMgr target = new SupplierMgr(); // TODO: Initialize to an appropriate value
            Supplier supplier = new Supplier(); // TODO: Initialize to an appropriate value
            supplier.SupplierCode = "ROB-100";
            supplier.SupplierName = "Robert's Poultry";
            supplier.StreetAddress = "2 Hope Road Kingston";
            supplier.ParishID = 1;

            try
            {
                //target.AddSupplier(supplier);
            }
            catch (SupplierMgrException e)
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
            SupplierMgr target = new SupplierMgr(); // TODO: Initialize to an appropriate value
            string supplierCode = "ROB-100"; // TODO: Initialize to an appropriate value
            
            try
            {
           // target.RemoveSupplier(supplierCode);
            }
            catch (SupplierMgrException e)
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
            SupplierMgr target = new SupplierMgr(); // TODO: Initialize to an appropriate value
            string supplierCode = "ROB-100"; // TODO: Initialize to an appropriate value

            try
            {
             //   target.SearchSupplier(supplierCode);
            }
            catch (SupplierMgrException e)
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
            SupplierMgr target = new SupplierMgr(); // TODO: Initialize to an appropriate value
            Supplier supplier = new Supplier(); // TODO: Initialize to an appropriate value
            supplier.SupplierCode = "ROB-100";
            supplier.SupplierName = "Robert's Poultry & Dary Farm";
            supplier.StreetAddress = "2 Hope Road Kingston";
            supplier.ParishID = 1;

            try
            {
               // target.UpdateSupplier(supplier);
            }
            catch (SupplierMgrException e)
            {
                Assert.Fail(e.ToString());//force fail of test
            }
        }
    }
}

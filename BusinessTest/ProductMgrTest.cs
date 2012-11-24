using GroceryApp.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using GroceryApp.Models.Domain;
using GroceryApp.Models.Services.Exceptions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using GroceryApp.Models.Services;

namespace BusinessTest
{
    
    
    /// <summary>
    ///This is a test class for ProductMgrTest and is intended
    ///to contain all ProductMgrTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductMgrTest
    {
        public void dbSetUp()
        {
          //AreaRegistration.RegisterAllAreas();
          //  RegisterGlobalFilters(GlobalFilters.Filters);
          //  RegisterRoutes(RouteTable.Routes);

          //  Database.SetInitializer(new DropCreateDatabaseTables());
        }

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
        ///A test for AddProduct
        ///</summary>
      
        [TestMethod()]      
        public void AddProductTest()
        {
          //  dbSetUp();
            ProductMgr target = new ProductMgr(); // TODO: Initialize to an appropriate value
         
            // Target product-------------
            Product product = new Product();
            product.ProductID = "CB-100";
            product.ProductName = "Corned Beef";
            product.UnitID = 1;
            product.QuantityReceived = 12;
            product.UnitPrice = 30;
            product.CategoryID = 1;
            product.Description = "Canned Beef";
            product.SupplierCode = "MT-100";
           
            //-------------
            try
            {
               target.AddProduct(product);
            }
            catch (ProductMgrException e)
            {             
                Assert.Fail(e.ToString());//force fail of test
            }
        }

        /// <summary>
        ///A test for SearchProduct
        ///</summary>
        [TestMethod()]     
        public void SearchProductTest()
        {
            Product product = new Product();

            ProductMgr target = new ProductMgr(); // TODO: Initialize to an appropriate value
            try
            {

               product = target.SearchProduct("CB-100");      


            }
            catch (ProductMgrException e)
            {                
                Assert.Fail(e.ToString());//force fail of test
            }
        }

        /// <summary>
        ///A test for UpdateProduct
        ///</summary>      
        [TestMethod()]      
        public void UpdateProductTest()
        {
            ProductMgr target = new ProductMgr(); // TODO: Initialize to an appropriate value
         
            // Target product-------------
            Product product = new Product();
            product.ProductID = "CB-100";
            product.ProductName = "CB Chicken";
            product.UnitID = 1;
            product.QuantityReceived = 12;
            product.UnitPrice = 30;
            product.CategoryID = 1;
            product.Description = "Chicken";
            //-------------
            try
            {
             target.UpdateProduct(product);           

            }
            catch (ProductMgrException e)
            {               
                Assert.Fail(e.ToString());//force fail of test
            }
        }

        /// <summary>
        ///A test for SearchProduct
        ///</summary>
        [TestMethod()]
        public void RemoveProductTest()
        {
           // Product product = new Product();

            ProductMgr target = new ProductMgr(); // TODO: Initialize to an appropriate value
            try
            {

               target.RemoveProduct("CB-100");


            }
            catch (ProductMgrException e)
            {
                Assert.Fail(e.ToString());//force fail of test
            }
        }

    }
}

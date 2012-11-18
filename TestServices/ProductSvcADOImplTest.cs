using GroceryApp.Models.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using GroceryApp.Models.Domain;

namespace TestServices
{
    
    
    /// <summary>
    ///This is a test class for ProductSvcADOImplTest and is intended
    ///to contain all ProductSvcADOImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductSvcADOImplTest
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
        ///A test for AddProduct
        ///</summary>
       
        [TestMethod()]        
        public void AddProductTest()
        {
            Factory factory = Factory.GetInstance();

            // Target product-------------
            Product product = new Product();
            product.ProductID = "MLR-100";
            product.ProductName = "Milk";
            product.UnitID = 1;
            product.QuantityReceived = 12;
            product.UnitPrice = 30;
            product.CategoryID = 1;
            product.Description = "Canned Milk";
            product.SupplierCode = "MT-100";
            //-------------

            try
            {
                //IProductSvc productSvc = (IProductSvc)factory.GetService(typeof(IProductSvc).Name);
              // productSvc.AddProduct(product);//adds product
         
            }
            catch (Exception e)
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
            Factory factory = Factory.GetInstance();
            Product product = new Product();

            //Add supplier for product to list
            try
            {
              //  IProductSvc productSvc = (IProductSvc)factory.GetService(typeof(IProductSvc).Name);
             //  product = productSvc.SearchProduct("MLR-100");//adds product
              
            }
            catch (Exception e)
            {
               
                Assert.Fail(e.ToString());//force fail of test
            }
            
        }

        [TestMethod()]
        public void RemoveProductTest()
        {
            Factory factory = Factory.GetInstance();
            Product product = new Product();

            //Add supplier for product to list
            try
            {
              //  IProductSvc productSvc = (IProductSvc)factory.GetService(typeof(IProductSvc).Name);
             // productSvc.RemoveProduct("MLR-100");//adds product

            }
            catch (Exception e)
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
            Factory factory = Factory.GetInstance();

            // Target product-------------
            Product product = new Product();
            product.ProductID = "MLR-100";
            product.ProductName = "Malta";
            product.UnitID = 1;
            product.QuantityReceived = 12;
            product.UnitPrice = 30;
            product.CategoryID = 1;
            product.Description = "Bottled Juice with B Vitamins";


            //-------------

            //Add supplier for product to list
            try
            {
               // IProductSvc productSvc = (IProductSvc)factory.GetService(typeof(IProductSvc).Name);
               // productSvc.UpdateProduct(product);//adds product

            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());//force fail of test
            }
           
        }
    }
}

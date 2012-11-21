using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryApp.Models.Domain;
using GroceryApp.Models.Services;
using GroceryApp.Models.Business;

namespace GroceryApp.Controllers
{ 
    public class ProductController : Controller
    {
        private GroceryDbContext db = new GroceryDbContext();
        private ProductMgr ProdMgr = new ProductMgr();
        //
        // GET: /Product/
         [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).Include(p => p.Unit);
            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5
         [Authorize(Roles = "Admin")]
        public ViewResult Details(string id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /Product/Create
         [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name");
            ViewBag.SupplierCode = new SelectList(db.Suppliers, "SupplierCode", "SupplierName");
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "name");
            return View();
        } 

        //
        // POST: /Product/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
               // db.Products.Add(product);
                //db.SaveChanges();
                ProdMgr.AddProduct(product);
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name", product.CategoryID);
            ViewBag.SupplierCode = new SelectList(db.Suppliers, "SupplierCode", "SupplierName", product.SupplierCode);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "name", product.UnitID);
            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
           // Product product = db.Products.Find(id);
            Product product = ProdMgr.SearchProduct(id);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name", product.CategoryID);
            ViewBag.SupplierCode = new SelectList(db.Suppliers, "SupplierCode", "SupplierName", product.SupplierCode);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "name", product.UnitID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
               // db.SaveChanges();
                ProdMgr.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "name", product.CategoryID);
            ViewBag.SupplierCode = new SelectList(db.Suppliers, "SupplierCode", "SupplierName", product.SupplierCode);
            ViewBag.UnitID = new SelectList(db.Units, "UnitID", "name", product.UnitID);
            return View(product);
        }

        //
        // GET: /Product/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
           // Product product = db.Products.Find(id);
           // db.Products.Remove(product);
           // db.SaveChanges();
            ProdMgr.RemoveProduct(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
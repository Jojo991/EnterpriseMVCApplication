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
    public class SupplierController : Controller
    {
        private GroceryDbContext db = new GroceryDbContext();
        private SupplierMgr SuppMgr = new SupplierMgr();

        //
        // GET: /Supplier/
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            var suppliers = db.Suppliers.Include(s => s.Parish);
            return View(suppliers.ToList());
        }

        //
        // GET: /Supplier/Details/5
        [Authorize(Roles = "Admin")]
        public ViewResult Details(string id)
        {
            Supplier supplier = SuppMgr.SearchSupplier(id);
           // Supplier supplier = db.Suppliers.Find(id);
            return View(supplier);
        }

        //
        // GET: /Supplier/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ParishID = new SelectList(db.Parish, "ParishID", "name");
            return View();
        } 

        //
        // POST: /Supplier/Create
       [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                //db.Suppliers.Add(supplier);
                //db.SaveChanges();
                SuppMgr.AddSupplier(supplier);
                return RedirectToAction("Index");  
            }

            ViewBag.ParishID = new SelectList(db.Parish, "ParishID", "name", supplier.ParishID);
            return View(supplier);
        }
        
        //
        // GET: /Supplier/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
           // Supplier supplier = db.Suppliers.Find(id);
            Supplier supplier = SuppMgr.SearchSupplier(id);
            ViewBag.ParishID = new SelectList(db.Parish, "ParishID", "name", supplier.ParishID);
            return View(supplier);
        }

        //
        // POST: /Supplier/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(supplier).State = EntityState.Modified;
               // db.SaveChanges();
                SuppMgr.UpdateSupplier(supplier);
                return RedirectToAction("Index");
            }
            ViewBag.ParishID = new SelectList(db.Parish, "ParishID", "name", supplier.ParishID);
            return View(supplier);
        }

        //
        // GET: /Supplier/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            return View(supplier);
        }

        //
        // POST: /Supplier/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            //Supplier supplier = db.Suppliers.Find(id);
            //db.Suppliers.Remove(supplier);
          //  db.SaveChanges();
            SuppMgr.RemoveSupplier(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
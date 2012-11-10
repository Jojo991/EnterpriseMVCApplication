using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryApp.Models.Domain;
using GroceryApp.Models.Services;

namespace GroceryApp.Controllers
{ 
    public class ParishController : Controller
    {
        private GroceryDbContext db = new GroceryDbContext();

        //
        // GET: /Parish/

        public ViewResult Index()
        {
            return View(db.Parish.ToList());
        }

        //
        // GET: /Parish/Details/5

        public ViewResult Details(int id)
        {
            Parish parish = db.Parish.Find(id);
            return View(parish);
        }

        //
        // GET: /Parish/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Parish/Create

        [HttpPost]
        public ActionResult Create(Parish parish)
        {
            if (ModelState.IsValid)
            {
                db.Parish.Add(parish);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(parish);
        }
        
        //
        // GET: /Parish/Edit/5
 
        public ActionResult Edit(int id)
        {
            Parish parish = db.Parish.Find(id);
            return View(parish);
        }

        //
        // POST: /Parish/Edit/5

        [HttpPost]
        public ActionResult Edit(Parish parish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parish);
        }

        //
        // GET: /Parish/Delete/5
 
        public ActionResult Delete(int id)
        {
            Parish parish = db.Parish.Find(id);
            return View(parish);
        }

        //
        // POST: /Parish/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Parish parish = db.Parish.Find(id);
            db.Parish.Remove(parish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace MockProject.Net4.Areas.admin.Controllers
{
    public class Product_detailsController : Controller
    {
        private Model11 db = new Model11();

        // GET: admin/Product_details
        public ActionResult Index()
        {
            var product_details = db.Product_details.Include(p => p.PRODUCT).Include(p => p.SIZE);
            return View(product_details.ToList());
        }

        // GET: admin/Product_details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_details product_details = db.Product_details.Find(id);
            if (product_details == null)
            {
                return HttpNotFound();
            }
            return View(product_details);
        }

        // GET: admin/Product_details/Create
        [HttpGet]
        public ActionResult Create(string ProductID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            ViewBag.ProductID = (from p in db.PRODUCTS where p.ProductID == ProductID select p.ProductID).FirstOrDefault();
            ViewBag.SizeID = new SelectList(db.SIZEs, "SizeID", "SizeType");
     //       PRODUCT pRODUCT = (from PRODUCT in db.PRODUCTS where PRODUCT.ProductID== ProductID select PRODUCT).SingleOrDefault();
            return View();
        }

        // POST: admin/Product_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Color,SizeID,DateAdd,Price,Quanlity")] Product_details product_details)
        {
            if (ModelState.IsValid)
            {
                db.Product_details.Add(product_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.PRODUCTS, "ProductID", "ProductName", product_details.ProductID);
            ViewBag.SizeID = new SelectList(db.SIZEs, "SizeID", "SizeType", product_details.SizeID);
            return View(product_details);
        }

        // GET: admin/Product_details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_details product_details = db.Product_details.Find(id);
            if (product_details == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.PRODUCTS, "ProductID", "ProductName", product_details.ProductID);
            ViewBag.SizeID = new SelectList(db.SIZEs, "SizeID", "SizeType", product_details.SizeID);
            return View(product_details);
        }

        // POST: admin/Product_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Color,SizeID,DateAdd,Price,Quanlity")] Product_details product_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.PRODUCTS, "ProductID", "ProductName", product_details.ProductID);
            ViewBag.SizeID = new SelectList(db.SIZEs, "SizeID", "SizeType", product_details.SizeID);
            return View(product_details);
        }

        // GET: admin/Product_details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_details product_details = (from p in db.Product_details where p.ProductID==id select p).FirstOrDefault();
            if (product_details == null)
            {
                return HttpNotFound();
            }
            return View(product_details);
        }

        // POST: admin/Product_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_details product_details = (from p in db.Product_details where p.ProductID == id select p).FirstOrDefault();
            db.Product_details.Remove(product_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

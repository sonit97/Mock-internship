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
    public class PRODUCTsController : Controller
    {
        private Model11 db = new Model11();

        // GET: admin/PRODUCTs
        public ActionResult Index()
        {
            var pRODUCTS = db.PRODUCTS.Include(p => p.BRAND).Include(p => p.PRODUCTSTYPE);
            return View(pRODUCTS.ToList());
        }

        // GET: admin/PRODUCTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: admin/PRODUCTs/Create
        public ActionResult Create()
        {
            ViewBag.BrandsID = new SelectList(db.BRANDS, "BrandsID", "BrandName");
            ViewBag.ProductTypeID = new SelectList(db.PRODUCTSTYPEs, "ProductTypeID", "ProductTypeName");
            return View();
        }

        // POST: admin/PRODUCTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Descripstion,Images,ProductTypeID,BrandsID,ProviderID")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTS.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandsID = new SelectList(db.BRANDS, "BrandsID", "BrandName", pRODUCT.BrandsID);
            ViewBag.ProductTypeID = new SelectList(db.PRODUCTSTYPEs, "ProductTypeID", "ProductTypeName", pRODUCT.ProductTypeID);
            return View(pRODUCT);
        }

        // GET: admin/PRODUCTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandsID = new SelectList(db.BRANDS, "BrandsID", "BrandName", pRODUCT.BrandsID);
            ViewBag.ProductTypeID = new SelectList(db.PRODUCTSTYPEs, "ProductTypeID", "ProductTypeName", pRODUCT.ProductTypeID);
            return View(pRODUCT);
        }

        // POST: admin/PRODUCTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Descripstion,Images,ProductTypeID,BrandsID,ProviderID")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandsID = new SelectList(db.BRANDS, "BrandsID", "BrandName", pRODUCT.BrandsID);
            ViewBag.ProductTypeID = new SelectList(db.PRODUCTSTYPEs, "ProductTypeID", "ProductTypeName", pRODUCT.ProductTypeID);
            return View(pRODUCT);
        }

        // GET: admin/PRODUCTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: admin/PRODUCTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT pRODUCT = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(pRODUCT);
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

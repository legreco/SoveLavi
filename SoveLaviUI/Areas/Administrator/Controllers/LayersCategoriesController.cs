using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace SoveLaviUI.Areas.Administrator.Controllers
{
    public class LayersCategoriesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Administrator/LayersCategories
        public ActionResult Index()
        {
            return View(db.tbl_LAYER_CATEGORY.ToList());
        }

        // GET: Administrator/LayersCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER_CATEGORY tbl_LAYER_CATEGORY = db.tbl_LAYER_CATEGORY.Find(id);
            if (tbl_LAYER_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER_CATEGORY);
        }

        // GET: Administrator/LayersCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/LayersCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] tbl_LAYER_CATEGORY tbl_LAYER_CATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LAYER_CATEGORY.Add(tbl_LAYER_CATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LAYER_CATEGORY);
        }

        // GET: Administrator/LayersCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER_CATEGORY tbl_LAYER_CATEGORY = db.tbl_LAYER_CATEGORY.Find(id);
            if (tbl_LAYER_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER_CATEGORY);
        }

        // POST: Administrator/LayersCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] tbl_LAYER_CATEGORY tbl_LAYER_CATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LAYER_CATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LAYER_CATEGORY);
        }

        // GET: Administrator/LayersCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER_CATEGORY tbl_LAYER_CATEGORY = db.tbl_LAYER_CATEGORY.Find(id);
            if (tbl_LAYER_CATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER_CATEGORY);
        }

        // POST: Administrator/LayersCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LAYER_CATEGORY tbl_LAYER_CATEGORY = db.tbl_LAYER_CATEGORY.Find(id);
            db.tbl_LAYER_CATEGORY.Remove(tbl_LAYER_CATEGORY);
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

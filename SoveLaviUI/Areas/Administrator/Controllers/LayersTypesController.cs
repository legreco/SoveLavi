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
    public class LayersTypesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Administrator/LayersTypes
        public ActionResult Index()
        {
            return View(db.tbl_LAYER_TYPE.ToList());
        }

        // GET: Administrator/LayersTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER_TYPE tbl_LAYER_TYPE = db.tbl_LAYER_TYPE.Find(id);
            if (tbl_LAYER_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER_TYPE);
        }

        // GET: Administrator/LayersTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/LayersTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] tbl_LAYER_TYPE tbl_LAYER_TYPE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LAYER_TYPE.Add(tbl_LAYER_TYPE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LAYER_TYPE);
        }

        // GET: Administrator/LayersTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER_TYPE tbl_LAYER_TYPE = db.tbl_LAYER_TYPE.Find(id);
            if (tbl_LAYER_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER_TYPE);
        }

        // POST: Administrator/LayersTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] tbl_LAYER_TYPE tbl_LAYER_TYPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LAYER_TYPE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LAYER_TYPE);
        }

        // GET: Administrator/LayersTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER_TYPE tbl_LAYER_TYPE = db.tbl_LAYER_TYPE.Find(id);
            if (tbl_LAYER_TYPE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER_TYPE);
        }

        // POST: Administrator/LayersTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LAYER_TYPE tbl_LAYER_TYPE = db.tbl_LAYER_TYPE.Find(id);
            db.tbl_LAYER_TYPE.Remove(tbl_LAYER_TYPE);
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

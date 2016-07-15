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
    public class PoisController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Administrator/Pois
        public ActionResult Index()
        {
            var tbl_POI = db.tbl_POI.Include(t => t.tbl_POI_TYPE);
            return View(tbl_POI.ToList());
        }

        // GET: Administrator/Pois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_POI tbl_POI = db.tbl_POI.Find(id);
            if (tbl_POI == null)
            {
                return HttpNotFound();
            }
            return View(tbl_POI);
        }

        // GET: Administrator/Pois/Create
        public ActionResult Create()
        {
            ViewBag.poiType = new SelectList(db.tbl_POI_TYPE, "id", "nom");
            return View();
        }

        // POST: Administrator/Pois/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,poiType,addresse,communeId,isVulnerable,lattitude,longitude")] tbl_POI tbl_POI)
        {
            if (ModelState.IsValid)
            {
                db.tbl_POI.Add(tbl_POI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.poiType = new SelectList(db.tbl_POI_TYPE, "id", "nom", tbl_POI.poiType);
            return View(tbl_POI);
        }

        // GET: Administrator/Pois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_POI tbl_POI = db.tbl_POI.Find(id);
            if (tbl_POI == null)
            {
                return HttpNotFound();
            }
            ViewBag.poiType = new SelectList(db.tbl_POI_TYPE, "id", "nom", tbl_POI.poiType);
            return View(tbl_POI);
        }

        // POST: Administrator/Pois/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,poiType,addresse,communeId,isVulnerable,lattitude,longitude")] tbl_POI tbl_POI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_POI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.poiType = new SelectList(db.tbl_POI_TYPE, "id", "nom", tbl_POI.poiType);
            return View(tbl_POI);
        }

        // GET: Administrator/Pois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_POI tbl_POI = db.tbl_POI.Find(id);
            if (tbl_POI == null)
            {
                return HttpNotFound();
            }
            return View(tbl_POI);
        }

        // POST: Administrator/Pois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_POI tbl_POI = db.tbl_POI.Find(id);
            db.tbl_POI.Remove(tbl_POI);
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

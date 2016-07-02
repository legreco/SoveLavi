using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace SoveLaviUI.Areas.DataEntry.Controllers
{
    public class FiabiliteSourceController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: DataEntry/FiabiliteSource
        public ActionResult Index()
        {
            return View(db.tbl_FIABILITE_SOURCE.ToList());
        }

        // GET: DataEntry/FiabiliteSource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FIABILITE_SOURCE tbl_FIABILITE_SOURCE = db.tbl_FIABILITE_SOURCE.Find(id);
            if (tbl_FIABILITE_SOURCE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FIABILITE_SOURCE);
        }

        // GET: DataEntry/FiabiliteSource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataEntry/FiabiliteSource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,description,levelNumber")] tbl_FIABILITE_SOURCE tbl_FIABILITE_SOURCE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_FIABILITE_SOURCE.Add(tbl_FIABILITE_SOURCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_FIABILITE_SOURCE);
        }

        // GET: DataEntry/FiabiliteSource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FIABILITE_SOURCE tbl_FIABILITE_SOURCE = db.tbl_FIABILITE_SOURCE.Find(id);
            if (tbl_FIABILITE_SOURCE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FIABILITE_SOURCE);
        }

        // POST: DataEntry/FiabiliteSource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,description,levelNumber")] tbl_FIABILITE_SOURCE tbl_FIABILITE_SOURCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_FIABILITE_SOURCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_FIABILITE_SOURCE);
        }

        // GET: DataEntry/FiabiliteSource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FIABILITE_SOURCE tbl_FIABILITE_SOURCE = db.tbl_FIABILITE_SOURCE.Find(id);
            if (tbl_FIABILITE_SOURCE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FIABILITE_SOURCE);
        }

        // POST: DataEntry/FiabiliteSource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_FIABILITE_SOURCE tbl_FIABILITE_SOURCE = db.tbl_FIABILITE_SOURCE.Find(id);
            db.tbl_FIABILITE_SOURCE.Remove(tbl_FIABILITE_SOURCE);
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

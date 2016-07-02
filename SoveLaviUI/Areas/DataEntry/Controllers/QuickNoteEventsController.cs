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
    public class QuickNoteEventsController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: DataEntry/QuickNoteEvents
        public ActionResult Index()
        {
            var tbl_DONNEE = db.tbl_DONNEE.Include(t => t.tbl_FIABILITE_SOURCE);
            return View(tbl_DONNEE.ToList());
        }

        // GET: DataEntry/QuickNoteEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DONNEE tbl_DONNEE = db.tbl_DONNEE.Find(id);
            if (tbl_DONNEE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DONNEE);
        }

        // GET: DataEntry/QuickNoteEvents/Create
        public ActionResult Create()
        {
            ViewBag.fiabiliteSource = new SelectList(db.tbl_FIABILITE_SOURCE, "id", "nom");
            return View();
        }

        // POST: DataEntry/QuickNoteEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,info,createdDate,createdBy,fiabiliteSource")] tbl_DONNEE tbl_DONNEE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_DONNEE.Add(tbl_DONNEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fiabiliteSource = new SelectList(db.tbl_FIABILITE_SOURCE, "id", "nom", tbl_DONNEE.fiabiliteSource);
            return View(tbl_DONNEE);
        }

        // GET: DataEntry/QuickNoteEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DONNEE tbl_DONNEE = db.tbl_DONNEE.Find(id);
            if (tbl_DONNEE == null)
            {
                return HttpNotFound();
            }
            ViewBag.fiabiliteSource = new SelectList(db.tbl_FIABILITE_SOURCE, "id", "nom", tbl_DONNEE.fiabiliteSource);
            return View(tbl_DONNEE);
        }

        // POST: DataEntry/QuickNoteEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,info,createdDate,createdBy,fiabiliteSource")] tbl_DONNEE tbl_DONNEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_DONNEE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fiabiliteSource = new SelectList(db.tbl_FIABILITE_SOURCE, "id", "nom", tbl_DONNEE.fiabiliteSource);
            return View(tbl_DONNEE);
        }

        // GET: DataEntry/QuickNoteEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DONNEE tbl_DONNEE = db.tbl_DONNEE.Find(id);
            if (tbl_DONNEE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DONNEE);
        }

        // POST: DataEntry/QuickNoteEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_DONNEE tbl_DONNEE = db.tbl_DONNEE.Find(id);
            db.tbl_DONNEE.Remove(tbl_DONNEE);
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

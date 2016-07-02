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
    public class MenacesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: DataEntry/Menaces
        public ActionResult Index()
        {
            var tbl_MENACE = db.tbl_MENACE.Include(t => t.tbl_TYPE_MENACE);
            return View(tbl_MENACE.ToList());
        }

        // GET: DataEntry/Menaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MENACE tbl_MENACE = db.tbl_MENACE.Find(id);
            if (tbl_MENACE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MENACE);
        }

        // GET: DataEntry/Menaces/Create
        public ActionResult Create()
        {
            ViewBag.typeMenaceId = new SelectList(db.tbl_TYPE_MENACE, "id", "nom");
            return View();
        }

        // POST: DataEntry/Menaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,typeMenaceId")] tbl_MENACE tbl_MENACE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_MENACE.Add(tbl_MENACE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.typeMenaceId = new SelectList(db.tbl_TYPE_MENACE, "id", "nom", tbl_MENACE.typeMenaceId);
            return View(tbl_MENACE);
        }

        // GET: DataEntry/Menaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MENACE tbl_MENACE = db.tbl_MENACE.Find(id);
            if (tbl_MENACE == null)
            {
                return HttpNotFound();
            }
            ViewBag.typeMenaceId = new SelectList(db.tbl_TYPE_MENACE, "id", "nom", tbl_MENACE.typeMenaceId);
            return View(tbl_MENACE);
        }

        // POST: DataEntry/Menaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,typeMenaceId")] tbl_MENACE tbl_MENACE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_MENACE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.typeMenaceId = new SelectList(db.tbl_TYPE_MENACE, "id", "nom", tbl_MENACE.typeMenaceId);
            return View(tbl_MENACE);
        }

        // GET: DataEntry/Menaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MENACE tbl_MENACE = db.tbl_MENACE.Find(id);
            if (tbl_MENACE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MENACE);
        }

        // POST: DataEntry/Menaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_MENACE tbl_MENACE = db.tbl_MENACE.Find(id);
            db.tbl_MENACE.Remove(tbl_MENACE);
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

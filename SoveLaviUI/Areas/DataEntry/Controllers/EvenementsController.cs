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
    public class EvenementsController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: DataEntry/Evenements
        public ActionResult Index()
        {
            var tbl_EVENEMENT = db.tbl_EVENEMENT.Include(t => t.tbl_MENACE).Include(t => t.tbl_PRIORITE_EVENEMENT).Include(t => t.tbl_TYPE_EVENEMENT);
            return View(tbl_EVENEMENT.ToList());
        }

        // GET: DataEntry/Evenements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EVENEMENT tbl_EVENEMENT = db.tbl_EVENEMENT.Find(id);
            if (tbl_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_EVENEMENT);
        }

        // GET: DataEntry/Evenements/Create
        public ActionResult Create()
        {
            ViewBag.menace = new SelectList(db.tbl_MENACE, "id", "nom");
            ViewBag.priorite = new SelectList(db.tbl_PRIORITE_EVENEMENT, "id", "nom");
            ViewBag.type = new SelectList(db.tbl_TYPE_EVENEMENT, "id", "nom");
            return View();
        }

        // POST: DataEntry/Evenements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,statutId,priorite,nom,startDate,endDate,lattitude,longittude,menace,type")] tbl_EVENEMENT tbl_EVENEMENT)
        {
            if (ModelState.IsValid)
            {
                db.tbl_EVENEMENT.Add(tbl_EVENEMENT);
                db.SaveChanges();
                new MapEventHub().Send("Incident", (float)tbl_EVENEMENT.lattitude, (float)tbl_EVENEMENT.longittude);
                return RedirectToAction("Index");
            }
            new MapEventHub().Send("Incident", (float) tbl_EVENEMENT.lattitude,(float) tbl_EVENEMENT.longittude);
            ViewBag.menace = new SelectList(db.tbl_MENACE, "id", "nom", tbl_EVENEMENT.menace);
            ViewBag.priorite = new SelectList(db.tbl_PRIORITE_EVENEMENT, "id", "nom", tbl_EVENEMENT.priorite);
            ViewBag.type = new SelectList(db.tbl_TYPE_EVENEMENT, "id", "nom", tbl_EVENEMENT.type);
            return View(tbl_EVENEMENT);
        }

        // GET: DataEntry/Evenements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EVENEMENT tbl_EVENEMENT = db.tbl_EVENEMENT.Find(id);
            if (tbl_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.menace = new SelectList(db.tbl_MENACE, "id", "nom", tbl_EVENEMENT.menace);
            ViewBag.priorite = new SelectList(db.tbl_PRIORITE_EVENEMENT, "id", "nom", tbl_EVENEMENT.priorite);
            ViewBag.type = new SelectList(db.tbl_TYPE_EVENEMENT, "id", "nom", tbl_EVENEMENT.type);
            return View(tbl_EVENEMENT);
        }

        // POST: DataEntry/Evenements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,statutId,priorite,nom,startDate,endDate,lattitude,longittude,menace,type")] tbl_EVENEMENT tbl_EVENEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_EVENEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.menace = new SelectList(db.tbl_MENACE, "id", "nom", tbl_EVENEMENT.menace);
            ViewBag.priorite = new SelectList(db.tbl_PRIORITE_EVENEMENT, "id", "nom", tbl_EVENEMENT.priorite);
            ViewBag.type = new SelectList(db.tbl_TYPE_EVENEMENT, "id", "nom", tbl_EVENEMENT.type);
            return View(tbl_EVENEMENT);
        }

        // GET: DataEntry/Evenements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EVENEMENT tbl_EVENEMENT = db.tbl_EVENEMENT.Find(id);
            if (tbl_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_EVENEMENT);
        }

        // POST: DataEntry/Evenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_EVENEMENT tbl_EVENEMENT = db.tbl_EVENEMENT.Find(id);
            db.tbl_EVENEMENT.Remove(tbl_EVENEMENT);
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

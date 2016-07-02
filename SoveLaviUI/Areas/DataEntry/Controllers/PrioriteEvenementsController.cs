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
    public class PrioriteEvenementsController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: DataEntry/PrioriteEvenements
        public ActionResult Index()
        {
            return View(db.tbl_PRIORITE_EVENEMENT.ToList());
        }

        // GET: DataEntry/PrioriteEvenements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_PRIORITE_EVENEMENT tbl_PRIORITE_EVENEMENT = db.tbl_PRIORITE_EVENEMENT.Find(id);
            if (tbl_PRIORITE_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_PRIORITE_EVENEMENT);
        }

        // GET: DataEntry/PrioriteEvenements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataEntry/PrioriteEvenements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,priorityNumber")] tbl_PRIORITE_EVENEMENT tbl_PRIORITE_EVENEMENT)
        {
            if (ModelState.IsValid)
            {
                db.tbl_PRIORITE_EVENEMENT.Add(tbl_PRIORITE_EVENEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_PRIORITE_EVENEMENT);
        }

        // GET: DataEntry/PrioriteEvenements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_PRIORITE_EVENEMENT tbl_PRIORITE_EVENEMENT = db.tbl_PRIORITE_EVENEMENT.Find(id);
            if (tbl_PRIORITE_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_PRIORITE_EVENEMENT);
        }

        // POST: DataEntry/PrioriteEvenements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,priorityNumber")] tbl_PRIORITE_EVENEMENT tbl_PRIORITE_EVENEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_PRIORITE_EVENEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_PRIORITE_EVENEMENT);
        }

        // GET: DataEntry/PrioriteEvenements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_PRIORITE_EVENEMENT tbl_PRIORITE_EVENEMENT = db.tbl_PRIORITE_EVENEMENT.Find(id);
            if (tbl_PRIORITE_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_PRIORITE_EVENEMENT);
        }

        // POST: DataEntry/PrioriteEvenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_PRIORITE_EVENEMENT tbl_PRIORITE_EVENEMENT = db.tbl_PRIORITE_EVENEMENT.Find(id);
            db.tbl_PRIORITE_EVENEMENT.Remove(tbl_PRIORITE_EVENEMENT);
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

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
    public class TypeEvenementsController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: DataEntry/TypeEvenements
        public ActionResult Index()
        {
            return View(db.tbl_TYPE_EVENEMENT.ToList());
        }

        // GET: DataEntry/TypeEvenements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TYPE_EVENEMENT tbl_TYPE_EVENEMENT = db.tbl_TYPE_EVENEMENT.Find(id);
            if (tbl_TYPE_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TYPE_EVENEMENT);
        }

        // GET: DataEntry/TypeEvenements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataEntry/TypeEvenements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,description")] tbl_TYPE_EVENEMENT tbl_TYPE_EVENEMENT)
        {
            if (ModelState.IsValid)
            {
                db.tbl_TYPE_EVENEMENT.Add(tbl_TYPE_EVENEMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_TYPE_EVENEMENT);
        }

        // GET: DataEntry/TypeEvenements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TYPE_EVENEMENT tbl_TYPE_EVENEMENT = db.tbl_TYPE_EVENEMENT.Find(id);
            if (tbl_TYPE_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TYPE_EVENEMENT);
        }

        // POST: DataEntry/TypeEvenements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,description")] tbl_TYPE_EVENEMENT tbl_TYPE_EVENEMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_TYPE_EVENEMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_TYPE_EVENEMENT);
        }

        // GET: DataEntry/TypeEvenements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TYPE_EVENEMENT tbl_TYPE_EVENEMENT = db.tbl_TYPE_EVENEMENT.Find(id);
            if (tbl_TYPE_EVENEMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TYPE_EVENEMENT);
        }

        // POST: DataEntry/TypeEvenements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_TYPE_EVENEMENT tbl_TYPE_EVENEMENT = db.tbl_TYPE_EVENEMENT.Find(id);
            db.tbl_TYPE_EVENEMENT.Remove(tbl_TYPE_EVENEMENT);
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

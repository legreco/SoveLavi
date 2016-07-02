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
    public class TypeMenacesController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: DataEntry/TypeMenaces
        public ActionResult Index()
        {
            return View(db.tbl_TYPE_MENACE.ToList());
        }

        // GET: DataEntry/TypeMenaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TYPE_MENACE tbl_TYPE_MENACE = db.tbl_TYPE_MENACE.Find(id);
            if (tbl_TYPE_MENACE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TYPE_MENACE);
        }

        // GET: DataEntry/TypeMenaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataEntry/TypeMenaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom")] tbl_TYPE_MENACE tbl_TYPE_MENACE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_TYPE_MENACE.Add(tbl_TYPE_MENACE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_TYPE_MENACE);
        }

        // GET: DataEntry/TypeMenaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TYPE_MENACE tbl_TYPE_MENACE = db.tbl_TYPE_MENACE.Find(id);
            if (tbl_TYPE_MENACE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TYPE_MENACE);
        }

        // POST: DataEntry/TypeMenaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom")] tbl_TYPE_MENACE tbl_TYPE_MENACE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_TYPE_MENACE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_TYPE_MENACE);
        }

        // GET: DataEntry/TypeMenaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TYPE_MENACE tbl_TYPE_MENACE = db.tbl_TYPE_MENACE.Find(id);
            if (tbl_TYPE_MENACE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TYPE_MENACE);
        }

        // POST: DataEntry/TypeMenaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_TYPE_MENACE tbl_TYPE_MENACE = db.tbl_TYPE_MENACE.Find(id);
            db.tbl_TYPE_MENACE.Remove(tbl_TYPE_MENACE);
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

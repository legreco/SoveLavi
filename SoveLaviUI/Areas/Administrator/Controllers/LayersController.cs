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
    public class LayersController : Controller
    {
        private SOVELAVIDBEntities db = new SOVELAVIDBEntities();

        // GET: Administrator/Layers
        public ActionResult Index()
        {
            var tbl_LAYER = db.tbl_LAYER.Include(t => t.tbl_LAYER_CATEGORY).Include(t => t.tbl_LAYER_TYPE);
            return View(tbl_LAYER.ToList());
        }

    

      

        // GET: Administrator/Layers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          
            tbl_LAYER tbl_LAYER = db.tbl_LAYER.Find(id);
            ViewBag.GeoJsonUrl = String.Format("http://Layers:8081/{0}",tbl_LAYER.fileName);
         ;

            if (tbl_LAYER == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER);
        }

        // GET: Administrator/Layers/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.tbl_LAYER_CATEGORY, "id", "name");
            ViewBag.layerTypeId = new SelectList(db.tbl_LAYER_TYPE, "id", "name");
            return View();
        }

        // POST: Administrator/Layers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, tbl_LAYER tbl_LAYER)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string layerName = System.IO.Path.GetFileName(file.FileName);
                    string LayerPath = System.IO.Path.Combine(Server.MapPath("~/Layers"), layerName);
                    file.SaveAs(LayerPath);
                    string newLayerName = String.Format("{0}-{1}", Guid.NewGuid(), layerName);

                    string newLayerPath = System.IO.Path.Combine(Server.MapPath("~/Layers"), newLayerName);
                    try
                    {
                        System.IO.File.Move(LayerPath, newLayerPath);
                       
                    }
                    catch (Exception e1)
                    {

                    }
                    tbl_LAYER.fileName = newLayerName;
                    tbl_LAYER.dateAdded = DateTime.Now;
                    db.tbl_LAYER.Add(tbl_LAYER);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.categoryId = new SelectList(db.tbl_LAYER_CATEGORY, "id", "name", tbl_LAYER.categoryId);
            ViewBag.layerTypeId = new SelectList(db.tbl_LAYER_TYPE, "id", "name", tbl_LAYER.layerTypeId);
            return View(tbl_LAYER);
        }

        // GET: Administrator/Layers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER tbl_LAYER = db.tbl_LAYER.Find(id);
            if (tbl_LAYER == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.tbl_LAYER_CATEGORY, "id", "name", tbl_LAYER.categoryId);
            ViewBag.layerTypeId = new SelectList(db.tbl_LAYER_TYPE, "id", "name", tbl_LAYER.layerTypeId);
            return View(tbl_LAYER);
        }

        // POST: Administrator/Layers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fileName,title,description,dateAdded,categoryId,layerTypeId,validFrom,validTo,imageName")] tbl_LAYER tbl_LAYER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LAYER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(db.tbl_LAYER_CATEGORY, "id", "name", tbl_LAYER.categoryId);
            ViewBag.layerTypeId = new SelectList(db.tbl_LAYER_TYPE, "id", "name", tbl_LAYER.layerTypeId);
            return View(tbl_LAYER);
        }

        // GET: Administrator/Layers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LAYER tbl_LAYER = db.tbl_LAYER.Find(id);
            if (tbl_LAYER == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LAYER);
        }

        // POST: Administrator/Layers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LAYER tbl_LAYER = db.tbl_LAYER.Find(id);
            db.tbl_LAYER.Remove(tbl_LAYER);
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

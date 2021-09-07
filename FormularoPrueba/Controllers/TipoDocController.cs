using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FormularoPrueba.ModeloDB;

namespace FormularoPrueba.Controllers
{
    public class TipoDocController : Controller
    {
        private FormularioDBEntities db = new FormularioDBEntities();

        // GET: TipoDoc
        public ActionResult Index()
        {
            return View(db.tb_TipoDoc.ToList());
        }

        // GET: TipoDoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoDoc tb_TipoDoc = db.tb_TipoDoc.Find(id);
            if (tb_TipoDoc == null)
            {
                return HttpNotFound();
            }
            return View(tb_TipoDoc);
        }

        // GET: TipoDoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDoc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_TipoDoc tb_TipoDoc)
        {
            if (ModelState.IsValid)
            {
                db.tb_TipoDoc.Add(tb_TipoDoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_TipoDoc);
        }

        // GET: TipoDoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoDoc tb_TipoDoc = db.tb_TipoDoc.Find(id);
            if (tb_TipoDoc == null)
            {
                return HttpNotFound();
            }
            return View(tb_TipoDoc);
        }

        // POST: TipoDoc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_TipoDoc tb_TipoDoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_TipoDoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_TipoDoc);
        }

        // GET: TipoDoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoDoc tb_TipoDoc = db.tb_TipoDoc.Find(id);
            if (tb_TipoDoc == null)
            {
                return HttpNotFound();
            }
            return View(tb_TipoDoc);
        }

        // POST: TipoDoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_TipoDoc tb_TipoDoc = db.tb_TipoDoc.Find(id);
            db.tb_TipoDoc.Remove(tb_TipoDoc);
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

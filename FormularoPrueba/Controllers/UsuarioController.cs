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
    public class UsuarioController : Controller
    {
        private FormularioDBEntities db = new FormularioDBEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            var tb_usuario = db.tb_usuario.Include(t => t.tb_ciudad).Include(t => t.tb_TipoDoc);
            return View(tb_usuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.id_ciudad = new SelectList(db.tb_ciudad, "id", "nombre");
            ViewBag.id_TipoDoc = new SelectList(db.tb_TipoDoc, "id", "nombre");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,correo,celular,id_ciudad,id_TipoDoc,documento,fecha_nacimiento")] tb_usuario tb_usuario)
        {
            if (ModelState.IsValid)
            {
                db.tb_usuario.Add(tb_usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_ciudad = new SelectList(db.tb_ciudad, "id", "nombre", tb_usuario.id_ciudad);
            ViewBag.id_TipoDoc = new SelectList(db.tb_TipoDoc, "id", "nombre", tb_usuario.id_TipoDoc);
            return View(tb_usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ciudad = new SelectList(db.tb_ciudad, "id", "nombre", tb_usuario.id_ciudad);
            ViewBag.id_TipoDoc = new SelectList(db.tb_TipoDoc, "id", "nombre", tb_usuario.id_TipoDoc);
            return View(tb_usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,primer_nombre,otros_nombres,primer_apellido,segundo_apellido,correo,celular,id_ciudad,id_TipoDoc,documento,fecha_nacimiento")] tb_usuario tb_usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_ciudad = new SelectList(db.tb_ciudad, "id", "nombre", tb_usuario.id_ciudad);
            ViewBag.id_TipoDoc = new SelectList(db.tb_TipoDoc, "id", "nombre", tb_usuario.id_TipoDoc);
            return View(tb_usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            if (tb_usuario == null)
            {
                return HttpNotFound();
            }
            return View(tb_usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_usuario tb_usuario = db.tb_usuario.Find(id);
            db.tb_usuario.Remove(tb_usuario);
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

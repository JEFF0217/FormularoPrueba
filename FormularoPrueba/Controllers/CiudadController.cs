using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccesoDeDatos.Implementacion;
using AccesoDeDatos.ModeloDatos;
using PagedList;


namespace FormularoPrueba.Controllers
{
    public class CiudadController : Controller
    {
        private ImpCiudadDatos acceso = new ImpCiudadDatos();

        // GET: Ciudad
        public ActionResult Index(string filtro= "")
        {
            int pageIndex = 5;
            int pageSize = 1;
            return View(acceso.ListarRegistros(filtro).ToList());
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = acceso.BuscarRegistro(id.Value);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_ciudad tb_ciudad)
        {
            if (ModelState.IsValid)
            {
                acceso.GuardarRegistro(tb_ciudad);
                
                return RedirectToAction("Index");
            }

            return View(tb_ciudad);
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = acceso.BuscarRegistro(id.Value);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudad);
        }

        // POST: Ciudad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_ciudad tb_ciudad)
        {
            if (ModelState.IsValid)
            {
                acceso.EditarRegistro(tb_ciudad);
                return RedirectToAction("Index");
            }
            return View(tb_ciudad);
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ciudad tb_ciudad = acceso.BuscarRegistro(id.Value);
            if (tb_ciudad == null)
            {
                return HttpNotFound();
            }
            return View(tb_ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            acceso.ELiminarRegistro(id);
            return RedirectToAction("Index");
        }


    }
}

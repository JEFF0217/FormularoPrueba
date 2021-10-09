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
using FormularoPrueba.Helpers;
using FormularoPrueba.Mapeadores.parametros;
using FormularoPrueba.Models;
using PagedList;


namespace FormularoPrueba.Controllers
{
    public class CiudadController : Controller
    {
        private ImpCiudadDatos acceso = new ImpCiudadDatos();

        // GET: Ciudad
        public ActionResult Index(string filtro= "")
        {
            IEnumerable<tb_ciudad> listaDatos = acceso.ListarRegistros(String.Empty);
            MapeadorCiudadGui mapper = new MapeadorCiudadGui();
            IEnumerable<ModeloCiudadGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            return View(listaGUI);
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


            MapeadorCiudadGui mapper = new MapeadorCiudadGui();
            ModeloCiudadGUI modelo = mapper.MapearTipo1Tipo2(tb_ciudad);
            return View(modelo);
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
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloCiudadGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCiudadGui mapper = new MapeadorCiudadGui();
                tb_ciudad tb_Ciudad = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(tb_Ciudad);
                return RedirectToAction("index");
            }

            
            

            return View(modelo);
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


            MapeadorCiudadGui mapper = new MapeadorCiudadGui();
            ModeloCiudadGUI modelo = mapper.MapearTipo1Tipo2(tb_ciudad);
            return View(modelo);
        }

        // POST: Ciudad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloCiudadGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCiudadGui mapper = new MapeadorCiudadGui();
                tb_ciudad tb_Ciudad = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(tb_Ciudad);
                return RedirectToAction("index");

            }


           
            return View(modelo);
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

            MapeadorCiudadGui mapper = new MapeadorCiudadGui();
            ModeloCiudadGUI modelo = mapper.MapearTipo1Tipo2(tb_ciudad);
            return View(modelo);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            bool respuesta = acceso.ELiminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                tb_ciudad tb_ciudad = acceso.BuscarRegistro(id);
                if (tb_ciudad == null)
                {
                    return HttpNotFound();
                }

                MapeadorCiudadGui mapper = new MapeadorCiudadGui();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;

                ModeloCiudadGUI modelo = mapper.MapearTipo1Tipo2(tb_ciudad);
                return View(modelo);
            }
        }


    }
}

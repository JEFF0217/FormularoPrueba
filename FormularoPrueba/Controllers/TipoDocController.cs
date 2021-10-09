using AccesoDeDatos.Implementacion;
using AccesoDeDatos.ModeloDatos;
using FormularoPrueba.Helpers;
using FormularoPrueba.Mapeadores.parametros;
using FormularoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace FormularoPrueba.Controllers
{
    public class TipoDocController : Controller
    {
        private ImpTipoDocDatos acceso = new ImpTipoDocDatos();

        // GET: TipoDoc
        public ActionResult Index(string filtro = "")
        {
            IEnumerable<tb_TipoDoc> listaDatos = acceso.ListarRegistros(String.Empty);
            MapeadorTipoDocGui mapper = new MapeadorTipoDocGui();
            IEnumerable<ModeloTipoDocGUI> listaGUI = mapper.MapearTipo1Tipo2(listaDatos);
            return View(listaGUI);
        }

        // GET: TipoDoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoDoc tb_TipoDoc = acceso.BuscarRegistro(id.Value);
            if (tb_TipoDoc == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoDocGui mapper = new MapeadorTipoDocGui();
            ModeloTipoDocGUI modelo = mapper.MapearTipo1Tipo2(tb_TipoDoc);
            return View(modelo);
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
        public ActionResult Create([Bind(Include = "Id,Nombre")] ModeloTipoDocGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorTipoDocGui mapper = new MapeadorTipoDocGui();
                tb_TipoDoc tb_tipoDoc = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(tb_tipoDoc);
                return RedirectToAction("index");
            }

            return View(modelo);
        }

        // GET: TipoDoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoDoc tb_TipoDoc = acceso.BuscarRegistro(id.Value);
            if (tb_TipoDoc == null)
            {
                return HttpNotFound();
            }


            MapeadorTipoDocGui mapper = new MapeadorTipoDocGui();
            ModeloTipoDocGUI modelo = mapper.MapearTipo1Tipo2(tb_TipoDoc);
            return View(modelo);
          
        }

        // POST: TipoDoc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] ModeloTipoDocGUI modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorTipoDocGui mapper = new MapeadorTipoDocGui();
                tb_TipoDoc tb_tipoDoc = mapper.MapearTipo2Tipo1(modelo);
                acceso.GuardarRegistro(tb_tipoDoc);
                return RedirectToAction("index");
            }



            return View(modelo);
        }

        // GET: TipoDoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_TipoDoc tb_TipoDoc = acceso.BuscarRegistro(id.Value);
            if (tb_TipoDoc == null)
            {
                return HttpNotFound();
            }

            MapeadorTipoDocGui mapper = new MapeadorTipoDocGui();
            ModeloTipoDocGUI modelo = mapper.MapearTipo1Tipo2(tb_TipoDoc);
            return View(modelo);
        }

        // POST: TipoDoc/Delete/5
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
                tb_TipoDoc tb_tipoDoc = acceso.BuscarRegistro(id);
                if (tb_tipoDoc == null)
                {
                    return HttpNotFound();
                }

                MapeadorTipoDocGui mapper = new MapeadorTipoDocGui();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;

                ModeloTipoDocGUI modelo = mapper.MapearTipo1Tipo2(tb_tipoDoc);
                return View(modelo);
            }
        }

       
    }
}

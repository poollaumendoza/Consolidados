using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Consolidados.Web.Models;

namespace Consolidados.Web.Controllers
{
    public class EntidadController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Entidad
        public ActionResult Index()
        {
            var entidad = db.Entidad.Include(e => e.Estado).Include(e => e.TipoDocumento);
            return View(entidad.ToList());
        }

        // GET: Entidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // GET: Entidad/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento");
            return View();
        }

        // POST: Entidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEntidad,IdTipoDocumento,NroDocumento,RazonSocial,Direccion,Telefono,Email,IdEstado")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                db.Entidad.Add(entidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", entidad.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", entidad.IdTipoDocumento);
            return View(entidad);
        }

        // GET: Entidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", entidad.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", entidad.IdTipoDocumento);
            return View(entidad);
        }

        // POST: Entidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEntidad,IdTipoDocumento,NroDocumento,RazonSocial,Direccion,Telefono,Email,IdEstado")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", entidad.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", entidad.IdTipoDocumento);
            return View(entidad);
        }

        // GET: Entidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidad entidad = db.Entidad.Find(id);
            if (entidad == null)
            {
                return HttpNotFound();
            }
            return View(entidad);
        }

        // POST: Entidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entidad entidad = db.Entidad.Find(id);
            db.Entidad.Remove(entidad);
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

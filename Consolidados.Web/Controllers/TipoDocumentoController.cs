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
    public class TipoDocumentoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: TipoDocumento
        public ActionResult Index()
        {
            var tipoDocumento = db.TipoDocumento.Include(t => t.ClasificacionTipoDocumento).Include(t => t.Estado);
            return View(tipoDocumento.ToList());
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            ViewBag.IdClasificacionTipoDocumento = new SelectList(db.ClasificacionTipoDocumento, "IdClasificacionTipoDocumento", "NombreClasificacionTipoDocumento");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: TipoDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoDocumento,IdClasificacionTipoDocumento,NombreTipoDocumento,IdEstado")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                db.TipoDocumento.Add(tipoDocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClasificacionTipoDocumento = new SelectList(db.ClasificacionTipoDocumento, "IdClasificacionTipoDocumento", "NombreClasificacionTipoDocumento", tipoDocumento.IdClasificacionTipoDocumento);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", tipoDocumento.IdEstado);
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClasificacionTipoDocumento = new SelectList(db.ClasificacionTipoDocumento, "IdClasificacionTipoDocumento", "NombreClasificacionTipoDocumento", tipoDocumento.IdClasificacionTipoDocumento);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", tipoDocumento.IdEstado);
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoDocumento,IdClasificacionTipoDocumento,NombreTipoDocumento,IdEstado")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClasificacionTipoDocumento = new SelectList(db.ClasificacionTipoDocumento, "IdClasificacionTipoDocumento", "NombreClasificacionTipoDocumento", tipoDocumento.IdClasificacionTipoDocumento);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", tipoDocumento.IdEstado);
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            if (tipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDocumento tipoDocumento = db.TipoDocumento.Find(id);
            db.TipoDocumento.Remove(tipoDocumento);
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

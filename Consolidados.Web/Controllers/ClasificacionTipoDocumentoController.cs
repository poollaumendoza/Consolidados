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
    public class ClasificacionTipoDocumentoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: ClasificacionTipoDocumento
        public ActionResult Index()
        {
            var clasificacionTipoDocumento = db.ClasificacionTipoDocumento.Include(c => c.Estado);
            return View(clasificacionTipoDocumento.ToList());
        }

        // GET: ClasificacionTipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionTipoDocumento clasificacionTipoDocumento = db.ClasificacionTipoDocumento.Find(id);
            if (clasificacionTipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(clasificacionTipoDocumento);
        }

        // GET: ClasificacionTipoDocumento/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: ClasificacionTipoDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdClasificacionTipoDocumento,NombreClasificacionTipoDocumento,IdEstado")] ClasificacionTipoDocumento clasificacionTipoDocumento)
        {
            if (ModelState.IsValid)
            {
                db.ClasificacionTipoDocumento.Add(clasificacionTipoDocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", clasificacionTipoDocumento.IdEstado);
            return View(clasificacionTipoDocumento);
        }

        // GET: ClasificacionTipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionTipoDocumento clasificacionTipoDocumento = db.ClasificacionTipoDocumento.Find(id);
            if (clasificacionTipoDocumento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", clasificacionTipoDocumento.IdEstado);
            return View(clasificacionTipoDocumento);
        }

        // POST: ClasificacionTipoDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdClasificacionTipoDocumento,NombreClasificacionTipoDocumento,IdEstado")] ClasificacionTipoDocumento clasificacionTipoDocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clasificacionTipoDocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", clasificacionTipoDocumento.IdEstado);
            return View(clasificacionTipoDocumento);
        }

        // GET: ClasificacionTipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClasificacionTipoDocumento clasificacionTipoDocumento = db.ClasificacionTipoDocumento.Find(id);
            if (clasificacionTipoDocumento == null)
            {
                return HttpNotFound();
            }
            return View(clasificacionTipoDocumento);
        }

        // POST: ClasificacionTipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClasificacionTipoDocumento clasificacionTipoDocumento = db.ClasificacionTipoDocumento.Find(id);
            db.ClasificacionTipoDocumento.Remove(clasificacionTipoDocumento);
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

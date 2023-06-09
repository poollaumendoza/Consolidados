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
    public class CompraController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Compra
        public ActionResult Index()
        {
            var compra = db.Compra.Include(c => c.Empresa).Include(c => c.Entidad).Include(c => c.Estado).Include(c => c.TipoDocumento);
            return View(compra.ToList());
        }

        // GET: Compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compra/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento");
            ViewBag.IdEntidad = new SelectList(db.Entidad, "IdEntidad", "NroDocumento");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento");
            return View();
        }

        // POST: Compra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompra,IdEmpresa,IdEntidad,IdTipoDocumento,Serie,Correlativo,FechaCompra,Importe,IGV,Total,IdEstado")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", compra.IdEmpresa);
            ViewBag.IdEntidad = new SelectList(db.Entidad, "IdEntidad", "NroDocumento", compra.IdEntidad);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", compra.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", compra.IdTipoDocumento);
            return View(compra);
        }

        // GET: Compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", compra.IdEmpresa);
            ViewBag.IdEntidad = new SelectList(db.Entidad, "IdEntidad", "NroDocumento", compra.IdEntidad);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", compra.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", compra.IdTipoDocumento);
            return View(compra);
        }

        // POST: Compra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompra,IdEmpresa,IdEntidad,IdTipoDocumento,Serie,Correlativo,FechaCompra,Importe,IGV,Total,IdEstado")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", compra.IdEmpresa);
            ViewBag.IdEntidad = new SelectList(db.Entidad, "IdEntidad", "NroDocumento", compra.IdEntidad);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", compra.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", compra.IdTipoDocumento);
            return View(compra);
        }

        // GET: Compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compra.Find(id);
            db.Compra.Remove(compra);
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

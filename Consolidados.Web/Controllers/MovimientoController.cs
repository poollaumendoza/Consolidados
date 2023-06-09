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
    public class MovimientoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Movimiento
        public ActionResult Index()
        {
            var movimiento = db.Movimiento.Include(m => m.Empresa).Include(m => m.Estado).Include(m => m.Lote).Include(m => m.TipoMovimiento);
            return View(movimiento.ToList());
        }

        // GET: Movimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // GET: Movimiento/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion");
            ViewBag.IdTipoMovimiento = new SelectList(db.TipoMovimiento, "IdTipoMovimiento", "NombreTipoMovimiento");
            return View();
        }

        // POST: Movimiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMovimiento,IdTipoMovimiento,IdEmpresa,IdLote,FechaMovimiento,StockInicial,Ingreso,Salida,StockActual,IdEstado")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Movimiento.Add(movimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", movimiento.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", movimiento.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", movimiento.IdLote);
            ViewBag.IdTipoMovimiento = new SelectList(db.TipoMovimiento, "IdTipoMovimiento", "NombreTipoMovimiento", movimiento.IdTipoMovimiento);
            return View(movimiento);
        }

        // GET: Movimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", movimiento.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", movimiento.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", movimiento.IdLote);
            ViewBag.IdTipoMovimiento = new SelectList(db.TipoMovimiento, "IdTipoMovimiento", "NombreTipoMovimiento", movimiento.IdTipoMovimiento);
            return View(movimiento);
        }

        // POST: Movimiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMovimiento,IdTipoMovimiento,IdEmpresa,IdLote,FechaMovimiento,StockInicial,Ingreso,Salida,StockActual,IdEstado")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", movimiento.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", movimiento.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", movimiento.IdLote);
            ViewBag.IdTipoMovimiento = new SelectList(db.TipoMovimiento, "IdTipoMovimiento", "NombreTipoMovimiento", movimiento.IdTipoMovimiento);
            return View(movimiento);
        }

        // GET: Movimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimiento.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // POST: Movimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movimiento movimiento = db.Movimiento.Find(id);
            db.Movimiento.Remove(movimiento);
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

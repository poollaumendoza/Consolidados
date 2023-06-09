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
    public class CompraDetalleController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: CompraDetalle
        public ActionResult Index()
        {
            var compraDetalle = db.CompraDetalle.Include(c => c.Compra).Include(c => c.Estado).Include(c => c.Lote);
            return View(compraDetalle.ToList());
        }

        // GET: CompraDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraDetalle compraDetalle = db.CompraDetalle.Find(id);
            if (compraDetalle == null)
            {
                return HttpNotFound();
            }
            return View(compraDetalle);
        }

        // GET: CompraDetalle/Create
        public ActionResult Create()
        {
            ViewBag.IdCompra = new SelectList(db.Compra, "IdCompra", "Serie");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion");
            return View();
        }

        // POST: CompraDetalle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompraDetalle,IdCompra,IdLote,Descripcion,Cantidad,Precio,IdEstado")] CompraDetalle compraDetalle)
        {
            if (ModelState.IsValid)
            {
                db.CompraDetalle.Add(compraDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompra = new SelectList(db.Compra, "IdCompra", "Serie", compraDetalle.IdCompra);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", compraDetalle.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", compraDetalle.IdLote);
            return View(compraDetalle);
        }

        // GET: CompraDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraDetalle compraDetalle = db.CompraDetalle.Find(id);
            if (compraDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompra = new SelectList(db.Compra, "IdCompra", "Serie", compraDetalle.IdCompra);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", compraDetalle.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", compraDetalle.IdLote);
            return View(compraDetalle);
        }

        // POST: CompraDetalle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompraDetalle,IdCompra,IdLote,Descripcion,Cantidad,Precio,IdEstado")] CompraDetalle compraDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompra = new SelectList(db.Compra, "IdCompra", "Serie", compraDetalle.IdCompra);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", compraDetalle.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", compraDetalle.IdLote);
            return View(compraDetalle);
        }

        // GET: CompraDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraDetalle compraDetalle = db.CompraDetalle.Find(id);
            if (compraDetalle == null)
            {
                return HttpNotFound();
            }
            return View(compraDetalle);
        }

        // POST: CompraDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraDetalle compraDetalle = db.CompraDetalle.Find(id);
            db.CompraDetalle.Remove(compraDetalle);
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

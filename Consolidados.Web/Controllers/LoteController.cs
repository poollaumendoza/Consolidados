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
    public class LoteController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Lote
        public ActionResult Index()
        {
            var lote = db.Lote.Include(l => l.Almacen).Include(l => l.Empresa).Include(l => l.Estado);
            return View(lote.ToList());
        }

        // GET: Lote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lote.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // GET: Lote/Create
        public ActionResult Create()
        {
            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "NombreAlmacen");
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: Lote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLote,IdAlmacen,IdEmpresa,Descripcion,NroLote,Cantidad,IdEstado")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                db.Lote.Add(lote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "NombreAlmacen", lote.IdAlmacen);
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", lote.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", lote.IdEstado);
            return View(lote);
        }

        // GET: Lote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lote.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "NombreAlmacen", lote.IdAlmacen);
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", lote.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", lote.IdEstado);
            return View(lote);
        }

        // POST: Lote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLote,IdAlmacen,IdEmpresa,Descripcion,NroLote,Cantidad,IdEstado")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAlmacen = new SelectList(db.Almacen, "IdAlmacen", "NombreAlmacen", lote.IdAlmacen);
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", lote.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", lote.IdEstado);
            return View(lote);
        }

        // GET: Lote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lote.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // POST: Lote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lote lote = db.Lote.Find(id);
            db.Lote.Remove(lote);
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

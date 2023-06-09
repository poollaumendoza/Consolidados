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
    public class TipoMovimientoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: TipoMovimiento
        public ActionResult Index()
        {
            var tipoMovimiento = db.TipoMovimiento.Include(t => t.Estado);
            return View(tipoMovimiento.ToList());
        }

        // GET: TipoMovimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMovimiento tipoMovimiento = db.TipoMovimiento.Find(id);
            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimiento);
        }

        // GET: TipoMovimiento/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: TipoMovimiento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoMovimiento,NombreTipoMovimiento,IdEstado")] TipoMovimiento tipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                db.TipoMovimiento.Add(tipoMovimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", tipoMovimiento.IdEstado);
            return View(tipoMovimiento);
        }

        // GET: TipoMovimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMovimiento tipoMovimiento = db.TipoMovimiento.Find(id);
            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", tipoMovimiento.IdEstado);
            return View(tipoMovimiento);
        }

        // POST: TipoMovimiento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoMovimiento,NombreTipoMovimiento,IdEstado")] TipoMovimiento tipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMovimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", tipoMovimiento.IdEstado);
            return View(tipoMovimiento);
        }

        // GET: TipoMovimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMovimiento tipoMovimiento = db.TipoMovimiento.Find(id);
            if (tipoMovimiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoMovimiento);
        }

        // POST: TipoMovimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMovimiento tipoMovimiento = db.TipoMovimiento.Find(id);
            db.TipoMovimiento.Remove(tipoMovimiento);
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

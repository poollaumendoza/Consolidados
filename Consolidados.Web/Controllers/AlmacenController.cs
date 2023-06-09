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
    public class AlmacenController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Almacen
        public ActionResult Index()
        {
            var almacen = db.Almacen.Include(a => a.Estado);
            return View(almacen.ToList());
        }

        // GET: Almacen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacen almacen = db.Almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // GET: Almacen/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: Almacen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAlmacen,NombreAlmacen,Direccion,IdEstado")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.Almacen.Add(almacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", almacen.IdEstado);
            return View(almacen);
        }

        // GET: Almacen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacen almacen = db.Almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", almacen.IdEstado);
            return View(almacen);
        }

        // POST: Almacen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAlmacen,NombreAlmacen,Direccion,IdEstado")] Almacen almacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(almacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", almacen.IdEstado);
            return View(almacen);
        }

        // GET: Almacen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Almacen almacen = db.Almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            return View(almacen);
        }

        // POST: Almacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Almacen almacen = db.Almacen.Find(id);
            db.Almacen.Remove(almacen);
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

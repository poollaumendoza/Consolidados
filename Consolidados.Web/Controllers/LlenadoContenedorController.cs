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
    public class LlenadoContenedorController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: LlenadoContenedor
        public ActionResult Index()
        {
            var llenadoContenedor = db.LlenadoContenedor.Include(l => l.Contrato).Include(l => l.ContratoContenedor).Include(l => l.Estado).Include(l => l.Lote);
            return View(llenadoContenedor.ToList());
        }

        // GET: LlenadoContenedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlenadoContenedor llenadoContenedor = db.LlenadoContenedor.Find(id);
            if (llenadoContenedor == null)
            {
                return HttpNotFound();
            }
            return View(llenadoContenedor);
        }

        // GET: LlenadoContenedor/Create
        public ActionResult Create()
        {
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato");
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion");
            return View();
        }

        // POST: LlenadoContenedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLlenadoContenedor,IdContrato,IdContratoContenedor,IdLote,Cantidad,IdEstado")] LlenadoContenedor llenadoContenedor)
        {
            if (ModelState.IsValid)
            {
                db.LlenadoContenedor.Add(llenadoContenedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", llenadoContenedor.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", llenadoContenedor.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", llenadoContenedor.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", llenadoContenedor.IdLote);
            return View(llenadoContenedor);
        }

        // GET: LlenadoContenedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlenadoContenedor llenadoContenedor = db.LlenadoContenedor.Find(id);
            if (llenadoContenedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", llenadoContenedor.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", llenadoContenedor.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", llenadoContenedor.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", llenadoContenedor.IdLote);
            return View(llenadoContenedor);
        }

        // POST: LlenadoContenedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLlenadoContenedor,IdContrato,IdContratoContenedor,IdLote,Cantidad,IdEstado")] LlenadoContenedor llenadoContenedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(llenadoContenedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", llenadoContenedor.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", llenadoContenedor.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", llenadoContenedor.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", llenadoContenedor.IdLote);
            return View(llenadoContenedor);
        }

        // GET: LlenadoContenedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlenadoContenedor llenadoContenedor = db.LlenadoContenedor.Find(id);
            if (llenadoContenedor == null)
            {
                return HttpNotFound();
            }
            return View(llenadoContenedor);
        }

        // POST: LlenadoContenedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LlenadoContenedor llenadoContenedor = db.LlenadoContenedor.Find(id);
            db.LlenadoContenedor.Remove(llenadoContenedor);
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

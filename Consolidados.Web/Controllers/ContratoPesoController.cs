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
    public class ContratoPesoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: ContratoPeso
        public ActionResult Index()
        {
            var contratoPeso = db.ContratoPeso.Include(c => c.Contrato).Include(c => c.ContratoContenedor).Include(c => c.Estado);
            return View(contratoPeso.ToList());
        }

        // GET: ContratoPeso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPeso contratoPeso = db.ContratoPeso.Find(id);
            if (contratoPeso == null)
            {
                return HttpNotFound();
            }
            return View(contratoPeso);
        }

        // GET: ContratoPeso/Create
        public ActionResult Create()
        {
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato");
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: ContratoPeso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContratoPeso,IdContrato,IdContratoContenedor,PesoTotal,IdEstado")] ContratoPeso contratoPeso)
        {
            if (ModelState.IsValid)
            {
                db.ContratoPeso.Add(contratoPeso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoPeso.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoPeso.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoPeso.IdEstado);
            return View(contratoPeso);
        }

        // GET: ContratoPeso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPeso contratoPeso = db.ContratoPeso.Find(id);
            if (contratoPeso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoPeso.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoPeso.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoPeso.IdEstado);
            return View(contratoPeso);
        }

        // POST: ContratoPeso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContratoPeso,IdContrato,IdContratoContenedor,PesoTotal,IdEstado")] ContratoPeso contratoPeso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratoPeso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoPeso.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoPeso.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoPeso.IdEstado);
            return View(contratoPeso);
        }

        // GET: ContratoPeso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPeso contratoPeso = db.ContratoPeso.Find(id);
            if (contratoPeso == null)
            {
                return HttpNotFound();
            }
            return View(contratoPeso);
        }

        // POST: ContratoPeso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoPeso contratoPeso = db.ContratoPeso.Find(id);
            db.ContratoPeso.Remove(contratoPeso);
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

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
    public class ContratoPrecintoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: ContratoPrecinto
        public ActionResult Index()
        {
            var contratoPrecinto = db.ContratoPrecinto.Include(c => c.Contrato).Include(c => c.ContratoContenedor).Include(c => c.Estado);
            return View(contratoPrecinto.ToList());
        }

        // GET: ContratoPrecinto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPrecinto contratoPrecinto = db.ContratoPrecinto.Find(id);
            if (contratoPrecinto == null)
            {
                return HttpNotFound();
            }
            return View(contratoPrecinto);
        }

        // GET: ContratoPrecinto/Create
        public ActionResult Create()
        {
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato");
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: ContratoPrecinto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContratoPrecinto,IdContrato,IdContratoContenedor,NroPrecinto,IdEstado")] ContratoPrecinto contratoPrecinto)
        {
            if (ModelState.IsValid)
            {
                db.ContratoPrecinto.Add(contratoPrecinto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoPrecinto.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoPrecinto.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoPrecinto.IdEstado);
            return View(contratoPrecinto);
        }

        // GET: ContratoPrecinto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPrecinto contratoPrecinto = db.ContratoPrecinto.Find(id);
            if (contratoPrecinto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoPrecinto.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoPrecinto.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoPrecinto.IdEstado);
            return View(contratoPrecinto);
        }

        // POST: ContratoPrecinto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContratoPrecinto,IdContrato,IdContratoContenedor,NroPrecinto,IdEstado")] ContratoPrecinto contratoPrecinto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratoPrecinto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoPrecinto.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoPrecinto.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoPrecinto.IdEstado);
            return View(contratoPrecinto);
        }

        // GET: ContratoPrecinto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoPrecinto contratoPrecinto = db.ContratoPrecinto.Find(id);
            if (contratoPrecinto == null)
            {
                return HttpNotFound();
            }
            return View(contratoPrecinto);
        }

        // POST: ContratoPrecinto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoPrecinto contratoPrecinto = db.ContratoPrecinto.Find(id);
            db.ContratoPrecinto.Remove(contratoPrecinto);
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

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
    public class ContratoLoteController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: ContratoLote
        public ActionResult Index()
        {
            var contratoLote = db.ContratoLote.Include(c => c.Contrato).Include(c => c.Estado).Include(c => c.Lote);
            return View(contratoLote.ToList());
        }

        // GET: ContratoLote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoLote contratoLote = db.ContratoLote.Find(id);
            if (contratoLote == null)
            {
                return HttpNotFound();
            }
            return View(contratoLote);
        }

        // GET: ContratoLote/Create
        public ActionResult Create()
        {
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion");
            return View();
        }

        // POST: ContratoLote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContratoLote,IdContrato,IdLote,Cantidad,IdEstado")] ContratoLote contratoLote)
        {
            if (ModelState.IsValid)
            {
                db.ContratoLote.Add(contratoLote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoLote.IdContrato);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoLote.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", contratoLote.IdLote);
            return View(contratoLote);
        }

        // GET: ContratoLote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoLote contratoLote = db.ContratoLote.Find(id);
            if (contratoLote == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoLote.IdContrato);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoLote.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", contratoLote.IdLote);
            return View(contratoLote);
        }

        // POST: ContratoLote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContratoLote,IdContrato,IdLote,Cantidad,IdEstado")] ContratoLote contratoLote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratoLote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoLote.IdContrato);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoLote.IdEstado);
            ViewBag.IdLote = new SelectList(db.Lote, "IdLote", "Descripcion", contratoLote.IdLote);
            return View(contratoLote);
        }

        // GET: ContratoLote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoLote contratoLote = db.ContratoLote.Find(id);
            if (contratoLote == null)
            {
                return HttpNotFound();
            }
            return View(contratoLote);
        }

        // POST: ContratoLote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoLote contratoLote = db.ContratoLote.Find(id);
            db.ContratoLote.Remove(contratoLote);
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

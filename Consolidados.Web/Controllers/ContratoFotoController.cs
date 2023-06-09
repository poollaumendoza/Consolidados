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
    public class ContratoFotoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: ContratoFoto
        public ActionResult Index()
        {
            var contratoFoto = db.ContratoFoto.Include(c => c.Contrato).Include(c => c.ContratoContenedor).Include(c => c.Estado);
            return View(contratoFoto.ToList());
        }

        // GET: ContratoFoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoFoto contratoFoto = db.ContratoFoto.Find(id);
            if (contratoFoto == null)
            {
                return HttpNotFound();
            }
            return View(contratoFoto);
        }

        // GET: ContratoFoto/Create
        public ActionResult Create()
        {
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato");
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: ContratoFoto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContratoFoto,IdContrato,IdContratoContenedor,Foto,IdEstado")] ContratoFoto contratoFoto)
        {
            if (ModelState.IsValid)
            {
                db.ContratoFoto.Add(contratoFoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoFoto.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoFoto.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoFoto.IdEstado);
            return View(contratoFoto);
        }

        // GET: ContratoFoto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoFoto contratoFoto = db.ContratoFoto.Find(id);
            if (contratoFoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoFoto.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoFoto.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoFoto.IdEstado);
            return View(contratoFoto);
        }

        // POST: ContratoFoto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContratoFoto,IdContrato,IdContratoContenedor,Foto,IdEstado")] ContratoFoto contratoFoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratoFoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoFoto.IdContrato);
            ViewBag.IdContratoContenedor = new SelectList(db.ContratoContenedor, "IdContratoContenedor", "NroContenedor", contratoFoto.IdContratoContenedor);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoFoto.IdEstado);
            return View(contratoFoto);
        }

        // GET: ContratoFoto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoFoto contratoFoto = db.ContratoFoto.Find(id);
            if (contratoFoto == null)
            {
                return HttpNotFound();
            }
            return View(contratoFoto);
        }

        // POST: ContratoFoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoFoto contratoFoto = db.ContratoFoto.Find(id);
            db.ContratoFoto.Remove(contratoFoto);
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

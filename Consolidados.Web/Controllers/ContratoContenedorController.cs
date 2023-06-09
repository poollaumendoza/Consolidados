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
    public class ContratoContenedorController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: ContratoContenedor
        public ActionResult Index()
        {
            var contratoContenedor = db.ContratoContenedor.Include(c => c.Contrato).Include(c => c.Estado);
            return View(contratoContenedor.ToList());
        }

        // GET: ContratoContenedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoContenedor contratoContenedor = db.ContratoContenedor.Find(id);
            if (contratoContenedor == null)
            {
                return HttpNotFound();
            }
            return View(contratoContenedor);
        }

        // GET: ContratoContenedor/Create
        public ActionResult Create()
        {
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: ContratoContenedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContratoContenedor,IdContrato,NroContenedor,Payload,IdEstado")] ContratoContenedor contratoContenedor)
        {
            if (ModelState.IsValid)
            {
                db.ContratoContenedor.Add(contratoContenedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoContenedor.IdContrato);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoContenedor.IdEstado);
            return View(contratoContenedor);
        }

        // GET: ContratoContenedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoContenedor contratoContenedor = db.ContratoContenedor.Find(id);
            if (contratoContenedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoContenedor.IdContrato);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoContenedor.IdEstado);
            return View(contratoContenedor);
        }

        // POST: ContratoContenedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContratoContenedor,IdContrato,NroContenedor,Payload,IdEstado")] ContratoContenedor contratoContenedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratoContenedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContrato = new SelectList(db.Contrato, "IdContrato", "NroContrato", contratoContenedor.IdContrato);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contratoContenedor.IdEstado);
            return View(contratoContenedor);
        }

        // GET: ContratoContenedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContratoContenedor contratoContenedor = db.ContratoContenedor.Find(id);
            if (contratoContenedor == null)
            {
                return HttpNotFound();
            }
            return View(contratoContenedor);
        }

        // POST: ContratoContenedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContratoContenedor contratoContenedor = db.ContratoContenedor.Find(id);
            db.ContratoContenedor.Remove(contratoContenedor);
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

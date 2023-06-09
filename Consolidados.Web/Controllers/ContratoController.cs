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
    public class ContratoController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Contrato
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.Empresa).Include(c => c.Estado);
            return View(contrato.ToList());
        }

        // GET: Contrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contrato/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento");
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            return View();
        }

        // POST: Contrato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContrato,IdEmpresa,NroContrato,NroContratoLote,FechaContrato,FechaCarga,LugarCarga,FechaDescarga,LugarDescarga,IdEstado")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", contrato.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contrato.IdEstado);
            return View(contrato);
        }

        // GET: Contrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", contrato.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contrato.IdEstado);
            return View(contrato);
        }

        // POST: Contrato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContrato,IdEmpresa,NroContrato,NroContratoLote,FechaContrato,FechaCarga,LugarCarga,FechaDescarga,LugarDescarga,IdEstado")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "NroDocumento", contrato.IdEmpresa);
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", contrato.IdEstado);
            return View(contrato);
        }

        // GET: Contrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contrato.Find(id);
            db.Contrato.Remove(contrato);
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

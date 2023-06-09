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
    public class EmpresaController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Empresa
        public ActionResult Index()
        {
            var empresa = db.Empresa.Include(e => e.Estado).Include(e => e.TipoDocumento);
            return View(empresa.ToList());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento");
            return View();
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpresa,IdTipoDocumento,NroDocumento,RazonSocial,Direccion,Telefono,Email,IdEstado")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", empresa.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", empresa.IdTipoDocumento);
            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", empresa.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", empresa.IdTipoDocumento);
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpresa,IdTipoDocumento,NroDocumento,RazonSocial,Direccion,Telefono,Email,IdEstado")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", empresa.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", empresa.IdTipoDocumento);
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresa.Find(id);
            db.Empresa.Remove(empresa);
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

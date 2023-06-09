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
    public class PersonaController : Controller
    {
        private ConsolidadosEntities db = new ConsolidadosEntities();

        // GET: Persona
        public ActionResult Index()
        {
            var persona = db.Persona.Include(p => p.Estado).Include(p => p.TipoDocumento);
            return View(persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado");
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento");
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersona,IdTipoDocumento,NroDocumento,ApellidoPaterno,ApellidoMaterno,PrimerNombre,SegundoNombre,FechaNacimiento,Direccion,Telefono,Email,IdEstado")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", persona.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", persona.IdTipoDocumento);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", persona.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", persona.IdTipoDocumento);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersona,IdTipoDocumento,NroDocumento,ApellidoPaterno,ApellidoMaterno,PrimerNombre,SegundoNombre,FechaNacimiento,Direccion,Telefono,Email,IdEstado")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "NombreEstado", persona.IdEstado);
            ViewBag.IdTipoDocumento = new SelectList(db.TipoDocumento, "IdTipoDocumento", "NombreTipoDocumento", persona.IdTipoDocumento);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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

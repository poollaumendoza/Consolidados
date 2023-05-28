using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarPersona()
        {
            List<EntityLayer.Persona> oLista = new List<EntityLayer.Persona>();
            oLista = new BusinessLayer.Persona().Listar().ToList();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPersona(EntityLayer.Persona objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdPersona == 0)
                resultado = new BusinessLayer.Persona().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Persona().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPersona(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Persona().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
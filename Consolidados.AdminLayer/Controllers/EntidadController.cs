using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class EntidadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarEntidad()
        {
            List<EntityLayer.Entidad> oLista = new List<EntityLayer.Entidad>();
            oLista = new BusinessLayer.Entidad().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEntidad(EntityLayer.Entidad objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEntidad == 0)
                resultado = new BusinessLayer.Entidad().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Entidad().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEntidad(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Entidad().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
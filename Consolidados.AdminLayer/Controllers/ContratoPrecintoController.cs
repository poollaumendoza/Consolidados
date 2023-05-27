using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ContratoPrecintoController : Controller
    {
        // GET: ContratoPrecinto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarContratoPrecinto()
        {
            List<EntityLayer.ContratoPrecinto> oLista = new List<EntityLayer.ContratoPrecinto>();
            oLista = new BusinessLayer.ContratoPrecinto().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarContratoPrecinto(EntityLayer.ContratoPrecinto objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdContratoPrecinto == 0)
                resultado = new BusinessLayer.ContratoPrecinto().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ContratoPrecinto().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarContratoPrecinto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ContratoPrecinto().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
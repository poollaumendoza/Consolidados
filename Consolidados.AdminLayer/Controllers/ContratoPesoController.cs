using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ContratoPesoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarContratoPeso()
        {
            List<EntityLayer.ContratoPeso> oLista = new List<EntityLayer.ContratoPeso>();
            oLista = new BusinessLayer.ContratoPeso().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarContratoPeso(EntityLayer.ContratoPeso objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdContratoPeso == 0)
                resultado = new BusinessLayer.ContratoPeso().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ContratoPeso().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarContratoPeso(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ContratoPeso().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
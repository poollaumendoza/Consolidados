using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ContratoController : Controller
    {
        // GET: Contrato
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarContrato()
        {
            List<EntityLayer.Contrato> oLista = new List<EntityLayer.Contrato>();
            oLista = new BusinessLayer.Contrato().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarContrato(EntityLayer.Contrato objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdContrato == 0)
                resultado = new BusinessLayer.Contrato().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Contrato().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarContrato(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Contrato().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class TransportistaController : Controller
    {
        // GET: Transportista
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTransportista()
        {
            List<EntityLayer.Transportista> oLista = new List<EntityLayer.Transportista>();
            oLista = new BusinessLayer.Transportista().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTransportista(EntityLayer.Transportista objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTransportista == 0)
                resultado = new BusinessLayer.Transportista().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Transportista().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTransportista(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Transportista().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
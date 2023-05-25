using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class LoteController : Controller
    {
        // GET: Lote
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarLote()
        {
            List<EntityLayer.Lote> oLista = new List<EntityLayer.Lote>();
            oLista = new BusinessLayer.Lote().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarLote(EntityLayer.Lote objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdLote == 0)
                resultado = new BusinessLayer.Lote().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Lote().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarLote(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Lote().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
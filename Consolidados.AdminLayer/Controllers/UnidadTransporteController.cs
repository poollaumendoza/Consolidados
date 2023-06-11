using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class UnidadTransporteController : Controller
    {
        // GET: UnidadTransporte
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarUnidadTransporte()
        {
            List<EntityLayer.UnidadTransporte> oLista = new List<EntityLayer.UnidadTransporte>();
            oLista = new BusinessLayer.UnidadTransporte().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUnidadTransporte(EntityLayer.UnidadTransporte objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdUnidadTransporte == 0)
                resultado = new BusinessLayer.UnidadTransporte().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.UnidadTransporte().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUnidadTransporte(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.UnidadTransporte().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
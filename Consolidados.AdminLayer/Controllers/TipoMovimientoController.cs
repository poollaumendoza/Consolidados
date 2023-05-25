using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class TipoMovimientoController : Controller
    {
        // GET: TipoMovimiento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTipoMovimiento()
        {
            List<EntityLayer.TipoMovimiento> oLista = new List<EntityLayer.TipoMovimiento>();
            oLista = new BusinessLayer.TipoMovimiento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoMovimiento(EntityLayer.TipoMovimiento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTipoMovimiento == 0)
                resultado = new BusinessLayer.TipoMovimiento().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.TipoMovimiento().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipoMovimiento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.TipoMovimiento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
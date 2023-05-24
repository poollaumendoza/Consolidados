using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ClasificacionTipoDocumentoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarClasificacionTipoDocumento()
        {
            List<EntityLayer.ClasificacionTipoDocumento> oLista = new List<EntityLayer.ClasificacionTipoDocumento>();
            oLista = new BusinessLayer.ClasificacionTipoDocumento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarClasificacionTipoDocumento(EntityLayer.ClasificacionTipoDocumento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdClasificacionTipoDocumento == 0)
                resultado = new BusinessLayer.ClasificacionTipoDocumento().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ClasificacionTipoDocumento().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarClasificacionTipoDocumento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ClasificacionTipoDocumento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class AlmacenController : Controller
    {
        // GET: Almacen
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarAlmacen()
        {
            List<EntityLayer.Almacen> oLista = new List<EntityLayer.Almacen>();
            oLista = new BusinessLayer.Almacen().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarAlmacen(EntityLayer.Almacen objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdAlmacen == 0)
                resultado = new BusinessLayer.Almacen().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Almacen().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarAlmacen(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Almacen().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
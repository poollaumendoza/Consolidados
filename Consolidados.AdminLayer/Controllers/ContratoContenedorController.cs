using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ContratoContenedorController : Controller
    {
        // GET: ContratoContenedor
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarContratoContenedor()
        {
            List<EntityLayer.ContratoContenedor> oLista = new List<EntityLayer.ContratoContenedor>();
            oLista = new BusinessLayer.ContratoContenedor().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarContratoContenedor(EntityLayer.ContratoContenedor objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdContratoContenedor == 0)
                resultado = new BusinessLayer.ContratoContenedor().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ContratoContenedor().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarContratoContenedor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ContratoContenedor().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
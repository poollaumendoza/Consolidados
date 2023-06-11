using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ContratoLoteController : Controller
    {
        // GET: ContratoLote
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarContratoLote()
        {
            List<EntityLayer.ContratoLote> oLista = new List<EntityLayer.ContratoLote>();
            oLista = new BusinessLayer.ContratoLote().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarContratoLote(int IdContrato)
        {
            List<EntityLayer.ContratoLote> oLista = new List<EntityLayer.ContratoLote>();
            oLista = new BusinessLayer.ContratoLote().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarUnidadTransporte()
        {
            List<EntityLayer.UnidadTransporte> oLista = new List<EntityLayer.UnidadTransporte>();
            oLista = new BusinessLayer.UnidadTransporte().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarContratoLote(EntityLayer.ContratoLote objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdContratoLote == 0)
                resultado = new BusinessLayer.ContratoLote().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ContratoLote().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarContratoLote(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ContratoLote().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
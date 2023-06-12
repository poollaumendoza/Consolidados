using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ContratoTransporteController : Controller
    {
        // GET: ContratoTransporte
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarContratoTransporte()
        {
            List<EntityLayer.ContratoTransporte> oLista = new List<EntityLayer.ContratoTransporte>();
            oLista = new BusinessLayer.ContratoTransporte().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarContrato()
        {
            List<EntityLayer.Contrato> oLista = new List<EntityLayer.Contrato>();
            oLista = new BusinessLayer.Contrato().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarUnidadTransporte()
        {
            List<EntityLayer.UnidadTransporte> oLista = new List<EntityLayer.UnidadTransporte>();
            oLista = new BusinessLayer.UnidadTransporte().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarLote()
        {
            List<EntityLayer.ContratoLote> oLista = new List<EntityLayer.ContratoLote>();
            oLista = new BusinessLayer.ContratoLote().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarContratoTransporte(EntityLayer.ContratoTransporte objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdContratoTransporte == 0)
                resultado = new BusinessLayer.ContratoTransporte().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ContratoTransporte().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarContratoTransporte(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ContratoTransporte().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
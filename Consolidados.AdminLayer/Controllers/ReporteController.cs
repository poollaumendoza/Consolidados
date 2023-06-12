using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ReporteController : Controller
    {
        public ActionResult SegunContrato()
        {
            return View();
        }

        public JsonResult ListarContratoTransporte(int IdContrato)
        {
            List<EntityLayer.ContratoTransporte> oLista = new List<EntityLayer.ContratoTransporte>();
            oLista = new BusinessLayer.ContratoTransporte().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarContratoContenedor(int IdContrato)
        {
            List<EntityLayer.ContratoContenedor> oLista = new List<EntityLayer.ContratoContenedor>();
            oLista = new BusinessLayer.ContratoContenedor().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarContratoLote(int IdContrato)
        {
            List<EntityLayer.ContratoLote> oLista = new List<EntityLayer.ContratoLote>();
            oLista = new BusinessLayer.ContratoLote().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarContratoFoto(int IdContrato)
        {
            List<EntityLayer.ContratoFoto> oLista = new List<EntityLayer.ContratoFoto>();
            oLista = new BusinessLayer.ContratoFoto().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarLlenadoContenedor(int IdContrato)
        {
            List<EntityLayer.LlenadoContenedor> oLista = new List<EntityLayer.LlenadoContenedor>();
            oLista = new BusinessLayer.LlenadoContenedor().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarContratoPeso(int IdContrato)
        {
            List<EntityLayer.ContratoPeso> oLista = new List<EntityLayer.ContratoPeso>();
            oLista = new BusinessLayer.ContratoPeso().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarContratoPrecinto(int IdContrato)
        {
            List<EntityLayer.ContratoPrecinto> oLista = new List<EntityLayer.ContratoPrecinto>();
            oLista = new BusinessLayer.ContratoPrecinto().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
    }
}
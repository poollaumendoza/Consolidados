﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class LlenadoContenedorController : Controller
    {
        // GET: LlenadoContenedor
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarLlenadoContenedor()
        {
            List<EntityLayer.LlenadoContenedor> oLista = new List<EntityLayer.LlenadoContenedor>();
            oLista = new BusinessLayer.LlenadoContenedor().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarContrato()
        {
            List<EntityLayer.Contrato> oLista = new List<EntityLayer.Contrato>();
            oLista = new BusinessLayer.Contrato().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarContratoContenedor(int IdContrato)
        {
            List<EntityLayer.ContratoContenedor> oLista = new List<EntityLayer.ContratoContenedor>();
            oLista = new BusinessLayer.ContratoContenedor().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarLote()
        {
            List<EntityLayer.ContratoLote> oLista = new List<EntityLayer.ContratoLote>();
            oLista = new BusinessLayer.ContratoLote().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerCantidadPorLote(int IdContrato, int IdLote)
        {
            int resultado = new BusinessLayer.ContratoLote().ObtenerCantidadPorLote(IdContrato, IdLote);
            return Json(new { data = resultado }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarLlenadoContenedor(EntityLayer.LlenadoContenedor objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdLlenadoContenedor == 0)
                resultado = new BusinessLayer.LlenadoContenedor().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.LlenadoContenedor().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarLlenadoContenedor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.LlenadoContenedor().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
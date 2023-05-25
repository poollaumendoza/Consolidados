using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarEmpresa()
        {
            List<EntityLayer.Empresa> oLista = new List<EntityLayer.Empresa>();
            oLista = new BusinessLayer.Empresa().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEmpresa(EntityLayer.Empresa objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEmpresa == 0)
                resultado = new BusinessLayer.Empresa().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Empresa().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEmpresa(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Empresa().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
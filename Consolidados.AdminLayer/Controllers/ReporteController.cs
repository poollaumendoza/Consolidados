using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ReporteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SegunContrato()
        {
            return View();
        }

        public JsonResult ListarContratoContenedor(int IdContrato)
        {
            List<EntityLayer.ContratoContenedor> oLista = new List<EntityLayer.ContratoContenedor>();
            oLista = new BusinessLayer.ContratoContenedor().Listar(IdContrato);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
    }
}
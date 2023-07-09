using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class TransportistaController : Controller
    {
        public class Result
        {
            public string Paterno { get; set; }
            public string Materno { get; set; }
            public string Nombre { get; set; }
            public string DNI { get; set; }
            public string CodVerificacion { get; set; }
        }

        public class ObjetoPrincipal
        {
            public bool sucess { get; set; }
            public Result result { get; set; }
        }

        public class DataCiudadano
        {
            public bool sucess { get; set; }
            public string mensaje { get; set; }
            public string Paterno { get; set; }
            public string Materno { get; set; }
            public string Nombre { get; set; }
            public string DNI { get; set; }
            public string CodVerificacion { get; set; }
        }

        // GET: Transportista
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTransportista()
        {
            List<EntityLayer.Transportista> oLista = new List<EntityLayer.Transportista>();
            oLista = new BusinessLayer.Transportista().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTransportista(EntityLayer.Transportista objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTransportista == 0)
                resultado = new BusinessLayer.Transportista().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Transportista().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTransportista(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Transportista().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getDataCiudadanoByDNI(string dni)
        {
            DataCiudadano data = new DataCiudadano();

            string url = string.Format("{0}{1}{2}", "https://dniruc.apisperu.com/api/v1/dni/", dni, "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6InBvb2xsYXVtZW5kb3phQG91dGxvb2suY29tIn0.4-S7Y2ZKu_IfOZkXvAPahYdi7q5PLpc_3tZVCnvQD-0");

            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            using (var response = webRequest.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string resultado = reader.ReadToEnd();
                    string json = Convert.ToString(resultado);

                    ObjetoPrincipal respuesta = JsonConvert.DeserializeObject<ObjetoPrincipal>(json);

                    if (respuesta.sucess)
                    {
                        data.sucess = true;
                        data.mensaje = "Petición completa";
                        data.Paterno = respuesta.result.Paterno;
                        data.Materno = respuesta.result.Materno;
                        data.Nombre = respuesta.result.DNI;
                        data.CodVerificacion = respuesta.result.CodVerificacion;
                    }
                    else
                    {
                        data.sucess = false;
                        data.mensaje = "DNI no válido";
                    }
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
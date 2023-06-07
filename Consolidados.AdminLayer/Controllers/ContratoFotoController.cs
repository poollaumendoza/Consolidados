using Consolidados.BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer.Controllers
{
    public class ContratoFotoController : Controller
    {
        // GET: ContratoFoto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarContratoFoto()
        {
            List<EntityLayer.ContratoFoto> oLista = new List<EntityLayer.ContratoFoto>();
            oLista = new BusinessLayer.ContratoFoto().Listar();
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

        [HttpPost]
        public JsonResult GuardarContratoFoto(string objeto, HttpPostedFileBase archivoImagen)
        {
            object resultado;
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;
            int idfotogenerada = 0;

            EntityLayer.ContratoFoto oFoto = new EntityLayer.ContratoFoto();
            oFoto = JsonConvert.DeserializeObject<EntityLayer.ContratoFoto>(objeto);

            if (oFoto.IdContratoFoto == 0)
            {
                idfotogenerada = new ContratoFoto().Registrar(oFoto, out mensaje);
                if (idfotogenerada != 0)
                    oFoto.IdContratoFoto = idfotogenerada;
                else
                    operacion_exitosa = false;
                if (operacion_exitosa)
                    if (archivoImagen != null)
                    {
                        string rutaImagenes = string.Format("{0}\\{1}\\{2}\\", ConfigurationManager.AppSettings["Photos"], oFoto.oContrato.NroContratoLote, oFoto.oContratoContenedor.NroContenedor);
                        string extension = Path.GetExtension(archivoImagen.FileName);
                        string nombreImagen = string.Concat(oFoto.IdContratoFoto.ToString("00"), extension);

                        try { archivoImagen.SaveAs(Path.Combine(rutaImagenes, nombreImagen)); }
                        catch (Exception ex)
                        {
                            string msg = ex.Message;
                            guardar_imagen_exito = false;
                        }
                        if (guardar_imagen_exito)
                        {
                            oFoto.Foto = Path.Combine(rutaImagenes, nombreImagen);
                            bool rpta = new ContratoFoto().GuardarFoto(oFoto, out mensaje);
                        }
                    }
            }
            else
                resultado = new ContratoFoto().Editar(oFoto, out mensaje);

            return Json(new { operacionExitosa = operacion_exitosa, idGenerado = oFoto.IdContratoFoto, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FotoContenedor(int id)
        {
            bool conversion;
            EntityLayer.ContratoFoto oContratoFoto = new ContratoFoto().Listar().Where(p => p.IdContratoFoto == id).FirstOrDefault();
            string textoBase64 = Recursos.ConvertirBase64(Path.Combine(oContratoFoto.Foto), out conversion);

            return Json(new { conversion = conversion, textobase64 = textoBase64, extension = Path.GetExtension(oContratoFoto.Foto) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarContratoFoto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new ContratoFoto().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
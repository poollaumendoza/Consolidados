using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class UnidadTransporte
    {
        DataLayer.UnidadTransporte dUnidadTransporte = new DataLayer.UnidadTransporte();

        public List<EntityLayer.UnidadTransporte> Listar()
        {
            return dUnidadTransporte.Listar();
        }

        public List<EntityLayer.UnidadTransporte> Listar(int IdUnidadTransporte)
        {
            return dUnidadTransporte.Listar(IdUnidadTransporte);
        }

        public int Registrar(EntityLayer.UnidadTransporte obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar una empresa";
            if (obj.oTransportista.IdTransportista == 0)
                Mensaje = "Debe seleccionar un transportista";
            else if (string.IsNullOrEmpty(obj.PlacaTracto) || string.IsNullOrWhiteSpace(obj.PlacaTracto))
                Mensaje = "La placa del tracto no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.PlacaCarreta) || string.IsNullOrWhiteSpace(obj.PlacaCarreta))
                Mensaje = "La placa de la carreta no puede ser vacía";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUnidadTransporte.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.UnidadTransporte obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar una empresa";
            if (obj.oTransportista.IdTransportista == 0)
                Mensaje = "Debe seleccionar un transportista";
            else if (string.IsNullOrEmpty(obj.PlacaTracto) || string.IsNullOrWhiteSpace(obj.PlacaTracto))
                Mensaje = "La placa del tracto no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.PlacaCarreta) || string.IsNullOrWhiteSpace(obj.PlacaCarreta))
                Mensaje = "La placa de la carreta no puede ser vacía";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUnidadTransporte.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dUnidadTransporte.Eliminar(id, out Mensaje);
        }
    }
}

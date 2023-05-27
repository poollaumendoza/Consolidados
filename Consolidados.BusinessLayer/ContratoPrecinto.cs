using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class ContratoPrecinto
    {
        DataLayer.ContratoPrecinto dContratoPrecinto = new DataLayer.ContratoPrecinto();

        public List<EntityLayer.ContratoPrecinto> Listar()
        {
            return dContratoPrecinto.Listar();
        }

        public int Registrar(EntityLayer.ContratoPrecinto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if (string.IsNullOrEmpty(obj.NroPrecinto) || string.IsNullOrWhiteSpace(obj.NroPrecinto))
                Mensaje = "El número de precinto no puede ser cero";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoPrecinto.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ContratoPrecinto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if (string.IsNullOrEmpty(obj.NroPrecinto) || string.IsNullOrWhiteSpace(obj.NroPrecinto))
                Mensaje = "El número de precinto no puede ser cero";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoPrecinto.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dContratoPrecinto.Eliminar(id, out Mensaje);
        }
    }
}

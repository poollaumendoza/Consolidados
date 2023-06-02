using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class ContratoPeso
    {
        DataLayer.ContratoPeso dContratoPeso = new DataLayer.ContratoPeso();

        public List<EntityLayer.ContratoPeso> Listar()
        {
            return dContratoPeso.Listar();
        }

        public List<EntityLayer.ContratoPeso> Listar(int IdPeso)
        {
            return dContratoPeso.Listar(IdPeso);
        }

        public int Registrar(EntityLayer.ContratoPeso obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if (obj.PesoTotal == 0 || string.IsNullOrWhiteSpace(obj.PesoTotal.ToString()))
                Mensaje = "El peso total no puede ser cero ni tener un espacio en blanco";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoPeso.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ContratoPeso obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if (obj.PesoTotal == 0 || string.IsNullOrWhiteSpace(obj.PesoTotal.ToString()))
                Mensaje = "El peso total no puede ser cero ni tener un espacio en blanco";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este ContratoPeso";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoPeso.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dContratoPeso.Eliminar(id, out Mensaje);
        }
    }
}
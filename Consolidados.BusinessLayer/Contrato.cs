using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class Contrato
    {
        DataLayer.Contrato dContrato = new DataLayer.Contrato();

        public List<EntityLayer.Contrato> Listar()
        {
            return dContrato.Listar();
        }

        public List<EntityLayer.Contrato> Listar(int IdContrato)
        {
            return dContrato.Listar(IdContrato);
        }

        public int Registrar(EntityLayer.Contrato obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (string.IsNullOrEmpty(obj.NroContrato) || string.IsNullOrWhiteSpace(obj.NroContrato))
                Mensaje = "El número de contrato no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.NroContratoLote) || string.IsNullOrWhiteSpace(obj.NroContratoLote))
                Mensaje = "El número de lote no puede ser vacío";
            else if (obj.FechaContrato == string.Empty)
                Mensaje = "Debe seleccionar una fecha de contrato";
            else if (obj.FechaCarga == string.Empty)
                Mensaje = "Debe seleccionar una fecha de carga";
            else if (string.IsNullOrEmpty(obj.LugarCarga) || string.IsNullOrWhiteSpace(obj.LugarCarga))
                Mensaje = "El lugar de carga no puede ser vacío";
            else if (obj.FechaDescarga == string.Empty)
                Mensaje = "Debe seleccionar una fecha de descarga";
            else if (string.IsNullOrEmpty(obj.LugarDescarga) || string.IsNullOrWhiteSpace(obj.LugarDescarga))
                Mensaje = "El lugar de descarga no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este Contrato";

            if (string.IsNullOrEmpty(Mensaje))
                return dContrato.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Contrato obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (string.IsNullOrEmpty(obj.NroContrato) || string.IsNullOrWhiteSpace(obj.NroContrato))
                Mensaje = "El número de contrato no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.NroContratoLote) || string.IsNullOrWhiteSpace(obj.NroContratoLote))
                Mensaje = "El número de lote no puede ser vacío";
            else if (obj.FechaContrato == string.Empty)
                Mensaje = "Debe seleccionar una fecha de contrato";
            else if (obj.FechaCarga == string.Empty)
                Mensaje = "Debe seleccionar una fecha de carga";
            else if (string.IsNullOrEmpty(obj.LugarCarga) || string.IsNullOrWhiteSpace(obj.LugarCarga))
                Mensaje = "El lugar de carga no puede ser vacío";
            else if (obj.FechaDescarga == string.Empty)
                Mensaje = "Debe seleccionar una fecha de descarga";
            else if (string.IsNullOrEmpty(obj.LugarDescarga) || string.IsNullOrWhiteSpace(obj.LugarDescarga))
                Mensaje = "El lugar de descarga no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este Contrato";

            if (string.IsNullOrEmpty(Mensaje))
                return dContrato.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dContrato.Eliminar(id, out Mensaje);
        }
    }
}
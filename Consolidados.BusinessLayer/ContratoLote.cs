using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class ContratoLote
    {
        DataLayer.ContratoLote dContratoLote = new DataLayer.ContratoLote();

        public List<EntityLayer.ContratoLote> Listar()
        {
            return dContratoLote.Listar();
        }

        public List<EntityLayer.ContratoLote> Listar(int IdContrato)
        {
            return dContratoLote.Listar(IdContrato);
        }

        public int ObtenerCantidadPorLote(int IdContrato, int IdLote)
        {
            return dContratoLote.ObtenerCantidadPorLote(IdContrato, IdLote);
        }

        public int Registrar(EntityLayer.ContratoLote obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oUnidadTransporte.IdUnidadTransporte == 0)
                Mensaje = "Debe seleccionar una unidad de transporte";
            else if (obj.oLote.IdLote == 0)
                Mensaje = "Debe seleccionar un lote";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser cero";
            else if (obj.Peso == 0)
                Mensaje = "El peso no puede ser cero";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoLote.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ContratoLote obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oUnidadTransporte.IdUnidadTransporte == 0)
                Mensaje = "Debe seleccionar una unidad de transporte";
            else if (obj.oLote.IdLote == 0)
                Mensaje = "Debe seleccionar un lote";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser cero";
            else if (obj.Peso == 0)
                Mensaje = "El peso no puede ser cero";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoLote.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dContratoLote.Eliminar(id, out Mensaje);
        }
    }
}
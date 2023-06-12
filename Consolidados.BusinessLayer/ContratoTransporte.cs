using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class ContratoTransporte
    {
        DataLayer.ContratoTransporte dContratoTransporte = new DataLayer.ContratoTransporte();

        public List<EntityLayer.ContratoTransporte> Listar()
        {
            return dContratoTransporte.Listar();
        }

        public List<EntityLayer.ContratoTransporte> Listar(int IdContrato)
        {
            return dContratoTransporte.Listar(IdContrato);
        }

        public int Registrar(EntityLayer.ContratoTransporte obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oUnidadTransporte.IdUnidadTransporte == 0)
                Mensaje = "Debe seleccionar una unidad de transporte";
            else if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oLote.IdLote == 0)
                Mensaje = "Debe seleccionar un lote";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.Peso == 0)
                Mensaje = "El peso no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoTransporte.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ContratoTransporte obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oUnidadTransporte.IdUnidadTransporte == 0)
                Mensaje = "Debe seleccionar una unidad de transporte";
            else if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oLote.IdLote == 0)
                Mensaje = "Debe seleccionar un lote";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.Peso == 0)
                Mensaje = "El peso no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoTransporte.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dContratoTransporte.Eliminar(id, out Mensaje);
        }
    }
}
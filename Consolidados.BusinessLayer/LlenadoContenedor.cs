using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class LlenadoContenedor
    {
        DataLayer.LlenadoContenedor dLlenadoContenedor = new DataLayer.LlenadoContenedor();

        public List<EntityLayer.LlenadoContenedor> Listar()
        {
            return dLlenadoContenedor.Listar();
        }

        public List<EntityLayer.LlenadoContenedor> Listar(int IdContrato)
        {
            return dLlenadoContenedor.Listar(IdContrato);
        }

        public int Registrar(EntityLayer.LlenadoContenedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if (obj.oLote.IdLote == 0)
                Mensaje = "Debe seleccionar un lote";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dLlenadoContenedor.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.LlenadoContenedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if (obj.oLote.IdLote == 0)
                Mensaje = "Debe seleccionar un lote";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dLlenadoContenedor.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dLlenadoContenedor.Eliminar(id, out Mensaje);
        }
    }
}
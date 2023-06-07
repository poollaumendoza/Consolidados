using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class ContratoContenedor
    {
        DataLayer.ContratoContenedor dContratoContenedor = new DataLayer.ContratoContenedor();

        public List<EntityLayer.ContratoContenedor> Listar()
        {
            return dContratoContenedor.Listar();
        }

        public List<EntityLayer.ContratoContenedor> Listar(int IdContrato)
        {
            return dContratoContenedor.Listar(IdContrato);
        }

        public List<EntityLayer.ContratoContenedor> Listar(string objeto, object valor)
        {
            return dContratoContenedor.Listar(objeto, valor);
        }

        public int Registrar(EntityLayer.ContratoContenedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (string.IsNullOrEmpty(obj.NroContenedor) || string.IsNullOrWhiteSpace(obj.NroContenedor))
                Mensaje = "El número del contenedor no puede ser vacío";
            else if (obj.Payload == 0)
                Mensaje = "La cantidad no puede ser cero";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoContenedor.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ContratoContenedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (string.IsNullOrEmpty(obj.NroContenedor) || string.IsNullOrWhiteSpace(obj.NroContenedor))
                Mensaje = "El número del contenedor no puede ser vacío";
            else if (obj.Payload == 0)
                Mensaje = "La cantidad no puede ser cero";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoContenedor.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dContratoContenedor.Eliminar(id, out Mensaje);
        }
    }
}
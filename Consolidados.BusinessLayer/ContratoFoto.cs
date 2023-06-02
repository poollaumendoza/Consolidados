using System.Collections.Generic;

namespace Consolidados.BusinessLayer
{
    public class ContratoFoto
    {
        DataLayer.ContratoFoto dContratoFoto = new DataLayer.ContratoFoto();

        public List<EntityLayer.ContratoFoto> Listar()
        {
            return dContratoFoto.Listar();
        }

        public List<EntityLayer.ContratoFoto> Listar(string objeto, object valor)
        {
            return dContratoFoto.Listar(objeto, valor);
        }

        public int Registrar(EntityLayer.ContratoFoto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if(obj.Foto.Length == 0)
                Mensaje = "Debe subir una foto";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoFoto.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ContratoFoto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oContrato.IdContrato == 0)
                Mensaje = "Debe seleccionar un contrato";
            else if (obj.oContratoContenedor.IdContratoContenedor == 0)
                Mensaje = "Debe seleccionar un contenedor";
            else if (obj.Foto.Length == 0)
                Mensaje = "Debe subir una foto";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dContratoFoto.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dContratoFoto.Eliminar(id, out Mensaje);
        }
    }
}
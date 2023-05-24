using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class TipoDocumento
    {
        DataLayer.TipoDocumento dTipoDocumento = new DataLayer.TipoDocumento();

        public List<EntityLayer.TipoDocumento> Listar()
        {
            return dTipoDocumento.Listar();
        }

        public int Registrar(EntityLayer.TipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreTipoDocumento))
                Mensaje = "El nombre del tipo de documento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este TipoDocumento";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoDocumento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.TipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreTipoDocumento))
                Mensaje = "El nombre del tipo de documento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este TipoDocumento";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoDocumento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dTipoDocumento.Eliminar(id, out Mensaje);
        }
    }
}
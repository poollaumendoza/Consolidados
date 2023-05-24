using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class ClasificacionTipoDocumento
    {
        DataLayer.ClasificacionTipoDocumento dClasificacionTipoDocumento = new DataLayer.ClasificacionTipoDocumento();

        public List<EntityLayer.ClasificacionTipoDocumento> Listar()
        {
            return dClasificacionTipoDocumento.Listar();
        }

        public int Registrar(EntityLayer.ClasificacionTipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreClasificacionTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreClasificacionTipoDocumento))
                Mensaje = "El nombre de la clasificación del tipo de documento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este ClasificacionTipoDocumento";

            if (string.IsNullOrEmpty(Mensaje))
                return dClasificacionTipoDocumento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.ClasificacionTipoDocumento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreClasificacionTipoDocumento) || string.IsNullOrWhiteSpace(obj.NombreClasificacionTipoDocumento))
                Mensaje = "El nombre de la clasificación del tipo de documento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este ClasificacionTipoDocumento";

            if (string.IsNullOrEmpty(Mensaje))
                return dClasificacionTipoDocumento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dClasificacionTipoDocumento.Eliminar(id, out Mensaje);
        }
    }
}
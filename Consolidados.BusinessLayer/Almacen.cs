using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consolidados.BusinessLayer;
using Consolidados.EntityLayer;

namespace Consolidados.BusinessLayer
{
    public class Almacen
    {
        DataLayer.Almacen dAlmacen = new DataLayer.Almacen();

        public List<EntityLayer.Almacen> Listar()
        {
            return dAlmacen.Listar();
        }

        public int Registrar(EntityLayer.Almacen obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreAlmacen) || string.IsNullOrWhiteSpace(obj.NombreAlmacen))
                Mensaje = "El nombre del almacén no puede ser vacío";
            else if(string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "La dirección del almacén no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dAlmacen.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Almacen obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreAlmacen) || string.IsNullOrWhiteSpace(obj.NombreAlmacen))
                Mensaje = "El nombre del almacén no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "La dirección del almacén no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este almacen";

            if (string.IsNullOrEmpty(Mensaje))
                return dAlmacen.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dAlmacen.Eliminar(id, out Mensaje);
        }
    }
}
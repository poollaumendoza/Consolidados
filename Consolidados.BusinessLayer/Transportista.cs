using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class Transportista
    {
        DataLayer.Transportista dTransportista = new DataLayer.Transportista();

        public List<EntityLayer.Transportista> Listar()
        {
            return dTransportista.Listar();
        }

        public int Registrar(EntityLayer.Transportista obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
                Mensaje = "El apellido no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
                Mensaje = "El apellido no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.DNI) || string.IsNullOrWhiteSpace(obj.DNI))
                Mensaje = "El DNI no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.LicConducir) || string.IsNullOrWhiteSpace(obj.LicConducir))
                Mensaje = "La licencia de conducir no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "El teléfono no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTransportista.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Transportista obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
                Mensaje = "El apellido no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
                Mensaje = "El apellido no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.DNI) || string.IsNullOrWhiteSpace(obj.DNI))
                Mensaje = "El DNI no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.LicConducir) || string.IsNullOrWhiteSpace(obj.LicConducir))
                Mensaje = "La licencia de conducir no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "El teléfono no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTransportista.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dTransportista.Eliminar(id, out Mensaje);
        }
    }
}
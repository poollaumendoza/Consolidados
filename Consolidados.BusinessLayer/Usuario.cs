using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class Usuario
    {
        DataLayer.Usuario dUsuario = new DataLayer.Usuario();

        public List<EntityLayer.Usuario> Listar()
        {
            return dUsuario.Listar();
        }

        public EntityLayer.Usuario BuscarUsuario(string nombreusuario, string contraseña)
        {
            return dUsuario.BuscarUsuario(nombreusuario, contraseña);
        }

        public int Registrar(EntityLayer.Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPersona.IdPersona == 0)
                Mensaje = "Debe seleccionar una persona";
            if (string.IsNullOrEmpty(obj.NombreUsuario) || string.IsNullOrWhiteSpace(obj.NombreUsuario))
                Mensaje = "El nombre del usuario no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Contraseña) || string.IsNullOrWhiteSpace(obj.Contraseña))
                Mensaje = "La contraseña no puede ser vacía";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUsuario.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oPersona.IdPersona == 0)
                Mensaje = "Debe seleccionar una persona";
            if (string.IsNullOrEmpty(obj.NombreUsuario) || string.IsNullOrWhiteSpace(obj.NombreUsuario))
                Mensaje = "El nombre del usuario no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Contraseña) || string.IsNullOrWhiteSpace(obj.Contraseña))
                Mensaje = "La contraseña no puede ser vacía";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUsuario.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dUsuario.Eliminar(id, out Mensaje);
        }
    }
}
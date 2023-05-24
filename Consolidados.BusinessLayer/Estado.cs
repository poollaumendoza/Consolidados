using System.Collections.Generic;

namespace Consolidados.BusinessLayer
{
    public class Estado
    {
        DataLayer.Estado dEstado = new DataLayer.Estado();

        public List<EntityLayer.Estado> Listar()
        {
            return dEstado.Listar();
        }

        public int Registrar(EntityLayer.Estado obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            
            if (string.IsNullOrEmpty(obj.NombreEstado) || string.IsNullOrWhiteSpace(obj.NombreEstado))
                Mensaje = "El campo nombre no puede estar vacío";

            if (string.IsNullOrEmpty(Mensaje))
                return dEstado.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Estado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreEstado) || string.IsNullOrWhiteSpace(obj.NombreEstado))
                Mensaje = "El campo nombre no puede estar vacío";

            if (string.IsNullOrEmpty(Mensaje))
                return dEstado.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dEstado.Eliminar(id, out Mensaje);
        }
    }
}
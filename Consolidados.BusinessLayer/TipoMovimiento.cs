using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class TipoMovimiento
    {
        DataLayer.TipoMovimiento dTipoMovimiento = new DataLayer.TipoMovimiento();

        public List<EntityLayer.TipoMovimiento> Listar()
        {
            return dTipoMovimiento.Listar();
        }

        public int Registrar(EntityLayer.TipoMovimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreTipoMovimiento) || string.IsNullOrWhiteSpace(obj.NombreTipoMovimiento))
                Mensaje = "El nombre del tipo de movimiento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este TipoMovimiento";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoMovimiento.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.TipoMovimiento obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreTipoMovimiento) || string.IsNullOrWhiteSpace(obj.NombreTipoMovimiento))
                Mensaje = "El nombre del tipo de movimiento no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este TipoMovimiento";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipoMovimiento.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dTipoMovimiento.Eliminar(id, out Mensaje);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.BusinessLayer
{
    public class Lote
    {
        DataLayer.Lote dLote = new DataLayer.Lote();

        public List<EntityLayer.Lote> Listar()
        {
            return dLote.Listar();
        }

        public int Registrar(EntityLayer.Lote obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oAlmacen.IdAlmacen == 0)
                Mensaje = "Debe seleccionar un almacén";
            else if (obj.oEmpresa.IdEmpresa == 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
                Mensaje = "La descripción no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.NroLote) || string.IsNullOrWhiteSpace(obj.NroLote))
                Mensaje = "La dirección no puede ser vacía";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este Lote";

            if (string.IsNullOrEmpty(Mensaje))
                return dLote.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Lote obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oAlmacen.IdAlmacen == 0)
                Mensaje = "Debe seleccionar un almacén";
            else if (obj.oEmpresa.IdEmpresa != 0)
                Mensaje = "Debe seleccionar una empresa";
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
                Mensaje = "La descripción no puede ser vacía";
            else if (string.IsNullOrEmpty(obj.NroLote) || string.IsNullOrWhiteSpace(obj.NroLote))
                Mensaje = "La dirección no puede ser vacía";
            else if (obj.Cantidad == 0)
                Mensaje = "La cantidad no puede ser 0";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado para este Lote";

            if (string.IsNullOrEmpty(Mensaje))
                return dLote.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dLote.Eliminar(id, out Mensaje);
        }
    }
}
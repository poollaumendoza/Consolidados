using Consolidados.DataLayer.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.DataLayer
{
    public class Busqueda
    {
        public DataTable Listar(string seleccion, string criterio)
        {
            DataTable Dt = new DataTable();
            string query = string.Empty;

            try
            {
                switch (seleccion)
                {
                    case "contrato":
                        query = "Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where emp.RazonSocial like '%' + @Criterio + '%' union Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where c.NroContrato like '%' + @Criterio + '%' union Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where c.NroContratoLote like '%' + @Criterio + '%' union Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where c.FechaContrato like '%' + @Criterio + '%' union Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where c.FechaCarga like '%' + @Criterio + '%' union Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where c.LugarCarga like '%' + @Criterio + '%' union Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where c.FechaDescarga like '%' + @Criterio + '%' union Select c.IdContrato, c.IdEmpresa, emp.RazonSocial, c.NroContrato, c.NroContratoLote, c.FechaContrato, c.FechaCarga, c.LugarCarga, c.FechaDescarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from contrato c join Empresa emp on c.IdEmpresa = emp.IdEmpresa join Estado es on c.IdEstado = es.IdEstado where c.LugarDescarga like '%' + @Criterio + '%'";
                        break;
                    case "contenedor":
                        query = "Select cc.IdContratoContenedor, c.NroContratoLote, cc.NroContenedor, cc.Payload, cc.IdEstado, e.NombreEstado from ContratoContenedor cc join Contrato c on cc.IdContrato = c.IdContrato join Estado e on cc.IdEstado = e.IdEstado where c.NroContratoLote like '%' + @Criterio + '%' union Select cc.IdContratoContenedor, c.NroContratoLote, cc.NroContenedor, cc.Payload, cc.IdEstado, e.NombreEstado from ContratoContenedor cc join Contrato c on cc.IdContrato = c.IdContrato join Estado e on cc.IdEstado = e.IdEstado where cc.NroContenedor like '%' + @Criterio + '%' union Select cc.IdContratoContenedor, c.NroContratoLote, cc.NroContenedor, cc.Payload, cc.IdEstado, e.NombreEstado from ContratoContenedor cc join Contrato c on cc.IdContrato = c.IdContrato join Estado e on cc.IdEstado = e.IdEstado where Payload like '%' + @Criterio + '%'";
                        break;
                    case "foto":
                        query = "Select cf.IdContratoFoto, cf.IdContrato, c.NroContratoLote, cf.IdContratoContenedor, cc.NroContenedor, cf.Foto, cf.IdEstado, e.NombreEstado from ContratoFoto cf join Contrato c on cf.IdContrato = c.IdContrato join ContratoContenedor cc on cc.IdContrato = cf.IdContrato join Estado e on cf.IdEstado = c.IdEstado where c.NroContratoLote like '%' + @Criterio + '%' union Select cf.IdContratoFoto, cf.IdContrato, c.NroContratoLote, cf.IdContratoContenedor, cc.NroContenedor, cf.Foto, cf.IdEstado, e.NombreEstado from ContratoFoto cf join Contrato c on cf.IdContrato = c.IdContrato join ContratoContenedor cc on cc.IdContrato = cf.IdContrato join Estado e on cf.IdEstado = c.IdEstado where cc.NroContenedor like '%' + @Criterio + '%' union Select cf.IdContratoFoto, cf.IdContrato, c.NroContratoLote, cf.IdContratoContenedor, cc.NroContenedor, cf.Foto, cf.IdEstado, e.NombreEstado from ContratoFoto cf join Contrato c on cf.IdContrato = c.IdContrato join ContratoContenedor cc on cc.IdContrato = cf.IdContrato join Estado e on cf.IdEstado = c.IdEstado where cf.Foto like '%' + @Criterio + '%'";
                        break;
                    case "lote":
                        query = "";
                        break;
                    case "precinto":
                        query = "";
                        break;
                }

                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("@Seleccion", seleccion);
                    Cmd.Parameters.AddWithValue("@Criterio", criterio);
                    Cnx.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(Cmd);
                    Da.Fill(Dt);
                }
            }
            catch(Exception ex)
            {
                string mensaje = ex.Message;
                Dt = new DataTable();
            }

            return Dt;
        }
    }
}
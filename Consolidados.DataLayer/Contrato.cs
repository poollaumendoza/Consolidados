using Consolidados.DataLayer.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.DataLayer
{
    public class Contrato
    {
        public List<EntityLayer.Contrato> Listar()
        {
            List<EntityLayer.Contrato> lista = new List<EntityLayer.Contrato>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    string query =
                        "Select c.IdContrato, c.IdEmpresa, em.RazonSocial, c.NroContrato, c.NroLote, c.FechaContrato, " +
                        "c.FechaCarga, c.FechaDescarga, c.LugarCarga, c.LugarDescarga, c.IdEstado, es.NombreEstado from " +
                        "Contrato c join Empresa em on c.IdEmpresa = em.IdEmpresa join Estado es on c.IdEstado = es.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Contrato()
                            {
                                IdContrato = Convert.ToInt32(Dr["IdContrato"]),
                                oEmpresa = new EntityLayer.Empresa()
                                {
                                    IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                NroContrato = Dr["NroContrato"].ToString(),
                                NroLote = Dr["NroLote"].ToString(),
                                FechaContrato = Convert.ToDateTime(Dr["FechaContrato"]),
                                FechaCarga = Convert.ToDateTime(Dr["FechaCarga"]),
                                LugarCarga = Dr["LugarCarga"].ToString(),
                                FechaDescarga = Convert.ToDateTime(Dr["FechaDescarga"]),
                                LugarDescarga = Dr["LugarDescarga"].ToString(),
                                oEstado = new EntityLayer.Estado()
                                {
                                    IdEstado = Convert.ToInt32(Dr["IdEstado"]),
                                    NombreEstado = Dr["NombreEstado"].ToString()
                                }
                            });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<EntityLayer.Contrato>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Contrato obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Contrato_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("NroContrato", obj.NroContrato);
                    Cmd.Parameters.AddWithValue("NroLote", obj.NroLote);
                    Cmd.Parameters.AddWithValue("FechaContrato", obj.FechaContrato);
                    Cmd.Parameters.AddWithValue("FechaCarga", obj.FechaCarga);
                    Cmd.Parameters.AddWithValue("LugarCarga", obj.LugarCarga);
                    Cmd.Parameters.AddWithValue("FechaDescarga", obj.FechaDescarga);
                    Cmd.Parameters.AddWithValue("LugarDescarga", obj.LugarDescarga);
                    Cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    Cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cnx.Open();
                    Cmd.ExecuteNonQuery();

                    IdAutogenerado = Convert.ToInt32(Cmd.Parameters["Resultado"].Value);
                    Mensaje = Cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdAutogenerado = 0;
                Mensaje = ex.Message;
            }
            return IdAutogenerado;
        }

        public bool Editar(EntityLayer.Contrato obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Contrato_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.IdContrato);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("NroContrato", obj.NroContrato);
                    Cmd.Parameters.AddWithValue("NroLote", obj.NroLote);
                    Cmd.Parameters.AddWithValue("FechaContrato", obj.FechaContrato);
                    Cmd.Parameters.AddWithValue("FechaCarga", obj.FechaCarga);
                    Cmd.Parameters.AddWithValue("LugarCarga", obj.LugarCarga);
                    Cmd.Parameters.AddWithValue("FechaDescarga", obj.FechaDescarga);
                    Cmd.Parameters.AddWithValue("LugarDescarga", obj.LugarDescarga);
                    Cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
                    Cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cnx.Open();
                    Cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(Cmd.Parameters["Resultado"].Value);
                    Mensaje = Cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Contrato_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdContrato", id);
                    Cmd.CommandType = CommandType.Text;
                    Cnx.Open();
                    resultado = Cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
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
    public class Empresa
    {
        public List<EntityLayer.Empresa> Listar()
        {
            List<EntityLayer.Empresa> lista = new List<EntityLayer.Empresa>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    string query =
                        "Select emp.IdEmpresa, emp.IdTipoDocumento, td.NombreTipoDocumento, emp.NroDocumento, emp.RazonSocial, emp.Direccion, emp.Telefono, emp.Email, " +
                        "emp.IdEstado, es.NombreEstado from Empresa emp join TipoDocumento td on emp.IdTipoDocumento = td.IdTipoDocumento join Estado es on emp.IdEstado = " +
                        "es.IdEstado where emp.IdEstado = (Select IdEstado from Estado where NombreEstado = 'ACTIVO')";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Empresa()
                            {
                                IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
                                oTipoDocumento = new EntityLayer.TipoDocumento()
                                {
                                    IdTipoDocumento = Convert.ToInt32(Dr["IdTipoDocumento"]),
                                    NombreTipoDocumento = Dr["NombreTipoDocumento"].ToString()
                                },
                                NroDocumento = Dr["NroDocumento"].ToString(),
                                RazonSocial = Dr["RazonSocial"].ToString(),
                                Direccion = Dr["Direccion"].ToString(),
                                Telefono = Dr["Telefono"].ToString(),
                                Email = Dr["Email"].ToString(),
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
                lista = new List<EntityLayer.Empresa>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Empresa obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Empresa_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
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

        public bool Editar(EntityLayer.Empresa obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Empresa_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.IdEmpresa);
                    Cmd.Parameters.AddWithValue("IdTipoDocumento", obj.oTipoDocumento.IdTipoDocumento);
                    Cmd.Parameters.AddWithValue("NroDocumento", obj.NroDocumento);
                    Cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);
                    Cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    Cmd.Parameters.AddWithValue("Email", obj.Email);
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
                    SqlCommand Cmd = new SqlCommand("sp_Empresa_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdEmpresa", id);
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
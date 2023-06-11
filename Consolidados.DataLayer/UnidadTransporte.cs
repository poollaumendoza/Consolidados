using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.DataLayer
{
    public class UnidadTransporte
    {
        public List<EntityLayer.UnidadTransporte> Listar()
        {
            List<EntityLayer.UnidadTransporte> lista = new List<EntityLayer.UnidadTransporte>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select ut.IdUnidadTransporte, ut.IdEntidad, ent.RazonSocial, ut.IdTransportista, CONCAT(tr.Apellidos, ' ', tr.Nombres)[NombreCompleto], ut.PlacaTracto, ut.IdEstado, est.NombreEstado from UnidadTransporte ut join Entidad ent on ut.IdEntidad = ent.IdEntidad join Transportista tr on ut.IdTransportista = tr.IdTransportista join Estado est on ut.IdEstado = est.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.UnidadTransporte()
                            {
                                IdUnidadTransporte = Convert.ToInt32(Dr["IdUnidadTransporte"]),
                                oEntidad = new EntityLayer.Entidad()
                                {
                                    IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                oTransportista = new EntityLayer.Transportista()
                                {
                                    IdTransportista = Convert.ToInt32(Dr["IdTransportista"]),
                                    NombreCompleto = Dr["NombreCompleto"].ToString()
                                },
                                PlacaTracto = Dr["PlacaTracto"].ToString(),
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
                lista = new List<EntityLayer.UnidadTransporte>();
            }

            return lista;
        }

        public List<EntityLayer.UnidadTransporte> Listar(int IdUnidadTransporte)
        {
            List<EntityLayer.UnidadTransporte> lista = new List<EntityLayer.UnidadTransporte>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "select ut.IdUnidadTransporte, ut.IdEntidad, ent.RazonSocial, ut.IdTransportista, CONCAT(tr.Apellidos, ' ', tr.Nombres)[NombreCompleto], ut.PlacaTracto, ut.IdEstado, est.NombreEstado from UnidadTransporte ut join Entidad ent on ut.IdEntidad = ent.IdEntidad join Transportista tr on ut.IdTransportista = tr.IdTransportista join Estado est on ut.IdEstado = est.IdEstado where ut.IdUnidadTransportista = @IdUnidadTransporte";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("IdUnidadTransporte", IdUnidadTransporte);
                    Cmd.CommandType = CommandType.Text;

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.UnidadTransporte()
                            {
                                IdUnidadTransporte = Convert.ToInt32(Dr["IdUnidadTransporte"]),
                                oEntidad = new EntityLayer.Entidad()
                                {
                                    IdEntidad = Convert.ToInt32(Dr["IdEntidad"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                oTransportista = new EntityLayer.Transportista()
                                {
                                    IdTransportista = Convert.ToInt32(Dr["IdTransportista"]),
                                    NombreCompleto = Dr["NombreCompleto"].ToString()
                                },
                                PlacaTracto = Dr["PlacaTracto"].ToString(),
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
                lista = new List<EntityLayer.UnidadTransporte>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.UnidadTransporte obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_UnidadTransporte_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdTransportista", obj.oTransportista.IdTransportista);
                    Cmd.Parameters.AddWithValue("PlacaTracto", obj.PlacaTracto);
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

        public bool Editar(EntityLayer.UnidadTransporte obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_UnidadTransporte_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdUnidadTransporte", obj.IdUnidadTransporte);
                    Cmd.Parameters.AddWithValue("IdEntidad", obj.oEntidad.IdEntidad);
                    Cmd.Parameters.AddWithValue("IdTransportista", obj.oTransportista.IdTransportista);
                    Cmd.Parameters.AddWithValue("PlacaTracto", obj.PlacaTracto);
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
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_UnidadTransporte_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdUnidadTransporte", id);
                    Cmd.CommandType = CommandType.StoredProcedure;
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
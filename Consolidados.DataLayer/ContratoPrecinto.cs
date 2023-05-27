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
    public class ContratoPrecinto
    {
        public List<EntityLayer.ContratoPrecinto> Listar()
        {
            List<EntityLayer.ContratoPrecinto> lista = new List<EntityLayer.ContratoPrecinto>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    string query =
                        "";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoPrecinto()
                            {
                                IdContratoPrecinto = Convert.ToInt32(Dr["IdContratoPrecinto"]),
                                oContrato = new EntityLayer.Contrato()
                                {
                                    IdContrato = Convert.ToInt32(Dr["IdContrato"]),
                                    NroContratoLote = Dr["NroContratoLote"].ToString()
                                },
                                oContratoContenedor = new EntityLayer.ContratoContenedor()
                                {
                                    IdContratoContenedor = Convert.ToInt32(Dr["IdContratoContenedor"]),
                                    NroContenedor = Dr["NroContenedor"].ToString()
                                },
                                NroPrecinto = Dr["PesoTotal"].ToString(),
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
                lista = new List<EntityLayer.ContratoPrecinto>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ContratoPrecinto obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoPrecinto_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.oContratoContenedor.IdContratoContenedor);
                    Cmd.Parameters.AddWithValue("NroPrecinto", obj.NroPrecinto);
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

        public bool Editar(EntityLayer.ContratoPrecinto obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoPrecinto_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoPrecinto", obj.IdContratoPrecinto);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContatoContenedor", obj.oContratoContenedor.IdContratoContenedor);
                    Cmd.Parameters.AddWithValue("NroPrecinto", obj.NroPrecinto);
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
                    SqlCommand Cmd = new SqlCommand("sp_ContratoPrecinto_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdContratoPrecinto", id);
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
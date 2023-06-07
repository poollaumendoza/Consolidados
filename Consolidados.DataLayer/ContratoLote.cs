using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.DataLayer
{
    public class ContratoLote
    {
        public List<EntityLayer.ContratoLote> Listar()
        {
            List<EntityLayer.ContratoLote> lista = new List<EntityLayer.ContratoLote>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select cl.IdContratoLote, cl.IdContrato, c.NroContratoLote, cl.IdLote, l.NroLote, cl.Cantidad, cl.IdEstado, e.NombreEstado from ContratoLote cl join contrato c on cl.IdContrato = c.IdContrato join Lote l on cl.IdLote = l.IdLote join estado e on cl.IdEstado = e.IdEstado where cl.IdEstado = (Select IdEstado from Estado where NombreEstado = 'ACTIVO')";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoLote()
                            {
                                IdContratoLote = Convert.ToInt32(Dr["IdContratoLote"]),
                                oContrato = new EntityLayer.Contrato()
                                {
                                    IdContrato = Convert.ToInt32(Dr["IdContrato"]),
                                    NroContratoLote = Dr["NroContratoLote"].ToString()
                                },
                                oLote = new EntityLayer.Lote()
                                {
                                    IdLote = Convert.ToInt32(Dr["IdLote"]),
                                    NroLote = Dr["NroLote"].ToString()
                                },
                                Cantidad = Convert.ToInt32(Dr["Cantidad"]),
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
                lista = new List<EntityLayer.ContratoLote>();
            }

            return lista;
        }

        public int ObtenerCantidadPorLote(int IdContrato, int IdLote)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query = "Select Cantidad from ContratoLote where IdContrato = @IdContrato and IdLote = @IdLote";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("@IdContrato", IdContrato);
                    Cmd.Parameters.AddWithValue("@IdLote", IdLote);
                    Cmd.CommandType = CommandType.Text;

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            resultado = Convert.ToInt32(Dr["Cantidad"]);
                        }
                    }
                }
            }
            catch
            {
                resultado = 0;
            }

            return resultado;
        }

        public List<EntityLayer.ContratoLote> Listar(int IdContrato)
        {
            List<EntityLayer.ContratoLote> lista = new List<EntityLayer.ContratoLote>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select cl.IdContratoLote, cl.IdContrato, c.NroContratoLote, cl.IdLote, l.NroLote, cl.Cantidad, cl.IdEstado, e.NombreEstado from ContratoLote cl join contrato c on cl.IdContrato = c.IdContrato join Lote l on cl.IdLote = l.IdLote join estado e on cl.IdEstado = e.IdEstado where cl.IdContrato = @IdContrato";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("@IdContrato", IdContrato);
                    Cmd.CommandType = CommandType.Text;

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoLote()
                            {
                                IdContratoLote = Convert.ToInt32(Dr["IdContratoLote"]),
                                oContrato = new EntityLayer.Contrato()
                                {
                                    IdContrato = Convert.ToInt32(Dr["IdContrato"]),
                                    NroContratoLote = Dr["NroContratoLote"].ToString()
                                },
                                oLote = new EntityLayer.Lote()
                                {
                                    IdLote = Convert.ToInt32(Dr["IdLote"]),
                                    NroLote = Dr["NroLote"].ToString()
                                },
                                Cantidad = Convert.ToInt32(Dr["Cantidad"]),
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
                lista = new List<EntityLayer.ContratoLote>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ContratoLote obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoLote_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdLote", obj.oLote.IdLote);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
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

        public bool Editar(EntityLayer.ContratoLote obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoLote_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoLote", obj.IdContratoLote);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdLote", obj.oLote.IdLote);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
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
                    SqlCommand Cmd = new SqlCommand("sp_ContratoLote_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdContratoLote", id);
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
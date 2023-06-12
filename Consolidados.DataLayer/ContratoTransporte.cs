using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Consolidados.EntityLayer;

namespace Consolidados.DataLayer
{
    public class ContratoTransporte
    {
        public List<EntityLayer.ContratoTransporte> Listar()
        {
            List<EntityLayer.ContratoTransporte> lista = new List<EntityLayer.ContratoTransporte>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select ct.IdContratoTransporte, ct.IdContrato, c.NroContratoLote, ct.IdUnidadTransporte, ut.PlacaTracto, ct.IdLote, l.NroLote, ct.Cantidad, ct.Peso, ct.IdEstado, e.NombreEstado from ContratoTransporte ct join Contrato c on ct.IdContrato = c.IdContrato join UnidadTransporte ut on ct.IdUnidadTransporte = ut.IdUnidadTransporte join lote l on ct.IdLote = l.IdLote join Estado e on ct.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoTransporte()
                            {
                                IdContratoTransporte = Convert.ToInt32(Dr["IdContratoTransporte"]),
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
                                Peso = Convert.ToInt32(Dr["Peso"]),
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
                lista = new List<EntityLayer.ContratoTransporte>();
            }

            return lista;
        }

        public List<EntityLayer.ContratoTransporte> Listar(int IdContrato)
        {
            List<EntityLayer.ContratoTransporte> lista = new List<EntityLayer.ContratoTransporte>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select ct.IdContratoTransporte, ct.IdContrato, c.NroContratoLote, ct.IdUnidadTransporte, ut.PlacaTracto, ct.IdLote, l.NroLote, ct.Cantidad, ct.Peso, ct.IdEstado, e.NombreEstado from ContratoTransporte ct join Contrato c on ct.IdContrato = c.IdContrato join UnidadTransporte ut on ct.IdUnidadTransporte = ut.IdUnidadTransporte join lote l on ct.IdLote = l.IdLote join Estado e on ct.IdEstado = e.IdEstado where ct.IdContrato = @IdContrato";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", IdContrato);
                    Cmd.CommandType = CommandType.Text;

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoTransporte()
                            {
                                IdContratoTransporte = Convert.ToInt32(Dr["IdContratoTransporte"]),
                                oUnidadTransporte = new EntityLayer.UnidadTransporte()
                                {
                                    IdUnidadTransporte = Convert.ToInt32(Dr["IdUnidadTransporte"]),
                                    PlacaTracto = Dr["PlacaTracto"].ToString()
                                },
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
                                Peso = Convert.ToInt32(Dr["Peso"]),
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
                lista = new List<EntityLayer.ContratoTransporte>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ContratoTransporte obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoTransporte_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdUnidadTransporte", obj.oUnidadTransporte.IdUnidadTransporte);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdLote", obj.oLote.IdLote);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("Peso", obj.Peso);
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

        public bool Editar(EntityLayer.ContratoTransporte obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoTransporte_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoTransporte", obj.IdContratoTransporte);
                    Cmd.Parameters.AddWithValue("IdUnidadTransporte", obj.oUnidadTransporte.IdUnidadTransporte);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdLote", obj.oLote.IdLote);
                    Cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);
                    Cmd.Parameters.AddWithValue("Peso", obj.Peso);
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
                    SqlCommand Cmd = new SqlCommand("sp_ContratoTransporte_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdContratoTransporte", id);
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
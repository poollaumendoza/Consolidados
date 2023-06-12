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
    public class LlenadoContenedor
    {
        public List<EntityLayer.LlenadoContenedor> Listar()
        {
            List<EntityLayer.LlenadoContenedor> lista = new List<EntityLayer.LlenadoContenedor>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select llc.IdLlenadoContenedor, llc.IdContrato, c.NroContratoLote, llc.IdContratoContenedor, cc.NroContenedor, llc.IdLote, l.NroLote, llc.Cantidad, llc.IdEstado, e.NombreEstado from LlenadoContenedor llc join contrato c on llc.IdContrato = c.IdContrato join ContratoContenedor cc on llc.IdContratoContenedor = cc.IdContratoContenedor join Lote l on llc.IdLote = l.IdLote join Estado e on llc.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.LlenadoContenedor()
                            {
                                IdLlenadoContenedor = Convert.ToInt32(Dr["IdLlenadoContenedor"]),
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
                lista = new List<EntityLayer.LlenadoContenedor>();
            }

            return lista;
        }

        public List<EntityLayer.LlenadoContenedor> Listar(int IdContrato)
        {
            List<EntityLayer.LlenadoContenedor> lista = new List<EntityLayer.LlenadoContenedor>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select llc.IdLlenadoContenedor, llc.IdContrato, c.NroContratoLote, llc.IdContratoContenedor, cc.NroContenedor, llc.IdLote, l.NroLote, llc.Cantidad, llc.IdEstado, e.NombreEstado from LlenadoContenedor llc join contrato c on llc.IdContrato = c.IdContrato join ContratoContenedor cc on llc.IdContratoContenedor = cc.IdContratoContenedor join Lote l on llc.IdLote = l.IdLote join Estado e on llc.IdEstado = e.IdEstado where llc.IdContrato = @IdContrato";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", IdContrato);
                    Cmd.CommandType = CommandType.Text;

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.LlenadoContenedor()
                            {
                                IdLlenadoContenedor = Convert.ToInt32(Dr["IdLlenadoContenedor"]),
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
                lista = new List<EntityLayer.LlenadoContenedor>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.LlenadoContenedor obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_LlenadoContenedor_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.oContratoContenedor.IdContratoContenedor);
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

        public bool Editar(EntityLayer.LlenadoContenedor obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_LlenadoContenedor_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdLlenadoContenedor", obj.IdLlenadoContenedor);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.oContratoContenedor.IdContratoContenedor);
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
                    SqlCommand Cmd = new SqlCommand("sp_LlenadoContenedor_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdLlenadoContenedor", id);
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
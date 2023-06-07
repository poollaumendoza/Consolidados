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
    public class ContratoPrecinto
    {
        public List<EntityLayer.ContratoPrecinto> Listar()
        {
            List<EntityLayer.ContratoPrecinto> lista = new List<EntityLayer.ContratoPrecinto>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select cp.IdContratoPrecinto, cp.IdContrato, c.NroContratoLote, cp.IdContratoContenedor, cc.NroContenedor, cp.NroPrecinto, cp.IdEstado, " +
                        "e.NombreEstado from ContratoPrecinto cp join Contrato c on cp.IdContrato = c.IdContrato join ContratoContenedor cc on cp.IdContratoContenedor = " +
                        "cc.IdContratoContenedor join Estado e on cp.IdEstado = e.IdEstado";
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
                                NroPrecinto = Dr["NroPrecinto"].ToString(),
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
            catch(Exception ex)
            {
                string mensaje = ex.Message;
                lista = new List<EntityLayer.ContratoPrecinto>();
            }

            return lista;
        }

        public List<EntityLayer.ContratoPrecinto> Listar(string objeto, object valor)
        {
            List<EntityLayer.ContratoPrecinto> lista = new List<EntityLayer.ContratoPrecinto>();
            string query = string.Empty;

            switch (objeto)
            {
                case "IdContrato":
                    query = 
                        "Select cp.IdContratoPrecinto, cp.IdContrato, c.NroContratoLote, cp.IdContratoContenedor, cc.NroContenedor, cp.NroPrecinto, cp.IdEstado, " +
                        "e.NombreEstado from ContratoPrecinto cp join Contrato c on cp.IdContrato = c.IdContrato join ContratoContenedor cc on cp.IdContratoContenedor = " +
                        "cc.IdContratoContenedor join Estado e on cp.IdEstado = e.IdEstado where cp.IdContrato = @IdContrato";
                    break;
                case "IdContratoPrecinto":
                    query =
                        "Select cp.IdContratoPrecinto, cp.IdContrato, c.NroContratoLote, cp.IdContratoContenedor, cc.NroContenedor, cp.NroPrecinto, cp.IdEstado, " +
                        "e.NombreEstado from ContratoPrecinto cp join Contrato c on cp.IdContrato = c.IdContrato join ContratoContenedor cc on cp.IdContratoContenedor = " +
                        "cc.IdContratoContenedor join Estado e on cp.IdEstado = e.IdEstado where cp.IdContratoPrecinto = @IdContratoPrecinto";
                    break;
            }

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue(objeto, valor);
                    Cmd.CommandType = CommandType.Text;

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
                                NroPrecinto = Dr["NroPrecinto"].ToString(),
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
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
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
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoPrecinto_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoPrecinto", obj.IdContratoPrecinto);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.oContratoContenedor.IdContratoContenedor);
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
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
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
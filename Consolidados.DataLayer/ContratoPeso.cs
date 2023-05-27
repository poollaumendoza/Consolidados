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
    public class ContratoPeso
    {
        public List<EntityLayer.ContratoPeso> Listar()
        {
            List<EntityLayer.ContratoPeso> lista = new List<EntityLayer.ContratoPeso>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    string query =
                        "Select cp.IdContratoPeso, cp.IdContrato, c.NroContratoLote, cp.IdContratoContenedor, cc.NroContenedor, " +
                        "cp.PesoTotal, cp.IdEstado, e.NombreEstado from ContratoPeso cp join Contrato c on cp.IdContrato = " +
                        "c.IdContrato join ContratoContenedor cc on cp.IdContratoContenedor = cc.IdContratoContenedor join " +
                        "Estado e on cp.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoPeso()
                            {
                                IdContratoPeso = Convert.ToInt32(Dr["IdContratoPeso"]),
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
                                PesoTotal = Convert.ToInt32(Dr["PesoTotal"]),
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
                lista = new List<EntityLayer.ContratoPeso>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ContratoPeso obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoPeso_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.oContratoContenedor.IdContratoContenedor);
                    Cmd.Parameters.AddWithValue("PesoTotal", obj.PesoTotal);
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

        public bool Editar(EntityLayer.ContratoPeso obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoPeso_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoPeso", obj.IdContratoPeso);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContatoContenedor", obj.oContratoContenedor.IdContratoContenedor);
                    Cmd.Parameters.AddWithValue("PesoTotal", obj.PesoTotal);
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
                    SqlCommand Cmd = new SqlCommand("sp_ContratoPeso_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdContratoPeso", id);
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
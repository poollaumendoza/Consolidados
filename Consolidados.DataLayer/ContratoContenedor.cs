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
    public class ContratoContenedor
    {
        public List<EntityLayer.ContratoContenedor> Listar()
        {
            List<EntityLayer.ContratoContenedor> lista = new List<EntityLayer.ContratoContenedor>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    string query =
                        "Select cc.IdContratoContenedor, cc.IdContrato, c.NroContratoLote, cc.NroContenedor, cc.Payload, " +
                        "cc.IdEstado, e.NombreEstado from ContratoContenedor cc join Contrato c on cc.IdContrato = c.IdContrato " +
                        "join Estado e on cc.IdEstado = e.IdEstado where cc.IdEstado = (Select IdEstado from Estado where NombreEstado " +
                        "= 'ACTIVO')";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoContenedor()
                            {
                                IdContratoContenedor = Convert.ToInt32(Dr["IdContratoContenedor"]),
                                oContrato = new EntityLayer.Contrato()
                                {
                                    IdContrato = Convert.ToInt32(Dr["IdContrato"]),
                                    NroContratoLote = Dr["NroContratoLote"].ToString()
                                },
                                NroContenedor = Dr["NroContenedor"].ToString(),
                                Payload = Convert.ToInt32(Dr["Payload"]),
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
                lista = new List<EntityLayer.ContratoContenedor>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ContratoContenedor obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoContenedor_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("NroContenedor", obj.NroContenedor);
                    Cmd.Parameters.AddWithValue("Payload", obj.Payload);
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

        public bool Editar(EntityLayer.ContratoContenedor obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(Settings.Default.CadenaConexion))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoContenedor_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.IdContratoContenedor);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("NroContenedor", obj.NroContenedor);
                    Cmd.Parameters.AddWithValue("Payload", obj.Payload);
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
                    SqlCommand Cmd = new SqlCommand("sp_ContratoContenedor_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdContratoContenedor", id);
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
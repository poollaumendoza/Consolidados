using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.DataLayer
{
    public class ContratoFoto
    {
        public List<EntityLayer.ContratoFoto> Listar()
        {
            List<EntityLayer.ContratoFoto> lista = new List<EntityLayer.ContratoFoto>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select cf.IdContratoFoto, cf.IdContrato, c.NroContratoLote, cf.IdContratoContenedor, cc.NroContenedor, cf.Foto, cf.IdEstado, e.NombreEstado from ContratoFoto cf join Contrato c on cf.IdContrato = c.IdContrato join ContratoContenedor cc on cf.IdContratoContenedor = cc.IdContratoContenedor join Estado e on cf.IdEstado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ContratoFoto()
                            {
                                IdContratoFoto = Convert.ToInt32(Dr["IdContratoFoto"]),
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
                                Foto = Dr["Foto"].ToString(),
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
                lista = new List<EntityLayer.ContratoFoto>();
            }

            return lista;
        }

        public List<EntityLayer.ContratoFoto> Listar(string objeto, object valor)
        {
            List<EntityLayer.ContratoFoto> lista = new List<EntityLayer.ContratoFoto>();
            string query = string.Empty;

            switch (objeto)
            {
                case "IdContratoFoto":
                    query = "Select cf.IdContratoFoto, cf.IdContrato, c.NroContratoLote, cf.IdContratoContenedor, cc.NroContenedor, cf.Foto, " +
                        "cf.IdEstado, e.NombreEstado from ContratoFoto cf join Contrato c on cf.IdContrato = c.IdContrato join ContratoContenedor " +
                        "cc on cf.IdContratoContenedor = cc.IdContratoContenedor join Estado e on cf.IdEstado = e.IdEstado where cf.IdContratoFoto = " +
                        "@IdContratoFoto";
                    break;
                case "IdContrato":
                    query = "Select cf.IdContratoFoto, cf.IdContrato, c.NroContratoLote, cf.IdContratoContenedor, cc.NroContenedor, cf.Foto, " +
                        "cf.IdEstado, e.NombreEstado from ContratoFoto cf join Contrato c on cf.IdContrato = c.IdContrato join ContratoContenedor cc " +
                        "on cf.IdContratoContenedor = cc.IdContratoContenedor join Estado e on cf.IdEstado = e.IdEstado where cf.IdContrato = " +
                        "@IdContrato";
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
                            lista.Add(new EntityLayer.ContratoFoto()
                            {
                                IdContratoFoto = Convert.ToInt32(Dr["IdContratoFoto"]),
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
                                Foto = Dr["Foto"].ToString(),
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
                lista = new List<EntityLayer.ContratoFoto>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ContratoFoto obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoFoto_RegistrarWeb", Cnx);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.oContratoContenedor.IdContratoContenedor);
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

        public bool Editar(EntityLayer.ContratoFoto obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ContratoFoto_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoFoto", obj.IdContratoFoto);
                    Cmd.Parameters.AddWithValue("IdContrato", obj.oContrato.IdContrato);
                    Cmd.Parameters.AddWithValue("IdContratoContenedor", obj.oContratoContenedor.IdContratoContenedor);
                    Cmd.Parameters.AddWithValue("Foto", obj.Foto);
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
                    SqlCommand Cmd = new SqlCommand("sp_ContratoFoto_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdContratoFoto", id);
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

        public bool GuardarFoto(EntityLayer.ContratoFoto oContratoFoto, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("Update ContratoFoto set Foto = @Foto where IdContratoFoto = @IdContratoFoto", Cnx);
                    Cmd.Parameters.AddWithValue("IdContratoFoto", oContratoFoto.IdContratoFoto);
                    Cmd.Parameters.AddWithValue("Foto", oContratoFoto.Foto);
                    Cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    Cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    Cmd.CommandType = CommandType.Text;
                    Cnx.Open();

                    if (Cmd.ExecuteNonQuery() > 0)
                        resultado = true;
                    else
                        Mensaje = "No se puede actualizar imagen";
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
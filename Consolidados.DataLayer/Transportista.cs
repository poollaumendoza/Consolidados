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
    public class Transportista
    {
        public List<EntityLayer.Transportista> Listar()
        {
            List<EntityLayer.Transportista> lista = new List<EntityLayer.Transportista>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select t.IdTransportista, t.Apellidos, t.Nombres, t.DNI, t.LicConducir, t.Telefono, t.IdEstado, e.NombreEstado from Transportista t join estado e on t.idestado = e.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Transportista()
                            {
                                IdTransportista = Convert.ToInt32(Dr["IdTransportista"]),
                                Apellidos = Dr["Apellidos"].ToString(),
                                Nombres = Dr["Nombres"].ToString(),
                                DNI = Dr["DNI"].ToString(),
                                LicConducir = Dr["LicConducir"].ToString(),
                                Telefono = Dr["Telefono"].ToString(),
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
                lista = new List<EntityLayer.Transportista>();
            }

            return lista;
        }

        public List<EntityLayer.Transportista> Listar(int IdTransportista)
        {
            List<EntityLayer.Transportista> lista = new List<EntityLayer.Transportista>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select t.IdTransportista, t.Apellidos, t.Nombres, t.DNI, t.LicConducir, t.Telefono, t.IdEstado, e.NombreEstado from Transportista t join estado e on t.idestado = e.IdEstado where t.IdTransportista = @IdTransportista";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("IdTransportista", IdTransportista);
                    Cmd.CommandType = System.Data.CommandType.Text;

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Transportista()
                            {
                                IdTransportista = Convert.ToInt32(Dr["IdTransportista"]),
                                Apellidos = Dr["Apellidos"].ToString(),
                                Nombres = Dr["Nombres"].ToString(),
                                DNI = Dr["DNI"].ToString(),
                                LicConducir = Dr["LicConducir"].ToString(),
                                Telefono = Dr["Telefono"].ToString(),
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
                lista = new List<EntityLayer.Transportista>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Transportista obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Transportista_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("Nombres", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("DNI", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("LicConducir", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Apellidos);
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

        public bool Editar(EntityLayer.Transportista obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Transportista_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdTransportista", obj.IdTransportista);
                    Cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("Nombres", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("DNI", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("LicConducir", obj.Apellidos);
                    Cmd.Parameters.AddWithValue("Telefono", obj.Apellidos);
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
                    SqlCommand Cmd = new SqlCommand("sp_Transportista_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdTransportista", id);
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
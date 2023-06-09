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
    public class ClasificacionTipoDocumento
    {
        public List<EntityLayer.ClasificacionTipoDocumento> Listar()
        {
            List<EntityLayer.ClasificacionTipoDocumento> lista = new List<EntityLayer.ClasificacionTipoDocumento>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select ctd.IdClasificacionTipoDocumento, ctd.NombreClasificacionTipoDocumento, ctd.IdEstado, e.NombreEstado " +
                        "from ClasificacionTipoDocumento ctd join Estado e on ctd.IdEstado = e.IdEstado and ctd.IdEstado = (Select " +
                        "IdEstado from Estado Where NombreEstado = 'ACTIVO')";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.ClasificacionTipoDocumento()
                            {
                                IdClasificacionTipoDocumento = Convert.ToInt32(Dr["IdClasificacionTipoDocumento"]),
                                NombreClasificacionTipoDocumento = Dr["NombreClasificacionTipoDocumento"].ToString(),
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
                lista = new List<EntityLayer.ClasificacionTipoDocumento>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.ClasificacionTipoDocumento obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ClasificacionTipoDocumento_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("NombreClasificacionTipoDocumento", obj.NombreClasificacionTipoDocumento);
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

        public bool Editar(EntityLayer.ClasificacionTipoDocumento obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_ClasificacionTipoDocumento_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdClasificacionTipoDocumento", obj.IdClasificacionTipoDocumento);
                    Cmd.Parameters.AddWithValue("NombreClasificacionTipoDocumento", obj.NombreClasificacionTipoDocumento);
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
                    SqlCommand Cmd = new SqlCommand("sp_ClasificacionTipoDocumento_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdClasificacionTipoDocumento", id);
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
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
    public class Lote
    {
        public List<EntityLayer.Lote> Listar()
        {
            List<EntityLayer.Lote> lista = new List<EntityLayer.Lote>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select lt.IdLote, lt.IdAlmacen, a.NombreAlmacen, lt.IdEmpresa, emp.RazonSocial, lt.Descripcion, " +
                        "lt.NroLote, lt.Cantidad, lt.IdEstado, est.NombreEstado from Lote lt join Almacen a on a.IdAlmacen = " +
                        "lt.IdAlmacen join Empresa emp on emp.IdEmpresa = lt.IdEmpresa join estado est on lt.IdEstado = " +
                        "est.IdEstado";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Lote()
                            {
                                IdLote = Convert.ToInt32(Dr["IdLote"]),
                                oAlmacen = new EntityLayer.Almacen()
                                {
                                    IdAlmacen = Convert.ToInt32(Dr["IdAlmacen"]),
                                    NombreAlmacen = Dr["NombreAlmacen"].ToString()
                                },
                                oEmpresa = new EntityLayer.Empresa()
                                {
                                    IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                Descripcion = Dr["Descripcion"].ToString(),
                                NroLote = Dr["NroLote"].ToString(),
                                Cantidad = Convert.ToInt32(Dr["Cantidad"].ToString()),
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
                lista = new List<EntityLayer.Lote>();
            }

            return lista;
        }

        public List<EntityLayer.Lote> Listar(int IdLote)
        {
            List<EntityLayer.Lote> lista = new List<EntityLayer.Lote>();

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    string query =
                        "Select lt.IdLote, lt.IdAlmacen, a.NombreAlmacen, lt.IdEmpresa, emp.RazonSocial, lt.Descripcion, " +
                        "lt.NroLote, lt.Cantidad, lt.IdEstado, est.NombreEstado from Lote lt join Almacen a on a.IdAlmacen = " +
                        "lt.IdAlmacen join Empresa emp on emp.IdEmpresa = lt.IdEmpresa join estado est on lt.IdEstado = " +
                        "est.IdEstado where lt.IdLote = @IdLote";
                    SqlCommand Cmd = new SqlCommand(query, Cnx);
                    Cmd.Parameters.AddWithValue("IdLote", IdLote);
                    Cmd.CommandType = CommandType.Text;

                    Cnx.Open();
                    using (SqlDataReader Dr = Cmd.ExecuteReader())
                    {
                        while (Dr.Read())
                        {
                            lista.Add(new EntityLayer.Lote()
                            {
                                IdLote = Convert.ToInt32(Dr["IdLote"]),
                                oAlmacen = new EntityLayer.Almacen()
                                {
                                    IdAlmacen = Convert.ToInt32(Dr["IdAlmacen"]),
                                    NombreAlmacen = Dr["NombreAlmacen"].ToString()
                                },
                                oEmpresa = new EntityLayer.Empresa()
                                {
                                    IdEmpresa = Convert.ToInt32(Dr["IdEmpresa"]),
                                    RazonSocial = Dr["RazonSocial"].ToString()
                                },
                                Descripcion = Dr["Descripcion"].ToString(),
                                NroLote = Dr["NroLote"].ToString(),
                                Cantidad = Convert.ToInt32(Dr["Cantidad"].ToString()),
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
                lista = new List<EntityLayer.Lote>();
            }

            return lista;
        }

        public int Registrar(EntityLayer.Lote obj, out string Mensaje)
        {
            int IdAutogenerado = 0;

            Mensaje = string.Empty;
            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Lote_Registrar", Cnx);
                    Cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    Cmd.Parameters.AddWithValue("NroLote", obj.NroLote);
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

        public bool Editar(EntityLayer.Lote obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
                {
                    SqlCommand Cmd = new SqlCommand("sp_Lote_Editar", Cnx);
                    Cmd.Parameters.AddWithValue("IdLote", obj.IdLote);
                    Cmd.Parameters.AddWithValue("IdAlmacen", obj.oAlmacen.IdAlmacen);
                    Cmd.Parameters.AddWithValue("IdEmpresa", obj.oEmpresa.IdEmpresa);
                    Cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    Cmd.Parameters.AddWithValue("NroLote", obj.NroLote);
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
                    SqlCommand Cmd = new SqlCommand("sp_Lote_Eliminar", Cnx);
                    Cmd.Parameters.AddWithValue("@IdLote", id);
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
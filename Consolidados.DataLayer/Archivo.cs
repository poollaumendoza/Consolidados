using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolidados.DataLayer
{
    public class Archivo
    {
        public List<EntityLayer.Archivo> CargarListaArchivosPaquete(int IdContrato)
        {
            List<EntityLayer.Archivo> oLista = new List<EntityLayer.Archivo>();

            using (SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString()))
            {
                SqlCommand Cmd = new SqlCommand("sp_Archivos_CLAP", Cnx);
                Cmd.Parameters.AddWithValue("@IdContrato", IdContrato);
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cnx.Open();

                using (SqlDataReader Dr = Cmd.ExecuteReader())
                {
                    while (Dr.Read())
                    {
                        oLista.Add(new EntityLayer.Archivo()
                        {
                            NroContrato = Dr["NroContratoLote"].ToString(),
                            NroContenedor = Dr["NroContenedor"].ToString(),
                            NombreArchivo = Dr["Foto"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }
    }
}
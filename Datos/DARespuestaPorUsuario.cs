using Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DARespuestaPorUsuario
    {
        public List<Respuesta> listarRespuestasPorUsuarioDA(int idUsuario)
        {
            List<Respuesta> list_respuesta = new List<Respuesta>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spObtenerRespuestasPorUsuario", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = idUsuario;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.HasRows)
                                {
                                    Respuesta respuesta = new Respuesta();
                                    respuesta.idRespuesta = int.Parse(reader["idRespuesta"].ToString());
                                    respuesta.nombre = reader["nombre"].ToString();
                                    respuesta.fecha = reader["fecha"].ToString();
                                    respuesta.idUsuario = int.Parse(reader["idUsuario"].ToString());
                                    respuesta.nombreUsuario = reader["nombreUsuario"].ToString();
                                    respuesta.rutaImagen = reader["rutaImagen"].ToString();
                                    respuesta.idPregunta = int.Parse(reader["idPregunta"].ToString());
                                    list_respuesta.Add(respuesta);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                    finally
                    {
                        connection.Close();
                    }
                    return list_respuesta;
                }
            }
        }

    }
}

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
    public class DARespuesta
    {
        public int eliminarRespuestaDA(int idRespuesta)
        {
            int respuesta; // = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spEliminarRespuesta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idRespuesta", System.Data.SqlDbType.Int).Value = idRespuesta;

                    try
                    {
                        connection.Open();
                        respuesta = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                        respuesta = 0;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            return respuesta;
        }

        public int actualizarRespuestaDA(Respuesta respuesta)
        {
            int response; // = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spActualizarRespuesta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idRespuesta", System.Data.SqlDbType.Int).Value = respuesta.idRespuesta;
                    command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 200).Value = respuesta.nombre;
                    command.Parameters.Add("@rutaImagen", System.Data.SqlDbType.VarChar, 250).Value = respuesta.rutaImagen;

                    try
                    {
                        connection.Open();
                        response = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                        response = 0;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            return response;
        }

        public int grabarRespuestaDA(Respuesta respuesta)
        {
            int response; // = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spGrabarRespuesta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 200).Value = respuesta.nombre;
                    command.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = respuesta.idUsuario;
                    command.Parameters.Add("@rutaImagen", System.Data.SqlDbType.VarChar, 150).Value = respuesta.rutaImagen;
                    command.Parameters.Add("@idPregunta", System.Data.SqlDbType.Int).Value = respuesta.idPregunta;

                    try
                    {
                        connection.Open();
                        response = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //throw ex;
                        response = 0;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
            return response;
        }
    }
}

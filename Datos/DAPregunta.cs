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
    public class DAPregunta
    {
        public List<Pregunta> listarPreguntasDA()
        {
            List<Pregunta> list_pregunta = new List<Pregunta>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spObtenerPreguntas", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.HasRows)
                                {
                                    Pregunta pregunta = new Pregunta();
                                    pregunta.idPregunta = int.Parse(reader["idPregunta"].ToString());
                                    pregunta.nombre = reader["nombre"].ToString();
                                    pregunta.fecha = reader["fecha"].ToString();
                                    pregunta.tema = reader["tema"].ToString();
                                    pregunta.nombreUsuario = reader["nombreUsuario"].ToString();
                                    pregunta.rutaImagen = reader["rutaImagen"].ToString();                                    
                                    list_pregunta.Add(pregunta);
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
                    return list_pregunta;
                }
            }
        }

        public List<Pregunta> listarPreguntasPorUsuarioDA(int idUsuario)
        {
            List<Pregunta> list_pregunta = new List<Pregunta>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spObtenerPreguntasPorCodigo", connection))
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
                                    Pregunta pregunta = new Pregunta();
                                    pregunta.idPregunta = int.Parse(reader["idPregunta"].ToString());
                                    pregunta.nombre = reader["nombre"].ToString();
                                    pregunta.fecha = reader["fecha"].ToString();
                                    pregunta.tema = reader["tema"].ToString();
                                    pregunta.nombreUsuario = reader["nombreUsuario"].ToString();
                                    pregunta.rutaImagen = reader["rutaImagen"].ToString();
                                    list_pregunta.Add(pregunta);
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
                    return list_pregunta;
                }
            }
        }


        public int eliminarPreguntaDA(int idPregunta)
        {
            int respuesta; // = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spEliminarPregunta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idPregunta", System.Data.SqlDbType.Int).Value = idPregunta;

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

        public int actualizarPreguntaDA(Pregunta pregunta)
        {
            int respuesta; // = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spActualizarPregunta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idPregunta", System.Data.SqlDbType.Int).Value = pregunta.idPregunta;
                    command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 200).Value = pregunta.nombre;
                    command.Parameters.Add("@tema", System.Data.SqlDbType.VarChar, 50).Value = pregunta.tema;
                    command.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = pregunta.idUsuario;
                    command.Parameters.Add("@rutaImagen", System.Data.SqlDbType.VarChar, 250).Value = pregunta.rutaImagen;

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

        public int grabarPreguntaDA(Pregunta pregunta)
        {
            int respuesta; // = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spGrabarPregunta", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 200).Value = pregunta.nombre;
                    command.Parameters.Add("@tema", System.Data.SqlDbType.VarChar, 50).Value = pregunta.tema;
                    command.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int).Value = pregunta.idUsuario;
                    command.Parameters.Add("@rutaImagen", System.Data.SqlDbType.VarChar, 150).Value = pregunta.rutaImagen;

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
    }

}


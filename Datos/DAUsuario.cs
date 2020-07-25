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
    public class DAUsuario
    {
        public string autenticarCredencialesDA(string email, string contrasenya)
        {
            string resultado="";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spAutenticarCredenciales", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 100).Value = email;
                    command.Parameters.Add("@contrasenya", System.Data.SqlDbType.VarChar, 100).Value = contrasenya;
                    command.Parameters.Add("@Resultado", System.Data.SqlDbType.VarChar, 100).Direction= System.Data.ParameterDirection.Output;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        resultado = Convert.ToString(command.Parameters["@Resultado"].Value);
                    }
                    catch(Exception ex)
                    {
                        resultado = "";
                    }
                    finally
                    {
                        connection.Close();
                    }
                    return resultado;
                }                
            }
        }

        public int grabarUsuarioDA(Usuario usuario)
        {
            int respuesta; // = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spGrabarUsuario", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@nombres", System.Data.SqlDbType.VarChar, 250).Value = usuario.nombres;
                    command.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar, 250).Value = usuario.apellidos;
                    command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 250).Value = usuario.email;
                    command.Parameters.Add("@contrasenya", System.Data.SqlDbType.VarChar, 50).Value = usuario.contrasenya;
                    //command.Parameters.Add("@idUniversidad", System.Data.SqlDbType.Int).Value = usuario.idUniversidad;
                    //command.Parameters.Add("@rol", System.Data.SqlDbType.VarChar, 20).Value = usuario.rol;


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

        public Usuario obtenerDatosPersonalesDA(string idUsuario)
        {
            Usuario usuario = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString()))
            {
                using (SqlCommand command = new SqlCommand("spObtenerDatosPersonales", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@idUsuario", System.Data.SqlDbType.Int, 100).Value = int.Parse(idUsuario);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.HasRows)
                                {
                                    usuario = new Usuario();
                                    usuario.idUsuario = int.Parse(reader["idUsuario"].ToString());
                                    usuario.nombres = reader["nombres"].ToString();
                                    usuario.apellidos = reader["apellidos"].ToString();
                                    usuario.email = reader["email"].ToString();
                                    usuario.contrasenya = reader["contrasenya"].ToString();
                                    usuario.idUniversidad = int.Parse(reader["idUniversidad"].ToString());
                                    usuario.rol = reader["rol"].ToString();
                                }
                            }
                        }


                    }catch (Exception ex)
                    {
                        ex.Message.ToString();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return usuario;
            }
        }
    }
}

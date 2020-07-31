using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YoSeEso_ApiWeb.Controllers
{
    public class RespuestaController : ApiController
    {
        BLRespuesta capaNegocioRespuesta = new BLRespuesta();                     

        public Response Post([FromBody]Respuesta respuesta)
        {
            Response response;

            //string titulo = respuesta.nombre;
            //string autor = respuesta.fecha;            
            //string idioma = respuesta.idUsuario;
            //string genero = respuesta.rutaImagen;
            //string nombreUsuario = respuesta.nombreUsuario;
            //string idPregunta = respuesta.idPregunta;

            try
            {

                int resultado = capaNegocioRespuesta.grabarRespuesta(respuesta);

                //setear los valores del objeto reslultado
                if (resultado > 0)
                {

                    //Grabo el Libro
                    response = new Response();
                    response.mensajeCodigo = 200; //SUCCESS
                    response.mensajeResultado = "Pregunta grabada correctamente";
                }
                else
                {
                    response = new Response();
                    response.mensajeCodigo = 400;
                    response.mensajeResultado = "No se pudo grabar la pregunta";
                }
            }
            catch (Exception ex)
            {

                response = new Response();
                response.mensajeCodigo = 500;
                response.mensajeResultado = ex.Message.ToString();
            }


            return response;

        }

        public Response Put([FromBody]Respuesta respuesta)
        {
            Response response;

            try
            {

                int resultado = capaNegocioRespuesta.actualizarRespuesta(respuesta);

                //setear los valores del objeto reslultado
                if (resultado > 0)
                {

                    //Grabo el Libro
                    response = new Response();
                    response.mensajeCodigo = 200; //SUCCESS
                    response.mensajeResultado = "Pregunta actualizado correctamente";
                }
                else
                {
                    response = new Response();
                    response.mensajeCodigo = 400;
                    response.mensajeResultado = "No se pudo actualizar la pregunta";
                }
            }
            catch (Exception ex)
            {

                response = new Response();
                response.mensajeCodigo = 500;
                response.mensajeResultado = ex.Message.ToString();
            }


            return response;
        }


        [Route("api/Respuesta/{idRespuesta:int}")]
        public Response Delete(int idRespuesta)
        {

            Response response;

            try
            {
                int resultado = capaNegocioRespuesta.eliminarRespuesta(idRespuesta);

                if (resultado > 0)
                {
                    //Grabo el Libro
                    response = new Response();
                    response.mensajeCodigo = 200; //SUCCESS
                    response.mensajeResultado = "Pregunta eliminada correctamente";
                }
                else
                {

                    response = new Response();
                    response.mensajeCodigo = 400;
                    response.mensajeResultado = "No se pudo eliminar la pregunta";
                }
            }
            catch (Exception ex)
            {

                response = new Response();
                response.mensajeCodigo = 500;
                response.mensajeResultado = ex.Message.ToString();
            }

            return response;
        }
    }
}

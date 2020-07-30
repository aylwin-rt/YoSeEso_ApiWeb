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
    public class PreguntaController : ApiController
    {
        BLPregunta capaNegocioPregunta = new BLPregunta();


        [Authorize]
        public List<Pregunta> Get()
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            preguntas = capaNegocioPregunta.listarPreguntas();

            return preguntas;
        }


        [Authorize]
        [Route("api/Pregunta/{idUsuario:int}")]
            public List<Pregunta> Get(int idUsuario)
        {
            List<Pregunta> preguntas = new List<Pregunta>();

            preguntas = capaNegocioPregunta.listarPreguntasPorUsuario(idUsuario);

            return preguntas;
        }

        public Response Post([FromBody]Pregunta pregunta)
        {
            Response respuesta;

            //string titulo = pregunta.nombre;
            //string autor = pregunta.fecha;
            //string editorial = pregunta.tema;
            //string idioma = pregunta.idUsuario;
            //string genero = pregunta.rutaImagen;

            try
            {

                int resultado = capaNegocioPregunta.grabarPregunta(pregunta);

                //setear los valores del objeto reslultado
                if (resultado > 0)
                {

                    //Grabo el Libro
                    respuesta = new Response();
                    respuesta.mensajeCodigo = 200; //SUCCESS
                    respuesta.mensajeResultado = "Pregunta grabada correctamente";
                }
                else
                {
                    respuesta = new Response();
                    respuesta.mensajeCodigo = 400;
                    respuesta.mensajeResultado = "No se pudo grabar la pregunta";
                }
            }
            catch (Exception ex)
            {

                respuesta = new Response();
                respuesta.mensajeCodigo = 500;
                respuesta.mensajeResultado = ex.Message.ToString();
            }


            return respuesta;

        }

        public Response Put([FromBody]Pregunta pregunta)
        {
            Response respuesta;

            try
            {

                int resultado = capaNegocioPregunta.actualizarPregunta(pregunta);

                //setear los valores del objeto reslultado
                if (resultado > 0)
                {

                    //Grabo el Libro
                    respuesta = new Response();
                    respuesta.mensajeCodigo = 200; //SUCCESS
                    respuesta.mensajeResultado = "Pregunta actualizado correctamente";
                }
                else
                {
                    respuesta = new Response();
                    respuesta.mensajeCodigo = 400;
                    respuesta.mensajeResultado = "No se pudo actualizar la pregunta";
                }
            }
            catch (Exception ex)
            {

                respuesta = new Response();
                respuesta.mensajeCodigo = 500;
                respuesta.mensajeResultado = ex.Message.ToString();
            }


            return respuesta;
        }


        [Route("api/Pregunta/{idPregunta:int}")]
        public Response Delete(int idPregunta)
        {

            Response respuesta;

            try
            {
                int resultado = capaNegocioPregunta.eliminarPregunta(idPregunta);

                if (resultado > 0)
                {
                    //Grabo el Libro
                    respuesta = new Response();
                    respuesta.mensajeCodigo = 200; //SUCCESS
                    respuesta.mensajeResultado = "Pregunta eliminada correctamente";
                }
                else
                {

                    respuesta = new Response();
                    respuesta.mensajeCodigo = 400;
                    respuesta.mensajeResultado = "No se pudo eliminar la pregunta";
                }
            }
            catch (Exception ex)
            {

                respuesta = new Response();
                respuesta.mensajeCodigo = 500;
                respuesta.mensajeResultado = ex.Message.ToString();
            }

            return respuesta;
        }

        
    }
}


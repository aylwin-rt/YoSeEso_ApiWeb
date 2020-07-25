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
    public class UsuarioController : ApiController
    {
        BLUsuario capaNegocioUsuario = new BLUsuario();

        public Respuesta Post([FromBody]Usuario usuario)
        {
            Respuesta respuesta;

            try
            {

                int resultado = capaNegocioUsuario.grabarUsuario(usuario);

                //setear los valores del objeto reslultado
                if (resultado > 0)
                {

                    //Grabo el Libro
                    respuesta = new Respuesta();
                    respuesta.mensajeCodigo = 200; //SUCCESS
                    respuesta.mensajeResultado = "Usuario grabado correctamente";
                }
                else
                {
                    respuesta = new Respuesta();
                    respuesta.mensajeCodigo = 400;
                    respuesta.mensajeResultado = "No se pudo grabar el usuario";
                }
            }
            catch (Exception ex)
            {

                respuesta = new Respuesta();
                respuesta.mensajeCodigo = 500;
                respuesta.mensajeResultado = ex.Message.ToString();
            }


            return respuesta;

        }
    }
}


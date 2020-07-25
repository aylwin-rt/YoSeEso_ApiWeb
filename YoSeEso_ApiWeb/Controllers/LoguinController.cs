using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoSeEso_ApiWeb.Controllers.security;

namespace YoSeEso_ApiWeb.Controllers
{    
    public class LoguinController : ApiController
    {
        BLUsuario capaNegocioUsuario = new BLUsuario();

        public Usuario Post([FromBody]Usuario usuario)
        {
            Usuario datosPersonales = null;

            string email = usuario.email;
            string contrasenya = usuario.contrasenya;

            try
            {
                String idUsuario = capaNegocioUsuario.autenticarCredenciales(email,contrasenya);
                if (idUsuario.Equals(""))
                {
                    //No autenticó
                    datosPersonales = new Usuario();
                    datosPersonales.mensajeCodigo = "400";
                    datosPersonales.mensajeResultado = "Credenciales incorrectas";
                }
                else
                {
                    //Sí autenticó
                    datosPersonales = new Usuario();
                    datosPersonales = capaNegocioUsuario.obtenerDatosPersonales(idUsuario);

                    if (datosPersonales != null)
                    {
                        string token = TokenGenerator.GenerateTokenJwt(usuario.email);

                        datosPersonales.mensajeCodigo = "200";
                        datosPersonales.mensajeResultado = "Exitoso";
                        datosPersonales.token = token;
                    }
                }


            }catch (Exception ex)
            {
                datosPersonales = new Usuario();
                datosPersonales.mensajeCodigo = "400";
                datosPersonales.mensajeResultado = ex.Message.ToString();
            }
            return datosPersonales;
        }       
    }
}

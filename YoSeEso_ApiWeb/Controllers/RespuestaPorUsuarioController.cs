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
    public class RespuestaPorUsuarioController : ApiController
    {
        BLRespuestaPorUsuario capaNegocioRespuesta = new BLRespuestaPorUsuario();

        [Authorize]
        [Route("api/RespuestaPorUsuario/{idUsuario:int}")]
        public List<Respuesta> Get(int idUsuario)
        {
            List<Respuesta> respuestas = new List<Respuesta>();

            respuestas = capaNegocioRespuesta.listarRespuestasPorUsuario(idUsuario);

            return respuestas;
        }        
    }
}

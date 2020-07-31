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
    public class RespuestaPorPreguntaController : ApiController
    {
        BLRespuestaPorPregunta capaNegocioRespuesta = new BLRespuestaPorPregunta();

        [Authorize]
        [Route("api/RespuestaPorPregunta/{idPregunta:int}")]
        public List<Respuesta> Get(int idPregunta)
        {
            List<Respuesta> respuestas = new List<Respuesta>();

            respuestas = capaNegocioRespuesta.listarRespuestasPorPregunta(idPregunta);

            return respuestas;
        }
    }
}

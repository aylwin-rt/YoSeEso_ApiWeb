using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLRespuesta
    {
        DARespuesta capaNegocioRespuesta = new DARespuesta();
        public List<Respuesta> listarRespuestas()
        {
            return capaNegocioRespuesta.listarRespuestasDA();
        }

        public int grabarRespuesta(Respuesta respuesta)
        {
            //REGLA DE NEGOCIA
            return capaNegocioRespuesta.grabarRespuestaDA(respuesta);
        }

        public int actualizarRespuesta(Respuesta respuesta)
        {
            return capaNegocioRespuesta.actualizarRespuestaDA(respuesta);
        }

        public int eliminarRespuesta(int idRespuesta)
        {
            return capaNegocioRespuesta.eliminarRespuestaDA(idRespuesta);
        }

        public List<Respuesta> listarRespuestasPorPregunta(int idRespuesta)
        {
            return capaNegocioRespuesta.listarRespuestasPorPreguntaDA(idRespuesta);
        }
    }
}

using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLRespuestaPorPregunta
    {
        DARespuestaPorPregunta capaNegocioRespuesta = new DARespuestaPorPregunta();
        public List<Respuesta> listarRespuestasPorPregunta(int idRespuesta)
        {
            return capaNegocioRespuesta.listarRespuestasPorPreguntaDA(idRespuesta);
        }
    }
}

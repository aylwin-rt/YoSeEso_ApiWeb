using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLRespuestaPorUsuario
    {
        DARespuestaPorUsuario capaNegocioRespuesta = new DARespuestaPorUsuario();
        public List<Respuesta> listarRespuestasPorUsuario(int idUsuario)
        {
            return capaNegocioRespuesta.listarRespuestasPorUsuarioDA(idUsuario);
        }
    }
}

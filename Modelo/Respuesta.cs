using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Respuesta
    {
        public int idRespuesta { get; set; }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public int idUsuario { get; set; }
        public string rutaImagen { get; set; }
        public string nombreUsuario { get; set; }
        public int idPregunta { get; set; }
    }
}

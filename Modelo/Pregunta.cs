using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pregunta
    {
        public int idPregunta { get; set; }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public string tema { get; set; }
        public string idUsuario { get; set; }
        public string rutaImagen { get; set; }

        public string respuesta { get; set; }

        public string nombreUsuario { get; set; }
    }
}

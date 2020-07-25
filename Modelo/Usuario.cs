using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public String email { get; set; }
        public String contrasenya { get; set; }
        public int idUniversidad { get; set; }
        public String rol { get; set; }


        public String mensajeCodigo { get; set; }
        public String mensajeResultado { get; set; }

        public String token { get; set; }
    }
}

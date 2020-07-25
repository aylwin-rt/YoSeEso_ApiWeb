using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLUsuario
    {
        DAUsuario capaDatosUsuario = new DAUsuario();
        public string autenticarCredenciales(string email, string contrasenya)
        {
            return capaDatosUsuario.autenticarCredencialesDA(email, contrasenya);
        }

        public Usuario obtenerDatosPersonales(string idUsuario)
        {
            return capaDatosUsuario.obtenerDatosPersonalesDA(idUsuario);
        }

        public int grabarUsuario(Usuario usuario)
        {
            return capaDatosUsuario.grabarUsuarioDA(usuario);
        }
    }
}

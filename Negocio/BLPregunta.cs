using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BLPregunta
    {
        DAPregunta capaNegocioPregunta = new DAPregunta();
        public List<Pregunta> listarPreguntas()
        {
            return capaNegocioPregunta.listarPreguntasDA();
        }

        public int grabarPregunta(Pregunta pregunta)
        {
            //REGLA DE NEGOCIA
            return capaNegocioPregunta.grabarPreguntaDA(pregunta);
        }

        public int actualizarPregunta(Pregunta pregunta)
        {
            return capaNegocioPregunta.actualizarPreguntaDA(pregunta);
        }

        public int eliminarPregunta(int idPregunta)
        {
            return capaNegocioPregunta.eliminarPreguntaDA(idPregunta);
        }

            public List<Pregunta> listarPreguntasPorUsuario(int idUsuario)
        {
            return capaNegocioPregunta.listarPreguntasPorUsuarioDA(idUsuario);
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trofeoDelCazadorServicio.Logica;



namespace trofeoDelCazadorServicio.Servicios.gestionUsuario
{
    public class gestionUsuarioServicio : IGestionUsuario
    {
        private readonly gestionUsuarioLogica _gestionUsuarioLogica;

        // Constructor
        public gestionUsuarioServicio()
        {
            _gestionUsuarioLogica = new gestionUsuarioLogica();
        }

        // Método para agregar un nuevo jugador
        public int agregarJugador(Jugadorr jugador)
        {
            return _gestionUsuarioLogica.agregarJugador(jugador);
        }

        // Método para obtener un jugador por su ID
        public Jugadorr obtenerJugador(int idJugador)
        {
            return _gestionUsuarioLogica.obtenerJugador(idJugador);
        }

    }
}


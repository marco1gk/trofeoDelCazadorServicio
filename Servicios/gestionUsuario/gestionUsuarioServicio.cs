using System;
<<<<<<< HEAD
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

        public int agregarJugador(Jugadorr jugador)
        {
            using (var context = new ModeloBDContainer())
            {
                // Iniciar una transacción para asegurar que ambas operaciones se completen
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // Crear y guardar una nueva instancia de Cuenta
                        Cuenta nuevaCuenta = new Cuenta
                        {
                            nombre = jugador.CuentaLlaveForanea.nombre,
                            apellido = jugador.CuentaLlaveForanea.apellido,
                            fechaRegistro = DateTime.Now,
                            contrasenia = jugador.CuentaLlaveForanea.contrasenia,
                            correo = jugador.CuentaLlaveForanea.correo
                        };

                        context.Cuenta.Add(nuevaCuenta);
                        context.SaveChanges(); // Guardar para generar el idCuenta

                        // Crear el nuevo jugador, asociando la cuenta recién creada
                        Jugador nuevoJugador = new Jugador
                        {
                            usuario = jugador.usuario,
                            fechaNacimiento = jugador.fechaNacimiento,
                            partidasJugadas = jugador.partidasJugadas, // Puede ser null
                            partidasGanadas = jugador.partidasGanadas, // Puede ser null
                            fechaRegistro = DateTime.Now,
                            idCuenta = nuevaCuenta.idCuenta // Relacionar con la cuenta creada
                        };

                        context.Jugador.Add(nuevoJugador);
                        context.SaveChanges(); // Guardar el jugador

                        // Confirmar la transacción
                        transaction.Commit();

                        // Retornar el id del nuevo jugador registrado
                        return nuevoJugador.idJugador;
                    }
                    catch (Exception ex)
                    {
                        // Revertir transacción en caso de error
                        transaction.Rollback();
                        throw new FaultException("Error al registrar el jugador: " + ex.Message);
                    }
                }
            }

        }

    }
}
}
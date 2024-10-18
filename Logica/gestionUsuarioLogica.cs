using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccess;
using trofeoDelCazadorServicio.Servicios.gestionUsuario;

namespace trofeoDelCazadorServicio.Logica
{
    public class gestionUsuarioLogica
    {
        public int agregarJugador(Jugadorr jugador)
        {
            // Creamos una instancia del contexto o manejador de la base de datos
            using (var db = new ModeloBDContainer()) // Suponiendo que DataAccessContext es tu clase de acceso a la DB
            {
                try
                {
                    // Crear una nueva cuenta dentro del método
                    var nuevaCuenta = new Cuenta // La entidad debe reflejar la tabla en la base de datos
                    {
                        correo = "ejemplo@correo.com", // Generar el correo o recibirlo dinámicamente
                        contrasenia = "123456", // Recibir o generar la contraseña
                        nombre = "Nombre", // Nombre dinámico o predeterminado
                        apellido = "Apellido", // Apellido dinámico o predeterminado
                        fechaRegistro = DateTime.Now // Fecha de registro actual
                    };

                    // Agregar la cuenta en la base de datos
                    db.Cuenta.Add(nuevaCuenta);
                    db.SaveChanges(); // Guardar para obtener el idCuenta

                    // Crear un nuevo registro de Jugadorr basado en la entidad de la base de datos
                    var nuevoJugador = new Jugador
                    {
                        usuario = jugador.usuario,
                        fechaNacimiento = jugador.fechaNacimiento,
                        partidasJugadas = jugador.partidasJugadas,
                        partidasGanadas = jugador.partidasGanadas,
                        fechaRegistro = DateTime.Now, // Asignar la fecha actual
                        idCuenta = nuevaCuenta.idCuenta // Relacionar con la cuenta creada
                    };

                    // Agregar el jugador en la base de datos
                    db.Jugador.Add(nuevoJugador);
                    db.SaveChanges(); // Guardar los cambios

                    // Retornar el ID del nuevo jugador
                    return nuevoJugador.idJugador;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    // Manejar la excepción
                    Console.WriteLine($"Error al agregar el jugador y la cuenta: {ex.Message}");
                    return -1; // Código de error
                }
            }
        }

        public Jugadorr obtenerJugador(int idJugador)
        {
            using (var db = new ModeloBDContainer())
            {
                var jugador = db.Jugador.Include("Cuenta") // Incluye los datos de la cuenta
                    .FirstOrDefault(j => j.idJugador == idJugador);

                if (jugador != null)
                {
                    return new Jugadorr
                    {
                        idJugador = jugador.idJugador,
                        usuario = jugador.usuario,
                        fechaNacimiento = jugador.fechaNacimiento,
                        partidasJugadas = jugador.partidasJugadas,
                        partidasGanadas = jugador.partidasGanadas,
                        fechaRegistro = jugador.fechaRegistro,
                        idCuenta = jugador.idCuenta,
                        // Si necesitas el correo, nombre y apellido de la cuenta, agrégalo aquí.
                    };
                }
                return null;
            }
        }

    }
}

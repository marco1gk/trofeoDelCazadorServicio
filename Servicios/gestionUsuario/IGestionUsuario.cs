using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using dataAccess;
using System.Globalization;
using System.Security.Principal;


namespace trofeoDelCazadorServicio.Servicios.gestionUsuario
{
    [ServiceContract]
    public interface IGestionUsuario
    {
        [OperationContract]
        int agregarJugador(Jugadorr jugador);


        /*[OperationContract]
        void editarNombreJugador(int idJugador, string nuevoNombre);

        [OperationContract]
        void editarApellidoJugador(int idJugador, string nuevoApellido);

        [OperationContract]
        void editarUsuario(int idJugador, string nuevoUsuario);

        [OperationContract]
        void editarCorreo(int idJugador, string nuevoCorreo);

        [OperationContract]
        void editarContrasenia(int idJugador, string nuevacontrasenia);*/

        [OperationContract]
        Jugadorr obtenerJugador(int idJugador);
    }

    [DataContract]
    public class Jugadorr
    {
        [DataMember]
        public int idJugador { get; set; }

        [DataMember]
        public string usuario { get; set; }

        [DataMember]
        public DateTime fechaNacimiento { get; set; }

        [DataMember]
        public Nullable<int> partidasJugadas { get; set; }

        [DataMember]
        public Nullable<int> partidasGanadas { get; set; }

        [DataMember]
        public DateTime fechaRegistro { get; set; }

        [DataMember]
        public int idCuenta { get; set; }

        [DataMember] 
        public Cuenta CuentaLlaveForanea { get; set; }
    }

    [DataContract]
    public class Cuentaa
    {
        [DataMember]
        public int idCuenta { get; set; }

        [DataMember]
        public string correo { get; set; }

        [DataMember]
        public string contrasenia { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string apellido { get; set; }

        [DataMember]
        public DateTime fechaRegistro { get; set; }

       
    }




}






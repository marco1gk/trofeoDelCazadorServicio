using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using dataAccess;

namespace trofeoDelCazadorServicio.Servicios.gestionUsuario
{
    [ServiceContract]
    public interface IGestionUsuario
    {
        [OperationContract]
        int agregarJugador(Jugador jugador);




    }

    [DataContract]
    public class Jugador
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
    }

    [DataContract]
    public class Cuenta
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






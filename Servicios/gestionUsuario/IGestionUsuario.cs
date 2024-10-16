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
    [ServiceContract(CallbackContract = typeof(IGestionUsuario))]
    internal interface IGestionUsuario 
    {
        [OperationContract(IsOneWay = true)]
        void agregarCuenta(Cuenta cuenta);
    }

    interface IGestionUsuarioCallBack
    {
        [OperationContract]
        void UsersResponse(String response);
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






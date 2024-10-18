using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using trofeoDelCazadorServicio;
using trofeoDelCazadorServicio.Servicios.gestionUsuario;


namespace host
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(gestionUsuarioServicio)))
            {
                host.Open();
                Console.WriteLine("Servicio machin");
                Console.ReadLine();

            }  
        }
    }
}
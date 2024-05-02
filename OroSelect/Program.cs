using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OroSelect
{
    public class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona();
            persona.crearNuevaPersona();
            persona.ToString();
            Console.ReadKey();
        }
    }
}

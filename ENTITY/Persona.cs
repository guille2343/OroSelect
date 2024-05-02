using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Persona
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        public Persona() { }

        public Persona(string id, string nombre, string apellido, string telefono, string direccion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.direccion = direccion;
        }

        public Persona crearNuevaPersona()
        {
            Persona persona = new Persona();
            string id, nombre, apellido, telefono, direccion;

            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.WriteLine("                                                     ");

                Console.SetCursorPosition(10, 7); Console.WriteLine("Digite El Numero De Identificacion: ");
                Console.SetCursorPosition(50, 7); id = Console.ReadLine();
                if (!String.IsNullOrEmpty(id))
                {
                    persona.id = id;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.WriteLine("Error: No Se Admiten Campos Vacios");
                }
            }

            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.WriteLine("                                                     ");

                Console.SetCursorPosition(10, 8); Console.WriteLine("Digite El Nombre: ");
                Console.SetCursorPosition(50, 8); nombre = Console.ReadLine();
                if (!String.IsNullOrEmpty(nombre) && validarStringAceptarSoloLetras(nombre))
                {
                    persona.id = id;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.WriteLine("Error: No Se Admiten Campos Vacios");
                }
            }
            return null;
        } 

        public bool validarStringAceptarSoloLetras(string dato)
        {
            string patron = "^[a-zA-Z]+$";

            return Regex.IsMatch(dato, patron);
        }
    }
}
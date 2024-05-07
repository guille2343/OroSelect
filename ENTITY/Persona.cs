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
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(65, 8); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 8); Console.Write("IDENTRIFICACION: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 8); id = Console.ReadLine();
                if (!String.IsNullOrEmpty(id))
                {
                    persona.id = id.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(65, 9); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 9); Console.Write("NOMBRE: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 9); nombre = Console.ReadLine();
                if (!String.IsNullOrEmpty(nombre) && validarStringAceptarSoloLetras(nombre))
                {
                    persona.nombre = nombre.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {

                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(65, 10); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 10); Console.Write("APELLIDO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 10); apellido = Console.ReadLine();
                if (!String.IsNullOrEmpty(apellido) && validarStringAceptarSoloLetras(apellido))
                {
                    persona.apellido = apellido.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(65, 11); Console.Write("                                   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 11); Console.Write("TELEFONO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 11); telefono = Console.ReadLine();
                validarLong(telefono);

                if (!String.IsNullOrEmpty(telefono) && validarLong(telefono))
                {
                    persona.telefono = telefono;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 12); Console.Write("DIRECCION: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 12); direccion = Console.ReadLine();
                if (!String.IsNullOrEmpty(direccion))
                {
                    persona.direccion = direccion;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }
            Console.ResetColor();
            return persona; 
        }


        public bool validarStringAceptarSoloLetras(string dato)
        {
            string patron = "^[a-zA-Z]+$";

            return Regex.IsMatch(dato, patron);
        }

        public bool validarLong(string dato)
        {
            long enteroProducto;
            try
            {
                enteroProducto = long.Parse(dato);
                if (enteroProducto <= 0)
                {
                    return false;
                }

            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            return true;
        }

        public String generarCodigoAleatoriamente()
        {
            String codigo;
            int longitudCodigo = 7;
            const string caracteresDelCodigo = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder token = new StringBuilder();
            Random caracterRandom = new Random();
            for (int i = 0; i < longitudCodigo; i++)
            {
                int ubicacionDelCaracter = caracterRandom.Next(caracteresDelCodigo.Length);
                token.Append(caracteresDelCodigo[ubicacionDelCaracter]);
            }
            codigo = token.ToString();
            return codigo;
        }

    }
}
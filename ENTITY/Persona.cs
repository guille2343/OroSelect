﻿using System;
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
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.WriteLine("                                                     ");
                Console.SetCursorPosition(50, 8); Console.WriteLine("                                                              ");

                Console.SetCursorPosition(10, 8); Console.WriteLine("Digite El Nombre(s): ");
                Console.SetCursorPosition(50, 8); nombre = Console.ReadLine();
                if (!String.IsNullOrEmpty(nombre) && validarStringAceptarSoloLetras(nombre))
                {
                    persona.nombre = nombre;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.WriteLine("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.WriteLine("                                                     ");
                Console.SetCursorPosition(50, 9); Console.WriteLine("                                                              ");

                Console.SetCursorPosition(10, 9); Console.WriteLine("Digite Los Apellidos: ");
                Console.SetCursorPosition(50, 9); apellido = Console.ReadLine();
                if (!String.IsNullOrEmpty(apellido) && validarStringAceptarSoloLetras(apellido))
                {
                    persona.apellido = apellido;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.WriteLine("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.WriteLine("                                                     ");
                Console.SetCursorPosition(50, 10); Console.WriteLine("                                   ");

                Console.SetCursorPosition(10, 10); Console.WriteLine("Digite El Telefono: ");
                Console.SetCursorPosition(50, 10); telefono = Console.ReadLine();
                validarEntero(telefono);

                if (!String.IsNullOrEmpty(telefono) && validarEntero(telefono))
                {
                    persona.telefono = telefono;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.WriteLine("Error: Solo Se Admiten Valores Numericos 0-9");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.WriteLine("                                                     ");

                Console.SetCursorPosition(10, 11); Console.WriteLine("Digite La Direccion: ");
                Console.SetCursorPosition(50, 11); direccion = Console.ReadLine();
                if (!String.IsNullOrEmpty(direccion))
                {
                    persona.direccion = direccion;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.WriteLine("Error: No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }

            return persona; 
        }


        } 


        public bool validarStringAceptarSoloLetras(string dato)
        {
            string patron = "^[a-zA-Z]+$";

            return Regex.IsMatch(dato, patron);
        }

        public bool validarEntero(string dato)
        {
            int enteroProducto;
            try
            {
                enteroProducto = int.Parse(dato);
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

    }
}
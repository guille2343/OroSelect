using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cliente : Persona
    {
        public String codigoCliente {  get; set; }

        public Cliente() { }
        public Cliente(string codigoCliente)
        {
            this.codigoCliente = codigoCliente;
        }

         public Cliente crearNuevoCliente()
         {
            Cliente cliente = new Cliente();
            Persona persona = new Persona();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(53, 5); Console.Write("REGISTRAR CLIENTE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 7); Console.Write("CODIGO:  ");
            cliente.codigoCliente = generarCodigoAleatoriamente();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(65, 7); Console.Write(cliente.codigoCliente);
            persona = persona.crearNuevaPersona();
            cliente.id = persona.id;
            cliente.nombre = persona.nombre;
            cliente.apellido = persona.apellido;
            cliente.telefono = persona.telefono;
            cliente.direccion = persona.direccion;
        
             return cliente;
         }

    }
}

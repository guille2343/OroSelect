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
        
             Console.SetCursorPosition(20, 5); Console.Write("Registrar Nuevo Cliente");

            Console.SetCursorPosition(10, 7); Console.Write("Codigo Cliente:  ");
            cliente.codigoCliente = generarCodigoAleatoriamente();
            Console.SetCursorPosition(50, 7); Console.Write(cliente.codigoCliente);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cliente : Persona
    {
        public String CodigoCliente {  get; set; }

        public Cliente() { }
        public Cliente(string codigoCliente)
        {
            CodigoCliente = codigoCliente;
        }

         public Cliente crearNuevoCliente()
         {
             Cliente cliente = new Cliente();
             Persona persona = new Persona();
             string codigo;
        
             Console.SetCursorPosition(20, 5); Console.Write("Registrar Nuevo Cliente");
             persona = persona.crearNuevaPersona();
             cliente.id = persona.id;
             cliente.nombre = persona.nombre;
             cliente.apellido = persona.apellido;
             cliente.telefono = persona.telefono;
             cliente.direccion = persona.direccion;
        
             while (true)
             {
                 Console.SetCursorPosition(10, 17); Console.Write("                                                     ");
        
                 Console.SetCursorPosition(10, 12); Console.Write("Asigne Codigo Al Cliente: ");
                 Console.SetCursorPosition(50, 12); codigo = Console.ReadLine();
                 if (!String.IsNullOrEmpty(codigo))
                 {
                     cliente.CodigoCliente = codigo;
                     break;
                 }
                 else
                 {
                     Console.SetCursorPosition(10, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                     Console.ReadKey();
                 }
             }
        
             return cliente;
         }
    }
}

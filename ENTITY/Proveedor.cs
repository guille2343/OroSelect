using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Proveedor : Persona
    {
        public string codigoProveedor {  get; set; }

        public Proveedor() { }

        public Proveedor (string codigoProveedor)
        {
            this.codigoProveedor = codigoProveedor;
        }

        public Proveedor crearNuevoProveedor()
        {
            Proveedor proveedor = new Proveedor();
            Persona persona = new Persona();

            Console.SetCursorPosition(20, 5); Console.Write("Registrar Nuevo Proveedor");

            Console.SetCursorPosition(10, 7); Console.Write("Codigo Proveedor:  ");
            proveedor.codigoProveedor = generarCodigoAleatoriamente();
            Console.SetCursorPosition(50, 7); Console.Write(proveedor.codigoProveedor);
            persona = persona.crearNuevaPersona();
            proveedor.id = persona.id;
            proveedor.nombre = persona.nombre;
            proveedor.apellido = persona.apellido;
            proveedor.telefono = persona.telefono;
            proveedor.direccion = persona.direccion;

            return proveedor;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Empleado : Persona
    {
        public String CodigoEmpleado {  get; set; }
        public decimal Salario { get; set; }

        public Empleado() { }

        public Empleado(string codigoEmpleado, decimal salario)
        {
            CodigoEmpleado = codigoEmpleado;
            Salario = salario;
        }

        public Empleado crearNuevoEmpleado()
        {
            Empleado empleado = new Empleado();
            Persona persona = new Persona();
            string codigo, salario;

            Console.SetCursorPosition(20, 5); Console.WriteLine("Registrar Nuevo Empleado");
            persona = persona.crearNuevaPersona();
            empleado.id = persona.id;
            empleado.nombre = persona.nombre;
            empleado.apellido = persona.apellido;
            empleado.telefono = persona.telefono;
            empleado.direccion = persona.direccion;

            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.WriteLine("                                                     ");

                Console.SetCursorPosition(10, 12); Console.WriteLine("Digite El Codigo de Empleado: ");
                Console.SetCursorPosition(50, 12); codigo = Console.ReadLine();
                if (!String.IsNullOrEmpty(codigo))
                {
                    empleado.CodigoEmpleado = codigo;
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
                Console.SetCursorPosition(50, 13); Console.WriteLine("                                        ");

                Console.SetCursorPosition(10, 13); Console.WriteLine("Digite El Salario: ");
                Console.SetCursorPosition(50, 13); salario = Console.ReadLine();
                validarDecimal(salario);

                if (!String.IsNullOrEmpty(salario) && validarDecimal(salario))
                {
                    empleado.Salario = decimal.Parse(salario);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.WriteLine("Error: Solo Se Admiten Valores Numericos 0-9");
                    Console.ReadKey();
                }
            }

            return empleado;
        }

        public bool validarDecimal(string dato)
        {
            decimal enteroProducto;
            try
            {
                enteroProducto = decimal.Parse(dato);
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

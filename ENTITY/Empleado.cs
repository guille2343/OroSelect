﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Empleado : Persona
    {
        public String codigoEmpleado {  get; set; }
        public decimal salario { get; set; }

        public Empleado() { }

        public Empleado(string codigoEmpleado, decimal salario)
        {
            this.codigoEmpleado = codigoEmpleado;
            this.salario = salario;
        }

        public Empleado crearNuevoEmpleado()
        {
            Empleado empleado = new Empleado();
            Persona persona = new Persona();
            string codigo, salario;

            Console.SetCursorPosition(20, 5); Console.Write("Registrar Nuevo Empleado");

            Console.SetCursorPosition(10, 7); Console.Write("Codigo Empleado:  ");
            empleado.codigoEmpleado = generarCodigoAleatoriamente();
            Console.SetCursorPosition(50, 7); Console.Write(empleado.codigoEmpleado);
            persona = persona.crearNuevaPersona();
            empleado.id = persona.id;
            empleado.nombre = persona.nombre;
            empleado.apellido = persona.apellido;
            empleado.telefono = persona.telefono;
            empleado.direccion = persona.direccion;

          
            while (true)
            {
                Console.SetCursorPosition(10, 17); Console.Write("                                                      ");
                Console.SetCursorPosition(50, 13); Console.Write("                                        ");

                Console.SetCursorPosition(10, 13); Console.Write("Digite El Salario: ");
                Console.SetCursorPosition(50, 13); salario = Console.ReadLine();
                validarDecimal(salario);

                if (!String.IsNullOrEmpty(salario) && validarDecimal(salario))
                {
                    empleado.salario = decimal.Parse(salario);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Gerente : Persona
    {
        public string codigoGerente { get; set; }
        public decimal salario { get; set; }

        public Gerente() { }

        public Gerente(string codigoGerente, decimal salario)
        {
            this.codigoGerente = codigoGerente;
            this.salario = salario;
        }

         public Gerente crearNuevoGerente()
        {
            Gerente gerente = new Gerente();
            Persona persona = new Persona();
            string codigo, salario;
        
            Console.SetCursorPosition(20, 5); Console.Write("Registrar Datos Del Gerente");

            Console.SetCursorPosition(10, 7); Console.Write("Codigo Gerente:  ");
            gerente.codigoGerente = generarCodigoAleatoriamente();
            Console.SetCursorPosition(50, 7); Console.Write(gerente.codigoGerente);
            persona = persona.crearNuevaPersona();
            gerente.id = persona.id;
            gerente.nombre = persona.nombre;
            gerente.apellido = persona.apellido;
            gerente.telefono = persona.telefono;
            gerente.direccion = persona.direccion;
   
        
              while (true)
              {
                  Console.SetCursorPosition(10, 17); Console.Write("                                                      ");
                  Console.SetCursorPosition(50, 13); Console.Write("                                        ");
        
                  Console.SetCursorPosition(10, 13); Console.Write("Digite El Salario: ");
                  Console.SetCursorPosition(50, 13); salario = Console.ReadLine();
                  validarDecimal(salario);
        
                  if (!String.IsNullOrEmpty(salario) && validarDecimal(salario))
                  {
                      gerente.salario = decimal.Parse(salario);
                      break;
                  }
                  else
                  {
                      Console.SetCursorPosition(10, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                      Console.ReadKey();
                  }
              }
        
              return gerente;
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

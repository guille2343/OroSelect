using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Contrato
    {
        public String CodigoContrato { get; set; }
        public DateTime FechaEmisionContrato { get; set; }
        public string EstadoContrato { get; set; }

        public Contrato() { }   

        public Contrato(String codigoContrato, String estadoContrato)
        {
            CodigoContrato = codigoContrato;
            EstadoContrato = estadoContrato;
            FechaEmisionContrato = DateTime.Today;
        }

        public Contrato emitirNuevoContrato()
        {
            Contrato contrato = new Contrato();
            string estadoContrato;
        
            Console.SetCursorPosition(10, 7); Console.Write("Codigo Contrato:  ");
            contrato.codigoContrato = generarCodigoAleatoriamente();
            Console.SetCursorPosition(50, 7); Console.Write(contrato.codigoContrato);
            Console.SetCursorPosition(10, 8); Console.Write("Fecha De Emision:  ");
            contrato.fechaEmisionContrato = DateTime.Today;
            Console.SetCursorPosition(50, 8); Console.Write(contrato.fechaEmisionContrato);
            while (true)
            {
                Console.SetCursorPosition(10, 18); Console.Write("                                                     ");
                Console.SetCursorPosition(50, 9); Console.Write("                                      ");
        
                Console.SetCursorPosition(10, 9); Console.Write("Estado Del Contrato: ");
                Console.SetCursorPosition(10, 17); Console.Write("El Contrato Solo Puede Tener Dos Estados (CANCELADO/PENDIENTE)");
                Console.SetCursorPosition(50, 9); estadoContrato = Console.ReadLine();
                validarEstadoContrato(estadoContrato);
                if (!String.IsNullOrEmpty(estadoContrato) && validarEstadoContrato(estadoContrato))
                {
                    contrato.estadoContrato = estadoContrato;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 18); Console.Write("Error: Intente Nuevamente");
                    Console.ReadKey();
                }
            }
            Console.SetCursorPosition(10, 17); Console.Write("                                                                              ");
        
            return contrato;
        }
        
        public bool validarEstadoContrato(String estado)
        {
            estado = estado.ToUpper();
            if(estado != "PENDIENTE" && estado != "CANCELADO")
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

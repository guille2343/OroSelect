using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Contrato
    {
        public String codigoContrato { get; set; }
        public DateTime fechaEmisionContrato { get; set; }
        public string estadoContrato { get; set; }
        public string idComprador { get; set; }
        public string apellidoComprador { get; set; }
        public string nombreComprador { get; set; }
        public string telefonoComprador { get; set; }
        public int purezaProducto { get; set; }
        public decimal pesoProducto { get; set; }
        public decimal valorPorGramoOro { get; set; }
        public decimal valorProducto { get; set; }    
        public string descripciobProducto { get; set; }
        public decimal saldoContrato { get; set; }

        public Contrato() { }

        public Contrato(string codigoContrato, DateTime fechaEmisionContrato, string estadoContrato, string idComprador, string apellidoComprador, string nombreComprador, string telefonoComprador, int purezaProducto, decimal pesoProducto, decimal valorPorGramoOro, decimal valorProducto, string descripciobProducto, decimal saldoContrato)
        {
            this.codigoContrato = codigoContrato;
            this.fechaEmisionContrato = fechaEmisionContrato;
            this.estadoContrato = estadoContrato;
            this.idComprador = idComprador;
            this.apellidoComprador = apellidoComprador;
            this.nombreComprador = nombreComprador;
            this.telefonoComprador = telefonoComprador;
            this.purezaProducto = purezaProducto;
            this.pesoProducto = pesoProducto;
            this.valorPorGramoOro = valorPorGramoOro;
            this.valorProducto = valorProducto;
            this.descripciobProducto = descripciobProducto;
            this.saldoContrato = saldoContrato;
        }

        public Contrato emitirNuevoContrato(Cliente cliente, ProductoOro producto)
        {
            Console.Clear();
            Contrato contrato = new Contrato();
            string estadoContrato;
        
            Console.SetCursorPosition(10, 3); Console.Write("Codigo Contrato:  ");
            contrato.codigoContrato = generarCodigoAleatoriamente();
            Console.SetCursorPosition(35, 3); Console.Write(contrato.codigoContrato);
            Console.SetCursorPosition(10, 4); Console.Write("Fecha De Emision:  ");
            contrato.fechaEmisionContrato = DateTime.Today;
            Console.SetCursorPosition(35, 4); Console.Write(contrato.fechaEmisionContrato);
            while (true)
            {
                Console.SetCursorPosition(10, 18); Console.Write("                                                     ");
                Console.SetCursorPosition(30, 5); Console.Write("                                      ");
        
                Console.SetCursorPosition(10, 5); Console.Write("Estado Del Contrato: ");
                Console.SetCursorPosition(10, 17); Console.Write("El Contrato Solo Puede Tener Dos Estados (CANCELADO/PENDIENTE)");
                Console.SetCursorPosition(35, 5); estadoContrato = Console.ReadLine();
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
            contrato.idComprador = cliente.id;
            contrato.apellidoComprador = cliente.apellido;
            contrato.nombreComprador = cliente.nombre;
            contrato.telefonoComprador = cliente.telefono;
            contrato.purezaProducto = producto.pureza;
            contrato.pesoProducto = producto.pesoProductoOro;
            contrato.valorPorGramoOro = producto.precioPorGramoOro;
            contrato.valorProducto = contrato.pesoProducto * contrato.valorPorGramoOro;
            contrato.descripciobProducto = producto.descripcionProducto;

            Console.SetCursorPosition(15, 7); Console.Write("DATOS DEL CLIENTE");
            Console.SetCursorPosition(10, 8); Console.Write("ID ");
            Console.SetCursorPosition(10, 9); Console.Write(contrato.idComprador);
            Console.SetCursorPosition(25, 8); Console.Write("APELLIDO");
            Console.SetCursorPosition(25, 9); Console.Write(contrato.apellidoComprador);
            Console.SetCursorPosition(40, 8); Console.Write("NOMBRE ");
            Console.SetCursorPosition(40, 9); Console.Write(contrato.nombreComprador);
            Console.SetCursorPosition(55, 8); Console.Write("TELEFONO ");
            Console.SetCursorPosition(55, 9); Console.Write(contrato.telefonoComprador);
            Console.SetCursorPosition(15, 11); Console.Write("DATOS DEL PRODUCTO");
            Console.SetCursorPosition(10, 13); Console.Write("PUREZA");
            Console.SetCursorPosition(10, 14); Console.Write(contrato.purezaProducto);
            Console.SetCursorPosition(25, 13); Console.Write("PESO ");
            Console.SetCursorPosition(25, 14); Console.Write(contrato.pesoProducto);
            Console.SetCursorPosition(40, 13); Console.Write("VALOR GRAMO ");
            Console.SetCursorPosition(40, 14); Console.Write(contrato.valorPorGramoOro);
            
            Console.SetCursorPosition(55, 13); Console.Write("DESCRIPCCION");
            Console.SetCursorPosition(55, 14); Console.Write(contrato.descripciobProducto);
            Console.SetCursorPosition(5, 16); Console.Write("-------------------------------------------------------------------------------");

            Console.SetCursorPosition(10, 18); Console.Write("VALOR TOTAL ");
            Console.SetCursorPosition(35, 18); Console.Write(contrato.valorProducto);
            Console.SetCursorPosition(10, 19); Console.Write("SALDO ");

            validarSaldoContrato(contrato.estadoContrato);
            if (validarSaldoContrato(contrato.estadoContrato))
            {
                contrato.saldoContrato =contrato.valorProducto;
                Console.SetCursorPosition(35, 19); Console.Write(contrato.saldoContrato);
            }
            else
            {
                contrato.saldoContrato = 0;
                Console.SetCursorPosition(35, 19); Console.Write(contrato.saldoContrato);
            }
            
            

            Console.ReadKey();
            return contrato;
        }

        public bool validarSaldoContrato(String estado)
        {
            if(estado.ToUpper().Trim() != "PENDIENTE")
            {
                return false;
            }
            return true;
        }
        
        public bool validarEstadoContrato(String estado)
        {
            if(estado.ToUpper().Trim() != "PENDIENTE" && estado.ToUpper().Trim() != "CANCELADO")
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

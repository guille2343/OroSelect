using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ProductoOro
    {
        public string codigoProducto {  get; set; }
        public decimal validarEnteros { get; set; }
        public decimal pesoProductoOro { get; set; }
        public string descripcionProducto { get; set; }
        public int pureza { get; set; }
        public decimal precioPorGramoOro { get; set; }

        public ProductoOro() { }

        public ProductoOro(string codigoProducto, decimal valorProductoOro, decimal pesoProductoOro, string descripcionProductoO, int pureza)
        {
            this.codigoProducto = codigoProducto;
            this.validarEnteros = valorProductoOro;
            this.pesoProductoOro = pesoProductoOro;
            this.descripcionProducto = descripcionProductoO;
            this.pureza = pureza;
        }

        public ProductoOro crearNuevoProductoOro()
        {
            ProductoOro productoOro = new ProductoOro();
            string pesoProducto, valorPorGramoProducto, purezaProducto;

            Console.SetCursorPosition(15, 4); Console.Write("Ingrese los datos relacionados con el producto:");

            while (true)
            {
                Console.SetCursorPosition(50, 7); Console.Write("                              ");
                Console.SetCursorPosition(10, 15); Console.Write("                                                                                                                              ");

                Console.SetCursorPosition(10, 6);Console.Write("Codigo Producto");
                codigoProducto = generarCodigoAleatoriamente();
                Console.SetCursorPosition(50, 6);Console.Write(codigoProducto);
                Console.SetCursorPosition(10, 7); Console.Write("Peso Del Producto:");
                Console.SetCursorPosition(50, 7); pesoProducto = Console.ReadLine();
                validarDecimal(pesoProducto);
                if (validarDecimal(pesoProducto))
                {
                    productoOro.pesoProductoOro = decimal.Parse(pesoProducto);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 15); Console.Write("Error: el valor introducido debe ser mayor que cero y contener los siguientes caracteres (0-9, puntos y comas)");
                    Console.ReadKey();
                }

            }

            while (true)
            {
                Console.SetCursorPosition(50, 8); Console.Write("                              ");
                Console.SetCursorPosition(10, 15); Console.Write("                                                                                                                              ");

                Console.SetCursorPosition(10, 8); Console.Write("Precio Por Gramo:");
                Console.SetCursorPosition(50, 8); valorPorGramoProducto = Console.ReadLine();
                validarDecimal(valorPorGramoProducto);
                if (validarDecimal(valorPorGramoProducto))
                {
                    productoOro.precioPorGramoOro = decimal.Parse(valorPorGramoProducto);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 15); Console.Write("Error: el valor introducido debe ser mayor que cero y contener los siguientes caracteres (0-9, puntos y comas)");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(50, 9); Console.Write("                                      ");
                Console.SetCursorPosition(10, 15); Console.Write("                                                                                                                    ");

                Console.SetCursorPosition(10, 9); Console.Write("Nivel De Pureza:");
                Console.SetCursorPosition(50, 9); purezaProducto = Console.ReadLine();
                validarEntero(purezaProducto);
                if (validarEntero(purezaProducto))
                {
                    productoOro.pureza = int.Parse(purezaProducto);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(10, 15); Console.Write("Error: Los Niveles De Pureza Permitidos Son: 10, 14, 18. Presine intro para continuar");
                    Console.ReadKey();
                }
            }

            Console.SetCursorPosition(10, 10); Console.Write("Valor Total Producto: ");
            Console.SetCursorPosition(50, 10); productoOro.validarEnteros = calcularValorProductoOro(productoOro.pesoProductoOro, productoOro.precioPorGramoOro);
            Console.SetCursorPosition(50, 10); Console.Write(productoOro.validarEnteros);
            Console.SetCursorPosition(10, 11); Console.Write("Decripcion Del Producto:");
            Console.SetCursorPosition(10, 12); productoOro.descripcionProducto = Console.ReadLine();

            return productoOro;
        }

        //esta funcion recibe un string lo convierte a decimal y vaida que sea mas que cero y que no tenga caracteres no numericos
        public bool validarDecimal(String dato)
        {
            decimal decimalProducto;

            try
            {
                decimalProducto = decimal.Parse(dato);
                if (decimalProducto <= 0)
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

        //esta funcion recibe una cadena de caracteres la convierte a entero y valida que solo sea la cantidad permitida
        public bool validarEntero(string dato)
        {
            int enteroProducto;
            try
            {
                enteroProducto = int.Parse(dato);
                if (enteroProducto != 10 && enteroProducto != 14 && enteroProducto != 18)
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

        //esta funcion calcula el valor del oro tomando como referencia el peso del producto y el valor que
        //se le haya asignado al cliente o contrato en especifico (el valor que podemos pagar o cobrar por gramo es variable y diferente entre clientes)
        public decimal calcularValorProductoOro(decimal pesoProductoOro, decimal valorPorGramo)
        {
            decimal valorCalculadoProductoOro = pesoProductoOro * valorPorGramo;

            return valorCalculadoProductoOro;
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
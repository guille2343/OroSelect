using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ContratoCompra : Contrato
    {
        
        public string idComprador {  get; set; }
        public string apellidoComprador { get; set; }
        public string nombreComprador { get; set; }
        public string telefonoComprador { get; set; }
        public decimal valorPorGramoOro {  get; set; }
        public decimal pesoProducto { get; set; }
        public int purezaProducto { get; set; }
        public string descripciobProducto { get; set; }
        public decimal valorProducto { get; set; }
        public string descripcionContrato { get; set; }
        
        public ContratoCompra() { }

        public ContratoCompra(string idComprador, string apellidoComprador, string nombreComprador, string telefonoComprador, decimal valorPorGramoOro, decimal pesoProducto, int purezaProducto, string descripciobProducto, decimal valorProducto, string descripcionContrato)
        {
            this.idComprador = idComprador;
            this.apellidoComprador = apellidoComprador;
            this.nombreComprador = nombreComprador;
            this.telefonoComprador = telefonoComprador;
            this.valorPorGramoOro = valorPorGramoOro;
            this.pesoProducto = pesoProducto;
            this.purezaProducto = purezaProducto;
            this.descripciobProducto = descripciobProducto;
            this.valorProducto = valorProducto;
            this.descripcionContrato = descripcionContrato;
        }

        public ContratoCompra generarContratoCompra(Cliente cliente, ProductoOro productoOro)
        {
            ContratoCompra contratoCompra = new ContratoCompra();

            

            contratoCompra.emitirNuevoContrato();
            Console.SetCursorPosition(15, 7); Console.Write("DATOS DEL CLIENTE");
            Console.SetCursorPosition(10, 8); Console.Write("ID ");
            Console.SetCursorPosition(10, 9); Console.Write(cliente.id);
            Console.SetCursorPosition(25, 8); Console.Write("APELLIDO");
            Console.SetCursorPosition(25, 9); Console.Write(cliente.apellido);
            Console.SetCursorPosition(40, 8); Console.Write("NOMBRE ");
            Console.SetCursorPosition(40, 9); Console.Write(cliente.nombre);
            Console.SetCursorPosition(55, 8); Console.Write("TELEFONO ");
            Console.SetCursorPosition(55, 9); Console.Write(cliente.telefono);
            Console.SetCursorPosition(15, 11); Console.Write("DATOS DEL PRODUCTO");
            Console.SetCursorPosition(10, 13); Console.Write("VALOR GRAMO");
            Console.SetCursorPosition(10, 14); Console.Write(productoOro.precioPorGramoOro);
            Console.SetCursorPosition(25, 13); Console.Write("PESO ");
            Console.SetCursorPosition(25, 14); Console.Write(productoOro.pesoProductoOro);
            Console.SetCursorPosition(40, 13); Console.Write("PUREZA ");
            Console.SetCursorPosition(40, 14); Console.Write(productoOro.pesoProductoOro);
            Console.SetCursorPosition(55, 13); Console.Write("DESCRIPCION ");
            Console.SetCursorPosition(55, 14); Console.Write(productoOro.descripcionProducto);
            Console.SetCursorPosition(70, 13); Console.Write("VALOR  ");
            Console.SetCursorPosition(70, 14); Console.Write(productoOro.calcularValorProductoOro(productoOro.precioPorGramoOro, productoOro.pesoProductoOro));
            Console.SetCursorPosition(5, 16); Console.Write("--------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(10, 18); Console.Write("VALOR DEL CONTRATO: ");
            Console.SetCursorPosition(40, 18); Console.Write(productoOro.calcularValorProductoOro(productoOro.precioPorGramoOro, productoOro.pesoProductoOro));
            Console.SetCursorPosition(10, 19); Console.Write("OBSERVACIONES");
            Console.SetCursorPosition(40, 19); contratoCompra.descripcionContrato = Console.ReadLine();

            idComprador = cliente.id;
            apellidoComprador = cliente.apellido;
            nombreComprador = cliente.nombre;
            telefonoComprador = cliente.telefono;
            pesoProducto = productoOro.pesoProductoOro;
            valorPorGramoOro = productoOro.precioPorGramoOro;
            purezaProducto = productoOro.pureza;
            valorProducto = productoOro.calcularValorProductoOro(productoOro.precioPorGramoOro, productoOro.pesoProductoOro);
            descripciobProducto = productoOro.descripcionProducto;


            return contratoCompra;
        }
    }
}

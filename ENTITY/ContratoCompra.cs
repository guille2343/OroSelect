using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ContratoCompra : Contrato
    {
        public Cliente cliente { get; set; }
        public ProductoOro productoOro { get; set; }
        public decimal valorContrato { get; set; }
        public string descripcionContrato { get; set; }
        
        public ContratoCompra () { }
        
        public ContratoCompra (Cliente cliente, ProductoOro productoOro, decimal valorContrato, string descripcionContrato)
        {
            this.cliente = cliente;
            this.productoOro = productoOro;
            this.valorContrato = valorContrato;
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
            Console.SetCursorPosition(40, 14); Console.Write(productoOro.pureza);
            Console.SetCursorPosition(55, 13); Console.Write("DESCRIPCION ");
            Console.SetCursorPosition(55, 14); Console.Write(productoOro.descripcionProducto);
            Console.SetCursorPosition(70, 13); Console.Write("VALOR  ");
            Console.SetCursorPosition(70, 14); Console.Write(productoOro.calcularValorProductoOro(productoOro.precioPorGramoOro, productoOro.pesoProductoOro));
            Console.SetCursorPosition(5, 16); Console.Write("--------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(10, 18); Console.Write("VALOR DEL CONTRATO: ");
            Console.SetCursorPosition(40, 18); Console.Write(productoOro.calcularValorProductoOro(productoOro.precioPorGramoOro, productoOro.pesoProductoOro));
            Console.SetCursorPosition(10, 19); Console.Write("OBSERVACIONES");
            Console.SetCursorPosition(40, 19); contratoCompra.descripcionContrato = Console.ReadLine();
            
            Console.ReadKey();
            return contratoCompra;
        }
    }
}

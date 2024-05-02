using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ContratoCompra : Contrato
    {
        public Proveedor proveedor { get; set; }
        public ProductoOro productoOro { get; set; }
        public decimal valorContrato { get; set; }
        public string descripcionContrato { get; set; }
        
        public ContratoCompra () { }
        
        public ContratoCompra (Proveedor proveedor, ProductoOro productoOro, decimal valorContrato, string descripcionContrato)
        {
            this.proveedor = proveedor;
            this.productoOro = productoOro;
            this.valorContrato = valorContrato;
            this.descripcionContrato = descripcionContrato;
        }
        
        public ContratoCompra generarContratoCompra(Proveedor proveedor, ProductoOro productoOro)
        {
            ContratoCompra contratoCompra = new ContratoCompra();
        
            Console.SetCursorPosition(15, 5); Console.Write("Comprobante De Compra");
            contratoCompra.emitirNuevoContrato();
            Console.SetCursorPosition(15, 11); Console.Write("Datos Del Proveedor");
            Console.SetCursorPosition(10, 12); Console.Write("No. Identificacion: ");
            Console.SetCursorPosition(50, 12); Console.Write(proveedor.id);
            Console.SetCursorPosition(10, 13); Console.Write("Nombre: ");
            Console.SetCursorPosition(50, 13); Console.Write(proveedor.nombre);
            Console.SetCursorPosition(10, 14); Console.Write("Apellido:");
            Console.SetCursorPosition(50, 14); Console.Write(proveedor.apellido);
            Console.SetCursorPosition(10, 15); Console.Write("Telefono: ");
            Console.SetCursorPosition(50, 15); Console.Write(proveedor.telefono);
            Console.SetCursorPosition(15, 17); Console.Write("Datos Del Producto");
            Console.SetCursorPosition(10, 18); Console.Write("Valor Por Gramo;");
            Console.SetCursorPosition(50, 18); Console.Write(productoOro.precioPorGramoOro);
            Console.SetCursorPosition(10, 19); Console.Write("Peso: ");
            Console.SetCursorPosition(50, 19); Console.Write(productoOro.pesoProductoOro);
            Console.SetCursorPosition(10, 20); Console.Write("Pureza: ");
            Console.SetCursorPosition(50, 20); Console.Write(productoOro.pureza);
            Console.SetCursorPosition(10, 21); Console.Write("Descripcion: ");
            Console.SetCursorPosition(50, 21); Console.Write(productoOro.descripcionProducto);
            Console.SetCursorPosition(10, 22); Console.Write("Valor Total: ");
            Console.SetCursorPosition(50, 22); Console.Write(productoOro.calcularValorProductoOro(productoOro.precioPorGramoOro, productoOro.pesoProductoOro));
            Console.SetCursorPosition(5, 24); Console.Write("-------------------------------------------------------");
            Console.SetCursorPosition(10, 26); Console.Write("Valor Total Contrato: ");
            Console.SetCursorPosition(50, 26); Console.Write(productoOro.calcularValorProductoOro(productoOro.precioPorGramoOro, productoOro.pesoProductoOro));
            Console.SetCursorPosition(10, 27); Console.Write("Observaciones");
            Console.SetCursorPosition(13, 28); descripcionContrato = Console.ReadLine();
        
            return contratoCompra;
            
        }
    }
}

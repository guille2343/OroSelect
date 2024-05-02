using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ContratoVenta : Contrato
    {
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public ProductoOro ProductoOro { get; set; }
        public decimal ValorContratoVenta {  get; set; }
        public string DescripcionContratoVenta { get; set; }
        
        public ContratoVenta() { }
        
        public ContratoVenta(Cliente cliente, Empleado empleado, ProductoOro productoOro, decimal valorContratoVenta, string descripcionContratoVenta)
        {
            Cliente = cliente;
            Empleado = empleado;
            ProductoOro = productoOro;
            ValorContratoVenta = valorContratoVenta;
            DescripcionContratoVenta = descripcionContratoVenta;
        }
        
        public ContratoVenta generarContratoVenta(Cliente cliente, Empleado empleado, ProductoOro productoOro)
        {
            ContratoVenta contratoVenta = new ContratoVenta();
        
            Console.SetCursorPosition(15, 1); Console.Write("Comprobante De Venta");
            contratoVenta.emitirNuevoContrato();
            Console.SetCursorPosition(15, 7); Console.Write("Datos Del Cliente");
            Console.SetCursorPosition(10, 8); Console.Write("No. Identificacion: ");
            Console.SetCursorPosition(50, 8); Console.Write(cliente.id);
            Console.SetCursorPosition(10, 9); Console.Write("Nombre: ");
            Console.SetCursorPosition(50, 9); Console.Write(cliente.nombre);
            Console.SetCursorPosition(10, 10); Console.Write("Apellido:");
            Console.SetCursorPosition(50, 10); Console.Write(cliente.apellido);
            Console.SetCursorPosition(10, 11); Console.Write("Telefono: ");
            Console.SetCursorPosition(50, 11); Console.Write(cliente.telefono);
        
            Console.SetCursorPosition(15, 13); Console.Write("Datos Del Vendedro");
            Console.SetCursorPosition(10, 14); Console.Write("Nombre: ");
            Console.SetCursorPosition(50, 14); Console.Write(cliente.nombre);
            Console.SetCursorPosition(10, 15); Console.Write("Apellido:");
            Console.SetCursorPosition(50, 15); Console.Write(cliente.apellido);
        
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
            Console.SetCursorPosition(13, 28); contratoVenta.DescripcionContratoVenta = Console.ReadLine();
        
            return contratoVenta;
        
        }
    }
}

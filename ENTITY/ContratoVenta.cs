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

    }
}

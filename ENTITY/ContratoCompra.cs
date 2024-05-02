using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ContratoCompra : Contrato
    {
        public Proveedor Proveedor { get; set; }
        public ProductoOro ProductoOro { get; set; }
        public decimal ValorContrato { get; set; }
        public string DescripcionContrato { get; set; }

        public ContratoCompra () { }

        public ContratoCompra (Proveedor proveedor, ProductoOro productoOro, decimal valorContrato, string descripcionContrato)
        {
            Proveedor = proveedor;
            ProductoOro = productoOro;
            ValorContrato = valorContrato;
            DescripcionContrato = descripcionContrato;
        }
    }
}

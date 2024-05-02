using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class InventarioContrato
    {
        public List<ContratoCompra> contratosCompra = new List<ContratoCompra>();
        public List<ContratoCompromiso> contratosCompromiso = new List<ContratoCompromiso>();
        public List<ContratoVenta> contratosVenta = new List<ContratoVenta>();

        public InventarioContrato() { }
       
    }
}

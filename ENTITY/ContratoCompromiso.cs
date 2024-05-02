using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class ContratoCompromiso : Contrato
    {
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public ProductoOro ProductoOro { get; set; }
        public decimal ValorContratoCompromiso { get; set; }
        public decimal SaldoContratoCompromiso { get; set; }
        public decimal AbonoContratoCompromiso { get; set; }
        public DateTime VencimientoContrato {  get; set; }

        public ContratoCompromiso () { }
        
        public ContratoCompromiso (Cliente cliente, Empleado empleado, ProductoOro productoOro, decimal valorContratoCompromiso, decimal saldoContratoCompromiso, decimal abonoContratoCompromiso, DateTime vencimientoContrato)
        {
            Cliente = cliente;
            Empleado = empleado;
            ProductoOro = productoOro;
            ValorContratoCompromiso = valorContratoCompromiso;
            SaldoContratoCompromiso = saldoContratoCompromiso;
            AbonoContratoCompromiso = abonoContratoCompromiso;
            VencimientoContrato = vencimientoContrato;
        }
    }
}

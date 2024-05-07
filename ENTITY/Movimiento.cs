using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Movimiento
    {
        Movimiento movimiento { get; set; }
        public DateTime fechaMovimineto { get; set; }
        public decimal valor {  get; set; }
        public string idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string apellidoCliente { get; set; }
        public string descripcion = "ABONO";

        public Movimiento() { }
    
        public Movimiento(DateTime fechaMovimiento, decimal valor, string idCliente, String nombreCliente, string apellidoCliente)
        {
            this.fechaMovimineto = fechaMovimineto;
            this.valor = valor; 
            this.idCliente = idCliente;
            this.nombreCliente = nombreCliente;
            this.apellidoCliente = apellidoCliente;
            this.descripcion = "ABONO";

        }

        public Movimiento nuevoMovimiento(Contrato contrato, decimal abono)
        {
            Console.Clear();
            Movimiento movimiento = new Movimiento();
            movimiento.fechaMovimineto = DateTime.Today;
            movimiento.valor = abono;
            movimiento.idCliente = contrato.idComprador;
            movimiento.nombreCliente = contrato.nombreComprador;
            movimiento.apellidoCliente = contrato.apellidoComprador;
            movimiento.descripcion = "ABONO";

            return movimiento;
        }
    }
}

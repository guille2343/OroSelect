using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ENTITY
{
    public class Caja
    {
        public decimal saldoCaja { get; set; }

        public Caja() { }

        public Caja(decimal saldoCaja)
        {
            this.saldoCaja = saldoCaja;
        }

        public void saldoEnCaja()
        {
            Console.WriteLine("El Saldo Actual En Caja Es: " + saldoCaja);
            Console.ReadKey();
        }

        public void restarSaldoALaCaja(decimal valor)
        {
            restarSaldoALaCajaValidacion(valor);
            if (!restarSaldoALaCajaValidacion(valor))
            {
                Console.WriteLine("No ha sido posible realizar la transaccion," +
                    " revise que la cifra sea mayor que cero y que no exceda el saldo en caja. \nSaldo en caja: " + saldoCaja);
            }
            if (restarSaldoALaCajaValidacion(valor))
            {
                saldoCaja -= valor;
                Console.WriteLine("La Transaccion se ha realizado con exito");
                Console.WriteLine("Saldo anterior: " + (valor + saldoCaja));
                Console.WriteLine("Saldo retirado: " + valor);
                Console.WriteLine("saldo actual: " + saldoCaja);
            }
        }

        public bool restarSaldoALaCajaValidacion(decimal valor)
        {
           if (valor <= 0) {return false;}
           if (valor > saldoCaja) { return false;}
           return true;
        }
    }
}

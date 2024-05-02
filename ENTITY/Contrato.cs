using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Contrato
    {
        public String CodigoContrato { get; set; }
        public DateTime FechaEmisionContrato { get; set; }
        public string EstadoContrato { get; set; }

        public Contrato() { }   

        public Contrato(String codigoContrato, String estadoContrato)
        {
            CodigoContrato = codigoContrato;
            EstadoContrato = estadoContrato;
            FechaEmisionContrato = DateTime.Today;
        }
      
    }
}

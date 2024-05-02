using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Gerente : Persona
    {
        public string CodigoGerente { get; set; }
        public decimal Salario { get; set; }

        public Gerente() { }

        public Gerente(string codigoGerente, decimal salario)
        {
            CodigoGerente = codigoGerente;
            Salario = salario;
        }

    }
}

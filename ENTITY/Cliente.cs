using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cliente : Persona
    {
        public String CodigoCliente {  get; set; }

        public Cliente() { }
        public Cliente(string codigoCliente)
        {
            CodigoCliente = codigoCliente;
        }
    }
}

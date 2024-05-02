using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Proveedor : Persona
    {
        public string CodigoProveedor {  get; set; }

        public Proveedor() { }

        public Proveedor (string codigoProveedor)
        {
            CodigoProveedor = codigoProveedor;
        }
    }
}

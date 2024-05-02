using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Empleado : Persona
    {
        public String CodigoEmpleado {  get; set; }
        public decimal Salario { get; set; }

        public Empleado() { }

        public Empleado(string codigoEmpleado, decimal salario)
        {
            CodigoEmpleado = codigoEmpleado;
            Salario = salario;
        }
    }
}

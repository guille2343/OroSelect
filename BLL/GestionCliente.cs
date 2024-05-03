using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionCliente
    {
        public void RegistrarClientes()
        {
            Cliente cliente = new Cliente();
            Inventario inventario = new Inventario();
            cliente = cliente.crearNuevoCliente();
            inventario.clienteAgregarALaLista(cliente);
            Console.ReadKey();
            Console.Clear();
        }

        public void modificarDatosCliente() {
            
        }

        public void mostrarListaClientes()
        {

        }

        public void consultarUnCliente()
        {

        }

        public void eliminarCliente()
        {

        }
    }
}

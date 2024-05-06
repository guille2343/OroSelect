using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionContrato
    {
        public List<Contrato> contratos = new List<Contrato>();
        public List<Cliente> clientes = new List<Cliente>();

        public GestionContrato() { }


        public void generarUnContratoCompra()
        {
            Cliente cliente = new Cliente();
            Contrato contrato = new Contrato();
            ProductoOro productoOro = new ProductoOro();
            PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
            clientes = persistenciaCliente.LeerClientesDesdeArchivo("clientes.txt");
            string idComprador;

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(48, 10); Console.Write("                                       ");
                Console.SetCursorPosition(53, 1); Console.Write("Generar Contato Compra");
                Console.SetCursorPosition(48, 3); Console.Write("Identificacion Del Comprador:");
                Console.SetCursorPosition(80, 3); idComprador = Console.ReadLine();
                if (!String.IsNullOrEmpty(idComprador))
                {
                    int existeCliente =  clienteExiste(idComprador);
                    if (existeCliente == -1)
                    {
                        Console.Clear();
                        cliente = cliente.crearNuevoCliente();
                        persistenciaCliente.GuardarClienteEnArchivo(cliente, "clientes.txt");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                        
                    }
                    else
                    {
                        cliente = clientes[existeCliente];
                        break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(48, 10); Console.Write("No Se Admiten Campos Vacios");
                }
            }
            Console.Clear() ;
            productoOro = productoOro.crearNuevoProductoOro();
            contrato = contrato.emitirNuevoContrato(cliente, productoOro);
            PersistenciaContato persistenciaContato = new PersistenciaContato();
            persistenciaContato.GuardarContratoCompraEnArchivo(contrato, "contratos.txt");
            Console.Clear();
            
            
            Console.ReadKey();
            Console.Clear();
        }


        public int clienteExiste(String codigo)
        {
            int encontro = -1;
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].id.Equals(codigo))
                {
                    encontro = i;
                }
            }
            return encontro;
        }


    }
}

using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        public void cargarContratosDelArchivo() { 
            PersistenciaContato persistenciaContato = new PersistenciaContato();
            contratos = persistenciaContato.LeerContratoCompraDesdeArchivo("contratos.txt");
          
        }

        public void generarUnContratoCompra()
        {
            Console.Clear();

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
            contratos.Add(contrato);
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

        public Contrato buscarContratoEnLista(String codigo)
        {
            for (int i = 0; i < contratos.Count; i++)
            {
                if (contratos[i].codigoContrato.Equals(codigo))
                {
                    return contratos[i];
                }
            }
            return null;
        }
        
        public bool listaVacia()
        {
            cargarContratosDelArchivo();

            if(contratos.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void consultarContratoEnLista()
        {
            if (!listaVacia()) {

                Contrato contrato = new Contrato();
                string codigo;
                int intentos = 0, intentosRestantes = 3;
                while (true && intentos != 3)
                {
                    Console.Clear();
                    Console.SetCursorPosition(53, 5); Console.Write("Consultar Contrato");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Codigo Del Contrato");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.SetCursorPosition(58, 8); codigo = Console.ReadLine();
                    Console.SetCursorPosition(48, 11); Console.Write("Intentos Restantes: " + intentosRestantes);

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        contrato = buscarContratoEnLista(codigo);
                        if (contrato == null)
                        {
                            Console.SetWindowPosition(48, 12); Console.Write("No Hay Elementos Con Ese Codigo");
                            Console.ReadKey();
                            intentos++;
                            intentosRestantes--;
                        }
                        else
                        {
                            mostrarInformacionContrato(contrato);
                            break;
                        }
                    }
                    else
                    {
                        intentos++;
                        intentosRestantes--;
                        Console.SetCursorPosition(48, 11); Console.Write("No Se Admiten Campos Vacios");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(48, 10); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
            }
        }

        public void mostrarInformacionContrato(Contrato contrato)
        {   
          Console.Clear();
            Console.SetCursorPosition(10, 3); Console.Write("Codigo Contrato:  ");
            Console.SetCursorPosition(35, 3); Console.Write(contrato.codigoContrato);
            Console.SetCursorPosition(10, 4); Console.Write("Fecha De Emision:  ");
            Console.SetCursorPosition(35, 4); Console.Write(contrato.fechaEmisionContrato);
            Console.SetCursorPosition(10, 5); Console.Write("Estado Del Contrato: ");
            Console.SetCursorPosition(35, 5); Console.Write(contrato.estadoContrato);
            Console.SetCursorPosition(15, 7); Console.Write("DATOS DEL CLIENTE");
            Console.SetCursorPosition(10, 8); Console.Write("ID ");
            Console.SetCursorPosition(10, 9); Console.Write(contrato.idComprador);
            Console.SetCursorPosition(25, 8); Console.Write("APELLIDO");
            Console.SetCursorPosition(25, 9); Console.Write(contrato.apellidoComprador);
            Console.SetCursorPosition(40, 8); Console.Write("NOMBRE ");
            Console.SetCursorPosition(40, 9); Console.Write(contrato.nombreComprador);
            Console.SetCursorPosition(55, 8); Console.Write("TELEFONO ");
            Console.SetCursorPosition(55, 9); Console.Write(contrato.telefonoComprador);
            Console.SetCursorPosition(15, 11); Console.Write("DATOS DEL PRODUCTO");
            Console.SetCursorPosition(10, 13); Console.Write("PUREZA");
            Console.SetCursorPosition(10, 14); Console.Write(contrato.purezaProducto);
            Console.SetCursorPosition(25, 13); Console.Write("PESO ");
            Console.SetCursorPosition(25, 14); Console.Write(contrato.pesoProducto);
            Console.SetCursorPosition(40, 13); Console.Write("VALOR GRAMO ");
            Console.SetCursorPosition(40, 14); Console.Write(contrato.valorPorGramoOro);
            Console.SetCursorPosition(55, 13); Console.Write("DESCRIPCCION");
            Console.SetCursorPosition(55, 14); Console.Write(contrato.descripciobProducto);
            Console.SetCursorPosition(5, 16); Console.Write("-------------------------------------------------------------------------------");
            Console.SetCursorPosition(10, 18); Console.Write("VALOR TOTAL ");
            Console.SetCursorPosition(35, 18); Console.Write(contrato.valorProducto);
            Console.SetCursorPosition(10, 19); Console.Write("SALDO ");
            Console.SetCursorPosition(35, 19); Console.Write(contrato.saldoContrato);
            Console.ReadKey();
            Console.Clear();
        }
    }
}

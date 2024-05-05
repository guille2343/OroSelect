using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionContratoCompra
    {
        public List<ContratoCompra> contratosCompra = new List<ContratoCompra>();

        public GestionContratoCompra() { }  

        public void generarContratoCompra()
        {
            GestionCliente gestionCliente = new GestionCliente();
            Cliente cliente = new Cliente();
            int opcion;
            string opcionMenu;
            bool salir = false;

            while (!salir)
            {
                Console.SetCursorPosition(53, 1); Console.Write("Generar Contato Compra");
                Console.SetCursorPosition(48, 3); Console.Write("Cliente");
                Console.SetCursorPosition(48, 4); Console.Write("1. Cliente Nuevo");
                Console.SetCursorPosition(48, 5); Console.Write("2. Seleccionar En Lista");
                Console.SetCursorPosition(48, 7); Console.Write("Seleccione Una Opcion: ");

                while (true)
                {
                    Console.SetCursorPosition(48, 10); Console.Write("                                                            ");
                    Console.SetCursorPosition(73, 7); Console.Write("      ");
                    Console.SetCursorPosition(73, 7); opcionMenu = Console.ReadLine();
                    validarEntero(opcionMenu);
                    if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                    {
                        opcion = int.Parse(opcionMenu);
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 10); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
                        Console.ReadKey();
                    }
                }

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        cliente = cliente.crearNuevoCliente();
                        gestionCliente.clienteAgregarALaLista(cliente);
                        Console.ReadKey(); 
                        Console.Clear();
                        salir = true;
                        break;
                    case 2:
                        cliente = clienteNuevoParaContrato();
                        salir = true;
                        break;
                    default:
                        Console.SetCursorPosition(48, 16); Console.Write("Opción no válida. Inténtalo de nuevo.");
                        Console.ReadKey();
                        break;
                }
            }

            ProductoOro productoOro = new ProductoOro();
            productoOro = productoOro.crearNuevoProductoOro();
            Console.Clear();
            ContratoCompra contratoCompra = new ContratoCompra();
            contratoCompra = contratoCompra.generarContratoCompra(cliente, productoOro);
            Console.Clear();
        }

        public Cliente clienteNuevoParaContrato()
        {
            Cliente cliente = new Cliente();
            GestionCliente gestionCliente = new GestionCliente();
            String codigo;
            if (gestionCliente.listaClienteVacia())
            {
                Console.SetCursorPosition(48, 10); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();

                cliente = cliente.crearNuevoCliente();
                gestionCliente.clienteAgregarALaLista(cliente);
                Console.ReadKey();
                Console.Clear(); ;

            }
            else
            {
                bool seguir = true;
                while (seguir )
                {
                    Console.SetCursorPosition(48, 11); Console.Write("                                             ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.SetCursorPosition(53, 5); Console.Write("Consultar Cliente");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Cliente a Consultar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        cliente = gestionCliente.clienteBuscarEnLista(codigo);

                        if (cliente != null)
                        {
                            seguir = false;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Cliente no encontrado.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 11); Console.Write("Error: No se admiten campos vacíos.");
                        Console.ReadKey();
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
            return cliente;
        }

        public bool validarEntero(string dato)
        {
            int enteroProducto;
            try
            {
                enteroProducto = int.Parse(dato);
                if (enteroProducto <= 0)
                {
                    return false;
                }

            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            return true;
        }
    }
}

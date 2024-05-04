using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionCliente
    {
        public List<Cliente> clientes = new List<Cliente>();

        public GestionCliente()
        {

        }

        public bool listaClienteVacia()
        {
            if (clientes.Count != 0) { return false; }
            return true;
        }

        public void clienteAgregarALaLista(Cliente cliente)
        {

            bool clienteExiste = false;

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].id == cliente.id)
                {
                    clienteExiste = true;
                    break;
                }
            }

            if (clienteExiste)
            {
                Console.SetCursorPosition(10, 15); Console.WriteLine("El cliente ya existe en la lista.");
            }
            else
            {
                clientes.Add(cliente);
            }

        }

        public Cliente clienteBuscarEnLista(String codigo)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].codigoCliente.Equals(codigo))
                {
                    return clientes[i];
                }
            }
            return null;
        }

        public bool clienteEliminarDeLista(String codigo)
        {
            int encontrado = -1;

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].id.Equals(codigo))
                {
                    clientes.RemoveAt(i);
                    encontrado = i;
                    break;
                }
            }
            if (encontrado == -1)
            {
                return false;
            }

            return true;
        }

        public void modificarDatosCliente()
        {
            Cliente cliente;

            if (listaClienteVacia())
            {
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                string codigo;
                int intentos = 0, intentosRetantes = 3;
                while (true && intentos != 3)
                {
                    Console.SetCursorPosition(48, 9); Console.Write("Intentos Restantes: " + intentosRetantes);
                    Console.SetCursorPosition(48, 11); Console.Write("                                             ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.SetCursorPosition(53, 5); Console.Write("Editar Cliente");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Cliente a Consultar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        cliente = clienteBuscarEnLista(codigo);

                        if (cliente != null)
                        {
                            cliente = editarClienteAuxiliar(cliente);

                            //clientes.Insert(posicionDelObjetoEnLista, cliente);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Cliente no encontrado.");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 11); Console.Write("Error: No se admiten campos vacíos.");
                        Console.ReadKey();
                        intentos++;
                        intentosRetantes--;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }

        }

        public Cliente editarClienteAuxiliar(Cliente cliente)
        {   
            string telefono;

            Console.Clear();
            Console.SetCursorPosition(53, 5); Console.Write("Datos del Cliente");
            Console.SetCursorPosition(48, 7); Console.Write("Código: ");
            Console.SetCursorPosition(70, 7); Console.Write(cliente.codigoCliente);
            Console.SetCursorPosition(48, 8); Console.Write("No. Identificación: ");
            Console.SetCursorPosition(70, 8); Console.Write(cliente.id);


            while (true)
            {
                Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(70, 9); Console.Write("                                                              ");

                Console.SetCursorPosition(48, 9); Console.Write("Apellido: ");
                Console.SetCursorPosition(70, 9); cliente.apellido = Console.ReadLine();
                if (!String.IsNullOrEmpty(cliente.apellido) && cliente.validarStringAceptarSoloLetras(cliente.apellido))
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }
            while (true)
            {
                Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(70, 10); Console.Write("                                                              ");

                Console.SetCursorPosition(48, 10); Console.Write("Nombre: ");
                Console.SetCursorPosition(70, 10); cliente.nombre = Console.ReadLine();
                if (!String.IsNullOrEmpty(cliente.nombre) && cliente.validarStringAceptarSoloLetras(cliente.nombre))
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(70, 11); Console.Write("                                   ");

                Console.SetCursorPosition(48, 11); Console.Write("Teléfono: ");
                Console.SetCursorPosition(70, 11); telefono = Console.ReadLine();
                cliente.validarLong(telefono);

                if (!String.IsNullOrEmpty(telefono) && cliente.validarLong(telefono))
                {
                    cliente.telefono = telefono;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(40, 17); Console.Write("                                                     ");

                Console.SetCursorPosition(48, 12); Console.Write("Direccion");
                Console.SetCursorPosition(70, 12); cliente.direccion = Console.ReadLine();
                if (!String.IsNullOrEmpty(cliente.direccion))
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(40, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }

            return cliente;
        }

        public void RegistrarClientes()
        {
            Cliente cliente = new Cliente();
            cliente = cliente.crearNuevoCliente();
            clienteAgregarALaLista(cliente);
            Console.ReadKey();
            Console.Clear();
        }


        public void mostrarListaClientes()
        {
            if (listaClienteVacia())
            {
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int posicionPantalla = 8;
                Console.SetCursorPosition(53, 5); Console.Write("Listado De Clientes");
                Console.SetCursorPosition(10, 7); Console.Write("COIDIGO");
                Console.SetCursorPosition(25, 7); Console.Write("ID");
                Console.SetCursorPosition(40, 7); Console.Write("APELLIDO");
                Console.SetCursorPosition(55, 7); Console.Write("NOMBRE");
                Console.SetCursorPosition(70, 7); Console.Write("TLEFONO");
                Console.SetCursorPosition(85, 7); Console.Write("DIRECCION");
                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.SetCursorPosition(10, posicionPantalla); Console.Write(clientes[i].codigoCliente);
                    Console.SetCursorPosition(25, posicionPantalla); Console.Write(clientes[i].id);
                    Console.SetCursorPosition(40, posicionPantalla); Console.Write(clientes[i].apellido);
                    Console.SetCursorPosition(55, posicionPantalla); Console.Write(clientes[i].nombre);
                    Console.SetCursorPosition(70, posicionPantalla); Console.Write(clientes[i].telefono);
                    Console.SetCursorPosition(85, posicionPantalla); Console.Write(clientes[i].direccion);

                    posicionPantalla++;
                }
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void consultarUnCliente()
        {
            Cliente cliente;   
            string codigo;

            if (listaClienteVacia())
            {
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                int intentos = 0, intentosRetantes = 3;
                while (true && intentos != 3)
                {
                    Console.SetCursorPosition(48, 9); Console.Write("Intentos Restantes: " + intentosRetantes);
                    Console.SetCursorPosition(48, 11); Console.Write("                                             ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.SetCursorPosition(53, 5); Console.Write("Consultar Cliente");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Cliente a Consultar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        cliente = clienteBuscarEnLista(codigo);

                        if (cliente != null)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(53, 5); Console.Write("Datos del Cliente");
                            Console.SetCursorPosition(48, 7); Console.Write("Código: ");
                            Console.SetCursorPosition(70, 7); Console.Write(cliente.codigoCliente);
                            Console.SetCursorPosition(48, 8); Console.Write("No. Identificación: ");
                            Console.SetCursorPosition(70, 8); Console.Write(cliente.id);
                            Console.SetCursorPosition(48, 9); Console.Write("Apellido: ");
                            Console.SetCursorPosition(70, 9); Console.Write(cliente.apellido);
                            Console.SetCursorPosition(48, 10); Console.Write("Nombre: ");
                            Console.SetCursorPosition(70, 10); Console.Write(cliente.nombre);
                            Console.SetCursorPosition(48, 11); Console.Write("Teléfono: ");
                            Console.SetCursorPosition(70, 11); Console.Write(cliente.telefono);
                            Console.SetCursorPosition(48, 12); Console.Write("Direccion");
                            Console.SetCursorPosition(70, 12); Console.Write(cliente.direccion);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Cliente no encontrado.");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 11); Console.Write("Error: No se admiten campos vacíos.");
                        Console.ReadKey();
                        intentos++;
                        intentosRetantes--;
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void eliminarCliente()
        {
            if (listaClienteVacia())
            {
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                string id;
                int intentos = 0, intentosRetantes = 3;
                while (true && intentos != 3)
                {
                    Console.SetCursorPosition(48, 9); Console.Write("Intentos Restantes: " + intentosRetantes);
                    Console.SetCursorPosition(48, 11); Console.Write("                                                  ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.SetCursorPosition(53, 5); Console.Write("Eliminar Cliente");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese La Identificacion Del Cliente A Eliminar");
                    Console.SetCursorPosition(48, 8); Console.Write("Id: ");
                    Console.SetCursorPosition(60, 8); id = Console.ReadLine();

                    if (!string.IsNullOrEmpty(id))
                    {
                        bool mensaje = clienteEliminarDeLista(id);

                        if (mensaje)
                        {
                            Console.SetCursorPosition(48, 11); Console.Write("Se Elimino Correctamente");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 11); Console.Write("No Se Encontro Un Cliente Con Esa Id");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 11); Console.Write("Error: No Se Admiten Campos Vacios.");
                        Console.ReadKey();
                        intentos++;
                        intentosRetantes--;
                    }
                }
            }
            Console.Clear();
        }
    }
}


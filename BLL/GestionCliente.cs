﻿using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
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

        //esta funcion esta encargada de llenar la lista de clientes con la informacion que tenemos guardada en archivo de texto
        public void descargarArchivoCliente()
        {
            PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
            clientes = persistenciaCliente.LeerClientesDesdeArchivo("clientes.txt");
        }

        //retorna un true si la lista esta vacia y false si en la lista hay objetos(es una validacion)
        public bool listaClienteVacia()
        {
            if (clientes.Count != 0) { return false; }
            return true;
        }

        //esta funcion solo agrega clientes a la lista
        public void clienteAgregarALaLista(Cliente cliente)
        {
                clientes.Add(cliente);
        }

        //esta funcion valida que no hayan clientes repetidos en la lista 
        public bool clienteRepetido(String codigo)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].id.Equals(codigo))
                {
                    return true;
                }
            }
            return false;
        }


        //esta funcion busca un cliente de la lista de clientes y retorna ese cliente si lo encuentra, de lo contrario retorna null
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

        //esta es la funcion encargada de editar los datos de un cliente
        public void modificarDatosCliente()
        {
            Cliente cliente;
            descargarArchivoCliente();//llamamos la funcion para cargar en la lista de la clase, los objetos que hayan en archivo

            if (listaClienteVacia()) //validamos que si existen objetos en la lista
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 10); Console.Write("No Se Encontraton Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                string codigo;
                int intentos = 0, intentosRetantes = 3;//limitamos el intento de busqueda a 3 intentos, de lo contrario se saldra

                while (true && intentos != 3)//bucle infinito hasta que los intentos sean 3 o hasta que se halle el objeto
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 9); Console.Write("Intentos Restantes: " + intentosRetantes);
                    Console.SetCursorPosition(48, 11); Console.Write("                                             ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(53, 5); Console.Write("MODIFICAR DATOS");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Cliente a Consultar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))//validacion de string vacios o nulos
                    {
                        cliente = clienteBuscarEnLista(codigo);

                        if (cliente != null)
                        {
                            PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
                            cliente = editarClienteAuxiliar(cliente);
                            //una vez modificado el objeto en la lista, sobre escribimos el archivo con el objeto modificado de esta forma se guardaran los cambios
                            persistenciaCliente.sobreescribirClientesEnArchivo(clientes, "clientes.txt");
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Registro no encontrado.");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(48, 11); Console.Write("Error: No se admiten campos vacíos.");
                        Console.ReadKey();
                        intentos++;
                        intentosRetantes--;
                    }
                }
                Console.ResetColor();
                Console.Clear();
            }

        }

        //funcion axiliar de la que esta arriba, esto para que no se haga tan extensa una sola funcion, esta lleva 
        //la logica de modificar los atributos del objeto y retorna el objeto mdificado
        public Cliente editarClienteAuxiliar(Cliente cliente)
        {   
            string telefono;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(53, 5); Console.Write("DATOS DEL CLIENTE");
            Console.SetCursorPosition(48, 7); Console.Write("CODIGO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 7); Console.Write(cliente.codigoCliente);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 8); Console.Write("IDENTIFICACION: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 8); Console.Write(cliente.id);


            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                              ");
                Console.SetCursorPosition(70, 9); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 9); Console.Write("APELLIDO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 9); cliente.apellido = Console.ReadLine();
                if (!String.IsNullOrEmpty(cliente.apellido) && cliente.validarStringAceptarSoloLetras(cliente.apellido))
                {
                    cliente.apellido.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }
            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(70, 10); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 10); Console.Write("NOMBRE: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 10); cliente.nombre = Console.ReadLine();
                if (!String.IsNullOrEmpty(cliente.nombre) && cliente.validarStringAceptarSoloLetras(cliente.nombre))
                {
                    cliente.nombre.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(70, 11); Console.Write("                                   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 11); Console.Write("TELEFONO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 11); telefono = Console.ReadLine();
                cliente.validarLong(telefono);

                if (!String.IsNullOrEmpty(telefono) && cliente.validarLong(telefono))
                {
                    cliente.telefono = telefono;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 12); Console.Write("DIRECCION:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 12); cliente.direccion = Console.ReadLine();
                if (!String.IsNullOrEmpty(cliente.direccion))
                {
                    cliente.direccion.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }
            Console.ResetColor();
            return cliente;  
        }


        //esta funncion es la funcion principal, encargada de guardar los clientes en lista 
        public void RegistrarClientes()
        {
            descargarArchivoCliente();
            PersistenciaCliente pc = new PersistenciaCliente(); 
            Cliente cliente = new Cliente();
            cliente = cliente.crearNuevoCliente();
            clienteRepetido(cliente.id);

            if (clienteRepetido(cliente.id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 15); Console.Write("Ya Existe Un Registro Con Esta Identidifacion");
            }
            else
            {
                clienteAgregarALaLista(cliente);
                pc.GuardarClienteEnArchivo(cliente, "clientes.txt");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(48, 10); Console.Write("Almacenado De Forma Exitosa...");
                Console.ReadKey();
            }
            Console.ResetColor ();
            Console.Clear();
        }

        //funcion encargada de mosstrar en forma de lista los clientes existentes en el archivo
        public void mostrarListaClientes()
        {
            descargarArchivoCliente();
            if (listaClienteVacia())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 10); Console.Write("No Hay Elementos En La Lista...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int posicionPantalla = 8;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(53, 5); Console.Write("LISTADO DE CLIENTES");
                Console.SetCursorPosition(10, 7); Console.Write("COIDIGO");
                Console.SetCursorPosition(25, 7); Console.Write("ID");
                Console.SetCursorPosition(40, 7); Console.Write("APELLIDO");
                Console.SetCursorPosition(55, 7); Console.Write("NOMBRE");
                Console.SetCursorPosition(70, 7); Console.Write("TLEFONO");
                Console.SetCursorPosition(85, 7); Console.Write("DIRECCION");
                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(10, posicionPantalla); Console.Write(clientes[i].codigoCliente);
                    Console.SetCursorPosition(25, posicionPantalla); Console.Write(clientes[i].id);
                    Console.SetCursorPosition(40, posicionPantalla); Console.Write(clientes[i].apellido);
                    Console.SetCursorPosition(55, posicionPantalla); Console.Write(clientes[i].nombre);
                    Console.SetCursorPosition(70, posicionPantalla); Console.Write(clientes[i].telefono);
                    Console.SetCursorPosition(85, posicionPantalla); Console.Write(clientes[i].direccion);

                    posicionPantalla++;
                }
            }

            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        //esta funcion busca un cliente de la lista por su codigo
        public void consultarUnCliente()
        {
            Cliente cliente;   
            string codigo;
            descargarArchivoCliente();

            if (listaClienteVacia())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                int intentos = 0, intentosRetantes = 3;
                while (true && intentos != 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 9); Console.Write("Intentos Restantes: " + intentosRetantes);
                    Console.SetCursorPosition(48, 11); Console.Write("                                             ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(53, 5); Console.Write("CONSULTAR CLIENTE");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Cliente a Consultar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        cliente = clienteBuscarEnLista(codigo);

                        if (cliente != null)
                        {
                            mostrarCliente(cliente);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Registro no encontrado.");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(48, 11); Console.Write("Error: No se admiten campos vacíos.");
                        Console.ReadKey();
                        intentos++;
                        intentosRetantes--;
                    }
                }
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void mostrarCliente (Cliente cliente)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(53, 5); Console.Write("DATOS DEL CLIENTE");
            Console.SetCursorPosition(48, 7); Console.Write("CODIGO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 7); Console.Write(cliente.codigoCliente);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 8); Console.Write("IDENTIFICACION: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 8); Console.Write(cliente.id);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 9); Console.Write("APELLIDO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 9); Console.Write(cliente.apellido);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 10); Console.Write("NOMBRE: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 10); Console.Write(cliente.nombre);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 11); Console.Write("TELEFONO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 11); Console.Write(cliente.telefono);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 12); Console.Write("DIRECCION");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 12); Console.Write(cliente.direccion);

            Console.ResetColor();
            Console.ReadKey();
        }

        //esta funcion busca un cliente por su id para eliminarlo
        public void eliminarCliente()
        {
            descargarArchivoCliente();

            if (listaClienteVacia())
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 9); Console.Write("Intentos Restantes: " + intentosRetantes);
                    Console.SetCursorPosition(48, 11); Console.Write("                                                  ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(53, 5); Console.Write("ELIMINAR CLIENTE");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Codigo Del Cliente A Eliminar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        int posicion = clienteEliminarDeLista(codigo);

                        if (posicion == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(48, 11); Console.Write("No Se Encontro Un Cliente Con Esa Id");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;

                        }
                        else
                        {
                            mostrarCliente(clientes[posicion]);
                            if (confirmarEliminado())
                            {
                                Console.Clear();
                                clientes.RemoveAt(posicion);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(40, 10); Console.Write("Registro Eliminado Correctamente...");
                                PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
                                persistenciaCliente.sobreescribirClientesEnArchivo(clientes, "clientes.txt");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(40, 10); Console.Write("Proceso Abortado...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                           
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(48, 11); Console.Write("Error: No Se Admiten Campos Vacios.");
                        Console.ReadKey();
                        intentos++;
                        intentosRetantes--;
                    }
                }
            }
            Console.ResetColor();
            Console.Clear();
        }


        //esta funcion busca un cliente en la lista y si lo encuentra lo elimina, retorna un booleano de confirmacion
        //true si lo elimino, false si no lo hizo
        public int clienteEliminarDeLista(String codigo)
        {
            int encontrado = -1;

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].codigoCliente.Equals(codigo))
                {
                    encontrado = i;
                }
            }

            return encontrado;
        }

        public bool confirmarEliminado()
        {
            int seleccion;
            string opccion;
            bool respuesta = true;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 10); Console.Write("Se Eliminara De Forma Permanente Este Contrato");
                Console.SetCursorPosition(48, 12); Console.Write("Esta Seguro De Esto?");
                Console.SetCursorPosition(48, 13); Console.Write("1. Confirmar.");
                Console.SetCursorPosition(48, 14); Console.Write("2. Cancelar.");

                Console.SetCursorPosition(48, 16); Console.Write("Seleccione Una Opcion");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 17); opccion = Console.ReadLine();

                if (!string.IsNullOrEmpty(opccion))
                {
                    if (validarEntero(opccion))
                    {
                        seleccion = int.Parse(opccion);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(48, 20); Console.Write("Elija Una Opcion Valida");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 20); Console.Write("No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }
            if (seleccion == 1)
            {
                respuesta = true;
            }
            else if (seleccion == 2)
            {
                respuesta = false;

            }
            Console.ResetColor();
            return respuesta;
        }

        public bool validarEntero(string dato)
        {
            int enteroProducto;
            try
            {
                enteroProducto = int.Parse(dato);
                if (enteroProducto != 1 && enteroProducto != 2)
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


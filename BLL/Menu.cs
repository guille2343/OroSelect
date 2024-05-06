using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Menu
    {
        public void menuPrincipal()
        {
                int opcion;
                string opcionMenu;
                bool salir = false;
            
                while (!salir)
                {    
                    Console.SetCursorPosition(53, 4); Console.Write("Oro Select");
                    Console.SetCursorPosition(51, 5); Console.Write("Menu Principal");
                    Console.SetCursorPosition(48, 7); Console.WriteLine("1. Gestionar Clientes");
                    Console.SetCursorPosition(48, 8); Console.WriteLine("2. Gestionar Empleados");
                    Console.SetCursorPosition(48, 9); Console.WriteLine("3. Gestionar Gerentes");
                    Console.SetCursorPosition(48, 10); Console.WriteLine("4. Gestionar Contratos");
                    Console.SetCursorPosition(48, 11); Console.WriteLine("5. Gestion Productos");
                    Console.SetCursorPosition(48, 12); Console.WriteLine("6. Salir");
            
                    Console.SetCursorPosition(48, 14); Console.Write("Selecciones Una Opcion: ");
            
                    while (true) {
                         
                        Console.SetCursorPosition(48, 17); Console.Write("                                                            ");
                        Console.SetCursorPosition(73, 14); Console.Write("      ");
                        Console.SetCursorPosition(73, 14); opcionMenu = Console.ReadLine();
                        validarEntero(opcionMenu);
                        if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                        {
                            opcion = int.Parse(opcionMenu);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 17); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
                            Console.ReadKey();
                        }
                    }
            
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            menuCliente();
                            break;
                        case 2:
                            Console.Clear();
                            menuEmpleado();
                            break;
                        case 3:
                            Console.Clear();
                            menuGerente();
                            break;
                        case 4:
                            Console.Clear();
                            menuContrato();
                            break;
                        case 5:
                            Console.Clear();
                            gestionarProductos();
                            break;
                        case 6:
                            Console.SetCursorPosition(48, 16); Console.Write("Saliendo del programa...");
                            salir = true;
                            break;
                        default:
                            Console.SetCursorPosition(48, 16); Console.Write("Opción no válida. Inténtalo de nuevo.");
                            Console.ReadKey();
                            break;
                    }
                }
            
            }
            
            public void menuCliente()
            {
                GestionCliente gestionCliente = new GestionCliente();
                int opcion;
                string opcionMenu;
                bool salir = false;
            
                while (!salir)
                {
                    Console.SetCursorPosition(53, 4); Console.Write("Oro Select");
                    Console.SetCursorPosition(49, 5); Console.Write("Gestionar Clientes");                
                    Console.SetCursorPosition(48, 7); Console.WriteLine("1. Registrar Cliente Nuevo");
                    Console.SetCursorPosition(48, 8); Console.WriteLine("2. Modificar Datos Del Cliente");
                    Console.SetCursorPosition(48, 9); Console.WriteLine("3. Lista De Clientes ");
                    Console.SetCursorPosition(48, 10); Console.WriteLine("4. Consultar Cliente");
                    Console.SetCursorPosition(48, 11); Console.WriteLine("5. Eliminar Cliente");
                    Console.SetCursorPosition(48, 12); Console.WriteLine("6. Volver Al Menu Principal");
            
                    Console.SetCursorPosition(48, 14); Console.Write("Selecciones Una Opcion: ");
            
                    while (true)
                    {
            
                        Console.SetCursorPosition(48, 18); Console.Write("                                                            ");
                        Console.SetCursorPosition(73, 14); Console.Write("      ");
                        Console.SetCursorPosition(73, 14); opcionMenu = Console.ReadLine();
                        validarEntero(opcionMenu);
                        if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                        {
                            opcion = int.Parse(opcionMenu);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 18); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
                            Console.ReadKey();
                        }
                    }
            
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            gestionCliente.RegistrarClientes();
                            break;
                        case 2:
                            Console.Clear();
                            gestionCliente.modificarDatosCliente();
                            break;
                        case 3:
                            Console.Clear();
                            gestionCliente.mostrarListaClientes();
                            break;
                        case 4:
                            Console.Clear();
                            gestionCliente.consultarUnCliente();
                            break;
                        case 5:
                            Console.Clear();
                            gestionCliente.eliminarCliente();
                            break;
                        case 6:
                            Console.Clear();
                            salir = true;
                            break;
                        default:
                            Console.SetCursorPosition(48, 18); Console.Write("Opción no válida. Inténtalo de nuevo.");
                            Console.ReadKey();
                            break;
                    }
                }
            
            }
            
            public void menuEmpleado()
            {
                GestionEmpleado gestionEmpleado = new GestionEmpleado();
                int opcion;
                string opcionMenu;
                bool salir = false;
            
                while (!salir)
                {
                    Console.SetCursorPosition(53, 4); Console.Write("Oro Select");
                    Console.SetCursorPosition(49, 5); Console.Write("Gestionar Empleados");
                    Console.SetCursorPosition(48, 7); Console.WriteLine("1. Registrar Emplado");
                    Console.SetCursorPosition(48, 8); Console.WriteLine("2. Modificar Datos Del Empleado");
                    Console.SetCursorPosition(48, 9); Console.WriteLine("3. Listar Personal ");
                    Console.SetCursorPosition(48, 10); Console.WriteLine("4. Consultar Datos Del Emplado");
                    Console.SetCursorPosition(48, 11); Console.WriteLine("5. Eliminar Empleado");
                    Console.SetCursorPosition(48, 12); Console.WriteLine("6. Volver Al Menu Principal");
            
                    Console.SetCursorPosition(48, 14); Console.Write("Selecciones Una Opcion: ");
            
                    while (true)
                    {
            
                        Console.SetCursorPosition(48, 18); Console.Write("                                                            ");
                        Console.SetCursorPosition(73, 14); Console.Write("      ");
                        Console.SetCursorPosition(73, 14); opcionMenu = Console.ReadLine();
                        validarEntero(opcionMenu);
                        if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                        {
                            opcion = int.Parse(opcionMenu);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 18); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
                            Console.ReadKey();
                        }
                    }
            
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            gestionEmpleado.RegistrarEmpleado();
                            break;
                        case 2:
                            Console.Clear();
                            gestionEmpleado.modificarDatosEmpleado();
                            break;
                        case 3:
                            Console.Clear();
                            gestionEmpleado.mostrarListaEmpleado();
                            break;
                        case 4:
                            Console.Clear();
                            gestionEmpleado.consultarUnEmpleado();
                            break;
                        case 5:
                            Console.Clear();
                            gestionEmpleado.eliminarEmpleado();
                            break;
                        case 6:
                            Console.Clear();
                            salir = true;
                            break;
                        default:
                            Console.SetCursorPosition(48, 18); Console.Write("Opción no válida. Inténtalo de nuevo.");
                            Console.ReadKey();
                            break;
                    }
                }
            
            }

        public void menuContrato()
        {
            GestionContrato gestionContrato = new GestionContrato();
            int opcion;
            string opcionMenu;
            bool salir = false;

            while (!salir)
            {
                Console.SetCursorPosition(53, 4); Console.Write("Oro Select");
                Console.SetCursorPosition(49, 5); Console.Write("Gestionar Contratos");
                Console.SetCursorPosition(48, 7); Console.WriteLine("1. Emitir Nuevo Contrato");
                Console.SetCursorPosition(48, 8); Console.WriteLine("2. Realizar Abono Al Contrato");
                Console.SetCursorPosition(48, 9); Console.WriteLine("3. Lista De Contratos ");
                Console.SetCursorPosition(48, 10); Console.WriteLine("4. Consultar Contrato");
                Console.SetCursorPosition(48, 11); Console.WriteLine("5. Eliminar Contrato");
                Console.SetCursorPosition(48, 12); Console.WriteLine("6. Volver Al Menu Principal");

                Console.SetCursorPosition(48, 14); Console.Write("Selecciones Una Opcion: ");

                while (true)
                {

                    Console.SetCursorPosition(48, 18); Console.Write("                                                            ");
                    Console.SetCursorPosition(73, 14); Console.Write("      ");
                    Console.SetCursorPosition(73, 14); opcionMenu = Console.ReadLine();
                    validarEntero(opcionMenu);
                    if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                    {
                        opcion = int.Parse(opcionMenu);
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 18); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
                        Console.ReadKey();
                    }
                }

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        gestionContrato.generarUnContratoCompra();
                        break;
                    case 2:
                        Console.Clear();
                        gestionContrato.realizarAbonoAlContrato();
                        break;
                    case 3:
                        Console.Clear();
                        gestionContrato.generarListaContratos();
                        break;
                    case 4:
                        Console.Clear();
                        gestionContrato.consultarContratoEnLista();
                        break;
                    case 5:
                        Console.Clear();
                        gestionContrato.eliminarUnContrato();
                        break;
                    case 6:
                        Console.Clear();
                        salir = true;
                        break;
                    default:
                        Console.SetCursorPosition(48, 18); Console.Write("Opción no válida. Inténtalo de nuevo.");
                        Console.ReadKey();
                        break;
                }
            }

        }


        public void menuGerente()
            {
                GestionGerente gestionGerente = new GestionGerente();
                int opcion;
                string opcionMenu;
                bool salir = false;
            
                while (!salir)
                {
                    Console.SetCursorPosition(53, 4); Console.Write("Oro Select");
                    Console.SetCursorPosition(49, 5); Console.Write("Gestionar Gerente");
                    Console.SetCursorPosition(48, 7); Console.WriteLine("1. Registrar Gerente");
                    Console.SetCursorPosition(48, 8); Console.WriteLine("2. Modificar Datos Del Gerente");
                    Console.SetCursorPosition(48, 9); Console.WriteLine("3. Listar Personal ");
                    Console.SetCursorPosition(48, 10); Console.WriteLine("4. Consultar Datos Del Gerente");
                    Console.SetCursorPosition(48, 11); Console.WriteLine("5. Eliminar Gerente");
                    Console.SetCursorPosition(48, 12); Console.WriteLine("6. Volver Al Menu Principal");
            
                    Console.SetCursorPosition(48, 14); Console.Write("Selecciones Una Opcion: ");
            
                    while (true)
                    {
            
                        Console.SetCursorPosition(48, 18); Console.Write("                                                            ");
                        Console.SetCursorPosition(73, 14); Console.Write("      ");
                        Console.SetCursorPosition(73, 14); opcionMenu = Console.ReadLine();
                        validarEntero(opcionMenu);
                        if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                        {
                            opcion = int.Parse(opcionMenu);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 18); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
                            Console.ReadKey();
                        }
                    }
            
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            gestionGerente.RegistrarGerente();
                            break;
                        case 2:
                            Console.Clear();
                            gestionGerente.modificarDatosGerente();
                            break;
                        case 3:
                            Console.Clear();
                            gestionGerente.mostrarListaGerente();
                            break;
                        case 4:
                            Console.Clear();
                            gestionGerente.consultarUnGerente();
                            break;
                        case 5:
                            Console.Clear();
                            gestionGerente.eliminarGerente();
                            break;
                        case 6:
                            Console.Clear();
                            salir = true;
                            break;
                        default:
                            Console.SetCursorPosition(48, 18); Console.Write("Opción no válida. Inténtalo de nuevo.");
                            Console.ReadKey();
                            break;
                    }
                }
            
            }
            
            public void gestionarProductos()
            {
                int opcion;
                string opcionMenu;
                bool salir = false;
            
                while (!salir)
                {
                    Console.SetCursorPosition(53, 4); Console.Write("Oro Select");
                    Console.SetCursorPosition(49, 5); Console.Write("Opciones De Inventario");
                    Console.SetCursorPosition(48, 7); Console.WriteLine("1. Registrar Emplado");
                    Console.SetCursorPosition(48, 8); Console.WriteLine("2. Modificar Datos Del Empleado");
                    Console.SetCursorPosition(48, 9); Console.WriteLine("3. Listar Personal ");
                    Console.SetCursorPosition(48, 10); Console.WriteLine("4. Consultar Datos Del Emplado");
                    Console.SetCursorPosition(48, 11); Console.WriteLine("5. Eliminar Empleado");
                    Console.SetCursorPosition(48, 12); Console.WriteLine("6. Volver Al Menu Principal");
            
                    Console.SetCursorPosition(48, 14); Console.Write("Selecciones Una Opcion: ");
            
                    while (true)
                    {
            
                        Console.SetCursorPosition(48, 18); Console.Write("                                                            ");
                        Console.SetCursorPosition(73, 14); Console.Write("      ");
                        Console.SetCursorPosition(73, 14); opcionMenu = Console.ReadLine();
                        validarEntero(opcionMenu);
                        if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                        {
                            opcion = int.Parse(opcionMenu);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 18); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
                            Console.ReadKey();
                        }
                    }
            
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Has elegido la opción 1");
                            // Agrega aquí la lógica para la opción 1
                            break;
                        case 2:
                            Console.WriteLine("Has elegido la opción 2");
                            // Agrega aquí la lógica para la opción 2
                            break;
                        case 3:
                            Console.WriteLine("Has elegido la opción 3");
                            // Agrega aquí la lógica para la opción 3
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        case 6:
                            Console.Clear();
                            salir = true;
                            break;
                        default:
                            Console.SetCursorPosition(48, 18); Console.Write("Opción no válida. Inténtalo de nuevo.");
                            Console.ReadKey();
                            break;
                    }
                }
            
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

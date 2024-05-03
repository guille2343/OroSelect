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
                Console.SetCursorPosition(15, 4); Console.Write("Oro Select");
                Console.SetCursorPosition(13, 5); Console.Write("Menu Principal");
                Console.SetCursorPosition(10, 7); Console.Write("Selecciones Una Opcion: ");
                Console.SetCursorPosition(10, 9); Console.WriteLine("1. Gestionar Clientes");
                Console.SetCursorPosition(10, 10); Console.WriteLine("2. Gestionar Personal");
                Console.SetCursorPosition(10, 11); Console.WriteLine("3. Opciones De Inventario ");
                Console.SetCursorPosition(10, 12); Console.WriteLine("4. Salir");

                while (true) {
                     
                    Console.SetCursorPosition(10, 20); Console.Write("                                                            ");
                    Console.SetCursorPosition(35, 7); Console.Write("      ");
                    Console.SetCursorPosition(35, 7); opcionMenu = Console.ReadLine();
                    validarEntero(opcionMenu);
                    if (!String.IsNullOrEmpty(opcionMenu) && validarEntero(opcionMenu))
                    {
                        opcion = int.Parse(opcionMenu);
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 20); Console.Write("Error... Solo Caracter Numerico, Intente Nuevamente");
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
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
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

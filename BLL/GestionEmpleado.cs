using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionEmpleado
    {
        public List<Empleado> empleados = new List<Empleado>();

        public GestionEmpleado() { }
        
        public void descargarArchivoEmpleado()
        {
            PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
            empleados = persistenciaEmpleado.LeerEmpleadoDesdeArchivo("empleados.txt");
        }
        
        public bool empleadosRepetido(String codigo)
        {
            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].id.Equals(codigo))
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool listaEmpleadoVacia()
        {
            if (empleados.Count != 0) { return false; }
            return true;
        }
        
        public void empleadoAgregarALaLista(Empleado empleado)
        {          
            empleados.Add(empleado);
        }
        
        public Empleado empleadoBuscarEnLista(String codigo)
        {
            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].codigoEmpleado.Equals(codigo))
                {
                    return empleados[i];
                }
            }
            return null;
        }
        
        public void modificarDatosEmpleado()
        {
            Empleado empleado;
            descargarArchivoEmpleado();
        
            if (listaEmpleadoVacia())
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
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Código Del Empleado A Consultar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();
        
                    if (!string.IsNullOrEmpty(codigo))
                    {
                        empleado = empleadoBuscarEnLista(codigo);
        
                        if (empleado != null)
                        {
                            PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                            empleado = editarEmpleadoAuxiliar(empleado);
                            persistenciaEmpleado.sobreescribirEmpleadoEnArchivo(empleados, "empleados.txt");
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Empleado no encontrado.");
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
        
        public Empleado editarEmpleadoAuxiliar(Empleado empleado)
        {
            string telefono, salario;
        
            Console.Clear();
            Console.SetCursorPosition(53, 5); Console.Write("Datos del Empleado");
            Console.SetCursorPosition(48, 7); Console.Write("Código: ");
            Console.SetCursorPosition(70, 7); Console.Write(empleado.codigoEmpleado);
            Console.SetCursorPosition(48, 8); Console.Write("No. Identificación: ");
            Console.SetCursorPosition(70, 8); Console.Write(empleado.id);
        
        
            while (true)
            {
                Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(70, 9); Console.Write("                                                              ");
        
                Console.SetCursorPosition(48, 9); Console.Write("Apellido: ");
                Console.SetCursorPosition(70, 9); empleado.apellido = Console.ReadLine();
                if (!String.IsNullOrEmpty(empleado.apellido) && empleado.validarStringAceptarSoloLetras(empleado.apellido))
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
                Console.SetCursorPosition(70, 10); empleado.nombre = Console.ReadLine();
                if (!String.IsNullOrEmpty(empleado.nombre) && empleado.validarStringAceptarSoloLetras(empleado.nombre))
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
                empleado.validarLong(telefono);
        
                if (!String.IsNullOrEmpty(telefono) && empleado.validarLong(telefono))
                {
                    empleado.telefono = telefono;
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
                Console.SetCursorPosition(70, 12); empleado.direccion = Console.ReadLine();
                if (!String.IsNullOrEmpty(empleado.direccion))
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(40, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }
        
            while (true)
            {
                Console.SetCursorPosition(40, 17); Console.Write("                                                      ");
                Console.SetCursorPosition(70, 13); Console.Write("                                        ");
        
                Console.SetCursorPosition(48, 13); Console.Write("Salario");
                Console.SetCursorPosition(70, 13); salario = Console.ReadLine();
                empleado.validarDecimal(salario);
        
                if (!String.IsNullOrEmpty(salario) && empleado.validarDecimal(salario))
                {
                    empleado.salario = decimal.Parse(salario);
                    break;
                }
                else
                {
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                    Console.ReadKey();
                }
            }
        
            return empleado;
        }
        
        public void RegistrarEmpleado()
        {
            descargarArchivoEmpleado();
            PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
            Empleado empleado = new Empleado();
            empleado = empleado.crearNuevoEmpleado();
            empleadosRepetido(empleado.id); 
            if (empleadosRepetido(empleado.id))
            {
                Console.SetCursorPosition(10, 15); Console.Write("Ya Existe Un Cliente Con Esta Identidifacion");
            }
            else
            {
                empleadoAgregarALaLista(empleado);
                persistenciaEmpleado.GuardarEmpleadoEnArchivo(empleado, "empleados.txt");
            }
            Console.ReadKey();
            Console.Clear();
        }
        
        
        public void mostrarListaEmpleado()
        {
            descargarArchivoEmpleado();
        
            if (listaEmpleadoVacia())
            {
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                int posicionPantalla = 8;
                Console.SetCursorPosition(53, 5); Console.Write("Listado De Empleados");
                Console.SetCursorPosition(10, 7); Console.Write("COIDIGO");
                Console.SetCursorPosition(25, 7); Console.Write("ID");
                Console.SetCursorPosition(40, 7); Console.Write("APELLIDO");
                Console.SetCursorPosition(55, 7); Console.Write("NOMBRE");
                Console.SetCursorPosition(70, 7); Console.Write("TLEFONO");
                Console.SetCursorPosition(85, 7); Console.Write("DIRECCION");
                Console.SetCursorPosition(100, 7); Console.Write("SALARIO");
        
                for (int i = 0; i < empleados.Count; i++)
                {
                    Console.SetCursorPosition(10, posicionPantalla); Console.Write(empleados[i].codigoEmpleado);
                    Console.SetCursorPosition(25, posicionPantalla); Console.Write(empleados[i].id);
                    Console.SetCursorPosition(40, posicionPantalla); Console.Write(empleados[i].apellido);
                    Console.SetCursorPosition(55, posicionPantalla); Console.Write(empleados[i].nombre);
                    Console.SetCursorPosition(70, posicionPantalla); Console.Write(empleados[i].telefono);
                    Console.SetCursorPosition(85, posicionPantalla); Console.Write(empleados[i].direccion);
                    Console.SetCursorPosition(100, posicionPantalla); Console.Write(empleados[i].salario);
        
                    posicionPantalla++;
                }
            }
        
            Console.ReadKey();
            Console.Clear();
        }
        
        public void consultarUnEmpleado()
        {
            Empleado empleado;
            descargarArchivoEmpleado();
            
            string codigo;
        
            if (listaEmpleadoVacia())
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
                    Console.SetCursorPosition(53, 5); Console.Write("Consultar Empleado");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Empleado a Consultar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();
        
                    if (!string.IsNullOrEmpty(codigo))
                    {
                        empleado = empleadoBuscarEnLista(codigo);
        
                        if (empleado != null)
                        {
                            imprimirEmpleado(empleado);
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Empleado no encontrado.");
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

        public void imprimirEmpleado(Empleado empleado)
        {
            Console.Clear();
            Console.SetCursorPosition(53, 5); Console.Write("Datos del Empleado");
            Console.SetCursorPosition(48, 7); Console.Write("Código: ");
            Console.SetCursorPosition(70, 7); Console.Write(empleado.codigoEmpleado);
            Console.SetCursorPosition(48, 8); Console.Write("No. Identificación: ");
            Console.SetCursorPosition(70, 8); Console.Write(empleado.id);
            Console.SetCursorPosition(48, 9); Console.Write("Apellido: ");
            Console.SetCursorPosition(70, 9); Console.Write(empleado.apellido);
            Console.SetCursorPosition(48, 10); Console.Write("Nombre: ");
            Console.SetCursorPosition(70, 10); Console.Write(empleado.nombre);
            Console.SetCursorPosition(48, 11); Console.Write("Teléfono: ");
            Console.SetCursorPosition(70, 11); Console.Write(empleado.telefono);
            Console.SetCursorPosition(48, 12); Console.Write("Direccion: ");
            Console.SetCursorPosition(70, 12); Console.Write(empleado.direccion);
            Console.SetCursorPosition(48, 13); Console.Write("Salario: ");
            Console.SetCursorPosition(70, 13); Console.Write(empleado.salario);
        }
        
        public void eliminarEmpleado()
        {
            descargarArchivoEmpleado();
        
            if (listaEmpleadoVacia())
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 9); Console.Write("Intentos Restantes: " + intentosRetantes);
                    Console.SetCursorPosition(48, 11); Console.Write("                                                  ");
                    Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(53, 5); Console.Write("ELIMINAR EMPLEADO");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Codigo Del Empleado A Eliminar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        int posicion = empleadoEliminarDeLista(codigo);

                        if (posicion == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(48, 11); Console.Write("No Se Encontro Un Registro Con Ese Codigo");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;

                        }
                        else
                        {
                            imprimirEmpleado(empleados[posicion]);
                            if (confirmarEliminado())
                            {
                                Console.Clear();
                                empleados.RemoveAt(posicion);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(40, 10); Console.Write("Registro Eliminado Correctamente...");
                                PersistenciaEmpleado persistenciaEmpleado = new PersistenciaEmpleado();
                                persistenciaEmpleado.sobreescribirEmpleadoEnArchivo(empleados, "empleados.txt");
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
            Console.Clear();
        }

        public int empleadoEliminarDeLista(String codigo)
        {
            int encontrado = -1;

            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].codigoEmpleado.Equals(codigo))
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

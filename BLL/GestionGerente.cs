using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class GestionGerente
    {
         public List<Gerente> gerentes = new List<Gerente>();

         public GestionGerente() { }

        public void descargarArchivoGerente()
        {
            PersistenciaGerente persistenciaGerente = new PersistenciaGerente();
            gerentes = persistenciaGerente.LeerGerenteDesdeArchivo("gerentes.txt");
        }

        public bool gerenteRepetido(String codigo)
        {
            for (int i = 0; i < gerentes.Count; i++)
            {
                if (gerentes[i].id.Equals(codigo))
                {
                    return true;
                }
            }
            return false;
        }

        public bool listaGerenteVacia()
         {
             if (gerentes.Count != 0) { return false; }
             return true;
         }
        
         public void gerenteAgregarALaLista(Gerente gerente)
         {
            gerentes.Add(gerente);
         }
        
         public Gerente gerenteBuscarEnLista(String codigo)
         {
             for (int i = 0; i < gerentes.Count; i++)
             {
                 if (gerentes[i].codigoEmpleado.Equals(codigo))
                 {
                     return gerentes[i];
                 }
             }
             return null;
         }
        
         public void modificarDatosGerente()
         {
            descargarArchivoGerente();
            Gerente gerente;
        
             if (listaGerenteVacia())
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
                     Console.SetCursorPosition(48, 11); Console.Write("                                             ");
                     Console.SetCursorPosition(60, 8); Console.Write("                         ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(53, 5); Console.Write("EDITAR GERENTE");
                     Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Código Del Gerente A Consultar");
                     Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();
        
                     if (!string.IsNullOrEmpty(codigo))
                     {
                         gerente = gerenteBuscarEnLista(codigo);
        
                         if (gerente != null)
                         {
                             gerente = editarGerenteAuxiliar(gerente);
                            PersistenciaGerente persistenciaGerente = new PersistenciaGerente();
                            persistenciaGerente.sobreescribirGerenteEnArchivo(gerentes, "gerentes.txt");
                            break;
                         }
                         else
                         {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(48, 11); Console.Write("Error: Gerente no encontrado.");
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
                 Console.ReadKey();
                 Console.Clear();
             }
             Console.ResetColor();
        
         }
        
         public Gerente editarGerenteAuxiliar(Gerente gerente)
         {
             string telefono, salario;
        
             Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(53, 5); Console.Write("DATOS DEL GERENTE");
             Console.SetCursorPosition(48, 7); Console.Write("CODIGO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 7); Console.Write(gerente.codigoEmpleado);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 8); Console.Write("IDENTIFICACION: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 8); Console.Write(gerente.id.ToUpper());
        
        
             while (true)
             {
                 Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                 Console.SetCursorPosition(70, 9); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 9); Console.Write("APELLIDO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 9); gerente.apellido = Console.ReadLine();
                 if (!String.IsNullOrEmpty(gerente.apellido) && gerente.validarStringAceptarSoloLetras(gerente.apellido))
                 {
                    gerente.apellido.ToUpper();
                     break;
                 }
                 else
                 {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                     Console.ReadKey();
                 }
             }
             while (true)
             {
                 Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                 Console.SetCursorPosition(70, 10); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 10); Console.Write("NOMBRE: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 10); gerente.nombre = Console.ReadLine();
                 if (!String.IsNullOrEmpty(gerente.nombre) && gerente.validarStringAceptarSoloLetras(gerente.nombre))
                 {
                    gerente.nombre.ToUpper();
                     break;
                 }
                 else
                 {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                     Console.ReadKey();
                 }
             }
        
             while (true)
             {
                 Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                 Console.SetCursorPosition(70, 11); Console.Write("                                   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 11); Console.Write("TELEFONO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 11); telefono = Console.ReadLine();
                 gerente.validarLong(telefono);
        
                 if (!String.IsNullOrEmpty(telefono) && gerente.validarLong(telefono))
                 {
                     gerente.telefono = telefono;
                     break;
                 }
                 else
                 {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                     Console.ReadKey();
                 }
             }
        
             while (true)
             {
                 Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 12); Console.Write("DIRECCION:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 12); gerente.direccion = Console.ReadLine();
                 if (!String.IsNullOrEmpty(gerente.direccion))
                 {
                     break;
                 }
                 else
                 {
                    Console.ForegroundColor = ConsoleColor.Red;      
                    Console.SetCursorPosition(40, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                     Console.ReadKey();
                 }
             }
        
             while (true)            
             {
                 Console.SetCursorPosition(40, 17); Console.Write("                                                      ");
                 Console.SetCursorPosition(70, 13); Console.Write("                                        ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 13); Console.Write("SALIO:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(70, 13); salario = Console.ReadLine();
                 gerente.validarDecimal(salario);
        
                 if (!String.IsNullOrEmpty(salario) && gerente.validarDecimal(salario))
                 {
                     gerente.salario = decimal.Parse(salario);
                     break;
                 }
                 else
                 {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                     Console.ReadKey();
                 }
             }
            Console.ResetColor();
             return gerente;
         }
        
         public void RegistrarGerente()
         {
            PersistenciaGerente persistenciaGerente = new PersistenciaGerente();
            descargarArchivoGerente();
            Gerente gerente = new Gerente();
             gerente = gerente.crearNuevoGerente();
            gerenteRepetido(gerente.id);

            if (gerenteRepetido(gerente.id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(10, 15); Console.Write("Ya Existe Un Registro Con Esta Identidifacion");
            }
            else
            {
                gerenteAgregarALaLista(gerente);
                persistenciaGerente.GuardarGerenteEnArchivo(gerente, "gerentes.txt");
            }
            Console.ResetColor ();
            Console.ReadKey();
            Console.Clear();
        }
        
        
         public void mostrarListaGerente()
         {
            descargarArchivoGerente();

            if (listaGerenteVacia())
             {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                 Console.ReadKey();
                 Console.Clear();
             }
             else
             {
                 int posicionPantalla = 8;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(53, 5); Console.Write("Listado De Gerentes");
                 Console.SetCursorPosition(10, 7); Console.Write("COIDIGO");
                 Console.SetCursorPosition(25, 7); Console.Write("ID");
                 Console.SetCursorPosition(40, 7); Console.Write("APELLIDO");
                 Console.SetCursorPosition(55, 7); Console.Write("NOMBRE");
                 Console.SetCursorPosition(70, 7); Console.Write("TLEFONO");
                 Console.SetCursorPosition(85, 7); Console.Write("DIRECCION");
                 Console.SetCursorPosition(100, 7); Console.Write("SALARIO");
        
                 for (int i = 0; i < gerentes.Count; i++)
                 {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(10, posicionPantalla); Console.Write(gerentes[i].codigoEmpleado);
                     Console.SetCursorPosition(25, posicionPantalla); Console.Write(gerentes[i].id);
                     Console.SetCursorPosition(40, posicionPantalla); Console.Write(gerentes[i].apellido);
                     Console.SetCursorPosition(55, posicionPantalla); Console.Write(gerentes[i].nombre);
                     Console.SetCursorPosition(70, posicionPantalla); Console.Write(gerentes[i].telefono);
                     Console.SetCursorPosition(85, posicionPantalla); Console.Write(gerentes[i].direccion);
                     Console.SetCursorPosition(100, posicionPantalla); Console.Write(gerentes[i].salario);
        
                     posicionPantalla++;
                 }
             }
            Console.ResetColor();
             Console.ReadKey();
             Console.Clear();
         }
        
         public void consultarUnGerente()
         {
            descargarArchivoGerente();
            Gerente gerente;
        
             string codigo;
        
             if (listaGerenteVacia())
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
                    Console.SetCursorPosition(53, 5); Console.Write("CONSULTAR GERENTE");
                     Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Gerente a Consultar");
                     Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();
        
                     if (!string.IsNullOrEmpty(codigo))
                     {
                         gerente = gerenteBuscarEnLista(codigo);
        
                         if (gerente != null)
                         {
                             mostrarGerente(gerente);
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
                              
        public void mostrarGerente(Gerente gerente)
        {                                                                
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(53, 5); Console.Write("DATOS DEL GERENTE");
            Console.SetCursorPosition(48, 7); Console.Write("CODIGO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 7); Console.Write(gerente.codigoEmpleado);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 8); Console.Write("IDENTIFICACION: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 8); Console.Write(gerente.id);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 9); Console.Write("APELLIDO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 9); Console.Write(gerente.apellido);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 10); Console.Write("NOMBRE: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 10); Console.Write(gerente.nombre);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 11); Console.Write("TELEFONO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 11); Console.Write(gerente.telefono);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 12); Console.Write("NOMBRE: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 12); Console.Write(gerente.direccion);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 13); Console.Write("SALARIO: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(70, 13); Console.Write(gerente.salario);
            Console.ReadKey();
            Console.ResetColor();
        }
                                                                                      
         public void eliminarGerente()  
         {
            descargarArchivoGerente();                
            if (listaGerenteVacia())
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
                    Console.SetCursorPosition(53, 5); Console.Write("ELIMINAR GERENTE");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Codigo Del Gerente A Eliminar");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        int posicion = gerenteEliminarDeLista(codigo);

                        if (posicion == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(48, 11); Console.Write("No Se Encontro Un Registro Con Este Codigo");
                            Console.ReadKey();
                            intentos++;
                            intentosRetantes--;

                        }
                        else
                        {
                            mostrarGerente(gerentes[posicion]);
                            if (confirmarEliminado())
                            {
                                Console.Clear();
                                gerentes.RemoveAt(posicion);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(40, 10); Console.Write("Registro Eliminado Correctamente...");
                                PersistenciaGerente persistenciaGerente = new PersistenciaGerente();
                                persistenciaGerente.sobreescribirGerenteEnArchivo(gerentes, "gerentes.txt");
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

        public int gerenteEliminarDeLista(String codigo)
        {
            int encontrado = -1;

            for (int i = 0; i < gerentes.Count; i++)
            {
                if (gerentes[i].codigoEmpleado.Equals(codigo))
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
                Console.SetCursorPosition(48, 10); Console.Write("Se Eliminara De Forma Permanente Este Registro");
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

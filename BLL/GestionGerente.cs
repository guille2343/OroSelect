using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionGerente
    {
         public List<Empelado> gerentes = new List<Empelado>();

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
        
         public void gerenteAgregarALaLista(Empelado gerente)
         {
             gerentes.Add(gerente);
         }
        
         public Empelado gerenteBuscarEnLista(String codigo)
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
        
         public bool gerenteEliminarDeLista(String codigo)
         {
             int encontrado = -1;
        
             for (int i = 0; i < gerentes.Count; i++)
             {
                 if (gerentes[i].id.Equals(codigo))
                 {
                     gerentes.RemoveAt(i);
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
        
         public void modificarDatosGerente()
         {
             Empelado gerente;
            descargarArchivoGerente();
        
             if (listaGerenteVacia())
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
                     Console.SetCursorPosition(53, 5); Console.Write("Editar Gerente");
                     Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Código Del Gerente A Consultar");
                     Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
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
                             Console.SetCursorPosition(48, 11); Console.Write("Error: Gerente no encontrado.");
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
        
         public Empelado editarGerenteAuxiliar(Empelado gerente)
         {
             string telefono, salario;
        
             Console.Clear();
             Console.SetCursorPosition(53, 5); Console.Write("Datos del Gerente");
             Console.SetCursorPosition(48, 7); Console.Write("Código: ");
             Console.SetCursorPosition(70, 7); Console.Write(gerente.codigoEmpleado);
             Console.SetCursorPosition(48, 8); Console.Write("No. Identificación: ");
             Console.SetCursorPosition(70, 8); Console.Write(gerente.id);
        
        
             while (true)
             {
                 Console.SetCursorPosition(40, 17); Console.Write("                                                     ");
                 Console.SetCursorPosition(70, 9); Console.Write("                                                              ");
        
                 Console.SetCursorPosition(48, 9); Console.Write("Apellido: ");
                 Console.SetCursorPosition(70, 9); gerente.apellido = Console.ReadLine();
                 if (!String.IsNullOrEmpty(gerente.apellido) && gerente.validarStringAceptarSoloLetras(gerente.apellido))
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
                 Console.SetCursorPosition(70, 10); gerente.nombre = Console.ReadLine();
                 if (!String.IsNullOrEmpty(gerente.nombre) && gerente.validarStringAceptarSoloLetras(gerente.nombre))
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
                 gerente.validarLong(telefono);
        
                 if (!String.IsNullOrEmpty(telefono) && gerente.validarLong(telefono))
                 {
                     gerente.telefono = telefono;
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
                 Console.SetCursorPosition(70, 12); gerente.direccion = Console.ReadLine();
                 if (!String.IsNullOrEmpty(gerente.direccion))
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
                 gerente.validarDecimal(salario);
        
                 if (!String.IsNullOrEmpty(salario) && gerente.validarDecimal(salario))
                 {
                     gerente.salario = decimal.Parse(salario);
                     break;
                 }
                 else
                 {
                     Console.SetCursorPosition(40, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                     Console.ReadKey();
                 }
             }
        
             return gerente;
         }
        
         public void RegistrarGerente()
         {
            descargarArchivoGerente();
            PersistenciaGerente persistenciaGerente = new PersistenciaGerente();
            Empelado gerente = new Empelado();
            gerente = gerente.crearNuevoGerente();
            gerenteRepetido(gerente.id);
        
            if (gerenteRepetido(gerente.id))
            {
                Console.SetCursorPosition(10, 15); Console.Write("Ya Existe Un Gerente Con Esta Identidifacion");
            }
            else
            {
                gerenteAgregarALaLista(gerente);
                persistenciaGerente.GuardarGerenteEnArchivo(gerente, "gerentes.txt");
            }
            Console.ReadKey();
            Console.Clear();
         }
        
        
         public void mostrarListaGerente()
         {
            descargarArchivoGerente();
        
            if (listaGerenteVacia())
             {
                 Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                 Console.ReadKey();
                 Console.Clear();
             }
             else
             {
                 int posicionPantalla = 8;
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
        
             Console.ReadKey();
             Console.Clear();
         }
        
         public void consultarUnGerente()
         {
            descargarArchivoGerente();
            Empelado gerente;
             string codigo;
        
             if (listaGerenteVacia())
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
                     Console.SetCursorPosition(48, 7); Console.Write("Ingrese el Código del Gerente a Consultar");
                     Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                     Console.SetCursorPosition(60, 8); codigo = Console.ReadLine();
        
                     if (!string.IsNullOrEmpty(codigo))
                     {
                         gerente = gerenteBuscarEnLista(codigo);
        
                         if (gerente != null)
                         {
                             Console.Clear();
                             Console.SetCursorPosition(53, 5); Console.Write("Datos del Gerente");
                             Console.SetCursorPosition(48, 7); Console.Write("Código: ");
                             Console.SetCursorPosition(70, 7); Console.Write(gerente.codigoEmpleado);
                             Console.SetCursorPosition(48, 8); Console.Write("No. Identificación: ");
                             Console.SetCursorPosition(70, 8); Console.Write(gerente.id);
                             Console.SetCursorPosition(48, 9); Console.Write("Apellido: ");
                             Console.SetCursorPosition(70, 9); Console.Write(gerente.apellido);
                             Console.SetCursorPosition(48, 10); Console.Write("Nombre: ");
                             Console.SetCursorPosition(70, 10); Console.Write(gerente.nombre);
                             Console.SetCursorPosition(48, 11); Console.Write("Teléfono: ");
                             Console.SetCursorPosition(70, 11); Console.Write(gerente.telefono);
                             Console.SetCursorPosition(48, 12); Console.Write("Direccion: ");
                             Console.SetCursorPosition(70, 12); Console.Write(gerente.direccion);
                             Console.SetCursorPosition(48, 13); Console.Write("Salario: ");
                             Console.SetCursorPosition(70, 13); Console.Write(gerente.salario);
                             break;
                         }
                         else
                         {
                             Console.SetCursorPosition(48, 11); Console.Write("Error: Gerente no encontrado.");
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
        
         public void eliminarGerente()
         {
            descargarArchivoGerente();
            if (listaGerenteVacia())
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
                     Console.SetCursorPosition(48, 7); Console.Write("Ingrese La Identificacion Del Gerente A Eliminar");
                     Console.SetCursorPosition(48, 8); Console.Write("Id: ");
                     Console.SetCursorPosition(60, 8); id = Console.ReadLine();
        
                     if (!string.IsNullOrEmpty(id))
                     {
                         bool mensaje = gerenteEliminarDeLista(id);
        
                         if (mensaje)
                         {
                            PersistenciaGerente persistenciaGerente = new PersistenciaGerente();
                             Console.SetCursorPosition(48, 11); Console.Write("Se Elimino Correctamente");
                             Console.ReadKey();
                            persistenciaGerente.sobreescribirGerenteEnArchivo(gerentes, "gerentes.txt");
                             break;
                         }
                         else
                         {
                             Console.SetCursorPosition(48, 11); Console.Write("No Se Encontro Un Gerente Con Esa Id");
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

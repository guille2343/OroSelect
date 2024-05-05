using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersistenciaProducto
    {
         public void sobreescribirProductosEnArchivo(List<ProductoOro> productosOro, string nombreArchivo)
         {
             try
             {
                 // Obtener la ruta del directorio actual donde se encuentra el ejecutable
                 string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
        
                 // Combinar el directorio actual con el nombre del archivo para obtener la ruta completa
                 string rutaArchivo = Path.Combine(directorioActual, nombreArchivo);
        
                 // Escribir en el archivo
                 using (StreamWriter writer = new StreamWriter(rutaArchivo))
                 {
                     foreach (var productoOro in productosOro)
                     {
                         // Escribir cada cliente en una línea del archivo
                         writer.WriteLine($"{productoOro.codigoProducto},{productoOro.valorProductoOro},{productoOro.pesoProductoOro},{productoOro.descripcionProducto},{productoOro.pureza},{productoOro.precioPorGramoOro}");
                     }
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error al guardar el archivo");
             }
         }
        
        
         //
         public void GuardarProductosEnArchivo(ProductoOro productoOro, string nombreArchivo)
         {
             try
             {
                 // Obtener la ruta del directorio actual donde se encuentra el ejecutable
                 string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
        
                 // Combinar el directorio actual con el nombre del archivo para obtener la ruta completa
                 string rutaArchivo = Path.Combine(directorioActual, nombreArchivo);
        
                 // Escribir en el archivo
                 using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                 {
                     // Escribir el cliente en una línea del archivo
                     writer.WriteLine($"{productoOro.codigoProducto},{productoOro.valorProductoOro},{productoOro.pesoProductoOro},{productoOro.descripcionProducto},{productoOro.pureza},{productoOro.precioPorGramoOro}");
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error al guardar el producto en el archivo");
             }
         }
        
        
         public List<ProductoOro> LeerProductoOroDesdeArchivo(string nombreArchivo)
         {
             List<ProductoOro> productosOro = new List<ProductoOro>();
        
             try
             {
                 // Obtener la ruta completa del archivo
                 string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
                 string rutaArchivo = Path.Combine(directorioActual, nombreArchivo);
        
                 // Verificar si el archivo existe
                 if (File.Exists(rutaArchivo))
                 {
                     // Leer todas las líneas del archivo
                     string[] lineas = File.ReadAllLines(rutaArchivo);
        
                     // Procesar cada línea para crear objetos Cliente
                     foreach (string linea in lineas)
                     {
                         // Dividir la línea por las comas para obtener los atributos del cliente
                         string[] atributos = linea.Split(',');
        
                         // Crear un nuevo objeto Cliente y agregarlo a la lista
                         ProductoOro productoOro = new ProductoOro
                         {
                             codigoProducto = atributos[0],
                             valorProductoOro = decimal.Parse(atributos[1]),
                             pesoProductoOro = decimal.Parse(atributos[2]),
                             descripcionProducto = atributos[3],
                             pureza = int.Parse(atributos[4]),
                             precioPorGramoOro = decimal.Parse(atributos[5]),
                         };
        
                         productosOro.Add(productoOro);
                     }
                 }
        
             }
             catch (Exception ex)
             {
                 Console.WriteLine("Error al leer el archivo");
             }
        
             return productosOro;
         }
    }
}

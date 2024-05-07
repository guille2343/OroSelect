using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersisteciaMovimiento
    {
        public void registrarMovimiento (Movimiento movimiento, string nombreArchivo)
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
                    writer.WriteLine($"{movimiento.fechaMovimineto},{movimiento.valor},{movimiento.idCliente},{movimiento.nombreCliente},{movimiento.apellidoCliente},{movimiento.descripcion}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el cliente en el archivo");
            }
        }


        public List<Movimiento> cargarMovimientos (string nombreArchivo)
        {
            List<Movimiento> movimientos = new List<Movimiento>();

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
                        Movimiento movimiento = new Movimiento
                        {
                            fechaMovimineto =DateTime.Parse( atributos[0]),
                            valor = decimal.Parse(atributos[1]),
                            idCliente = atributos[2],
                            nombreCliente = atributos[3],
                            apellidoCliente = atributos[4],
                            descripcion = atributos[5]
                        };

                        movimientos.Add(movimiento);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo");
            }

            return movimientos;
        }
    }
}

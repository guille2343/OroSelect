using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersistenciaEmpleado
    {
        public void sobreescribirEmpleadoEnArchivo(List<Empleado> empleados, string nombreArchivo)
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
                    foreach (var empleado in empleados)
                    {
                        // Escribir cada cliente en una línea del archivo
                        writer.WriteLine($"{empleado.codigoEmpleado},{empleado.id},{empleado.apellido},{empleado.nombre},{empleado.telefono},{empleado.direccion}, {empleado.salario}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo");
            }
        }


        //
        public void GuardarEmpleadoEnArchivo(Empleado empleado, string nombreArchivo)
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
                    writer.WriteLine($"{empleado.codigoEmpleado},{empleado.id},{empleado.apellido},{empleado.nombre},{empleado.telefono},{empleado.direccion}, {empleado.salario}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el gerente en el archivo");
            }
        }


        public List<Empleado> LeerEmpleadoDesdeArchivo(string nombreArchivo)
        {
            List<Empleado> empleados = new List<Empleado>();

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
                        Empleado empleado = new Empleado
                        {
                            codigoEmpleado = atributos[0],
                            id = atributos[1],
                            apellido = atributos[2],
                            nombre = atributos[3],
                            telefono = atributos[4],
                            direccion = atributos[5],
                            salario = decimal.Parse(atributos[6])
                        };

                        empleados.Add(empleado);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo");
            }

            return empleados;
        }
    }
}

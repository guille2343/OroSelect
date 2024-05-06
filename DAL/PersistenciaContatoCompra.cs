using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersistenciaContatoCompra
    {
        public void sobreescribirContratoCompraEnArchivo(List<ContratoCompra> contratoscompra, string nombreArchivo)
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
                    foreach (var contratoCompra in contratoscompra)
                    {
                        // Escribir cada cliente en una línea del archivo
                        writer.WriteLine($"{contratoCompra.codigoContrato},{contratoCompra.fechaEmisionContrato},{contratoCompra.estadoContrato},{contratoCompra.idComprador},{contratoCompra.apellidoComprador},{contratoCompra.nombreComprador},{contratoCompra.telefonoComprador},{contratoCompra.valorPorGramoOro},{contratoCompra.pesoProducto}, {contratoCompra.purezaProducto}" +
                            $"{contratoCompra.descripciobProducto},{contratoCompra.valorProducto},{contratoCompra.descripcionContrato}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo");
            }
        }


        //
        public void GuardarContratoCompraEnArchivo(ContratoCompra contratoCompra, string nombreArchivo)
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
                    writer.WriteLine($"{contratoCompra.codigoContrato},{contratoCompra.fechaEmisionContrato},{contratoCompra.estadoContrato},{contratoCompra.idComprador},{contratoCompra.apellidoComprador},{contratoCompra.nombreComprador},{contratoCompra.telefonoComprador},{contratoCompra.valorPorGramoOro},{contratoCompra.pesoProducto}, {contratoCompra.purezaProducto}" +
                            $"{contratoCompra.descripciobProducto},{contratoCompra.valorProducto},{contratoCompra.descripcionContrato}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el gerente en el archivo");
            }
        }


        public List<ContratoCompra> LeerContratoCompraDesdeArchivo(string nombreArchivo)
        {
            List<ContratoCompra> contratosCompra = new List<ContratoCompra>();

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
                        ContratoCompra contratoCompra = new ContratoCompra
                        {
                            idComprador = atributos[0],
                            apellidoComprador = atributos[1],
                            nombreComprador = atributos[2],
                            telefonoComprador = atributos[3],
                            valorPorGramoOro = decimal.Parse( atributos[4]),
                            pesoProducto = decimal.Parse(atributos[5]),
                            purezaProducto = int.Parse(atributos[6]),
                            descripciobProducto = atributos[7],
                            valorProducto = decimal.Parse(atributos[8]),
                            descripcionContrato = atributos[9]
                        };

                        contratosCompra.Add(contratoCompra);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo");
            }

            return contratosCompra;
        }
    }
}

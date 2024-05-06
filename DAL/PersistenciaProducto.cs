using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersistenciaProducto
    {
        public void sobreescribirContratoCompraEnArchivo(List<Contrato> contratos, string nombreArchivo)
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
                    foreach (var contrato in contratos)
                    {
                        // Escribir cada cliente en una línea del archivo
                        writer.WriteLine($"{contrato.codigoContrato},{contrato.fechaEmisionContrato},{contrato.estadoContrato},{contrato.idComprador},{contrato.apellidoComprador},{contrato.nombreComprador},{contrato.telefonoComprador},{contrato.purezaProducto},{contrato.pesoProducto}, {contrato.valorPorGramoOro}" +
                            $"{contrato.valorProducto},{contrato.descripciobProducto}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo");
            }
        }


        //
        public void GuardarContratoCompraEnArchivo(Contrato contrato, string nombreArchivo)
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
                    writer.WriteLine($"{contrato.codigoContrato},{contrato.fechaEmisionContrato},{contrato.estadoContrato},{contrato.idComprador},{contrato.apellidoComprador},{contrato.nombreComprador},{contrato.telefonoComprador},{contrato.purezaProducto},{contrato.pesoProducto}, {contrato.valorPorGramoOro}" +
                            $"{contrato.valorProducto},{contrato.descripciobProducto}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el gerente en el archivo");
            }
        }


        public List<Contrato> LeerContratoCompraDesdeArchivo(string nombreArchivo)
        {
            List<Contrato> contratos = new List<Contrato>();

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
                        Contrato contrato = new Contrato
                        {
                            codigoContrato = atributos[0],
                            fechaEmisionContrato = DateTime.Parse(atributos[1]),
                            estadoContrato = atributos[2],
                            idComprador = atributos[3],
                            apellidoComprador = atributos[4],
                            nombreComprador = atributos[5],
                            telefonoComprador = atributos[6],
                            purezaProducto = int.Parse(atributos[7]),
                            pesoProducto = decimal.Parse(atributos[8]),
                            valorPorGramoOro = decimal.Parse(atributos[9]),
                            valorProducto = decimal.Parse(atributos[10]),
                            descripciobProducto = atributos[11]

                        };

                        contratos.Add(contrato);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo");
            }

            return contratos;
        }
    }
}

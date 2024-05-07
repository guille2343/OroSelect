using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionContrato
    {
        public List<Contrato> contratos = new List<Contrato>();
        public List<Cliente> clientes = new List<Cliente>();

        public GestionContrato() { }

        public void cargarContratosDelArchivo() { 
            PersistenciaContato persistenciaContato = new PersistenciaContato();
            contratos = persistenciaContato.LeerContratoCompraDesdeArchivo("contratos.txt");
          
        }

        public void generarUnContratoCompra()
        {
            Console.Clear();

            Cliente cliente = new Cliente();
            Contrato contrato = new Contrato();
            ProductoOro productoOro = new ProductoOro();
            PersistenciaCliente persistenciaCliente = new PersistenciaCliente();
            clientes = persistenciaCliente.LeerClientesDesdeArchivo("clientes.txt");
            string idComprador;

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(48, 10); Console.Write("                                       ");
                Console.SetCursorPosition(53, 1); Console.Write("Generar Contato Compra");
                Console.SetCursorPosition(48, 3); Console.Write("Identificacion Del Comprador:");
                Console.SetCursorPosition(80, 3); idComprador = Console.ReadLine();
                if (!String.IsNullOrEmpty(idComprador))
                {
                    int existeCliente =  clienteExiste(idComprador);
                    if (existeCliente == -1)
                    {
                        Console.Clear();
                        cliente = nuevoCliente(idComprador);
                        persistenciaCliente.GuardarClienteEnArchivo(cliente, "clientes.txt");             
                        Console.Clear();
                        break;
                        
                    }
                    else
                    {
                        cliente = clientes[existeCliente];
                        break;
                    }
                }
                else
                {

                    Console.SetCursorPosition(48, 10); Console.Write("No Se Admiten Campos Vacios");
                }
            }
            Console.Clear() ;
            productoOro = productoOro.crearNuevoProductoOro();
            contrato = contrato.emitirNuevoContrato(cliente, productoOro);
            contratos.Add(contrato);
            PersistenciaContato persistenciaContato = new PersistenciaContato();
            persistenciaContato.GuardarContratoCompraEnArchivo(contrato, "contratos.txt");
            Console.Clear();
            Console.Clear();
        }

        public Cliente nuevoCliente(String id)
        {
            Cliente cliente = new Cliente();
            string nombre, apellido, telefono, direccion;

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(53, 5); Console.Write("REGISTRAR CLIENTE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 7); Console.Write("CODIGO:  ");
            cliente.codigoCliente = cliente.generarCodigoAleatoriamente();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(65, 7); Console.Write(cliente.codigoCliente);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(48, 8); Console.Write("IDENTRIFICACION: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(65, 8); cliente.id = id.ToUpper();
            Console.SetCursorPosition(65, 8); Console.Write(cliente.id);

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(65, 9); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 9); Console.Write("NOMBRE: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 9); nombre = Console.ReadLine();
                if (!String.IsNullOrEmpty(nombre) && cliente.validarStringAceptarSoloLetras(nombre))
                {
                    cliente.nombre = nombre.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {

                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(65, 10); Console.Write("                                                              ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 10); Console.Write("APELLIDO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 10); apellido = Console.ReadLine();
                if (!String.IsNullOrEmpty(apellido) && cliente.validarStringAceptarSoloLetras(apellido))
                {
                    cliente.apellido = apellido.ToUpper();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Caracteres Alfabeticos");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.SetCursorPosition(65, 11); Console.Write("                                   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 11); Console.Write("TELEFONO: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 11); telefono = Console.ReadLine();
                cliente.validarLong(telefono);

                if (!String.IsNullOrEmpty(telefono) && cliente.validarLong(telefono))
                {
                    cliente.telefono = telefono;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: Solo Se Admiten Valores Numericos 0-9");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                Console.SetCursorPosition(48, 17); Console.Write("                                                     ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(48, 12); Console.Write("DIRECCION: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(65, 12); direccion = Console.ReadLine();
                if (!String.IsNullOrEmpty(direccion))
                {
                    cliente.direccion = direccion;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(48, 17); Console.Write("Error: No Se Admiten Campos Vacios");
                    Console.ReadKey();
                }
            }
            Console.ResetColor();
            return cliente;
        }


        public int clienteExiste(String codigo)
        {
            int encontro = -1;
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].id.Equals(codigo))
                {
                    encontro = i;
                }
            }
            return encontro;
        }

        public Contrato buscarContratoEnLista(String codigo)
        {
            for (int i = 0; i < contratos.Count; i++)
            {
                if (contratos[i].codigoContrato.Equals(codigo))
                {
                    return contratos[i];
                }
            }
            return null;
        }
        
        public bool listaVacia()
        {
            cargarContratosDelArchivo();

            if(contratos.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void consultarContratoEnLista()
        {
            if (!listaVacia()) {

                Contrato contrato = new Contrato();
                string codigo;
                int intentos = 0, intentosRestantes = 3;
                while (true && intentos != 3)
                {
                    Console.Clear();
                    Console.SetCursorPosition(48, 11); Console.Write("Intentos Restantes: " + intentosRestantes);
                    Console.SetCursorPosition(53, 5); Console.Write("Consultar Contrato");
                    Console.SetCursorPosition(48, 7); Console.Write("Ingrese El Codigo Del Contrato");
                    Console.SetCursorPosition(48, 8); Console.Write("Codigo: ");
                    Console.SetCursorPosition(58, 8); codigo = Console.ReadLine();

                    if (!string.IsNullOrEmpty(codigo))
                    {
                        contrato = buscarContratoEnLista(codigo);
                        if (contrato == null)
                        {
                            Console.SetCursorPosition(48, 12); Console.Write("No Hay Elementos Con Ese Codigo");
                            Console.ReadKey();
                            intentos++;
                            intentosRestantes--;
                        }
                        else
                        {
                            mostrarInformacionContrato(contrato);
                            break;
                        }
                    }
                    else
                    {
                        intentos++;
                        intentosRestantes--;
                        Console.SetCursorPosition(48, 12); Console.Write("No Se Admiten Campos Vacios");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(48, 10); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
            }
            Console.Clear();
        }

        public void mostrarInformacionContrato(Contrato contrato)
        {   
          Console.Clear();
            Console.SetCursorPosition(10, 3); Console.Write("Codigo Contrato:  ");
            Console.SetCursorPosition(35, 3); Console.Write(contrato.codigoContrato);
            Console.SetCursorPosition(10, 4); Console.Write("Fecha De Emision:  ");
            Console.SetCursorPosition(35, 4); Console.Write(contrato.fechaEmisionContrato);
            Console.SetCursorPosition(10, 5); Console.Write("Estado Del Contrato: ");
            Console.SetCursorPosition(35, 5); Console.Write(contrato.estadoContrato);
            Console.SetCursorPosition(15, 7); Console.Write("DATOS DEL CLIENTE");
            Console.SetCursorPosition(10, 8); Console.Write("ID ");
            Console.SetCursorPosition(10, 9); Console.Write(contrato.idComprador);
            Console.SetCursorPosition(25, 8); Console.Write("APELLIDO");
            Console.SetCursorPosition(25, 9); Console.Write(contrato.apellidoComprador);
            Console.SetCursorPosition(40, 8); Console.Write("NOMBRE ");
            Console.SetCursorPosition(40, 9); Console.Write(contrato.nombreComprador);
            Console.SetCursorPosition(55, 8); Console.Write("TELEFONO ");
            Console.SetCursorPosition(55, 9); Console.Write(contrato.telefonoComprador);
            Console.SetCursorPosition(15, 11); Console.Write("DATOS DEL PRODUCTO");
            Console.SetCursorPosition(10, 13); Console.Write("PUREZA");
            Console.SetCursorPosition(10, 14); Console.Write(contrato.purezaProducto);
            Console.SetCursorPosition(25, 13); Console.Write("PESO ");
            Console.SetCursorPosition(25, 14); Console.Write(contrato.pesoProducto);
            Console.SetCursorPosition(40, 13); Console.Write("VALOR GRAMO ");
            Console.SetCursorPosition(40, 14); Console.Write(contrato.valorPorGramoOro);
            Console.SetCursorPosition(55, 13); Console.Write("DESCRIPCCION");
            Console.SetCursorPosition(55, 14); Console.Write(contrato.descripciobProducto);
            Console.SetCursorPosition(5, 16); Console.Write("-------------------------------------------------------------------------------");
            Console.SetCursorPosition(10, 18); Console.Write("VALOR TOTAL ");
            Console.SetCursorPosition(35, 18); Console.Write(contrato.valorProducto);
            Console.SetCursorPosition(10, 19); Console.Write("SALDO ");
            Console.SetCursorPosition(35, 19); Console.Write(contrato.saldoContrato);
            Console.ReadKey();
            Console.Clear();
        }

        public void generarListaContratos()
        {
            if (!listaVacia())
            {
                int posicionEnPnatalla = 8;

                Console.Clear();
                Console.SetCursorPosition(53, 5); Console.Write("LISTA DE CONTRATOS");
                Console.SetCursorPosition(10, 7); Console.Write("CODIGO");
                Console.SetCursorPosition(25, 7); Console.Write("ESTADO");
                Console.SetCursorPosition(40, 7); Console.Write("ID. CLIENTE");
                Console.SetCursorPosition(55, 7); Console.Write("APELLIDO");
                Console.SetCursorPosition(70, 7); Console.Write("NOMBRE");
                Console.SetCursorPosition(85, 7); Console.Write("VALOR");
                Console.SetCursorPosition(100, 7); Console.Write("SALDO");

                for(int i = 0; i < contratos.Count; i++)
                {
                    Console.SetCursorPosition(10, posicionEnPnatalla); Console.Write(contratos[i].codigoContrato);
                    Console.SetCursorPosition(25, posicionEnPnatalla); Console.Write(contratos[i].estadoContrato);
                    Console.SetCursorPosition(40, posicionEnPnatalla); Console.Write(contratos[i].idComprador);
                    Console.SetCursorPosition(55, posicionEnPnatalla); Console.Write(contratos[i].apellidoComprador);
                    Console.SetCursorPosition(70, posicionEnPnatalla); Console.Write(contratos[i].nombreComprador);
                    Console.SetCursorPosition(85, posicionEnPnatalla); Console.Write(contratos[i].valorProducto);
                    Console.SetCursorPosition(100, posicionEnPnatalla); Console.Write(contratos[i].saldoContrato);

                    posicionEnPnatalla++;
                }

                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(48, 10); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
            }

            Console.Clear();
        }

        public void realizarAbonoAlContrato()
        {

        }

        public void consultarUnContrato()
        {

        }

        public void eliminarUnContrato() {
        
        }
    }
}

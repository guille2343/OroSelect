using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestionMovimiento
    {
        public List<Movimiento> movimientos = new List<Movimiento>();
        List<Contrato> contratos = new List<Contrato>();

        public GestionMovimiento()
        {
        }

        public void cargarMovimientosRealizados()
        {
            PersisteciaMovimiento persisteciaMovimiento = new PersisteciaMovimiento();
            movimientos = persisteciaMovimiento.cargarMovimientos("movimiento.txt");   
        }

        public bool listaMovimientoVacia()
        {
            if (movimientos.Count != 0) { return false; }
            return true;
        }

        public void listaMovimientos()
        {
            cargarMovimientosRealizados();

            if (listaMovimientoVacia())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 5); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear() ;
                int posicionPantalla = 4;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(53, 1); Console.Write("Listado De Movimientos");
                
                
                Console.SetCursorPosition(10, 3); Console.Write("ID. CLIENTE");
                Console.SetCursorPosition(25, 3); Console.Write("NOMBRE");
                Console.SetCursorPosition(40, 3); Console.Write("APELLIDO");
                Console.SetCursorPosition(55, 3); Console.Write("DESCRIPCION");
                Console.SetCursorPosition(70, 3); Console.Write("VALOR");
                Console.SetCursorPosition(85, 3); Console.Write("FECHA");



                for (int i = 0; i < movimientos.Count; i++)
                {    
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.SetCursorPosition(10, posicionPantalla); Console.Write(movimientos[i].idCliente);
                    Console.SetCursorPosition(25, posicionPantalla); Console.Write(movimientos[i].nombreCliente);
                    Console.SetCursorPosition(40, posicionPantalla); Console.Write(movimientos[i].apellidoCliente);
                    Console.SetCursorPosition(55, posicionPantalla); Console.Write(movimientos[i].descripcion);
                    Console.SetCursorPosition(70, posicionPantalla); Console.Write(movimientos[i].valor);
                    Console.SetCursorPosition(85, posicionPantalla); Console.Write(movimientos[i].fechaMovimineto);
                    posicionPantalla++;
                }
                Console.ReadKey();
            }
            Console.ResetColor();
            Console.Clear();
        }

        public void contratosPendientes()
        {
            
            
            if (!listaVacia())
            {
                int posicionEnPnatalla = 8;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(53, 5); Console.Write("LISTA DE CONTRATOS");
                Console.SetCursorPosition(10, 7); Console.Write("CODIGO");
                Console.SetCursorPosition(25, 7); Console.Write("ESTADO");
                Console.SetCursorPosition(40, 7); Console.Write("ID. CLIENTE");
                Console.SetCursorPosition(55, 7); Console.Write("APELLIDO");
                Console.SetCursorPosition(70, 7); Console.Write("NOMBRE");
                Console.SetCursorPosition(85, 7); Console.Write("VALOR");
                Console.SetCursorPosition(100, 7); Console.Write("SALDO");

                for (int i = 0; i < contratos.Count; i++)
                {
                    if (contratos[i].estadoContrato.ToUpper() == "PENDIENTE")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.SetCursorPosition(10, posicionEnPnatalla); Console.Write(contratos[i].codigoContrato);
                        Console.SetCursorPosition(25, posicionEnPnatalla); Console.Write(contratos[i].estadoContrato);
                        Console.SetCursorPosition(40, posicionEnPnatalla); Console.Write(contratos[i].idComprador);
                        Console.SetCursorPosition(55, posicionEnPnatalla); Console.Write(contratos[i].apellidoComprador);
                        Console.SetCursorPosition(70, posicionEnPnatalla); Console.Write(contratos[i].nombreComprador);
                        Console.SetCursorPosition(85, posicionEnPnatalla); Console.Write(contratos[i].valorProducto);
                        Console.SetCursorPosition(100, posicionEnPnatalla); Console.Write(contratos[i].saldoContrato);

                        posicionEnPnatalla++;
                    }
                }

                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 10); Console.Write("No Hay Elementos En La Lista");
                Console.ReadKey();
            }
            Console.ResetColor();
            Console.Clear();
        }

        public bool listaVacia()
        {
            descargarContratos();

            if (contratos.Count == 0)
            {
                return true;
            }
            return false;
        } 

        public void descargarContratos()
        {
            PersistenciaContato persistenciaContato = new PersistenciaContato();
            contratos = persistenciaContato.LeerContratoCompraDesdeArchivo("contratos.txt");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Inventario
    {
        public List<ContratoCompra> contratosCompra = new List<ContratoCompra>();
        public List<ContratoCompromiso> contratosCompromiso = new List<ContratoCompromiso>();
        public List<ContratoVenta> contratosVenta = new List<ContratoVenta>();
        public List<Empleado> empleados = new List<Empleado>();
        public List<Cliente> clientes = new List<Cliente>();
        public List<Gerente> gerentes = new List<Gerente>();
        public List<ProductoOro> productosOro = new List<ProductoOro>();

        public Inventario() { }

        public void productoOroAgregarALaLista(ProductoOro productoOro)
        {
            productosOro.Add(productoOro);
        }

        public void empleadoAgregarALaLista(Empleado empleado)
        {
            empleados.Add(empleado);
        }

        public void clienteAgregarALaLista(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public void gerenteAgregarALaLista(Gerente gerente)
        {
            gerentes.Add(gerente);
        }

        public void contratoVentaAgregarALaLista(ContratoVenta contratoVenta)
        {
            contratosVenta.Add(contratoVenta);
        }

        public void contratoCompromisoAgregarALaLista(ContratoCompromiso contratoCompromiso)
        {
            contratosCompromiso.Add(contratoCompromiso);
        }

        public void comtratoCompraAgregarALaLista(ContratoCompra contratoCompra)
        {
            contratosCompra.Add(contratoCompra);
        }

        public ProductoOro productoOroBuscarEnLista(String codigo)
        {

            for (int i = 0; i < productosOro.Count; i++)
            {
                if (productosOro[i].codigoProducto.Equals(codigo))
                {
                    return productosOro[i];
                }

            }
            return null;
        }

        public Gerente gerenteBuscarEnLista(String codigo)
        {

            for (int i = 0; i < gerentes.Count; i++)
            {
                if (gerentes[i].id.Equals(codigo))
                {
                    return gerentes[i];
                }

            }
            return null;
        }

        public Cliente clienteBuscarEnLista(String codigo)
        {

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].id.Equals(codigo))
                {
                    return clientes[i];
                }

            }
            return null;
        }

        public Empleado empleadoBuscarEnLista(String codigo)
        {

            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].id.Equals(codigo))
                {
                    return empleados[i];
                }

            }
            return null;
        }

        public ContratoCompra contratoCompraBuscarEnLista(String codigo)
        {

            for (int i = 0; i < contratosCompra.Count; i++)
            {
                if (contratosCompra[i].codigoContrato.Equals(codigo))
                {
                    return contratosCompra[i];
                }

            }
            return null;
        }

        public ContratoCompromiso contratoCompromisoBuscarEnLista(String codigo)
        {

            for (int i = 0; i < contratosCompromiso.Count; i++)
            {
                if (contratosCompromiso[i].codigoContrato.Equals(codigo))
                {
                    return contratosCompromiso[i];
                }

            }
            return null;
        }

        public ContratoVenta contratoVentaBuscarEnLista(String codigo)
        {

            for (int i = 0; i < contratosVenta.Count; i++)
            {
                if (contratosVenta[i].codigoContrato.Equals(codigo))
                {
                    return contratosVenta[i];
                }

            }
            return null;
        }

        public String productoOroEliminarDeLista(String codigo)
        {
            int encontrado = -1;
            string mensaje ;

            for (int i = 0; i < productosOro.Count; i++)
            {
                if (productosOro[i].codigoProducto.Equals(codigo))
                {
                    productosOro.RemoveAt(i);
                    encontrado = i;
                    break;
                }
            }
            if (encontrado == -1) {
                mensaje = "No Se Encontro Elemento En La Lista";
            }
            else
            {
                mensaje = "Se Elimino El Elemento De La Lista Con Exito";
            }
            return mensaje;
        }

        public String empleadoEliminarDeLista(String codigo)
        {
            int encontrado = -1;
            string mensaje;

            for (int i = 0; i < empleados.Count; i++)
            {
                if (empleados[i].id.Equals(codigo))
                {
                    empleados.RemoveAt(i);
                    encontrado = i;
                    break;
                }
            }
            if (encontrado == -1)
            {
                mensaje = "No Se Encontro Elemento En La Lista";
            }
            else
            {
                mensaje = "Se Elimino El Elemento De La Lista Con Exito";
            }
            return mensaje;
        }

        public String gerenteEliminarDeLista(String codigo)
        {
            int encontrado = -1;
            string mensaje;

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
                mensaje = "No Se Encontro Elemento En La Lista";
            }
            else
            {
                mensaje = "Se Elimino El Elemento De La Lista Con Exito";
            }
            return mensaje;
        }

        public String clienteEliminarDeLista(String codigo)
        {
            int encontrado = -1;
            string mensaje;

            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].id.Equals(codigo))
                {
                    clientes.RemoveAt(i);
                    encontrado = i;
                    break;
                }
            }
            if (encontrado == -1)
            {
                mensaje = "No Se Encontro Elemento En La Lista";
            }
            else
            {
                mensaje = "Se Elimino El Elemento De La Lista Con Exito";
            }
            return mensaje;
        }

        public String contratoVentaEliminarDeLista(String codigo)
        {
            int encontrado = -1;
            string mensaje;

            for (int i = 0; i < contratosVenta.Count; i++)
            {
                if (contratosVenta[i].codigoContrato.Equals(codigo))
                {
                    contratosVenta.RemoveAt(i);
                    encontrado = i;
                    break;
                }
            }
            if (encontrado == -1)
            {
                mensaje = "No Se Encontro Elemento En La Lista";
            }
            else
            {
                mensaje = "Se Elimino El Elemento De La Lista Con Exito";
            }
            return mensaje;
        }

        public String contratoCompraEliminarDeLista(String codigo)
        {
            int encontrado = -1;
            string mensaje;

            for (int i = 0; i < contratosCompra.Count; i++)
            {
                if (contratosCompra[i].codigoContrato.Equals(codigo))
                {
                    contratosCompra.RemoveAt(i);
                    encontrado = i;
                    break;
                }
            }
            if (encontrado == -1)
            {
                mensaje = "No Se Encontro Elemento En La Lista";
            }
            else
            {
                mensaje = "Se Elimino El Elemento De La Lista Con Exito";
            }
            return mensaje;
        }

        public String contratoCompromisoEliminarDeLista(String codigo)
        {
            int encontrado = -1;
            string mensaje;

            for (int i = 0; i < contratosCompromiso.Count; i++)
            {
                if (contratosCompromiso[i].codigoContrato.Equals(codigo))
                {
                    contratosCompromiso.RemoveAt(i);
                    encontrado = i;
                    break;
                }
            }
            if (encontrado == -1)
            {
                mensaje = "No Se Encontro Elemento En La Lista";
            }
            else
            {
                mensaje = "Se Elimino El Elemento De La Lista Con Exito";
            }
            return mensaje;
        }

        //public void AlmacenarContrato<T>(T contrato) 
        //{
        //    if (contrato is ContratoCompra)
        //        contratosCompra.Add(contrato as ContratoCompra);
        //    else if (contrato is ContratoCompromiso)
        //        contratosCompromiso.Add(contrato as ContratoCompromiso);
        //    else if (contrato is ContratoVenta)
        //        contratosVenta.Add(contrato as ContratoVenta);
        //}

        //public T buscarContratoEnLista <T>(List<T> listaContratos, string codigoContrato)
        //{
        //    return listaContratos.FirstOrDefault();
        //}

        ////public T BuscarContratoPorCodigo<T>(List<T> listaContratos, string codigoContrato)
        ////{
        //    foreach (var contrato in listaContratos)
        //    {
        //        if (contrato.Codigo == codigoContrato)
        //        {
        //            return contrato;
        //        }
        //    }
        //    return null;
        //}   TODAVIA FALTA LA FUNCION PARA RECORRESR LAS LISTAS EN BUSCA DE UN OBJETO


    }
}

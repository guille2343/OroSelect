using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class InventarioContrato
    {
        public List<ContratoCompra> contratosCompra = new List<ContratoCompra>();
        public List<ContratoCompromiso> contratosCompromiso = new List<ContratoCompromiso>();
        public List<ContratoVenta> contratosVenta = new List<ContratoVenta>();

        public InventarioContrato() { }

          public void AlmacenarContrato<T>(T contrato) 
          {
              if (contrato is ContratoCompra)
                  contratosCompra.Add(contrato as ContratoCompra);
              else if (contrato is ContratoCompromiso)
                  contratosCompromiso.Add(contrato as ContratoCompromiso);
              else if (contrato is ContratoVenta)
                  contratosVenta.Add(contrato as ContratoVenta);
          }
        
          public T buscarContratoEnLista <T>(List<T> listaContratos, string codigoContrato)
          {
              return listaContratos.FirstOrDefault();
          }
        
          //public T BuscarContratoPorCodigo<T>(List<T> listaContratos, string codigoContrato)
          //{
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

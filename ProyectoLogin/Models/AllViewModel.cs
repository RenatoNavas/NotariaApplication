using System.Collections.Generic;

namespace ProyectoLogin.Models
{
    public class AllViewModel
    {
        public List<TipoProceso> TipoProcesos { get; set; }
        public List<Factura> Facturas { get; set; }
        public List<Archivo> Archivos { get; set; }
        public List<Cotizacion> Cotizaciones {  get; set; }


        public AllViewModel()
        {
            TipoProcesos = new List<TipoProceso>();
            Facturas = new List<Factura>();
            Archivos = new List<Archivo>();
            Cotizaciones = new List<Cotizacion>();
        }
    }
}

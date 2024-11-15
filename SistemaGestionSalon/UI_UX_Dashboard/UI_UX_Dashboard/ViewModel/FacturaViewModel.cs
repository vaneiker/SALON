using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_UX_Dashboard_P1.ViewModel
{
    public class FacturaViewModel
    {
        public Facturacion.Factura FacturaHeader { get; set; } 
        public Facturacion.DetalleFactura detalleFactura { get; set; }
        public List<Facturacion.DetalleFactura> detalleFacturas { get; set; }
    }
}

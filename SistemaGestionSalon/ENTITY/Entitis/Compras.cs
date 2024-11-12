using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class Compras
    {
        public class FacturacionCompra
        {
            public int? IdCompra { get; set; }
            public int? IdProveedor { get; set; }
            public string TipoPago { get; set; }
            public string MetodoPago { get; set; }
            public decimal? SubtotalCompra { get; set; }
            public decimal? Descuento { get; set; }
            public decimal? Impuesto { get; set; }
            public decimal? TotalNeto { get; set; } 
            public int? Usuario { get; set; }
        }

        public class DetallesFacturacionCompra
        {
            public int? IdCompra { get; set; }
            public int? IdProducto { get; set; }
            public decimal? PrecioUnitario { get; set; }
            public decimal? Subtotal { get; set; }
            public int? Cantidad { get; set; }
            public decimal? Impuesto { get; set; }
            public decimal? Total { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class Facturacion
    {

        public class Factura
        {
            public int? IdFactura { get; set; } 
            public string NumeroFactura { get; set; } 
            public string TipoPago { get; set; } 
            public int? IdCliente { get; set; } 
            public decimal? Descuento { get; set; } 
            public decimal? Monto { get; set; } 
            public decimal? Impuesto { get; set; } 
            public decimal? Total { get; set; } 
            public bool? EsCredito { get; set; } 
            
            public int? Usuario { get; set; } 

        }

        public class DetalleFactura
        {
            public int? IdDetalle { get; set; } 
            public int? IdFactura { get; set; } 
            public int? IdProducto { get; set; } 
            public int? Cantidad { get; set; } 
            public decimal? PrecioUnitario { get; set; } 
            public decimal? Descuento { get; set; } 
            public decimal? Monto { get; set; } 
            public decimal? Impuesto { get; set; } 
            public decimal? Total { get; set; } 
            public int? Usuario { get; set; } 
        }
    }
}

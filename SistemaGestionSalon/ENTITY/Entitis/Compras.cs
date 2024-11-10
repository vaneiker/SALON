using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class Compras
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public DateTime? FechaCompra { get; set; }
        public string TipoPago { get; set; }
        public string MetodoPago { get; set; }
        public decimal? SubtotalCompra { get; set; }
        public decimal? SubtotalDetalles { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? ImpuestoCompra { get; set; }
        public decimal? ImpuestoDetalles { get; set; }
        public decimal? TotalNetoCompra { get; set; }
        public decimal? TotalNetoDetalle { get; set; }
        public int? IdDetalleCompra { get; set; } 
        public int? IdProducto { get; set; }
        public int? CantidadCompras { get; set; }
        public int? CantidadDetalles { get; set; }
        public decimal? PrecioUnitarioDetalles { get; set; } 
        public decimal? TotalCompra { get; set; } 
        public decimal? TotalDetalles { get; set; } 
    }
}

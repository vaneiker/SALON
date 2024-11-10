using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_UX_Dashboard_P1.ViewModel
{
    public class CompraViewModel
    {
        public int? IdProducto { get; set; }
        public int? IdProveedor {get;set;}
        public double? PrecioCosto {get;set;}
        public string Nombre { get; set; }
        public string TipoPago { get; set; }
        public string MedioPago { get; set; }
        public int? Cantidad {get;set;}
        public double? Importe { get; set; }
        public double? Impuesto { get; set; } 
        public double? SubTotal {get;set;}
        public string CodigoBarra { get; set; }
    }
}

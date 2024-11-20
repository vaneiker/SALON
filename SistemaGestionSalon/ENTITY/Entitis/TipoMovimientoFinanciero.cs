using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class TipoMovimientoFinanciero
    {
        public string TipoMovimiento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? Fecha { get; set; }
        public string MetodoPago { get; set; }
        public decimal? Monto { get; set; }
        public int? ProveedorCliente { get; set; } 
        public string htmlDocumento { get; set; }
    }
}

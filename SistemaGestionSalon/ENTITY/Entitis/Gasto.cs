using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class Gasto
    {
        public int? GastoID { get; set; }
        public DateTime? FechaGasto { get; set; }
        public string Descripcion { get; set; }
        public decimal? Monto { get; set; }
        public int? UsuarioID { get; set; }
        public byte[] Soporte { get; set; }
    }
}

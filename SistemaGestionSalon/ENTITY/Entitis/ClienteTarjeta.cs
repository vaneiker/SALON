using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class ClienteTarjeta
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public string Tarjetahabiente { get; set; }

        public string Tarjeta { get; set; }

        public string TarjetaReferencia { get; set; }

        public DateTime? FechaCaducidad { get; set; }

        public int? Cvc { get; set; }

        public bool? Domisilida { get; set; }

        public int? Usuario { get; set; } 
    }
}

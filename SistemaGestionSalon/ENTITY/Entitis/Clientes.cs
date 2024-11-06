using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace ENTITY.Entitis
{
    public class Clientes
    {
        
        public int? ClienteID { get; set; }
        public string Nombre { get; set; }       
        public string Direccion { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; } 
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaInicio { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class Proveedores
    {
        public int? ProveedorID { get; set; }
        public string NombreProveedor { get; set; } 
        public string CedulaProveedor { get; set; }
        public string CelularProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string EmailProveedor { get; set; }   
        public string DireccionProveedor { get; set; }  
        public DateTime? FechaRegistroProveedor { get; set; } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_UX_Dashboard_P1.ViewModel
{
    public class ProductoServiciosInventariosViewModel
    {
        public string ProductoServicioID { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Tipo { get; set; }
        public string Stock { get; set; } 
        public string ProveedoresId { get; set; }
        public string CantidadEnInventario { get; set; }
        public string FechaActualizacion { get; set; }
        public string ProveedorID { get; set; }
        public string NombreProveedor { get; set; }
        public string Codigo { get; set; }

        public string PrecioVentaBase { get; set; }
        public string PrecioVentaFinal { get; set; }
        public string Porciento { get; set; } 
        public string Impuestos { get; set; }

        public string beneficios { get; set; }  
    }
}

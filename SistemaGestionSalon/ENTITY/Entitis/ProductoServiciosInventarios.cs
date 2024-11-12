using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class ProductoServiciosInventarios
    {
        public int? ProductoServicioID { get; set; } 
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public decimal? Precio { get; set; } 
        public string Tipo { get; set; } 
        public int? Stock { get; set; } 
        public bool? EsServicio { get; set; } 
        public int? ProveedoresId { get; set; } 
        public int? CantidadEnInventario { get; set; }
        public DateTime? FechaActualizacion { get; set; } 
        public int? ProveedorID { get; set; } 
        public string NombreProveedor { get; set; } 
        public string Codigo { get; set; } 
        public decimal? PrecioVentaBase { get; set; }
        public decimal? PrecioVentaFinal { get; set; }
        public decimal? Porciento { get; set; }
        public decimal? Impuestos { get; set; }
        public int? UsuarioId { get; set; }  
        public bool? EsCompra { get; set; } 

    }
}

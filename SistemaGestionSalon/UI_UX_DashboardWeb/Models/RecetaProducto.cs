using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_UX_DashboardWeb.Models
{
    public class RecetaProducto
    {
        public int RecetaID { get; set; }
        public int ProductoID { get; set; }
        public decimal Cantidad { get; set; }

        public Receta Receta { get; set; }
        public Producto Producto { get; set; }
    }
}
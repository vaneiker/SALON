//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI_UX_DashboardWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receta_Producto
    {
        public int RecetaID { get; set; }
        public int ProductoID { get; set; }
        public decimal Cantidad { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Receta Receta { get; set; }
    }
}

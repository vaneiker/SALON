//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    
    public partial class SP_ObtenerMovimientosFinancieros_Result
    {
        public int MovimientoID { get; set; }
        public string Tipo { get; set; }
        public Nullable<System.DateTime> FechaMovimiento { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> UsuarioID { get; set; }
    }
}
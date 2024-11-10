using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_UX_Dashboard_P1.ViewModel
{
    public class ProveedoresViewModel
    {
     public int? Proveedor_ID {get;set;}
     public string Nombre_Proveedor {get;set;}
     public decimal? LimiteCredito {get;set;}
     public decimal? DiasCancelacion { get; set; }
    }
}

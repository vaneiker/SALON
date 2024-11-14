using DAL.Repository;
using ENTITY;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class FacturacionAdmin
    {
        private FacturacionRepository db = new FacturacionRepository();

        public Base GuardarFactura(Facturacion.Factura c)
        {  
            return db.InsertarFactura(c);
        }
        public void GuardarCompraDetallesFactura(Facturacion.DetalleFactura s)
        {
            db.InsertarDetallesFactura(s);
        } 
    }
}

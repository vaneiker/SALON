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
    public class ComprasAdmin
    {
        private ComprasRepository db = new ComprasRepository();

        public Base GuardarCompra(Compras.FacturacionCompra c)
        {  
            return db.InsertarCompra(c);
        }
        public void GuardarCompraDetallesCompra(Compras.DetallesFacturacionCompra s)
        {
            db.InsertarDetallesCompra(s);
        } 
    }
}

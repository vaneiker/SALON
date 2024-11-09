using DAL.EF_MODEL;
using DAL.Repository;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class ProductoServiciosInventariosAdmin
    {
        private ProductoServiciosIntentarios db = new ProductoServiciosIntentarios();

        public List<ProductoServiciosInventarios> GetProductoServiciosInventarios()
        {
            return db.ObtenerProductoServiciosInventarios();
        } 
        public void SetProductoServiciosInventarios(ProductoServiciosInventarios s)
        {
           db.SetProductoServiciosInventarios(s);
        }
    }
}

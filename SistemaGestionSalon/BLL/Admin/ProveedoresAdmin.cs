using DAL.Repository;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class ProveedoresAdmin
    {
        ProveedorRepository db = new ProveedorRepository();

        public IEnumerable<Proveedores> GetProveedor()
        {
            return db.ObtenerProveedores();
        }

        public void SetProveedorCrearActualizar(Proveedores P)
        {
            db.CrearActualizarProveedores(P);
        } 
        public void SetInactivarProveedores(int? Id=0)
        {
            db.InactivarProveedores(Id);
        }
    }
}

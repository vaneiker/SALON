using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using ENTITY.Entitis;

namespace BLL.Admin
{
    public class GastoAdmin
    {
        GastosRepository db = new GastosRepository();

        public void InsertarGasto(Gasto g)
        {
            db.InsertarGastos(g);
        }
    }
}

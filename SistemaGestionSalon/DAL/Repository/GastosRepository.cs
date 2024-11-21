using DAL.EF_MODEL;
using ENTITY;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GastosRepository
    {
        public List<Gasto> ObtenerClientes()
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Gasto> RetornarValue = dbo.Database.SqlQuery<Gasto>("EXEC [Salon].[SP_GET_CLIENTE]"

                    ).ToList();
                return RetornarValue.ToList();
            }
        }

        public void InsertarGastos(Gasto p)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[SP_SET_Gastos] @GastoID,@FechaGasto,@Descripcion,@Monto,@UsuarioID,@Soporte",
                  new SqlParameter("@GastoID", p.GastoID),
                  new SqlParameter("@FechaGasto", p.FechaGasto),
                  new SqlParameter("@Descripcion", p.Descripcion),
                  new SqlParameter("@Monto", p.Monto),
                  new SqlParameter("@UsuarioID", p.UsuarioID),
                  new SqlParameter("@Soporte", p.Soporte)
                  ).ToList(); 
            }
        }
    }
}

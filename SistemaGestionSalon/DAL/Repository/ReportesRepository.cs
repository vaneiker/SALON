using DAL.EF_MODEL;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ReportesRepository
    {
        public IEnumerable<TipoMovimientoFinanciero> GetMovimientosFinancieros(DateTime? FechaInicio, DateTime? FechaFin)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<TipoMovimientoFinanciero> RetornarValue = dbo.Database.SqlQuery<TipoMovimientoFinanciero>("EXEC [Salon].[GetMovimientosFinancieros] @FechaInicio,@FechaFin",
                  new SqlParameter("@FechaInicio", FechaInicio),
                  new SqlParameter("@FechaFin", FechaFin)
                  ).ToList();
                return RetornarValue.ToList();
            }
        }
    }
}

using DAL.Repository;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class ReporteAdmin
    {
        private ReportesRepository db = new ReportesRepository();

        public IEnumerable<TipoMovimientoFinanciero> MovimientosFinancieros(DateTime? FechaInicio, DateTime? FechaFin)
        {
            return db.GetMovimientosFinancieros(FechaInicio, FechaFin);
        } 
    }
}

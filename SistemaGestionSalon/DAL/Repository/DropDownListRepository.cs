using DAL.EF_MODEL;
using ENTITY;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DropDownListRepository
    {
        public List<Base> DropDownList(string Filtro = "",string Filtro2="")
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>("EXEC [Salon].[GetDropDownList] @Filtro,@Filtro2",
                     new SqlParameter("@Filtro", Filtro),
                     new SqlParameter("@Filtro2", Filtro2)
                    ).ToList();
                return RetornarValue.ToList();
            }
        }
    }
}

using DAL.EF_MODEL;
using ENTITY;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DocumentoLogRepository
    {
        public Base InsertarDocumentoLog(DocumentoLog l)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[InsertDocumentoLog] @TipoDocumento,@HtmlDocumento,@Usuario,@NumeroComprobante", 
                  new SqlParameter("@TipoDocumento", l.TipoDocumento),
                  new SqlParameter("@HtmlDocumento", l.HtmlDocumento),
                  new SqlParameter("@Usuario", l.Usuario) ,
                  new SqlParameter("@NumeroComprobante", l.NumeroComprobante)
                  ).ToList();
                return RetornarValue.FirstOrDefault();
            }
        } 
    }
}

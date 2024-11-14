using DAL.Repository;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Admin
{
    public class DocumentoLogAdmin
    {
        DocumentoLogRepository db = new DocumentoLogRepository();

        public void InsertarDocumentoLog(DocumentoLog l)
        {
            db.InsertarDocumentoLog(l);
        }
    }
}

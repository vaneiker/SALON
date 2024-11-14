using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class DocumentoLog
    {
        public int? DocumentoLogId { get; set; }
        public string TipoDocumento { get; set; }
        public string HtmlDocumento { get; set; }        
        public int? Usuario { get; set; } 
        public string NumeroComprobante { get; set; }    
    }
}

using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_UX_Dashboard_P1.Custom
{
    public static class Helpers
    {
        public static string FormatException(Exception eex,string FullName="",string MethodExceptionName="")
        {
            var body = "StacTrace:{0}";
            body += Environment.NewLine + "InnerExceptin:{1}";
            body += Environment.NewLine + "Error:{2}";
            body += Environment.NewLine + "Usuario:{3}";
            body += Environment.NewLine + "Metodo:{4}";
            string rBody = string.Format(body, eex.StackTrace, eex.InnerException, eex.Message, FullName, MethodExceptionName); 
            return rBody;
        }
    }
}

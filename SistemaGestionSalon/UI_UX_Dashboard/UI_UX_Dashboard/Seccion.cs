using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI_UX_Dashboard_P1.Custom;
using static UI_UX_Dashboard_P1.Custom.AppEnun;

namespace UI_UX_Dashboard_P1
{
    public class Seccion
    {
        public int? Rol { get; set; }
        public int? UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; } 
        public string RolName { get; set; }

        private static Seccion _user = null;
        private Seccion() { }

        public static Seccion Instance
        {
            get
            {
                if (_user == null)
                    _user = new Seccion();

                return _user;
            } 
        } 
    }
}

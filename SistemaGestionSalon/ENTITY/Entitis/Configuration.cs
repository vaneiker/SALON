using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{
    public class Configuration
    { 
        public class Menus
        {
            public int? MenuID { get; set; }
            public string MenuNombre { get; set; }
            public string MenuUrl { get; set; }
            public string SubmenuID { get; set; }
            public string SubmenuNombre { get; set; }
            public string SubmenuUrl { get; set; }
            public string Action { get; set; }
            public string Controller { get; set; }
            public string Class { get; set; }
            public string Icon { get; set; }
        }

        public class SubMenu
        {
            public int? SubMenuID { get; set; }
            public int? MenuID { get; set; } 
            public string Nombre { get; set; } 
            public string Url { get; set; } 
            public bool? Activo { get; set; }
            public string Action { get; set; }
            public string Controller { get; set; }
            public string Class { get; set; } 
            public string Icon { get; set; }
        }

    }
}

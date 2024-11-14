using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY.Entitis
{

 
    public class Usuarios: Base
    {
        public int? UsuarioID { get; set; } 
        public string Nombre { get; set; } 
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; } 
        public string RolName { get; set; }
        public string Contrasena { get; set; } 
        public int? Rol { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; } 
        public bool EsBorrado { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? UltimoInicioSesion { get; set; }
    }
}


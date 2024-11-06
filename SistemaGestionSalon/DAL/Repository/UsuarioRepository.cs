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
    public class UsuarioRepository
    {

        public Base Login(string user = "", string password = "")
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>("EXEC [Salon].[SP_Login] @Usuario,@Contrasena",
                     new SqlParameter("@Usuario", user),
                     new SqlParameter("@Contrasena", password)
                    ).ToList();
                return RetornarValue.FirstOrDefault();
            }
        }
        public List<Usuarios> ObtenerUsuario(string user = "")
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Usuarios> RetornarValue = dbo.Database.SqlQuery<Usuarios>("EXEC [Salon].[SP_ObtenerUsuarios] @Usuario",
                     new SqlParameter("@Usuario", user) 
                    ).ToList();
                return RetornarValue.ToList();
            }
        }

        public void CambiarClave(int? UserId=0, string pass = "")
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>("EXEC [Salon].[SP_CambiarClave] @UserId,@pass",
                     new SqlParameter("@UserId", UserId),
                     new SqlParameter("@pass", pass)
                    ).ToList(); 
            }
        }
        public Usuarios CrearUsuario(Usuarios u)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Usuarios> RetornarValue = dbo.Database.SqlQuery<Usuarios>("EXEC [Salon].[sp_InsertOrUpdateUsuario] @UsuarioID,@Nombre,@Usuario,@Contrasena,@ROL_ID",
                     new SqlParameter("@UsuarioID", u.UsuarioID),
                     new SqlParameter("@Nombre", u.Nombre),
                     new SqlParameter("@Usuario", u.Usuario),
                     new SqlParameter("@Contrasena", u.Contrasena),
                     new SqlParameter("@ROL_ID", u.Rol)
                     ).ToList();
                return RetornarValue.FirstOrDefault();  
            }
        }

        public void EliminarUsuario(int UsuarioID)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Usuarios> RetornarValue = dbo.Database.SqlQuery<Usuarios>("EXEC [Salon].[sp_EliminarUsuario] @UsuarioID",
                     new SqlParameter("@UsuarioID", UsuarioID) 
                     ).ToList(); 
            }
        }
    }
}

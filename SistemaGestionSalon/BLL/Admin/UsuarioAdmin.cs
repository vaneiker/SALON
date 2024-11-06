using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using ENTITY;
using ENTITY.Entitis;

namespace BLL.Admin
{
    public class UsuarioAdmin
    {
        private UsuarioRepository db = new UsuarioRepository();

        public Base Acceder(string user = "", string password = "")
        {
            Base result = new Base();
            try
            {
                result = db.Login(user, password);
            }
            catch (Exception ex)
            {
                result.MSJ = ex.Message;
            }
            return result;
        }
        public List<Usuarios> ObtenerUsuarioAdmin(string user = "")
        {
            List<Usuarios> result = new List<Usuarios>();
            try
            {
                result = db.ObtenerUsuario(user);
            }
            catch (Exception ex)
            {
                result.Add(new Usuarios
                {
                    MSJ = ex.Message,
                });
            }
            return result;
        }
        public void CambiarClave(int? UserId=0,string user = "")
        {
            db.CambiarClave(UserId, user);
        }
        public Usuarios AddUpdateUsuario(Usuarios p)
        {
            Usuarios result = new Usuarios();
            try
            {
                result = db.CrearUsuario(p);
            }
            catch (Exception ex)
            {
                result.MSJ = ex.Message;
            }
            return result;
        }
        public void eliminarUsuario(int id)
        {
            db.EliminarUsuario(id);
        }
    }
}

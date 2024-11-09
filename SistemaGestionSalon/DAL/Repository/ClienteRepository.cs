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
    public class ClienteRepository
    {
        public List<Clientes> ObtenerClientes()
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Clientes> RetornarValue = dbo.Database.SqlQuery<Clientes>("EXEC [Salon].[SP_GET_CLIENTE]"

                    ).ToList();
                return RetornarValue.ToList();
            }
        }
        public void CrearActualizarCliente(Clientes c)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Clientes> RetornarValue = dbo.Database.SqlQuery<Clientes>("EXEC [Salon].[SP_UPDATE_INSERT_CLIENTES]@ClienteID,@Nombre,@Cedula,@Telefono,@Celular,@FechaNacimiento,@Email",
                  new SqlParameter("@ClienteID", c.ClienteID),
                  new SqlParameter("@Nombre", c.Nombre),
                  new SqlParameter("@Cedula", c.Cedula),
                  new SqlParameter("@Telefono", c.Telefono),
                  new SqlParameter("@Celular", c.Celular),
                  new SqlParameter("@FechaNacimiento", c.FechaNacimiento),
                  new SqlParameter("@Email", c.Email)).ToList();
            }
        }

        public void InactivarClientes(int? ClienteID = 0)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Clientes> RetornarValue = dbo.Database.SqlQuery<Clientes>("EXEC [Salon].SP_SET_DESACTIVAR_Clientes @ClienteID",
                  new SqlParameter("@ClienteID", ClienteID)).ToList();
            }
        }
    }
}

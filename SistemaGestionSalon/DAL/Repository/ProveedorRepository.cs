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
    public class ProveedorRepository
    {
        public List<Proveedores> ObtenerProveedores()
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Proveedores> RetornarValue = dbo.Database.SqlQuery<Proveedores>("EXEC [Salon].[Sp_Get_Proveedores]"

                    ).ToList();
                return RetornarValue.ToList();
            }
        }
        public void CrearActualizarProveedores(Proveedores c)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Clientes> RetornarValue = dbo.Database.SqlQuery<Clientes>("EXEC [Salon].[SP_SET_INSERT_UPDATE_PROVEEDORES]@ProveedorID,@Nombre,@Cedula,@Telefono,@Celular,@Email,@Direccion,@LimiteCredito,@DiasCancelacion,@Usuario,@HostName",
                  new SqlParameter("@ProveedorID", c.ProveedorID),
                  new SqlParameter("@Nombre", c.NombreProveedor),
                  new SqlParameter("@Cedula", c.CedulaProveedor),
                  new SqlParameter("@Telefono", c.TelefonoProveedor),
                  new SqlParameter("@Celular", c.CelularProveedor),
                  new SqlParameter("@Email", c.EmailProveedor),
                  new SqlParameter("@Direccion", c.DireccionProveedor),
                  new SqlParameter("@LimiteCredito", c.LimiteCredito),
                  new SqlParameter("@DiasCancelacion", c.DiasCancelacion),
                  new SqlParameter("@Usuario", c.Usuario),
                  new SqlParameter("@HostName", c.HostName)


                  ).ToList();
            }
        }  
        public void InactivarProveedores(int? ProveedorID = 0)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Clientes> RetornarValue = dbo.Database.SqlQuery<Clientes>("EXEC [Salon].SP_SET_DESACTIVAR_Proveedores @ProveedorID",
                  new SqlParameter("@ProveedorID", ProveedorID)).ToList();
            }
        }
    }
} 
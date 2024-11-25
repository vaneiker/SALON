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
    public class MedioPagoRepository
    { 
        public Base GuardarDatosTarjetaClientes(ClienteTarjeta t)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>("EXEC Salon.sp_InsertarClienteTarjeta @ClienteId,@Tarjetahabiente,@Tarjeta,@TarjetaReferencia,@FechaCaducidad,@Cvc,@Domisilida,@Usuario",
                  new SqlParameter("@ClienteId", t.ClienteId),
                  new SqlParameter("@Tarjetahabiente", t.Tarjetahabiente),
                  new SqlParameter("@Tarjeta", t.Tarjeta),
                  new SqlParameter("@TarjetaReferencia", t.TarjetaReferencia),
                  new SqlParameter("@FechaCaducidad", t.FechaCaducidad),
                  new SqlParameter("@Cvc", t.Cvc),
                  new SqlParameter("@Domisilida", t.Domisilida),
                  new SqlParameter("@Usuario", t.Usuario)
                  ).ToList();
                return RetornarValue.FirstOrDefault();
            }
        } 
    }
}

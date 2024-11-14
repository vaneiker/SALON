using DAL.EF_MODEL;
using ENTITY.Entitis;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class FacturacionRepository
    {

        public Base InsertarFactura(Facturacion.Factura f)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[sp_GuardarFactura]@IdFactura, @NumeroFactura,@TipoPago,@IdCliente,@Descuento,@Monto,@Impuesto,@Total,@EsCredito,@Usuario",
                  new SqlParameter("@IdFactura", f.IdFactura),
                  new SqlParameter("@NumeroFactura", f.NumeroFactura),
                  new SqlParameter("@TipoPago", f.TipoPago),
                  new SqlParameter("@IdCliente ", f.IdCliente),
                  new SqlParameter("@Descuento", f.Descuento),
                  new SqlParameter("@Monto", f.Monto),
                  new SqlParameter("@Impuesto", f.Impuesto),
                  new SqlParameter("@Total", f.Total),
                  new SqlParameter("@EsCredito", f.EsCredito),
                  new SqlParameter("@Usuario", f.Usuario)
                  ).ToList();
                return RetornarValue.FirstOrDefault();
            }
        }
        public void InsertarDetallesFactura(Facturacion.DetalleFactura  df)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[sp_GuardarDetallesFactura]@IdDetalle,@IdFactura,@IdProducto,@Cantidad,@PrecioUnitario,@Descuento,@Monto,@Impuesto,@Total,@Usuario",
                  new SqlParameter("@IdDetalle", df.IdDetalle),
                  new SqlParameter("@IdFactura", df.IdFactura),
                  new SqlParameter("@IdProducto", df.IdProducto),
                  new SqlParameter("@Cantidad ", df.Cantidad),
                  new SqlParameter("@PrecioUnitario", df.PrecioUnitario),
                  new SqlParameter("@Descuento", df.Descuento),
                  new SqlParameter("@Monto", df.Monto),
                  new SqlParameter("@Impuesto", df.Impuesto),
                  new SqlParameter("@Total", df.Total),
                  new SqlParameter("@Usuario", df.Usuario)
                  ).ToList();
            }
        }

    }
}

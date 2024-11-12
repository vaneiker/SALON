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
    public class ComprasRepository
    {
        public Base InsertarCompra(Compras.FacturacionCompra c)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[sp_InsertarCompra]@IdProveedor,@TipoPago,@MetodoPago,@Subtotal,@Descuento,@Impuesto,@TotalNeto,@Usuario",
                  new SqlParameter("@IdProveedor", c.IdProveedor),
                  new SqlParameter("@TipoPago", c.TipoPago),
                  new SqlParameter("@MetodoPago", c.MetodoPago),
                  new SqlParameter("@Subtotal", c.SubtotalCompra),
                  new SqlParameter("@Descuento", c.Descuento),
                  new SqlParameter("@Impuesto", c.Impuesto),
                  new SqlParameter("@TotalNeto", c.TotalNeto),
                  new SqlParameter("@Usuario", c.Usuario)
                  ).ToList();
                return RetornarValue.FirstOrDefault();
            }
        }
        public void InsertarDetallesCompra(Compras.DetallesFacturacionCompra c)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[sp_InsertarCompraDetalle]@IdCompra,@IdProducto,@Cantidad,@PrecioUnitario,@Subtotal,@Impuesto,@Total",
                  new SqlParameter("@IdCompra", c.IdCompra),
                  new SqlParameter("@IdProducto", c.IdProducto),
                  new SqlParameter("@Cantidad", c.Cantidad),
                  new SqlParameter("@PrecioUnitario", c.PrecioUnitario),
                  new SqlParameter("@Subtotal", c.Subtotal),
                  new SqlParameter("@Impuesto", c.Impuesto),
                  new SqlParameter("@Total", c.Total)
                  ).ToList();
            }
        } 
    }
}

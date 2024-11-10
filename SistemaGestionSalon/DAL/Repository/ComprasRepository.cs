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
        public Base InsertarCompra(Compras c)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[sp_InsertarCompra]@IdProveedor,@TipoPago,@MetodoPago,@Subtotal,@Descuento,@Impuesto,@TotalNeto",
                  new SqlParameter("@IdProveedor", c.IdProveedor),
                  new SqlParameter("@TipoPago", c.TipoPago),
                  new SqlParameter("@MetodoPago", c.MetodoPago),
                  new SqlParameter("@Subtotal", c.SubtotalCompra),
                  new SqlParameter("@Descuento", c.Descuento),
                  new SqlParameter("@Impuesto", c.ImpuestoCompra),
                  new SqlParameter("@TotalNeto", c.TotalCompra)
                  ).ToList();
                return RetornarValue.FirstOrDefault();
            }
        }
        public void InsertarDetallesCompra(Compras c)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<Base> RetornarValue = dbo.Database.SqlQuery<Base>(
                    "EXEC [Salon].[sp_InsertarCompraDetalle]@IdCompra,@IdProducto,@Cantidad,@PrecioUnitario,@Subtotal,@Impuesto,@Total",
                  new SqlParameter("@IdCompra", c.IdProveedor),
                  new SqlParameter("@IdProducto", c.TipoPago),
                  new SqlParameter("@Cantidad", c.MetodoPago),
                  new SqlParameter("@PrecioUnitario", c.PrecioUnitarioDetalles),
                  new SqlParameter("@Subtotal", c.Descuento),
                  new SqlParameter("@Impuesto", c.ImpuestoDetalles),
                  new SqlParameter("@Total", c.TotalDetalles)
                  ).ToList();
            }
        } 
    }
}

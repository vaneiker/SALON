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
    public class ProductoServiciosIntentarios
    {
        public List<ProductoServiciosInventarios> ObtenerProductoServiciosInventarios()
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<ProductoServiciosInventarios> RetornarValue = dbo.Database.SqlQuery<ProductoServiciosInventarios>("EXEC [Salon].[sp_ListarProductosEnExistencia]"

                    ).ToList();
                return RetornarValue.ToList();
            }
        }

        public void SetProductoServiciosInventarios(ProductoServiciosInventarios s)
        {
            using (var dbo = new salon_connection())
            {
                IEnumerable<ProductoServiciosInventarios> RetornarValue = dbo.Database.SqlQuery<ProductoServiciosInventarios>(
                    "EXEC [Salon].[SP_SET_AGREGAR_PRODUCTO_SERVICIO] @ProductoServicioID,@Nombre,@Descripcion,@Precio,@Tipo,@Stock,@EsServicio,@ProveedoresId,@Codigo,@PrecioVentaBase,@PrecioVentaFinal,@Porciento,@Impuestos,@UsuarioId,@EsCompra",
                  new SqlParameter("@ProductoServicioID", s.ProductoServicioID),
                  new SqlParameter("@Nombre", s.Nombre),
                  new SqlParameter("@Descripcion", s.Descripcion),
                  new SqlParameter("@Precio", s.Precio),
                  new SqlParameter("@Tipo", s.Tipo),
                  new SqlParameter("@Stock", s.Stock),
                  new SqlParameter("@EsServicio", s.EsServicio),
                  new SqlParameter("@ProveedoresId", s.ProveedoresId),
                  new SqlParameter("@Codigo", s.Codigo),
                  new SqlParameter("@PrecioVentaBase", s.PrecioVentaBase),
                  new SqlParameter("@PrecioVentaFinal", s.PrecioVentaFinal), 
                  new SqlParameter("@Porciento", s.Porciento),
                  new SqlParameter("@Impuestos", s.Impuestos),
                  new SqlParameter("@UsuarioId", s.UsuarioId),
                  new SqlParameter("@EsCompra", s.EsCompra)
                  ).ToList();
            }
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_UX_DashboardWeb
{
    using System.Data.Entity;
    using UI_UX_DashboardWeb.Models;

    public class SistemaDbContext : DbContext
    {
        public SistemaDbContext() : base("name=ConnectionStringGuar6") { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<RecetaProducto> RecetaProductos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
    }

}
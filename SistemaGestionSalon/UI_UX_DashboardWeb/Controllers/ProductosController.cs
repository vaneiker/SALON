using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_UX_DashboardWeb.Models;

namespace UI_UX_DashboardWeb.Controllers
{
    public class ProductosController : Controller
    {
        private SistemaDbContext db = new SistemaDbContext();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.ToList();
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Categoria,CantidadDisponible,PrecioCompra,PrecioVenta,Activo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }
    } 
}
using BLL.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_UX_Dashboard_P1.ViewModel;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class ComprasForm : Form
    {

        private ProveedoresAdmin dbp = new ProveedoresAdmin();
        private ProductoServiciosInventariosAdmin dbpro = new ProductoServiciosInventariosAdmin();
        private DropDownListAdmin drop = new DropDownListAdmin();

        public ComprasForm()
        {
            InitializeComponent();
        }

        private void ComprasForm_Load(object sender, EventArgs e)
        {
            CargarAllList();
        }


        private void CargarAllList()
        {
            bindingSource_proveedor_compras.DataSource= dbp.GetProveedor().Select(x=>new BaseViewModel()
            { 
                CODE=x.ProveedorID.ToString(),
                ACTION=x.NombreProveedor,                 
            }).ToArray();


            var xx = dbpro.GetProductoServiciosInventarios().ToArray();

            bindingSource_producto_compras.DataSource = dbpro.GetProductoServiciosInventarios().Where(x=>x.Tipo== "Producto").Select(x=>new BaseViewModel()
            {
                ACTION=x.Nombre,
                CODE=x.ProductoServicioID.ToString(),
                MSJ=x.Codigo
            }).ToArray(); 
        }

        private void dataGridView_proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dt = dataGridView_proveedores;
            if (dataGridView_proveedores.CurrentRow != null)
            {
                label_Proveedor.Text = dt.CurrentRow.Cells["ACTION"].Value.ToString(); 
            } 

            //label_Proveedor
        }

        private void dataGridView_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dt = dataGridView_Productos;
            if (dataGridView_Productos.CurrentRow != null)
            {
                txtCodigoBarra.Text = dt.CurrentRow.Cells["MSJ_PRODUCTO"].Value.ToString();
                txtnombre.Text = dt.CurrentRow.Cells["ACTION_PRODUCTO"].Value.ToString();
            }
        }
    }

}

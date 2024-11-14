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
using UI_UX_Dashboard_P1.Custom;
using UI_UX_Dashboard_P1.ViewModel;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class FacturacionForm : Form
    {
        Seccion seccion = Seccion.Instance;
        private ProveedoresAdmin dbp = new ProveedoresAdmin();
        private ProductoServiciosInventariosAdmin dbpro = new ProductoServiciosInventariosAdmin();
        private DropDownListAdmin drop = new DropDownListAdmin();
        private List<CompraViewModel> compraViewModels = new List<CompraViewModel>();
        private ComprasAdmin comprasAdmin = new ComprasAdmin();
        private ProductoServiciosInventariosAdmin inventariosAdmin = new ProductoServiciosInventariosAdmin();
        private DocumentoLogAdmin documentoLogAdmin = new DocumentoLogAdmin();
        private ClienteAdmin clienteAdmin = new ClienteAdmin();


        public FacturacionForm()
        {
            InitializeComponent();
        }

        private void FacturacionForm_Load(object sender, EventArgs e)
        {
            CargarAll();
        }

        private void CargarAll()
        {
            var ddClientes = drop.DropDownList(DropDownList.Clientes.ToString());
            comboBox_Clientes.DataSource = ddClientes;
            comboBox_Clientes.DisplayMember = "ACTION";
            comboBox_Clientes.ValueMember = "CODE";
            //comboBox_Clientes.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_Clientes.AutoCompleteSource = AutoCompleteSource.ListItems;


            var ddProducto = drop.DropDownList(DropDownList.ProductoServicios.ToString());
            comboBox_Producto.DataSource = ddProducto;
            comboBox_Producto.DisplayMember = "ACTION";
            comboBox_Producto.ValueMember = "CODE";
            //comboBox_Clientes.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox_Producto.AutoCompleteSource = AutoCompleteSource.ListItems; 
        }

        private void comboBox_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Clientes.SelectedIndex > 0)
            {
                var cliente = clienteAdmin.GetClientes().Where(x => x.ClienteID == int.Parse(comboBox_Clientes.SelectedValue.ToString())).FirstOrDefault();
                txtnombre.Text = cliente.Nombre;
                txtcedula.Text = cliente.Cedula;
                txtcelular.Text = cliente.Celular;
                txttelefono.Text = cliente.Telefono;
                txtcorreo.Text = cliente.Email;
                txtIdCliente.Text = cliente.ClienteID.ToString();
            }
        }

        private void comboBox_Producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Producto.SelectedIndex > 0)
            {
                var producto = dbpro.GetProductoServiciosInventarios().Where(x => x.ProductoServicioID == int.Parse(comboBox_Producto.SelectedValue.ToString())).FirstOrDefault();
                txtProducto.Text = producto.Codigo;
                txtStock.Text=producto.Stock.ToString();
                txtProductoServicio.Text = producto.Nombre;
                txtIdProducto.Text=producto.ProductoServicioID.ToString(); 
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}

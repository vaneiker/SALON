using BLL.Admin;
using ENTITY.Entitis;
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
using static ENTITY.Entitis.Facturacion;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class FacturacionForm : Form
    {
        Seccion seccion = Seccion.Instance;
        private ProveedoresAdmin dbp = new ProveedoresAdmin();
        private ProductoServiciosInventariosAdmin dbpro = new ProductoServiciosInventariosAdmin();
        private DropDownListAdmin drop = new DropDownListAdmin();
        private List<CompraViewModel> compraViewModels = new List<CompraViewModel>();
        private List<Facturacion.DetalleFactura> DetalleFacturaList = new List<Facturacion.DetalleFactura>();
        private ComprasAdmin comprasAdmin = new ComprasAdmin();
        private ProductoServiciosInventariosAdmin inventariosAdmin = new ProductoServiciosInventariosAdmin();
        private DocumentoLogAdmin documentoLogAdmin = new DocumentoLogAdmin();
        private ClienteAdmin clienteAdmin = new ClienteAdmin();
        private FacturaViewModel model = new FacturaViewModel();





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
                txtStock.Text = producto.Stock.ToString();
                txtProductoServicio.Text = producto.Nombre;
                txtIdProducto.Text = producto.ProductoServicioID.ToString();
                txtPrecio.Text = producto.Precio.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            decimal? _impuesto = 0.00m;
            decimal? _Total = 0.00m;
            decimal? _Monto = 0.00m;


            _Monto= (int.Parse(txtCantidadAdd.Text) * decimal.Parse(txtPrecio.Text));

            _impuesto = _Monto * 1.18m;

            _Total = _Monto + _impuesto;

            var modelo = new FacturaViewModel();
            var dfactura = new Facturacion.DetalleFactura();
            var detalleFacturasLista = new List<Facturacion.DetalleFactura>();


            dfactura.IdFactura = 0;
            dfactura.IdProducto = int.Parse(txtIdProducto.Text);
            dfactura.nombreProducto = txtProductoServicio.Text;
            dfactura.Cantidad = int.Parse(txtCantidadAdd.Text);
            dfactura.PrecioUnitario = decimal.Parse(txtPrecio.Text);
            dfactura.Descuento = 0;
            dfactura.Monto = _Monto;
            dfactura.Impuesto = (_impuesto);
            dfactura.Total = _Total;

            model.detalleFactura = dfactura;
            AddFactura(model);
        }


        private void AddFactura(FacturaViewModel model)
        {
             
            bindingSource_producto_servicios_a_facturar.DataSource=null;

            DetalleFacturaList.Add(new Facturacion.DetalleFactura()
            {

                IdFactura = model.detalleFactura.IdFactura,
                IdProducto = model.detalleFactura.IdProducto,
                nombreProducto = model.detalleFactura.nombreProducto,
                Cantidad = model.detalleFactura.Cantidad,
                PrecioUnitario = model.detalleFactura.PrecioUnitario,
                Descuento = model.detalleFactura.Descuento,
                Monto = model.detalleFactura.Monto,
                Impuesto = model.detalleFactura.Impuesto,
                Total = model.detalleFactura.Total
            });

            bindingSource_producto_servicios_a_facturar.DataSource = DetalleFacturaList;


            LblTotalApagar.Text = $"RD$ {DetalleFacturaList.Sum(x => x.Monto):N2}";


            ConfigureDataGridView();
        }


        private void ConfigureDataGridView()
        {
            // Configuración general del DataGridView
            dataGridView_Producto_Servicio_Facturacion.AutoGenerateColumns = false;
            dataGridView_Producto_Servicio_Facturacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Producto_Servicio_Facturacion.AllowUserToAddRows = false;
            dataGridView_Producto_Servicio_Facturacion.ReadOnly = true;
            dataGridView_Producto_Servicio_Facturacion.EnableHeadersVisualStyles = false;

            // Estilo de los encabezados
            dataGridView_Producto_Servicio_Facturacion.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dataGridView_Producto_Servicio_Facturacion.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_Producto_Servicio_Facturacion.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView_Producto_Servicio_Facturacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color alterno para las filas
            dataGridView_Producto_Servicio_Facturacion.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView_Producto_Servicio_Facturacion.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView_Producto_Servicio_Facturacion.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dataGridView_Producto_Servicio_Facturacion.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView_Producto_Servicio_Facturacion.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Bordes invisibles para un diseño más limpio
            dataGridView_Producto_Servicio_Facturacion.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView_Producto_Servicio_Facturacion.GridColor = Color.FromArgb(224, 224, 224);

            // Limpiar columnas anteriores
            dataGridView_Producto_Servicio_Facturacion.Columns.Clear();

            // Columna para el botón de Editar
            var editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "✏️ Editar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            editButtonColumn.DefaultCellStyle.BackColor = Color.Green;
            editButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            editButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView_Producto_Servicio_Facturacion.Columns.Add(editButtonColumn);

            // Columna para el botón de Borrar
            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Borrar",
                Text = "🗑️ Borrar",
                UseColumnTextForButtonValue = true,
                Width = 70,
                FlatStyle = FlatStyle.Flat
            };
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.Red;
            deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            deleteButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView_Producto_Servicio_Facturacion.Columns.Add(deleteButtonColumn);

            // Columnas de datos
            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Producto",
                DataPropertyName = "nombreProducto",
                Width = 200,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 200,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnitario",
                Width = 100,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                Width = 80,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Impuesto",
                DataPropertyName = "Impuesto",
                Width = 120,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "Total",
                Width = 100,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            }); 
        }

    }
}

using BLL;
using BLL.Admin;
using ENTITY.Entitis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using UI_UX_Dashboard_P1.Custom;
using UI_UX_Dashboard_P1.ViewModel;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class ProductoServiciosForm : Form
    {
        Seccion seccion = Seccion.Instance;

        private ProductoServiciosInventariosAdmin db = new ProductoServiciosInventariosAdmin();
        private DropDownListAdmin drop = new DropDownListAdmin();
        private int? _ProductoServicioID { get; set; } = 0;
        private bool EsPorcentaje { get; set; } = false;
        private string CodigoBarra { get; set; }

        public ProductoServiciosForm()
        {
            InitializeComponent();
        }

        private void ProductoServiciosForm_Load(object sender, EventArgs e)
        {
            CargaInicial();
            CargarProveedor();
        }
        private void CargarProveedor()
        {
            var data = drop.DropDownList(DropDownList.Proveedores.ToString());
            comboBox_Proveedor.DataSource = data;
            comboBox_Proveedor.DisplayMember = "ACTION";
            comboBox_Proveedor.ValueMember = "CODE";
            comboBox_Proveedor.Text = "---Selecionar---";
        }

        public void CargaInicial()
        {

            try
            {
                var result = db.GetProductoServiciosInventarios().Select(x => new ProductoServiciosInventariosViewModel()
                {

                    ProductoServicioID = x.ProductoServicioID.ToString(),
                    NombreProducto = x.Nombre,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio.Value.ToString("RD$ #,##0.00"),
                    Tipo = x.Tipo,
                    Stock = x.Stock.ToString(),
                    ProveedoresId = x.ProveedorID.ToString(),
                    CantidadEnInventario = x.CantidadEnInventario.ToString(),
                    FechaActualizacion = x.FechaActualizacion.Value.ToString("dd-MM-yyyy"),
                    ProveedorID = x.ProveedorID.ToString(),
                    NombreProveedor = x.NombreProveedor,
                    Codigo = x.Codigo,
                    PrecioVentaBase = x.PrecioVentaBase.Value.ToString("RD$ #,##0.00"),
                    PrecioVentaFinal = x.PrecioVentaFinal.Value.ToString("RD$ #,##0.00"),
                    Porciento = x.Porciento.ToString(),
                    Impuestos = x.Impuestos.Value.ToString("RD$ #,##0.00"),
                }).ToArray();
                bindingSource_Producto_Servicios.DataSource = result;
                AplicarEstilosDataGridView();
                //label_cantidad_registro.Text = $"Registro encontrados: {result.Count().ToString()}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el listado de Proveedores {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        private void Guardar()
        {
            int? count = 0;
            decimal _precio_costo = 0.00m;
            decimal _precio_base = 0.00m;
            decimal _precio_Venta_final = 0.00m;
            decimal _impuesto = 0.00m;
            decimal _porcientoReal = 0.00m;
            decimal _porciento = 0.00m;
            int _proveedor = 0;
            int _cantidad = 0;


            var Precio_base = textBox_precio_base.Text.ToString().Replace("RD$", "").Trim();
            //var Precio_Venta_final = textBox_Precio_Venta_final.Text.ToString().Replace("RD$", "").Trim();
            //var Impuesto = textBox_Impuesto.Text.ToString().Replace("RD$", "").Trim();
            var Proveedor = comboBox_Proveedor.SelectedValue.ToString();
           
            var Precio = textBox_Precio_costo.Text.ToString().Replace("RD$", "").Trim();
            var PrecioCosto = textBox_Precio_costo.Text.ToString();



            _precio_base = decimal.Parse(Precio_base);
            //_precio_Venta_final = decimal.Parse(Precio_Venta_final);
            //_impuesto = decimal.Parse(Impuesto);
            
            _proveedor = int.Parse(Proveedor);
            _precio_costo = decimal.Parse(PrecioCosto);



            if (_porciento == 0.00m)
            {
                _porcientoReal = (_precio_base - _precio_costo) / _precio_costo;
                _porcientoReal = _porcientoReal + 1m;
                _porcientoReal = Math.Round(_porcientoReal, 2); // Redondea a dos decimales
            }
            else
            {
                _porcientoReal = _porciento;
            }

            try
            {
                string code = string.Empty;

                var maximoCodigo = db.GetProductoServiciosInventarios();


                count = maximoCodigo.Any() ? count = maximoCodigo.Count() + 1 : 1;

                if (count > 0)
                {
                    code = Tools.GenerarCodigoProducto(count++);

                    var ProductoServicios = new ProductoServiciosInventarios()
                    {
                        ProductoServicioID = _ProductoServicioID == null ? 0 : _ProductoServicioID,
                        Nombre = textBox_nombre.Text,
                        Descripcion = textBox_Descripcion.Text,
                        Precio = _precio_costo,
                        Tipo = checkBox_servicio.Checked == true ? "Servicio" : "Producto",
                        Stock = 0,
                        EsServicio = checkBox_servicio.Checked,
                        ProveedoresId = _proveedor,
                        Codigo = _ProductoServicioID == 0 ? code : textBox_Codigo.Text,
                        PrecioVentaBase = _precio_base,
                        PrecioVentaFinal = _precio_Venta_final,
                        Porciento = _porcientoReal,
                        Impuestos = _impuesto,
                        UsuarioId = seccion.UsuarioID,
                        EsCompra = false
                    };
                    db.SetProductoServiciosInventarios(ProductoServicios);
                    RecargarTodo();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void AplicarEstilosDataGridView()
        {
            // Estilo general
            dataGridView_productos_servicios.BackgroundColor = Color.WhiteSmoke;
            dataGridView_productos_servicios.BorderStyle = BorderStyle.None;
            dataGridView_productos_servicios.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; // Color azul suave para filas alternas
            dataGridView_productos_servicios.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // Estilo de la cabecera
            dataGridView_productos_servicios.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView_productos_servicios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_productos_servicios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView_productos_servicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Centrar el texto en los encabezados
            dataGridView_productos_servicios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Sombra ligera en la cabecera de las columnas (más moderno)
            dataGridView_productos_servicios.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 0, 0, 5);
            dataGridView_productos_servicios.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView_productos_servicios.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Transparent;

            // Alineación de las celdas
            dataGridView_productos_servicios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_productos_servicios.DefaultCellStyle.Font = new Font("Segoe UI", 11); // Fuente más grande

            // Mayor altura de filas para mejorar la legibilidad
            dataGridView_productos_servicios.RowTemplate.Height = 35;

            // Ajustar el ancho de las columnas automáticamente según el contenido
            dataGridView_productos_servicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_productos_servicios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Formato de celdas
            dataGridView_productos_servicios.Columns["Precio"].DefaultCellStyle.Format = "C2"; // Formato moneda RD$
            dataGridView_productos_servicios.Columns["FechaActualizacion"].DefaultCellStyle.Format = "dd-MM-yyyy"; // Formato fecha

            // Estilo de las filas y celdas
            dataGridView_productos_servicios.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataGridView_productos_servicios.DefaultCellStyle.SelectionForeColor = Color.White;

            // Estilo de las celdas de solo lectura
            dataGridView_productos_servicios.ReadOnly = true;
            dataGridView_productos_servicios.AllowUserToAddRows = false;
            dataGridView_productos_servicios.AllowUserToDeleteRows = false;
            dataGridView_productos_servicios.AllowUserToResizeRows = false;

            // Ajustar las columnas
            dataGridView_productos_servicios.Columns["ProductoServicioID"].Width = 120;
            dataGridView_productos_servicios.Columns["NombreProducto"].Width = 220;
            dataGridView_productos_servicios.Columns["Descripcion"].Width = 270;
            dataGridView_productos_servicios.Columns["Stock"].Width = 100;

            // Configurar que no se pueda editar el Stock o Precio
            dataGridView_productos_servicios.Columns["Stock"].ReadOnly = true;
            dataGridView_productos_servicios.Columns["Precio"].ReadOnly = true;

            // Añadir eventos de formato condicional
            dataGridView_productos_servicios.CellFormatting += (sender, e) =>
            {



                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView_productos_servicios.Columns["Stock"].Index)
                {
                    var stock = int.Parse(e.Value.ToString());
                    if (stock == 1)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if ((stock > 1) && (stock < 10))
                    {
                        e.CellStyle.BackColor = Color.IndianRed;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if (stock >= 10)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView_productos_servicios.Columns["Precio"].Index)
                {
                    decimal precio = decimal.Parse(e.Value.ToString().Replace("RD$", "").Trim());
                    if (precio > 1000)
                    {
                        e.CellStyle.BackColor = Color.LightGoldenrodYellow;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            };
        }

        private void checkBox_servicio_CheckedChanged(object sender, EventArgs e)
        {


        }


       
      
       
        public void RecargarTodo()
        {
            textBox_precio_base.Text = "RD$ 0.00";
            //textBox_Precio_Venta_final.Text = "RD$ 0.00"; 
            this._ProductoServicioID = 0;
            this.EsPorcentaje = false;
            this.CodigoBarra = string.Empty;
            textBox_nombre.Text = string.Empty;
            textBox_Descripcion.Text = string.Empty;
            //textBox_Impuesto.Text = "0.00";
            txtbeneficios.Text = string.Empty;
            textBox_Codigo.Text = string.Empty;
            textBox_Precio_costo.Text = string.Empty;
            CargaInicial();
            CargarProveedor();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var data = db.GetProductoServiciosInventarios().Select(x => new ProductoServiciosInventariosViewModel()
                {

                    ProductoServicioID = x.ProductoServicioID.ToString(),
                    NombreProducto = x.Nombre,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio.Value.ToString("RD$ #,##0.00"),
                    Tipo = x.Tipo,
                    Stock = x.Stock.ToString(),
                    ProveedoresId = x.ProveedorID.ToString(),
                    CantidadEnInventario = x.CantidadEnInventario.ToString(),
                    FechaActualizacion = x.FechaActualizacion.Value.ToString("dd-MM-yyyy"),
                    ProveedorID = x.ProveedorID.ToString(),
                    NombreProveedor = x.NombreProveedor,
                    Codigo = x.Codigo,
                    PrecioVentaBase = x.PrecioVentaBase.Value.ToString("RD$ #,##0.00"),
                    PrecioVentaFinal = x.PrecioVentaFinal.Value.ToString("RD$ #,##0.00"),
                    Porciento = x.Porciento.ToString(),
                    Impuestos = x.Impuestos.Value.ToString("RD$ #,##0.00")

                }).ToArray();

                if (data != null)
                {

                    bindingSource_Producto_Servicios.Clear();
                    var filtro = data.Where(x =>
                                   x.Codigo.ToLower().Contains(txtBuscador.Text.ToLower()) ||
                                   x.Tipo.ToLower().Contains(txtBuscador.Text.ToLower())
                                   ).ToList();
                    if (filtro.Count > 0)
                    {

                        bindingSource_Producto_Servicios.DataSource = filtro;
                    }
                    else
                    {

                        CargaInicial();
                    }
                }
                AplicarEstilosDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el listado de Proveedores {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView_productos_servicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dt = dataGridView_productos_servicios;
            if (dataGridView_productos_servicios.CurrentRow != null)
            {
                _ProductoServicioID = int.Parse(dt.CurrentRow.Cells["ProductoServicioID"].Value.ToString());


                var resultTemp = db.GetProductoServiciosInventarios().Where(x => x.ProductoServicioID == _ProductoServicioID).FirstOrDefault();

                if (resultTemp != null)
                {

                    textBox_Codigo.Text = dt.CurrentRow.Cells["Codigo"].Value.ToString();
                    textBox_nombre.Text = dt.CurrentRow.Cells["NombreProducto"].Value.ToString();
                    textBox_Descripcion.Text = dt.CurrentRow.Cells["Descripcion"].Value.ToString();

                    checkBox_servicio.Checked = dt.CurrentRow.Cells["Tipo"].Value.ToString() == "Servicio" ? true : false;
                 

                    //textBox_Impuesto.Text = resultTemp.Impuestos.Value.ToString("RD$ #,##0.00");

                    textBox_precio_base.Text = resultTemp.PrecioVentaBase.Value.ToString("RD$ #,##0.00");
                    //textBox_Precio_Venta_final.Text = resultTemp.PrecioVentaFinal.Value.ToString("RD$ #,##0.00");
                    decimal? beneficio = resultTemp.PrecioVentaBase - resultTemp.Precio;

                    textBox_Precio_costo.Text = resultTemp.Precio.Value.ToString();
                    txtbeneficios.Text = $"{beneficio.Value.ToString("RD$ #,##0.00")}";
                    comboBox_Proveedor.Text = resultTemp.NombreProveedor;
                   

                }
            }
        }

        private void comboBox_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Precio_Venta_final_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_nombre.Text))
            {
                Helpers.ShowValidacion("Nombre");
                return;
            }


            if (string.IsNullOrWhiteSpace(textBox_Precio_costo.Text))
            {
                Helpers.ShowValidacion("Precio de costo");
                return;
            }
            if (comboBox_Proveedor.Text == "---Selecionar---")
            {
                Helpers.ShowValidacion("Proveedor");
                return;
            }


            Guardar();
        }

        private void textBox_Precio_costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, un punto decimal, y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal en el TextBox
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, un punto decimal, y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal en el TextBox
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void textBox_cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Bloquea el Ctrl + V
            }
        }

        private void textBox_Precio_costo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Bloquea el Ctrl + V
            }
        }

        private bool Validacion(string nombrecampo = "")
        {
            var result = false;






            return result;
        }

        private void textBox_precio_manual_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, un punto decimal, y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal en el TextBox
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox_precio_manual_TextChanged(object sender, EventArgs e)
        {
            double preciocosto = 0.00;
            double precioventa = 0.00;



            if (string.IsNullOrWhiteSpace(textBox_Precio_costo.Text))
            {
                textBox_Precio_costo.Focus();
                Helpers.ShowValidacion("Precio de costo");
                return;
            }


            if (string.IsNullOrWhiteSpace(textBox_precio_manual.Text))
                textBox_precio_manual.Text = "0.00";



            preciocosto = double.Parse(textBox_Precio_costo.Text);

            precioventa = double.Parse(textBox_precio_manual.Text.ToString());








            //preciocosto = double.Parse(textBox_Precio_costo.Text.ToString().Replace("RD$", "").Trim());
            //cantidad = int.Parse(textBox_cantidad.Text.ToString().Replace("RD$", "").Trim());
            //porcentaje = double.Parse(textBox_precio_manual.Text.ToString());

            //precioventabase = preciocosto * porcentaje;
            //impuesto = precioventabase * 18 / 100;
            //precioventa = precioventabase + impuesto;

            textBox_precio_base.Text = $"RD$ {preciocosto}";

            txtbeneficios.Text = $"RD$ {precioventa - preciocosto}"; ;

            //textBox_Impuesto.Text = impuesto.ToString("RD$ #,##0.00");
            //textBox_Precio_Venta_final.Text = precioventa.ToString("RD$ #,##0.00");



            //txtbeneficios.Text = (precioventabase - calculoPrecioBase).ToString("RD$ #,##0.00");
        }




        private void textBox_Precio_costo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_Precio_costo.Text))
                textBox_Precio_costo.Text = "0.00";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtbeneficios.Text = "0.00";
            textBox_Codigo.Text = string.Empty; ;
            textBox_nombre.Text = string.Empty; ;
            textBox_Descripcion.Text = string.Empty; ;
             
            textBox_precio_manual.Text = "0.00";
            textBox_Precio_costo.Text = "0.00";
            textBox_precio_base.Text = "0.00";
            txtbeneficios.Text = "0.00";
            CargaInicial();
            CargarProveedor(); 
            this._ProductoServicioID = 0;
            this.EsPorcentaje = false;
            this.CodigoBarra = string.Empty;
        }
    }
}

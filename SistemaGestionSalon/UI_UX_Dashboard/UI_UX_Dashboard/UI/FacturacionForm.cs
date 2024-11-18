using BLL.Admin;
using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using UI_UX_Dashboard_P1.Custom;
using UI_UX_Dashboard_P1.ViewModel;
using System.Text.RegularExpressions;
using ENTITY;
using BLL;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class FacturacionForm : Form
    {
        Seccion seccion = Seccion.Instance;
        private ProductoServiciosInventariosAdmin dbpro = new ProductoServiciosInventariosAdmin();
        private DropDownListAdmin drop = new DropDownListAdmin();
        private List<Facturacion.DetalleFactura> DetalleFacturaList = new List<Facturacion.DetalleFactura>();
        private ClienteAdmin clienteAdmin = new ClienteAdmin();
        private FacturaViewModel model = new FacturaViewModel();
        private FacturacionAdmin dbFactura = new FacturacionAdmin();


        private decimal? _impuesto { get; set; } = 0.00m;
        private decimal? precio_original { get; set; }
        private int? stock_original { get; set; }
        private decimal? precio_costo { get; set; }
        private int stockMinimo { get; set; }
        private bool? permitirActualizar { get; set; }
        string cliente_direccion { get; set; }



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
            try
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



                var minStok = drop.DropDownList(DropDownList.Parametros.ToString(), "Parametros_Minimo_Stock").FirstOrDefault().ACTION;


                var imp = drop.DropDownList(DropDownList.Impuestos.ToString()).FirstOrDefault().CODE;

                if (imp != null)
                {
                    this._impuesto = decimal.Parse(imp.ToString());
                }
                else
                {
                    this._impuesto = decimal.Parse(ConfigurationManager.AppSettings["Itbis"].ToString());
                }
                if (minStok != null)
                {
                    this.stockMinimo = int.Parse(minStok);
                }
                else
                {
                    this.stockMinimo = int.Parse(ConfigurationManager.AppSettings["Minimo"].ToString());
                }
            }
            catch (Exception ex)
            {
                Helpers.ShowError("Error en el metodo CargarAll: ", ex);

            }
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
                cliente_direccion = cliente.Direccion;

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
                txtPrecio.Text = producto.PrecioVentaBase.ToString();
                label_Servicio_Producto.Text = $"{producto.Tipo}";
                precio_original = producto.PrecioVentaBase;
                precio_costo = producto.Precio;
                stock_original = producto.Stock;


                if (producto.Tipo == "Servicio")
                {
                    txtCantidadAdd.Text = "1";
                    txtCantidadAdd.Enabled = false;
                }
                else
                {
                    txtCantidadAdd.Text = "0";
                    txtCantidadAdd.Enabled = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            decimal? impuestoAdd = 0.00m;
            decimal? _Total = 0.00m;
            decimal? _Monto = 0.00m;
            int? stock = 0;
            int? cantidadMinima = stockMinimo;
            int? cantidadAComprar = 0;




            if (string.IsNullOrWhiteSpace(txtIdProducto.Text) || string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                Helpers.ShowTypeError("Favor selecionar un producto o cliente", "error");
                return;
            } 

            if (string.IsNullOrWhiteSpace(txtCantidadAdd.Text) || txtCantidadAdd.Text == "0")
            {
                Helpers.ShowTypeError("Digite la cantidad", "error");
                return;
            } 
            cantidadAComprar = int.Parse(txtCantidadAdd.Text);
            stock = int.Parse(txtStock.Text);

            // Validar si es posible realizar la venta
            if ((cantidadAComprar > stock - cantidadMinima) && label_Servicio_Producto.Text == "Producto")
            {
                Helpers.ShowTypeError("No se puede realizar la venta. La cantidad a comprar excede el stock permitido.", "error");
            }
            else
            {
                // Actualizar el stock si la venta es válida
                stock -= cantidadAComprar;
                _Monto = (int.Parse(txtCantidadAdd.Text) * decimal.Parse(txtPrecio.Text));
                impuestoAdd = (_Monto * _impuesto) / 100;

                _Total = _Monto + impuestoAdd;

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
                dfactura.Impuesto = impuestoAdd;
                dfactura.Total = _Total;
                dfactura.Tipo = label_Servicio_Producto.Text;

                model.detalleFactura = dfactura;

                if (DetalleFacturaList.Where(x => x.IdProducto == dfactura.IdProducto).Any())
                {
                    Helpers.ShowWarning($"El artículo: {dfactura.nombreProducto} ya está registrado en la tabla de compras.\n" +
                                       "Si deseas actualizar su cantidad, por favor utiliza la opción editar.");
                    return;
                }
                AddFactura(model);

            }
        }


        private void AddFactura(FacturaViewModel model)
        {

            bindingSource_producto_servicios_a_facturar.DataSource = null;

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
                Total = model.detalleFactura.Total,
                Tipo = model.detalleFactura.Tipo

            });

            bindingSource_producto_servicios_a_facturar.DataSource = DetalleFacturaList;


            LblTotalApagar.Text = $"RD$ {DetalleFacturaList.Sum(x => x.Total):N2}";


            var updateStock = int.Parse(txtStock.Text) - int.Parse(txtCantidadAdd.Text);


            if (model.detalleFactura.Tipo != "Servicio")
            {
                txtStock.Text = updateStock.ToString();
            }
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
            //var editButtonColumn = new DataGridViewButtonColumn
            //{
            //    HeaderText = "Editar",
            //    Text = "✏️ Editar",
            //    UseColumnTextForButtonValue = true,
            //    Width = 80,
            //    FlatStyle = FlatStyle.Flat
            //};
            //editButtonColumn.DefaultCellStyle.BackColor = Color.White;
            //editButtonColumn.DefaultCellStyle.ForeColor = Color.Green;
            //editButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            //dataGridView_Producto_Servicio_Facturacion.Columns.Add(editButtonColumn);

            // Columna para el botón de Borrar
            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Borrar",
                Text = "🗑️ Borrar",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Standard
            };
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.Indigo;
            deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            deleteButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView_Producto_Servicio_Facturacion.Columns.Add(deleteButtonColumn);

            // Columnas de datos

            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "IdProducto",
                DataPropertyName = "IdProducto",
                Visible = false
            });


            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo",
                DataPropertyName = "Tipo",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

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
                Width = 100,
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
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dataGridView_Producto_Servicio_Facturacion.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Impuesto",
                DataPropertyName = "Impuesto",
                Width = 100,
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

        private void checkBox_cambiar_precio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_cambiar_precio.Checked == true)
            {
                txtPrecio.Enabled = true;
            }
            else
            {
                txtPrecio.Text = precio_original.ToString();
                txtPrecio.Enabled = false;
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0')
            {
                // Eliminar el primer carácter si es '0'
                textBox.Text = textBox.Text.Substring(1);

                // Mover el cursor al final del texto
                textBox.SelectionStart = textBox.Text.Length;
            }

            //txtPrecio.Text = new string(txtPrecio.Text.Where(char.IsDigit).ToArray());
            //txtPrecio.SelectionStart = txtPrecio.Text.Length; // Mantener el cursor al final
        }

        private void txtCantidadAdd_TextChanged(object sender, EventArgs e)
        {

            TextBox textBox = sender as TextBox;

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0')
            {
                // Eliminar el primer carácter si es '0'
                textBox.Text = textBox.Text.Substring(1);

                // Mover el cursor al final del texto
                textBox.SelectionStart = textBox.Text.Length;
            }

            txtCantidadAdd.Text = new string(txtCantidadAdd.Text.Where(char.IsDigit).ToArray());
            txtCantidadAdd.SelectionStart = txtCantidadAdd.Text.Length; // Mantener el cursor al final 
        }

        private void txtCantidadPagado_TextChanged(object sender, EventArgs e)
        {
            decimal? Total_A_Pagar = 0.00M;
            decimal? saldoTotal = 0.00m;


            // Validar el texto con una expresión regular que permita solo números
            string text = txtCantidadPagado.Text;

            // Reemplaza cualquier carácter que no sea un dígito
            txtCantidadPagado.Text = Regex.Replace(text, @"[^\d]", "");

            // Coloca el cursor al final del texto después de la corrección
            txtCantidadPagado.SelectionStart = txtCantidadPagado.Text.Length;



            if (DetalleFacturaList.Any())
            {

                TextBox textBox = sender as TextBox;

                if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0')
                {
                    // Eliminar el primer carácter si es '0'
                    textBox.Text = textBox.Text.Substring(1);

                    // Mover el cursor al final del texto
                    textBox.SelectionStart = textBox.Text.Length;
                }


                if (!string.IsNullOrWhiteSpace(txtCantidadPagado.Text))
                {

                    Total_A_Pagar = decimal.Parse(LblTotalApagar.Text.ToString().Replace("RD$", ""));
                    saldoTotal = Total_A_Pagar - decimal.Parse(txtCantidadPagado.Text.ToString());
                    //LblTotalApagar.Text = $"RD$ {DetalleFacturaList.Sum(x => x.Total):N2}";



                    if (decimal.Parse(txtCantidadPagado.Text.ToString()) > Total_A_Pagar)
                    {
                        label_cambio.Text = $"RD$ {saldoTotal:N2}";
                        label_cambio.ForeColor = Color.Red;
                    }
                    else
                    {
                        label_cambio.Text = $"RD$ {saldoTotal:N2}";
                    }


                    //10-9
                }
            }
            else
            {
                Helpers.ShowTypeError("No existe elemento agregado al listado de productos", "error");
                txtCantidadPagado.Text = "0";
            }
        }

        private void dataGridView_Producto_Servicio_Facturacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic haya sido en una celda válida y en una columna de botón
            if (e.RowIndex >= 0 && dataGridView_Producto_Servicio_Facturacion.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow fila = dataGridView_Producto_Servicio_Facturacion.Rows[e.RowIndex];      // Fila seleccionada

                switch (e.ColumnIndex)
                {
                    case 0:

                        var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {

                            DetalleFacturaList.RemoveAt(e.RowIndex);
                            bindingSource_producto_servicios_a_facturar.ResetBindings(false);
                            LblTotalApagar.Text = $"RD$ {DetalleFacturaList.Sum(x => x.Total):N2}";
                            txtStock.Text = stock_original.ToString();
                        }
                        break;

                    case 1:

                        //var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                        //if (result == DialogResult.Yes)
                        //{
                        //    //compraViewModels.RemoveAt(e.RowIndex);
                        //    //bindingSource_listado_producto_nuevos.ResetBindings(false);
                        //    //calcularMontoApagar();
                        //}
                        break;
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, el punto decimal y la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea cualquier otro carácter
            }
            else
            {
                // Permitir solo un punto decimal
                if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains("."))
                {
                    e.Handled = true; // Bloquea si ya hay un punto decimal
                }
            }
        }


        private void txtCantidadAdd_KeyDown(object sender, KeyEventArgs e)
        {
            //// Permitir teclas de números (0-9) y teclas especiales como retroceso
            //if (!char.IsDigit((char)e.KeyCode) && e.KeyCode != Keys.Back)
            //{
            //    // Prevenir la entrada de otras teclas
            //    e.SuppressKeyPress = true;
            //}

            // Permitir números (teclado principal y numérico), retroceso y teclas especiales
            if (!((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || // Teclado numérico superior
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || // Teclado numérico derecho
                  e.KeyCode == Keys.Back || // Retroceso
                  e.KeyCode == Keys.Delete || // Suprimir
                  e.KeyCode == Keys.Left || // Flecha izquierda
                  e.KeyCode == Keys.Right)) // Flecha derecha
            {
                // Prevenir la entrada de otras teclas
                e.SuppressKeyPress = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            FrmTarjetaMedioPago frmTarjeta = new FrmTarjetaMedioPago();
            frmTarjeta.ShowDialog();
        }

        private void txtCantidadPagado_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || // Teclado numérico superior
                 (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || // Teclado numérico derecho
                 e.KeyCode == Keys.Back || // Retroceso
                 e.KeyCode == Keys.Delete || // Suprimir
                 e.KeyCode == Keys.Left || // Flecha izquierda
                 e.KeyCode == Keys.Right)) // Flecha derecha
            {
                // Prevenir la entrada de otras teclas
                e.SuppressKeyPress = true;
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {

            if (DetalleFacturaList.Any())
            {
                Facturar();
            }
            else
            {
                Helpers.ShowError("No existe producto agregado");
            }
        }

        private void Facturar()
        {
            Facturacion.Factura facturaHeader = new Facturacion.Factura();
            try
            {

                facturaHeader.IdFactura = 0;
                facturaHeader.NumeroFactura = string.Empty;
                facturaHeader.TipoPago = "Efectivo";
                facturaHeader.IdCliente = int.Parse(txtIdCliente.Text);
                facturaHeader.Descuento = 0;
                facturaHeader.Monto = DetalleFacturaList.Sum(x => x.Monto);
                facturaHeader.Impuesto = DetalleFacturaList.Sum(x => x.Impuesto);
                facturaHeader.Total = decimal.Parse(LblTotalApagar.Text.Replace("RD$", "").ToString());
                facturaHeader.EsCredito = false;
                facturaHeader.Usuario = seccion.UsuarioID;

                var respuesta = dbFactura.GuardarFactura(facturaHeader);


                foreach (var i in DetalleFacturaList)
                {
                    dbFactura.GuardarCompraDetallesFactura(new Facturacion.DetalleFactura()
                    {
                        IdDetalle = 0,
                        IdFactura = 0,
                        nombreProducto = i.nombreProducto,
                        IdProducto = i.IdProducto,
                        Cantidad = i.Cantidad,
                        PrecioUnitario = i.PrecioUnitario,
                        Descuento = 0,
                        Monto = i.Monto,
                        Impuesto = i.Impuesto,
                        Total = i.Total,
                        Usuario = seccion.UsuarioID,
                        Tipo = i.Tipo
                    });
                    dbFactura.DescontarInventario(i.IdProducto, i.Cantidad, seccion.UsuarioID);
                }
                GenerateInvoiceHtml(respuesta.ACTION, facturaHeader.Monto, facturaHeader.Impuesto, facturaHeader.Total, DetalleFacturaList);
            }
            catch (Exception ex)
            {
                Helpers.ShowError("A ocurrido un error al guardar la factura. ", ex);
            }
        }
        private void GenerateInvoiceHtml(string Nofactura, decimal? subtotal, decimal? impuesto, decimal? total, List<Facturacion.DetalleFactura> items)
        {
            try
            {
                string htmlContent = Properties.Resources.FacturaConsumidoFinal.ToString();
                string htmlRow = "";
                string path = AppDomain.CurrentDomain.BaseDirectory;



                SaveFileDialog savefile = new SaveFileDialog();

                savefile.FileName = string.Format($"{Nofactura}.pdf");
                htmlContent = htmlContent.Replace("{{empresa}}", "Testing");
                htmlContent = htmlContent.Replace("{{rncempresa}}", "Testing");
                htmlContent = htmlContent.Replace("{{direccion}}", "Testing");
                htmlContent = htmlContent.Replace("{{telefono}}", "Testing");

                htmlContent = htmlContent.Replace("{{cliente_nombre}}", txtnombre.Text);
                htmlContent = htmlContent.Replace("{{cliente_direccion}}", cliente_direccion);
                htmlContent = htmlContent.Replace("{{cliente_telefono}}", txtcelular.Text);
                htmlContent = htmlContent.Replace("{{cliente_email}}", txtcorreo.Text);
                // Obtener la fecha actual en formato dd-MM-yyyy
                string fechaFactura = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");

                // Reemplazar el marcador {{fecha_factura}} en htmlContent con la fecha actual
                htmlContent = htmlContent.Replace("{{fecha_factura}}", fechaFactura);


                foreach (var item in items)
                {
                    htmlRow = htmlRow + $@"
                             <tr> 
                                 <td>{item.nombreProducto}</td>
                                 <td>{item.Cantidad}</td>
                                 <td>RD$ {item.PrecioUnitario.Value.ToString("C")}</td>
                                 <td>RD$ {item.Impuesto.Value.ToString("C")}</td> 
                                 <td>RD$ {item.Total.Value.ToString("C")}</td>
                             </tr>";

                }
                htmlContent = htmlContent.Replace("{{<tr></tr>}}", htmlRow);
                // Reemplazar los valores en el HTML con datos dinámicos
                htmlContent = htmlContent.Replace("{{condicion_pago}}", items.FirstOrDefault().Tipo);
                htmlContent = htmlContent.Replace("{{total_bruto}}", subtotal.Value.ToString("C"));
                htmlContent = htmlContent.Replace("{{itbis}}", impuesto.Value.ToString("C"));
                htmlContent = htmlContent.Replace("{{total_neto}}", total.Value.ToString("C"));
                htmlContent = htmlContent.Replace("{{usuario}}", seccion.Nombre);
                // Puedes añadir más reemplazos aquí según el contenido de tu HTML, como el nombre del proveedor, etc. 

                //documentoLogAdmin.InsertarDocumentoLog(new DocumentoLog()
                //{
                //    TipoDocumento = "Comprobante de compras",
                //    HtmlDocumento = htmlContent,
                //    Usuario = seccion.UsuarioID,
                //    NumeroComprobante = comprobante
                //});


                var popup = MessageBox.Show("¿Desea Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (popup == DialogResult.Yes)
                {
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        Tools.SavePDF(savefile, htmlContent);
                    }
                }
                //CancelarEntrada("Facturacion");
            }
            catch (Exception ex)
            {
                Helpers.ShowError("Error en el metodo de: GenerateInvoiceHtml ", ex);
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            LimpiarAll();
        }

        private void LimpiarAll()
        { 
            DetalleFacturaList = null;
            _impuesto = 0;
            precio_original = 0.00m;
            stock_original = 0;
            precio_costo = 0.00m;
            stockMinimo = 0;
            permitirActualizar = false;
            cliente_direccion = string.Empty;
            CargarAll(); 
            txtProducto.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtProductoServicio.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            label_Servicio_Producto.Text = "Tipo de Articulo";
            precio_original = 0.00m;
            txtCantidadAdd.Text = "0";
            txtCantidadAdd.Enabled = true; 
            txtnombre.Text = string.Empty;
            txtcedula.Text = string.Empty;
            txtcelular.Text = string.Empty;
            txttelefono.Text = string.Empty;
            txtcorreo.Text = string.Empty;
            txtIdCliente.Text = string.Empty;
            cliente_direccion = string.Empty;
            bindingSource_producto_servicios_a_facturar.DataSource = null;

            if (checkBox_cambiar_precio.Checked == true)
            {
                txtCantidadAdd.Text = "1";
                txtCantidadAdd.Enabled = false;
            }
            else
            {
                txtCantidadAdd.Text = "0";
                txtCantidadAdd.Enabled = true;
            }
            LblTotalApagar.Text = "RD$ 00.00";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            label_Servicio_Producto.Text = "Tipo de Articulo";
            txtProducto.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtProductoServicio.Text = string.Empty;
            txtIdProducto.Text = string.Empty;
            txtPrecio.Text = string.Empty; 
            precio_original = 0.00m;
            precio_costo = 0.00m;
            stock_original = 0;
            txtnombre.Text = string.Empty;
            txtcedula.Text = string.Empty;
            txtcelular.Text = string.Empty;
            txttelefono.Text = string.Empty;
            txtcorreo.Text = string.Empty;
            txtIdCliente.Text = string.Empty;
            cliente_direccion = string.Empty;
            if (checkBox_cambiar_precio.Checked==true)
            {
                txtCantidadAdd.Text = "1";
                txtCantidadAdd.Enabled = false;
            }
            else
            {
                txtCantidadAdd.Text = "0";
                txtCantidadAdd.Enabled = true;
            }
            CargarAll();
        }
    }
}

﻿using BLL.Admin;
using ENTITY.Entitis;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI_UX_Dashboard_P1.Custom;
using UI_UX_Dashboard_P1.ViewModel;
using Font = System.Drawing.Font;
using iTextSharp.tool.xml;
using BLL;



namespace UI_UX_Dashboard_P1.UI
{
    public partial class ComprasForm : Form
    {
        Seccion seccion = Seccion.Instance;
        private ProveedoresAdmin dbp = new ProveedoresAdmin();
        private ProductoServiciosInventariosAdmin dbpro = new ProductoServiciosInventariosAdmin();
        private DropDownListAdmin drop = new DropDownListAdmin();
        private List<CompraViewModel> compraViewModels = new List<CompraViewModel>();
        private ComprasAdmin comprasAdmin = new ComprasAdmin();
        private ProductoServiciosInventariosAdmin inventariosAdmin = new ProductoServiciosInventariosAdmin();
        private DocumentoLogAdmin documentoLogAdmin = new DocumentoLogAdmin();

        private int? _Proveedor_ID { get; set; } = 0;
        private int? _Producto_ID { get; set; } = 0;
        private decimal? _LimiteCredito { get; set; } = 0.00m;
        private int? _DiasCancelacion { get; set; } = 0;

        private double _impuesto { get; set; } = 0.00;

        public ComprasForm()
        {
            InitializeComponent();

        }

        private void ComprasForm_Load(object sender, EventArgs e)
        {
            CargarAllList();
            try
            {
                _impuesto = double.Parse(drop.DropDownList(DropDownList.Impuestos.ToString()).FirstOrDefault().CODE);
                CargarTipoPagos();
            }
            catch (Exception ex)
            {
                Helpers.ShowError("No se pudo generar el impuesto ", ex);
            }

        }

        private void CargarTipoPagos()
        {
            var data = drop.DropDownList(DropDownList.TiposPagos.ToString());
            comboBox_forma_pago.DataSource = data;
            comboBox_forma_pago.DisplayMember = "ACTION";
            comboBox_forma_pago.ValueMember = "CODE";
        }



        private void CargarAllList()
        {
            bindingSource_proveedor_compras.DataSource = dbp.GetProveedor().Select(x => new ProveedoresViewModel()
            {
                Proveedor_ID = x.ProveedorID,
                Nombre_Proveedor = x.NombreProveedor,
                LimiteCredito = x.LimiteCredito,
                DiasCancelacion = x.DiasCancelacion,
            }).ToArray();

            bindingSource_producto_compras.DataSource = dbpro.GetProductoServiciosInventarios().Where(x => x.Tipo == "Producto").Select(x => new BaseViewModel()
            {
                ACTION = x.Nombre,
                CODE = x.ProductoServicioID.ToString(),
                MSJ = x.Codigo
            }).ToArray();

        }

        private void dataGridView_proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dt = dataGridView_proveedores;
            if (dataGridView_proveedores.CurrentRow != null)
            {
                label_Proveedor.Text = dt.CurrentRow.Cells["Nombre_Proveedor"].Value.ToString();
                this._Proveedor_ID = int.Parse(dt.CurrentRow.Cells["Proveedor_ID"].Value.ToString());
                this._LimiteCredito = decimal.Parse(dt.CurrentRow.Cells["LimiteCredito"].Value.ToString());
                this._DiasCancelacion = int.Parse(dt.CurrentRow.Cells["DiasCancelacion"].Value.ToString());
                radioButton_contado.Enabled = true;
                radioButton_credito.Enabled = true;
            }
        }

        private void dataGridView_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dt = dataGridView_Productos;
            if (dataGridView_Productos.CurrentRow != null)
            {
                this._Producto_ID = int.Parse(dt.CurrentRow.Cells["CODE_Producto"].Value.ToString());
                txtCodigoBarra.Text = dt.CurrentRow.Cells["MSJ_PRODUCTO"].Value.ToString();
                txtnombre.Text = dt.CurrentRow.Cells["ACTION_PRODUCTO"].Value.ToString();
            }
        }

        private void Limpiar()
        {
            this._Proveedor_ID = 0;
            this._LimiteCredito = 0.00m;
            this._DiasCancelacion = 0;
        }

        private void radioButton_credito_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_credito.Checked)
            {
                if (this._DiasCancelacion == 0)
                {
                    Helpers.ShowTypeError("Este proveedor no permite crédito en sus facturas.", "Error de Crédito en Facturas");
                    radioButton_credito.Checked = false;
                    radioButton_contado.Checked = true;
                    return;
                }
                if (this._LimiteCredito <= 0.00m)
                {
                    Helpers.ShowTypeError("El límite de crédito debe ser un valor superior a 0.", "Error de Límite de Crédito");
                    radioButton_credito.Checked = false;
                    radioButton_contado.Checked = true;
                    return;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            double importe = 0.00;
            double impuestos = 0.00;
            double neto = 0.00;
            //if (!radioButton_credito.Checked && !radioButton_contado.Checked)
            //{
            //    MessageBox.Show($"Selecione el tipo de pago de la factura (Crédito o Al Contado) ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //CargarPorcentaje();
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioCosto.Text))
            //{
            //    Helpers.ShowValidacion("Cantidad y Precios");
            //    return;
            //}
            //if (comboBox_forma_pago.SelectedIndex == 0)
            //{
            //    Helpers.ShowValidacion("Forma de pago");
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(txtnombre.Text))
            //{
            //    Helpers.ShowWarning("Seleccione un Producto para continuar...");
            //    return;
            //}

            //if (label_Proveedor.Text == "N/A")
            //{
            //    Helpers.ShowWarning("Seleccione un proveedor para continuar...");
            //    return;
            //}

            //if (comboBox_forma_pago.SelectedIndex == 0)
            //{
            //    Helpers.ShowValidacion("Forma de pago");
            //    return;
            //}

            if (ValidarFormulario())
            {
                importe = double.Parse(txt_importe.Text.Replace("RD$", ""));
                impuestos = double.Parse(txt_impuesto.Text.Replace("RD$", ""));
                neto = double.Parse(txt_neto.Text.Replace("RD$", ""));
                AddCompraViewModels(new CompraViewModel()
                {
                    IdProducto = this._Producto_ID,
                    IdProveedor = this._Proveedor_ID,
                    PrecioCosto = double.Parse(txtPrecioCosto.Text),
                    Nombre = txtnombre.Text,
                    TipoPago = radioButton_contado.Checked == true ? "AL CONTADO" : "CRÉDITO",
                    MedioPago = comboBox_forma_pago.Text,
                    Cantidad = int.Parse(txtCantidad.Text),
                    Importe = importe,
                    Impuesto = impuestos,
                    SubTotal = neto,
                    CodigoBarra = txtCodigoBarra.Text,
                });


                txt_importe.Text = "RD$ 0.00";
                txt_impuesto.Text = "RD$ 0.00";
                txt_neto.Text = "RD$ 0.00";
                txtPrecioCosto.Text = "0.00";
                txtCantidad.Text = "0";
                this._Producto_ID = 0;
                txtCodigoBarra.Text = string.Empty;
                txtnombre.Text = string.Empty;
                txtCodigoBarra.Text = string.Empty;
            }
        }


        private void AddCompraViewModels(CompraViewModel model)
        {
            try
            {
                bindingSource_listado_producto_nuevos.DataSource = null; // Establecer en null para limpiar


                // Verifica si existe un objeto con el mismo CodigoBarra
                if (compraViewModels.Any(x => x.CodigoBarra == model.CodigoBarra))
                {
                    // Encuentra el índice del objeto en la lista
                    int index = compraViewModels.FindIndex(x => x.IdProducto == model.IdProducto);

                    // Si el objeto fue encontrado, elimina el elemento en el índice encontrado
                    if (index != -1)
                    {
                        compraViewModels.RemoveAt(index);
                        compraViewModels.Insert(index, model);
                    }
                }
                else
                {
                    // Agregar el modelo a la lista de compra
                    compraViewModels.Add(model);
                }

                // Forzar la actualización del origen de datos            
                bindingSource_listado_producto_nuevos.DataSource = compraViewModels; // Reasignar la lista actualizada
                                                                                     // Calcular el total a pagar asegurando que no sea nulo y formatearlo con dos decimales
                                                                                     //double total_a_pagar = compraViewModels.Sum(x => x.SubTotal) ?? 0.0;

                // Formatear el texto con dos decimales
                //txtTotalPagar.Text = $"RD$ {total_a_pagar:F2}";

                calcularMontoApagar();
                ConfigureDataGridView();

            }
            catch (Exception ex)
            {

                Helpers.ShowError("Error en el metodo AddCompraViewModels", ex);
            }
        }

        private void calcularMontoApagar()
        {
            double total_a_pagar = compraViewModels.Sum(x => x.SubTotal) ?? 0.0;
            txtTotalPagar.Text = $"RD$ {total_a_pagar:F2}";
        }
        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            double importe = 0.00;
            double impuestos = 0.00;
            double neto = 0.00;

            try
            {
                TextBox textBox = sender as TextBox;

                if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0')
                {
                    // Eliminar el primer carácter si es '0'
                    textBox.Text = textBox.Text.Substring(1);

                    // Mover el cursor al final del texto
                    textBox.SelectionStart = textBox.Text.Length;
                }

                txtCantidad.Text = new string(txtCantidad.Text.Where(char.IsDigit).ToArray());
                txtCantidad.SelectionStart = txtCantidad.Text.Length; // Mantener el cursor al final 



                importe = double.Parse(txtPrecioCosto.Text.ToString()) * double.Parse(txtCantidad.Text.ToString());
                impuestos = (importe * _impuesto) / 100;
                neto = importe + impuestos;

                txt_importe.Text = string.Format($"RD$ {importe:N2}");
                txt_impuesto.Text = string.Format($"RD$ {impuestos:N2}");
                txt_neto.Text = string.Format($"RD$ {neto:N2}");
            }
            catch (Exception ex)
            {
                Helpers.ShowError("Error en el txtCantidad_TextChanged ", ex);
            }

        }

        private void ConfigureDataGridView()
        {
            // Configuración general del DataGridView
            dataGridView_CompraViewModels.AutoGenerateColumns = false;
            dataGridView_CompraViewModels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_CompraViewModels.AllowUserToAddRows = false;
            dataGridView_CompraViewModels.ReadOnly = true;
            dataGridView_CompraViewModels.EnableHeadersVisualStyles = false;

            // Estilo de los encabezados
            dataGridView_CompraViewModels.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dataGridView_CompraViewModels.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_CompraViewModels.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView_CompraViewModels.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color alterno para las filas
            dataGridView_CompraViewModels.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView_CompraViewModels.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView_CompraViewModels.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dataGridView_CompraViewModels.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView_CompraViewModels.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Bordes invisibles para un diseño más limpio
            dataGridView_CompraViewModels.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView_CompraViewModels.GridColor = Color.FromArgb(224, 224, 224);

            // Limpiar columnas anteriores
            dataGridView_CompraViewModels.Columns.Clear();

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
            dataGridView_CompraViewModels.Columns.Add(editButtonColumn);

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
            dataGridView_CompraViewModels.Columns.Add(deleteButtonColumn);

            // Columnas de datos
            dataGridView_CompraViewModels.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Código Barra",
                DataPropertyName = "CodigoBarra",
                Width = 200,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dataGridView_CompraViewModels.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Nombre",
                DataPropertyName = "Nombre",
                Width = 200,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            dataGridView_CompraViewModels.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Precio Costo",
                DataPropertyName = "PrecioCosto",
                Width = 100,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dataGridView_CompraViewModels.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                Width = 80,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dataGridView_CompraViewModels.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Importe",
                DataPropertyName = "Importe",
                Width = 120,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dataGridView_CompraViewModels.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Impuesto",
                DataPropertyName = "Impuesto",
                Width = 100,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dataGridView_CompraViewModels.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SubTotal",
                DataPropertyName = "SubTotal",
                Width = 120,
                DefaultCellStyle = { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void dataGridView_CompraViewModels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic haya sido en una celda válida y en una columna de botón
            if (e.RowIndex >= 0 && dataGridView_CompraViewModels.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow fila = dataGridView_CompraViewModels.Rows[e.RowIndex];      // Fila seleccionada

                switch (e.ColumnIndex)
                {
                    case 0:


                        txtCodigoBarra.Text = fila.Cells[2].Value.ToString();
                        var p = dbpro.GetProductoServiciosInventarios().Where(x => x.Codigo == fila.Cells[2].Value.ToString()).FirstOrDefault();

                        if (p != null)
                        {
                            this._Producto_ID = p.ProductoServicioID;
                            txtnombre.Text = p.Nombre;
                            txtPrecioCosto.Text = fila.Cells[4].Value.ToString();
                            txtCantidad.Text = fila.Cells[5].Value.ToString();
                        }

                        break;

                    case 1:

                        var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            compraViewModels.RemoveAt(e.RowIndex);
                            bindingSource_listado_producto_nuevos.ResetBindings(false);
                            calcularMontoApagar();
                        }
                        break;
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BtnEntrada_Click(object sender, EventArgs e)
        {
            decimal? _SubtotalCompraHeader = 0.00m;
            decimal? _ImpuestoCompraHeader = 0.00m;
            decimal? _TotalCompraHeader = 0.00m;
            double? _porciento = 0.00;
           
  
            if (comboBox_forma_pago.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione una Forma de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!compraViewModels.Any())
            {
                MessageBox.Show("No existe producto en el listado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
           
            _SubtotalCompraHeader = Convert.ToDecimal(compraViewModels.Sum(x => x.Importe).Value);
            _ImpuestoCompraHeader = Convert.ToDecimal(compraViewModels.Sum(x => x.Impuesto).Value);
            _TotalCompraHeader = Convert.ToDecimal(compraViewModels.Sum(x => x.SubTotal).Value);

            var compraheader = new Compras.FacturacionCompra()
            {
                IdCompra = 0,
                IdProveedor = _Proveedor_ID,
                TipoPago = radioButton_contado.Checked == true ? "AL CONTADO" : "CRÉDITO",
                MetodoPago = comboBox_forma_pago.Text,
                SubtotalCompra = _SubtotalCompraHeader,
                Descuento = 0,
                Impuesto = _ImpuestoCompraHeader,
                TotalNeto = _TotalCompraHeader,
                Usuario = seccion.UsuarioID,
            };
            var result = comprasAdmin.GuardarCompra(compraheader);

            foreach (var i in compraViewModels)
            {
                comprasAdmin.GuardarCompraDetallesCompra(new Compras.DetallesFacturacionCompra()
                {
                    IdCompra = int.Parse(result.CODE),
                    IdProducto = i.IdProducto,
                    PrecioUnitario = decimal.Parse(i.PrecioCosto.ToString()),
                    Cantidad = i.Cantidad,
                    Impuesto = decimal.Parse(i.Impuesto.ToString()),
                    Subtotal = decimal.Parse(i.Importe.ToString()),
                    Total = decimal.Parse(i.SubTotal.ToString())
                });


                //_preciobase = i.PrecioCosto + i.Impuesto;
                var tasaActualPorciento = dbpro.GetProductoServiciosInventarios().Where(x => x.ProductoServicioID == i.IdProducto).FirstOrDefault();


                if (tasaActualPorciento != null)
                {
                    _porciento = tasaActualPorciento != null ? Convert.ToDouble(tasaActualPorciento.Porciento) : 0.00;
                }
                else
                {
                    _porciento = 0.00;
                }


                var ProductoServicios = new ProductoServiciosInventarios()
                {
                    ProductoServicioID = i.IdProducto,
                    Nombre = i.Nombre,
                    Precio = decimal.Parse(i.PrecioCosto.ToString()),
                    Descripcion = "",
                    Tipo = "Producto",
                    Stock = i.Cantidad,
                    EsServicio = false,
                    ProveedoresId = i.IdProveedor,
                    Codigo = i.CodigoBarra,
                    PrecioVentaBase = 0.00m,
                    PrecioVentaFinal = 0.00m,
                    Porciento = decimal.Parse(_porciento.ToString()),
                    Impuestos = decimal.Parse(i.Impuesto.ToString()),
                    UsuarioId = seccion.UsuarioID,
                    EsCompra = true
                };
                inventariosAdmin.SetProductoServiciosInventarios(ProductoServicios);
            }
            GenerateInvoiceHtml(result.ACTION, _SubtotalCompraHeader, _ImpuestoCompraHeader, _TotalCompraHeader, compraViewModels); 
        }

        public bool ValidarFormulario()
        {
            bool result = true;
            StringBuilder mensajeError = new StringBuilder();

            if (!radioButton_credito.Checked && !radioButton_contado.Checked)
            {
                mensajeError.AppendLine("\nSeleccione el tipo de pago de la factura (Crédito o Al Contado).");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioCosto.Text))
            {
                mensajeError.AppendLine("\nComplete los campos de Cantidad y Precio.");
                result = false;
            }

            if (txtPrecioCosto.Text == "0.00")
            {
                mensajeError.AppendLine("\nEl costo debe ser superior a 0.00.");
                result = false;
            }

            if (txtCantidad.Text == "0")
            {
                mensajeError.AppendLine("\nLa cantidad debe ser superior a 0.");
                result = false;
            }

            if (comboBox_forma_pago.SelectedIndex == 0)
            {
                mensajeError.AppendLine("\nSeleccione una Forma de pago.");
                result = false;
            }

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                mensajeError.AppendLine("\nSeleccione un Producto para continuar.");
                result = false;
            }

            if (label_Proveedor.Text == "N/A")
            {
                mensajeError.AppendLine("\nSeleccione un proveedor para continuar.");
                result = false;
            }

            // Si hubo algún error, mostrar el mensaje acumulado
            if (mensajeError.Length > 0)
            {
                MessageBox.Show(mensajeError.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }


        private void txtPrecioCosto_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && textBox.Text.Length > 0 && textBox.Text[0] == '0')
            {
                // Eliminar el primer carácter si es '0'
                textBox.Text = textBox.Text.Substring(1);

                // Mover el cursor al final del texto
                textBox.SelectionStart = textBox.Text.Length;
            }

            txtPrecioCosto.Text = new string(txtPrecioCosto.Text.Where(char.IsDigit).ToArray());
            txtPrecioCosto.SelectionStart = txtPrecioCosto.Text.Length; // Mantener el cursor al final 
        }

        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var p = dbp.GetProveedor().ToList();

                if (p.Count > 0)
                {
                    var dataResult = dbp.GetProveedor().Where(x => x.NombreProveedor.ToLower().Contains(txtBuscarProveedor.Text.ToLower())
                    || x.CelularProveedor == txtBuscarProveedor.Text).Select(x => new ProveedoresViewModel()
                    {
                        Proveedor_ID = x.ProveedorID,
                        Nombre_Proveedor = x.NombreProveedor,
                        LimiteCredito = x.LimiteCredito,
                        DiasCancelacion = x.DiasCancelacion,
                    }).ToArray();
                    if (dataResult != null)
                    {

                        bindingSource_proveedor_compras.DataSource = dataResult;
                    }
                    else
                    {
                        CargarAllList();
                    }

                }
                else
                {
                    MessageBox.Show($"No existe data Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtBuscarProducto_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                var p = dbpro.GetProductoServiciosInventarios().ToList();

                if (p.Count > 0)
                {
                    var dataResult = dbpro.GetProductoServiciosInventarios().Where(x => x.Tipo == "Producto" &
                    x.Codigo.Contains(txtBuscarProducto.Text) || x.Nombre.ToLower().Contains(txtBuscarProducto.Text.ToLower())

                    ).Select(x => new BaseViewModel()
                    {
                        ACTION = x.Nombre,
                        CODE = x.ProductoServicioID.ToString(),
                        MSJ = x.Codigo
                    }).ToArray();

                    //bindingSource_producto_compras.DataSource

                    if (dataResult != null)
                    {

                        bindingSource_producto_compras.DataSource = dataResult;
                    }
                    else
                    {
                        CargarAllList();
                    }

                }
                else
                {
                    MessageBox.Show($"No existe data Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            txt_importe.Text = "RD$ 0.00";
            txt_impuesto.Text = "RD$ 0.00";
            txt_neto.Text = "RD$ 0.00";
            txtPrecioCosto.Text = "0";
            txtCantidad.Text = "0";
            this._Producto_ID = 0;
            txtCodigoBarra.Text = string.Empty;
            txtnombre.Text = string.Empty;
            txtCodigoBarra.Text = string.Empty; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarEntrada("Cancelar");
        }

        private void CancelarEntrada(string accion = "")
        {


            if (accion == "Cancelar")
            {
                var result = MessageBox.Show("¿Estás seguro de que deseas cancelar esta operación?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    compraViewModels.Clear();
                    bindingSource_listado_producto_nuevos.Clear();
                    label_Proveedor.Text = "N/A";
                    txtTotalPagar.Text = "RD$ 0.00";
                    bindingSource_listado_producto_nuevos.DataSource = null;
                    this._DiasCancelacion = 0;
                    this._Proveedor_ID = 0;
                    this._Producto_ID = 0;
                    CargarTipoPagos();
                    CargarAllList();
                }
            }
            else if (accion == "Facturacion")
            {
                compraViewModels.Clear();
                bindingSource_listado_producto_nuevos.Clear();
                label_Proveedor.Text = "N/A";
                txtTotalPagar.Text = "RD$ 0.00";
                bindingSource_listado_producto_nuevos.DataSource = null;
                this._DiasCancelacion = 0;
                this._Proveedor_ID = 0;
                this._Producto_ID = 0;
                CargarTipoPagos();
                CargarAllList();
            }
        }

        private void GenerateInvoiceHtml(string comprobante, decimal? subtotal, decimal? impuesto, decimal? total, List<CompraViewModel> items)
        { 
            try
            {
                string htmlContent = Properties.Resources.ComprobanteCompra.ToString();


                string htmlRow = "";
                string path = AppDomain.CurrentDomain.BaseDirectory;



                SaveFileDialog savefile = new SaveFileDialog();

                savefile.FileName = string.Format($"{comprobante}.pdf");
                htmlContent = htmlContent.Replace("{{empresa}}", "Testing");
                htmlContent = htmlContent.Replace("{{rncempresa}}", "Testing");
                htmlContent = htmlContent.Replace("{{direccion}}", "Testing");
                htmlContent = htmlContent.Replace("{{telefono}}", "Testing");
                // Obtener la fecha actual en formato dd-MM-yyyy
                string fechaFactura = DateTime.Now.ToString("dd-MM-yyyy");

                // Reemplazar el marcador {{fecha_factura}} en htmlContent con la fecha actual
                htmlContent = htmlContent.Replace("{{fecha_factura}}", fechaFactura);


                foreach (var item in items)
                {
                    htmlRow = htmlRow + $@"
                             <tr>
                                 <td>{item.CodigoBarra}</td>
                                 <td>{item.Nombre}</td>
                                 <td>{item.Cantidad}</td>
                                 <td>RD$ {item.PrecioCosto.Value.ToString("C")}</td>
                                 <td>RD$ {item.Impuesto.Value.ToString("C")}</td> 
                                 <td>RD$ {item.SubTotal.Value.ToString("C")}</td>
                             </tr>";

                }
                htmlContent = htmlContent.Replace("{{<tr></tr>}}", htmlRow);
                // Reemplazar los valores en el HTML con datos dinámicos
                htmlContent = htmlContent.Replace("{{condicion_pago}}", items.FirstOrDefault().MedioPago);
                htmlContent = htmlContent.Replace("{{total_bruto}}", subtotal.Value.ToString("C"));
                htmlContent = htmlContent.Replace("{{itbis}}", impuesto.Value.ToString("C"));
                htmlContent = htmlContent.Replace("{{total_neto}}", total.Value.ToString("C"));
                // Puedes añadir más reemplazos aquí según el contenido de tu HTML, como el nombre del proveedor, etc. 

                documentoLogAdmin.InsertarDocumentoLog(new DocumentoLog()
                {
                    TipoDocumento = "Comprobante de compras",
                    HtmlDocumento = htmlContent,
                    Usuario = seccion.UsuarioID,
                    NumeroComprobante= comprobante
                });


                var popup = MessageBox.Show("¿Desea Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (popup == DialogResult.Yes)
                {
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        Tools.SavePDF(savefile, htmlContent);
                    }
                }
                CancelarEntrada("Facturacion");
            }
            catch (Exception ex)
            {
                Helpers.ShowError("Error en el metodo de: GenerateInvoiceHtml ", ex);
            }  
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
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

        private void txtPrecioCosto_KeyDown(object sender, KeyEventArgs e)
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
    }
}




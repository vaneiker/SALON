﻿using BLL.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
    public partial class ComprasForm : Form
    {

        private ProveedoresAdmin dbp = new ProveedoresAdmin();
        private ProductoServiciosInventariosAdmin dbpro = new ProductoServiciosInventariosAdmin();
        private DropDownListAdmin drop = new DropDownListAdmin();
        private List<CompraViewModel> compraViewModels = new List<CompraViewModel>();
        private int _Proveedor_ID { get; set; } = 0;
        private int _Producto_ID { get; set; } = 0;
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
            if (!radioButton_credito.Checked && !radioButton_contado.Checked)
            {
                MessageBox.Show($"Selecione el tipo de pago de la factura (Crédito o Al Contado) ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //CargarPorcentaje();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioCosto.Text))
            {
                Helpers.ShowValidacion("Cantidad y Precios");
                return;
            }
            if (comboBox_forma_pago.SelectedIndex == 0)
            {
                Helpers.ShowValidacion("Forma de pago");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                Helpers.ShowWarning("Seleccione un Producto para continuar...");
                return;
            }

            if (label_Proveedor.Text == "N/A")
            {
                Helpers.ShowWarning("Seleccione un proveedor para continuar...");
                return;
            }

            if (comboBox_forma_pago.SelectedIndex == 0)
            {
                Helpers.ShowValidacion("Forma de pago");
                return;
            }


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
                CodigoBarra=txtCodigoBarra.Text,
            });


            txt_importe.Text = "RD$ 0.00";
            txt_impuesto.Text = "RD$ 0.00";
            txt_neto.Text = "RD$ 0.00";
            txtPrecioCosto.Text = "0.00";
            txtCantidad.Text = "0";
            this._Producto_ID = 0;
            txtCodigoBarra.Text = string.Empty;
            txtnombre.Text = string.Empty;
            txtCodigoBarra.Text= string.Empty;
        }


        private void AddCompraViewModels(CompraViewModel model)
        {
            bindingSource_listado_producto_nuevos.DataSource = null; // Establecer en null para limpiar

            // Agregar el modelo a la lista de compra
            compraViewModels.Add(model);

            // Forzar la actualización del origen de datos            
            bindingSource_listado_producto_nuevos.DataSource = compraViewModels; // Reasignar la lista actualizada




            // Calcular el total a pagar asegurando que no sea nulo y formatearlo con dos decimales
            double total_a_pagar = compraViewModels.Sum(x => x.SubTotal) ?? 0.0;

            // Formatear el texto con dos decimales
            txtTotalPagar.Text = $"RD$ {total_a_pagar:F2}";
            ConfigureDataGridView();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            double importe = 0.00;
            double impuestos = 0.00;
            double neto = 0.00;


            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {

                return;
            }
            //if (string.IsNullOrWhiteSpace(txtPrecioCosto.Text))
            //{
            //    Helpers.ShowValidacion("Precio");
            //    return;
            //}



            importe = double.Parse(txtPrecioCosto.Text.ToString()) * double.Parse(txtCantidad.Text.ToString());
            impuestos = (importe * _impuesto) / 100;
            neto = importe + impuestos;

            txt_importe.Text = string.Format($"RD$ {importe:N2}");
            txt_impuesto.Text = string.Format($"RD$ {impuestos:N2}");
            txt_neto.Text = string.Format($"RD$ {neto:N2}");

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
            dataGridView_CompraViewModels.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
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

                        var algo= fila.Cells; 
                        txtCodigoBarra.Text = fila.Cells[2].Value.ToString(); 
                        break;

                    case 1:

                        var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            compraViewModels.RemoveAt(e.RowIndex);
                            bindingSource_listado_producto_nuevos.ResetBindings(false);
                        }
                        break;
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un dígito ni la tecla de retroceso, cancela el evento
                e.Handled = true;
            }
        }

        private void txtPrecioCosto_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}


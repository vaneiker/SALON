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

namespace UI_UX_Dashboard_P1.UI
{
    public partial class ProveedorForm : Form
    {
        private ProveedoresAdmin db = new ProveedoresAdmin();
        public ProveedorForm()
        {
            InitializeComponent();
        }

        public void CargaInicial()
        {

            try
            {
                var result = db.GetProveedor().ToArray();
                bindingSource_Proveedor.List.Clear();
                bindingSource_Proveedor.DataSource = result;
                label_cantidad_registro.Text = $"Registro encontrados: {result.Count().ToString()}";
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el listado de Proveedores {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void Limpiar()
        {
            txtCodigo.Text = "0";
            txtnombre.Text = string.Empty;
            maskedTextBox_cedula.Text = string.Empty;
            maskedTextBox_celular.Text = string.Empty;
            maskedTextBox_correo.Text = string.Empty;
            maskedTextBox_telefono.Text = string.Empty;
            textBox_direccion.Text = string.Empty;
            txtLimiteCredito.Text = "0.00";
            txtDiasCancelacion.Text = "0";
        }

        private void ProveedorForm_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show($"Campo Nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox_cedula.Text.Replace("-", "")))
            {
                MessageBox.Show($"Favor indicar la cedula de Proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(maskedTextBox_celular.Text) && string.IsNullOrWhiteSpace(maskedTextBox_telefono.Text))
            {
                MessageBox.Show($"Favor indicar un conctacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pProveedores = new Proveedores()
            {
                ProveedorID = int.Parse(txtCodigo.Text),
                NombreProveedor = txtnombre.Text,
                CedulaProveedor = maskedTextBox_cedula.Text.Replace("-", ""),
                CelularProveedor = maskedTextBox_celular.Text.Replace("(", "").Replace(")", "").Replace("-", ""),
                TelefonoProveedor = maskedTextBox_telefono.Text.Replace("(", "").Replace(")", "").Replace("-", ""),
                DireccionProveedor = textBox_direccion.Text,
                EmailProveedor = maskedTextBox_correo.Text,
                LimiteCredito = decimal.Parse(txtLimiteCredito.Text),
                DiasCancelacion = int.Parse(txtDiasCancelacion.Text)

            };
            try
            {
                db.SetProveedorCrearActualizar(pProveedores);
                CargaInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el Proveedores {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];      // Fila seleccionada

                switch (e.ColumnIndex)
                {
                    case 0:


                        txtCodigo.Text = fila.Cells["ProveedorID"].Value.ToString();
                        txtnombre.Text = fila.Cells["NombreProveedor"].Value.ToString();
                        maskedTextBox_cedula.Text = fila.Cells["CedulaProveedor"].Value.ToString();
                        maskedTextBox_celular.Text = fila.Cells["CelularProveedor"].Value.ToString();
                        maskedTextBox_correo.Text = fila.Cells["EmailProveedor"].Value.ToString();
                        maskedTextBox_telefono.Text = fila.Cells["TelefonoProveedor"].Value.ToString();
                        textBox_direccion.Text = fila.Cells["DireccionProveedor"].Value.ToString();
                        txtLimiteCredito.Text = fila.Cells["LimiteCredito"].Value.ToString();
                        txtDiasCancelacion.Text = fila.Cells["DiasCancelacion"].Value.ToString();


                        break;

                    case 1:  // Columna "Borrar"
                        if (MessageBox.Show($"¿Desea Borrar el Proveedor:  {fila.Cells["NombreProveedor"].Value.ToString()}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                db.SetInactivarProveedores(int.Parse(fila.Cells["ProveedorID"].Value.ToString()));
                                CargaInicial();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al eliminar el Proveedores {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        break;
                }
            }
        }

        private void txtDiasCancelacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, un punto decimal, y control de retroceso (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtliitecredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, un punto decimal, y control de retroceso (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

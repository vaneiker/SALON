using BLL.Admin;
using ENTITY.Entitis;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class ClientesForm : Form
    {
        private ClienteAdmin db = new ClienteAdmin();


        public ClientesForm()
        {
            InitializeComponent();
        }
        private void ClientesForm_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        public void CargaInicial()
        {

            try
            {
                var result = db.GetClientes().ToArray();
                bindingSource_Clientes.List.Clear();
                bindingSource_Clientes.DataSource = result;
                label_cantidad_registro.Text = $"Registro encontrados: {result.Count().ToString()}";
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el listado de clientes {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
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

            if (string.IsNullOrWhiteSpace(maskedTextBox_celular.Text) && string.IsNullOrWhiteSpace(maskedTextBox_telefono.Text))
            {
                MessageBox.Show($"Favor indicar un conctacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pcliente = new Clientes()
            {
                ClienteID = int.Parse(txtCodigo.Text),
                Nombre = txtnombre.Text,
                Cedula = maskedTextBox_cedula.Text.Replace("-", ""),
                Celular = maskedTextBox_celular.Text.Replace("(", "").Replace(")", "").Replace("-", ""),
                Telefono = maskedTextBox_telefono.Text.Replace("(", "").Replace(")", "").Replace("-", ""),
                FechaNacimiento = dateTimePicker_fecha_nacimiento.Value,
                Email = maskedTextBox_correo.Text,
            };
            try
            {
                db.SetClienteCrearActualizar(pcliente);
                CargaInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el cliente {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            var filtro = db.GetClientes().ToArray()
                .Where(x => x.Nombre.ToLower().Contains(txtBuscador.Text.ToLower()) ||
                            x.Telefono == txtBuscador.Text)
                .ToList();

            if (filtro.Count > 0)
            {
                label_cantidad_registro.Text = $"Registro encontrados: {filtro.Count().ToString()}";
                bindingSource_Clientes.List.Clear();
                bindingSource_Clientes.DataSource = filtro;
            }
            else
            {
                CargaInicial();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Limpiar()
        {
            txtCodigo.Text = "0";
            txtnombre.Text = string.Empty;
            maskedTextBox_cedula.Text = string.Empty;
            maskedTextBox_celular.Text = string.Empty;
            maskedTextBox_correo.Text = string.Empty;
            maskedTextBox_telefono.Text = string.Empty;
            dateTimePicker_fecha_nacimiento.Text = string.Empty;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];      // Fila seleccionada

                switch (e.ColumnIndex)
                {
                    case 0:


                        txtCodigo.Text = fila.Cells["ClienteID"].Value.ToString();
                        txtnombre.Text = fila.Cells["Nombre"].Value.ToString();
                        maskedTextBox_cedula.Text = fila.Cells["Cedula"].Value.ToString();
                        maskedTextBox_celular.Text = fila.Cells["Celular"].Value.ToString();
                        maskedTextBox_correo.Text = fila.Cells["Email"].Value.ToString();
                        maskedTextBox_telefono.Text = fila.Cells["Telefono"].Value.ToString();
                        dateTimePicker_fecha_nacimiento.Value = DateTime.Parse(fila.Cells["FechaNacimiento"].Value.ToString());

                        break;
                    ////case 1:  // Columna "Editar"
                    ////    comboBox_rol.SelectedItem = fila.Cells["Rol"].Value.ToString(); // Cargar el rol en el ComboBox
                    ////    MessageBox.Show($"Editar usuario: {nombreUsuario}");
                    ////    break;
                    case 1:  // Columna "Borrar"
                        if (MessageBox.Show($"¿Desea Borrar el Cliente {txtnombre.Text = fila.Cells["Nombre"].Value.ToString()}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                db.SetInactivarClientes(int.Parse(fila.Cells["ClienteID"].Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al borrar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        break;
                }
            }
        }

    }
}

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
    public partial class ClientesForm : Form
    {
        private ClienteAdmin db = new ClienteAdmin();
        private int pageSize = 10;
        private int currentPage = 1;
        private int totalRecords;
        private int totalPages;
        private List<Clientes> allClientes;  // Lista completa de clientes
        private List<Clientes> filteredClientes; // Lista de clientes filtrados

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
            allClientes = db.GetClientes().ToList(); // Carga la lista completa al inicio
            CargarClientesPaginados(allClientes); // Carga inicial de todos los clientes
            Limpiar();
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
                        //case 1:  // Columna "Borrar"
                        //    //if (MessageBox.Show($"¿Borrar usuario {nombreUsuario}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        //    //{

                        //    //}
                        //    break;
                }
            }
        }




        private void CargarClientesPaginados(List<Clientes> clientes)
        {
            totalRecords = clientes.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            // Obtener el subconjunto de clientes para la página actual
            var paginatedData = clientes
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            bindingSource_Clientes.DataSource = paginatedData;
            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            btnPrimero.Enabled = currentPage > 1;
            btnAtras.Enabled = currentPage > 1;
            btnSiguiente.Enabled = currentPage < totalPages;
            btnUltimo.Enabled = currentPage < totalPages;

            // Actualizar el texto del label con la página actual
            label_cantidad_registro.Text = $"Página {currentPage} de {totalPages}";
        }


        private void btnPrimero_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            CargarClientesPaginados(filteredClientes);
        }


        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                CargarClientesPaginados(filteredClientes);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                CargarClientesPaginados(filteredClientes);
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            CargarClientesPaginados(filteredClientes);
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            var filtro = allClientes
                .Where(x => x.Nombre.ToLower().Contains(txtBuscador.Text.ToLower()) ||
                            x.Telefono == txtBuscador.Text)
                .ToList();

            currentPage = 1; // Reiniciar a la primera página al hacer una búsqueda

            if (filtro.Count > 0)
            {
                filteredClientes = filtro;
                CargarClientesPaginados(filteredClientes);
            }
            else
            {
                filteredClientes = allClientes;
                CargarClientesPaginados(allClientes);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } 


        //public void GetClientes(int pageSize = 10, int currentPage = 1)
        //{
        //    try
        //    {
        //        var data = db.GetClientes();

        //        if (data != null)
        //        {
        //            // Paginación: saltar los registros de las páginas anteriores y tomar los del tamaño de la página
        //            var paginatedData = data
        //                .Skip((currentPage - 1) * pageSize)
        //                .Take(pageSize)
        //                .ToList();

        //            // Cargar los datos paginados en el BindingSource
        //            label_cantidad_registro.Text = paginatedData.Count.ToString();
        //            bindingSource_Clientes.DataSource = paginatedData;
        //        }
        //        else
        //        {
        //            bindingSource_Clientes.DataSource = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void txtBuscador_TextChanged(object sender, EventArgs e)
        //{
        //    var data = db.GetClientes();

        //    if (data != null)
        //    {
        //        var filtro = data.Where(x =>
        //                       x.Nombre.ToLower().Contains(txtBuscador.Text.ToLower()) ||
        //                       x.Telefono == txtBuscador.Text
        //                       ).ToList();

        //        if (filtro.Count > 0)
        //        {
        //            bindingSource_Clientes.Clear();
        //            bindingSource_Clientes.DataSource = filtro;
        //            label_cantidad_registro.Text = $"Página {currentPage} de {totalPages}";

        //        }
        //        else
        //        {
        //            CargarClientesPaginados();
        //        }
        //    }
        //}

        //private void CargarClientesPaginados()
        //{
        //    var data = db.GetClientes();
        //    totalRecords = data?.Count() ?? 0;
        //    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        //    GetClientes(pageSize, currentPage);
        //    ActualizarEstadoBotones();
        //}

        //private void ActualizarEstadoBotones()
        //{
        //    btnPrimero.Enabled = currentPage > 1;
        //    btnAtras.Enabled = currentPage > 1;
        //    btnSiguiente.Enabled = currentPage < totalPages;
        //    btnUltimo.Enabled = currentPage < totalPages;
        //    label_cantidad_registro.Text = $"Página {currentPage} de {totalPages}";
        //}

        //private void btnPrimero_Click(object sender, EventArgs e)
        //{
        //    currentPage = 1;
        //    CargarClientesPaginados();
        //}

        //private void btnAtras_Click(object sender, EventArgs e)
        //{
        //    if (currentPage > 1)
        //    {
        //        currentPage--;
        //        CargarClientesPaginados();
        //    }
        //}

        //private void btnSiguiente_Click(object sender, EventArgs e)
        //{
        //    if (currentPage < totalPages)
        //    {
        //        currentPage++;
        //        CargarClientesPaginados();
        //    }
        //}

        //private void btnUltimo_Click(object sender, EventArgs e)
        //{
        //    currentPage = totalPages;
        //    CargarClientesPaginados();

        //}
    }
}

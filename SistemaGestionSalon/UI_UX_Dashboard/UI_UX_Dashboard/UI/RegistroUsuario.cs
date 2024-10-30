using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BLL.Admin;
using ENTITY.Entitis;


namespace UI_UX_Dashboard_P1.UI
{
    public partial class FrmRegistroUsuario : Form
    {
        private UsuarioAdmin Admin = new UsuarioAdmin();
        private Usuarios usuario = new Usuarios();

        private int id { get; set; } = 0;
        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Dasboard dasboard = new Dasboard();
            this.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show($"Campo Nombre es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox_rol.SelectedIndex == 0 || string.IsNullOrWhiteSpace(comboBox_rol.Text))
            {
                MessageBox.Show($"Selecione un rol para este usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GuardarUsuario();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDataGrid();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void GuardarUsuario()
        { 
            usuario.UsuarioID = id;
            usuario.Contrasena = "12345";
            usuario.Usuario = Tools.GenerarNombreUsuario(txtNombre.Text);
            usuario.Nombre=txtNombre.Text;
            usuario.Rol=comboBox_rol.Text; 
            Admin.AddUpdateUsuario(usuario);
            CargarDataGrid();
        }
        private void CargarDataGrid()
        {
            comboBox_rol.SelectedIndex = 0;
            txtNombre.Text =string.Empty;
            var data = Admin.ObtenerUsuarioAdmin();
            bindingSource_Usuarios.DataSource = data;
            this.id = 0;
        }
        private void limpiar()
        {
            txtNombre.Text = string.Empty;
            TxtBuscar.Text = string.Empty;
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {
            CargarDataGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el clic haya sido en una celda válida y en una columna de botón
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];      // Fila seleccionada
                string nombreUsuario = fila.Cells["Nombre"].Value.ToString(); // Obtener el nombre del usuario
                this.id = int.Parse(fila.Cells["UsuarioID"].Value.ToString());
                switch (e.ColumnIndex)
                {
                    case 0: 
                        comboBox_rol.SelectedItem = fila.Cells["Rol"].Value.ToString();
                        txtNombre.Text = fila.Cells["Nombre"].Value.ToString(); 
                        break;
                    //case 1:  // Columna "Editar"
                    //    comboBox_rol.SelectedItem = fila.Cells["Rol"].Value.ToString(); // Cargar el rol en el ComboBox
                    //    MessageBox.Show($"Editar usuario: {nombreUsuario}");
                    //    break;
                    case 1:  // Columna "Borrar"
                        if (MessageBox.Show($"¿Borrar usuario {nombreUsuario}?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Admin.eliminarUsuario(this.id);
                            CargarDataGrid();
                        }
                        break;
                }
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {


            var data = Admin.ObtenerUsuarioAdmin();

            if (data != null)
            {
                // Limpia el binding source
                bindingSource_Usuarios.Clear();

                // Aplica el filtro sobre la lista de datos
                var filtro = data.Where(x =>
                               x.Nombre.ToLower().Contains(TxtBuscar.Text.ToLower()) ||
                               x.Usuario.ToLower().Contains(TxtBuscar.Text.ToLower()) ||
                               x.Rol.ToLower().Contains(TxtBuscar.Text.ToLower())
                           ).ToList(); // Convierte a lista

                // Verifica si el filtro devolvió resultados
                if (filtro.Count > 0)
                {
                    // Actualiza el binding source con los datos filtrados
                    bindingSource_Usuarios.DataSource = filtro;
                }
                else
                {
                    // Carga los datos originales en caso de no encontrar resultados
                    CargarDataGrid();
                }
            }
        }
    }
}

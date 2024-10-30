using System;
using System.Linq;
using System.Windows.Forms;
using BLL.Admin;
 
namespace UI_UX_Dashboard_P1.UI
{
    public partial class Login : Form
    {
        private UsuarioAdmin Admin = new UsuarioAdmin();
        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show($"Campo usuario es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show($"Campo contraseñas es requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = Admin.Acceder(txtUsuario.Text, txtPassword.Text);

            if (result != null)
            {
                if (result.ACTION == "OK")
                {
                    var user=Admin.ObtenerUsuarioAdmin(result.MSJ).FirstOrDefault();

                    if (user != null)
                    {
                        Seccion seccion = Seccion.Instance;
                        seccion.UsuarioID = user.UsuarioID;
                        seccion.Usuario = user.Usuario;
                        seccion.Nombre = user.Nombre;
                        seccion.Rol = user.Rol;
                        Dasboard dasboard = new Dasboard();
                        this.Hide();
                        dasboard.Show();
                    }
                    else
                    {
                        MessageBox.Show($"{result.ACTION}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                                    
                }
                else 
                {
                    MessageBox.Show($"{result.ACTION}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                } 
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }
    }
}

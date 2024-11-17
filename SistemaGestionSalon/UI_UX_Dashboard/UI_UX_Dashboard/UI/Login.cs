using System;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BLL.Admin;
using UI_UX_Dashboard_P1.Custom;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class Login : Form
    {
        private UsuarioAdmin Admin = new UsuarioAdmin();
        private int? UserId { get; set; }
        private string User { get; set; }


        public class RoleSelector
        {
            private static readonly string[] Roles = { "ADMIN" };
            private static readonly Random random = new Random();

            public static string GetRandomRole()
            {
                int index = random.Next(Roles.Length); // Genera un índice aleatorio
                return Roles[index];
            }
        }

        public Login()
        {
            InitializeComponent();
            panel_cambiar_clave.Visible = false;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                string password = string.Empty;

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
                password = Tools.Encrypt_Query(txtPassword.Text);
                var result = Admin.Acceder(txtUsuario.Text, password);

                if (result != null)
                {
                    if (result.ACTION == "OK")
                    {
                        var user = Admin.ObtenerUsuarioAdmin(result.MSJ).FirstOrDefault();
                        this.UserId = user.UsuarioID;
                        if (user != null)
                        { 
                            if (user.EsBorrado == true)
                            {
                                Helpers.ShowTypeError("Cuenta Inactiva!", "Stop");
                                return;
                            }
                            if (!user.EstaActivo == false)
                            {
                                Helpers.ShowTypeError("Usuario Bloqueado", "Stop");
                                return;
                            } 

                            Dasboard dasboard = new Dasboard();

                            FrmGestionFinanciera contable = new FrmGestionFinanciera();
                            FrmSecretaria secretaria = new FrmSecretaria();
                            FrmCaja caja = new FrmCaja();
                            FrmAlmacen almacen = new FrmAlmacen();
                            Dasboard principal = new Dasboard();


                            Seccion seccion = Seccion.Instance;
                            seccion.UsuarioID = user.UsuarioID;
                            seccion.Usuario = user.Usuario;
                            seccion.Nombre = user.Nombre;
                            seccion.Rol = user.Rol;
                            seccion.RolName = user.RolName;

                            switch (user.Rol)
                            {
                                case (int?)Roles.Administrador:
                                    this.Hide();
                                    principal.Show();
                                    break;
                                case (int?)Roles.Almacen:
                                    this.Hide();
                                    almacen.Show();
                                    break;
                                case (int?)Roles.Caja:
                                    this.Hide();
                                    caja.Show();
                                    break;
                                case (int?)Roles.Secretariada:
                                    this.Hide();
                                    secretaria.Show();
                                    break;
                                case (int?)Roles.Finanzas:
                                    this.Hide();
                                    contable.Show();
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"{result.ACTION}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else if (result.ACTION == "Cambio Clave")
                    {
                        this.UserId = int.Parse(result.CODE);
                        label_menu.Text = "Cambio de contraseñas";
                        panel_cambiar_clave.Visible = true;
                        panel_Login.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show($"{result.ACTION}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Helpers.ShowError("Error en el metodo:btnAcceder_Click ", ex);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            label_menu.Text = "inicio de sesión";
            panel_cambiar_clave.Visible = false;
            panel_Login.Visible = true;
        }

        private void btnCambiarclave_Click(object sender, EventArgs e)
        {
            string passord = string.Empty;

            if ((string.IsNullOrWhiteSpace(textcambiarclave.Text)) || (string.IsNullOrWhiteSpace(textcambiarclaverepite.Text)))
            {
                MessageBox.Show($"Campos requeridos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textcambiarclave.Text == textcambiarclaverepite.Text)
            {

                try
                {
                    passord = Tools.Encrypt_Query(textcambiarclaverepite.Text);

                    Admin.CambiarClave(this.UserId, passord);
                    label_menu.Text = "inicio de sesión";
                    panel_cambiar_clave.Visible = false;
                    panel_Login.Visible = true;
                }
                catch (Exception ex)
                {
                    var ExceptionResult = Helpers.FormatException(ex, "Admin", "btnCambiarclave_Click");
                    MessageBox.Show(ExceptionResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Las contraseña no son iguales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string selectedRole = RoleSelector.GetRandomRole();
            txtUsuario.Text = selectedRole;
        }
    }
}

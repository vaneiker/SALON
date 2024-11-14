using System; 
using System.Drawing; 
using System.Windows.Forms;
using UI_UX_Dashboard_P1.Custom;
 

namespace UI_UX_Dashboard_P1.UI
{
    public partial class FrmGestionFinanciera : Form
    {
        Seccion seccion = Seccion.Instance;

        public FrmGestionFinanciera()
        {
            InitializeComponent();
            
        }

        private void timer_panel_Tick(object sender, EventArgs e)
        {
            LblReloj.Text = DateTime.Now.ToString("h:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void FrmGestionFinanciera_Load(object sender, EventArgs e)
        {
            if (seccion.Rol == (int?)Roles.Administrador)
            {
                pictureBox_dasboard.Visible = true;
                btnDasboard.Visible = true;
                btnLogout.Visible = false;
                pictureBox_salir.Visible = false;
            }
            //LblNombre.Text = $"{seccion.Nombre}({seccion.Rol})";
            LblNombre.Text = $"Bienvenido, {seccion.Nombre} - Rol: {seccion.RolName}";
            LblNombre.ForeColor = Color.Blue; // Cambia el color del texto a azul
            LblNombre.Font = new Font("Arial", 12, FontStyle.Bold); // Cambia el estilo de la fuente
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login(); 
            this.Close(); 
            login.Show();
        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            Dasboard dasboard = new Dasboard();
            dasboard.Show();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
             
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UsuarioForm usuarioform = new UsuarioForm();
            usuarioform.ShowDialog();
        }
    }
}

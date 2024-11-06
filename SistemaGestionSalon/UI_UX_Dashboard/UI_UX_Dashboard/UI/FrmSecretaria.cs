using System; 
using System.Drawing; 
using System.Windows.Forms;
using UI_UX_Dashboard_P1.Custom; 
 

namespace UI_UX_Dashboard_P1.UI
{
    public partial class FrmSecretaria : Form
    {
        Seccion seccion = Seccion.Instance;
        public FrmSecretaria()
        {
            InitializeComponent();
        }

        private void FrmSecretaria_Load(object sender, EventArgs e)
        {
            if (seccion.Rol == (int?)Roles.Administrador)
            {
                pictureBox_dasboard.Visible =true;
                btnDasboard.Visible = true;
                btnLogout.Visible = false;
                pictureBox_salir.Visible = false;
            }
            //LblNombre.Text = $"{seccion.Nombre}({seccion.Rol})";
            LblNombre.Text = $"Bienvenido, {seccion.Nombre} - Rol: {seccion.RolName}";
            LblNombre.ForeColor = Color.Blue; // Cambia el color del texto a azul
            LblNombre.Font = new Font("Arial", 12, FontStyle.Bold); // Cambia el estilo de la fuente

        }

        private void btnDasboard_Click(object sender, EventArgs e)
        {
            Dasboard dasboard = new Dasboard();
            dasboard.Show();
            this.Close();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void timer_panel_Tick(object sender, EventArgs e)
        {
            LblReloj.Text = DateTime.Now.ToString("h:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnAdminUsers_Click(object sender, EventArgs e)
        { 
            ClientesForm form = new ClientesForm(); 
            form.ShowDialog();
        }
    }
}

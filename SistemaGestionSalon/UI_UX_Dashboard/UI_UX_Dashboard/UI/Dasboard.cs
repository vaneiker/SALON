using System;  
using System.Drawing; 
using System.Windows.Forms;
using UI_UX_Dashboard_P1.UI;
using UI_UX_Dashboard_P1.UI.REPORTES;

namespace UI_UX_Dashboard_P1
{
    public partial class Dasboard : Form
    {
        Seccion seccion = Seccion.Instance;
        public Dasboard()
        {
            InitializeComponent();
        }

        private void Reloj()
        {
            //LblReloj
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LblNombre.Text = $"{seccion.Nombre}({seccion.Rol})";
            LblNombre.Text = $"Bienvenido, {seccion.Nombre} - Rol: {seccion.RolName}";
            LblNombre.ForeColor = Color.Blue; // Cambia el color del texto a azul
            LblNombre.Font = new Font("Arial", 12, FontStyle.Bold); // Cambia el estilo de la fuente
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

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

        private void button7_Click(object sender, EventArgs e)
        {
            FrmRegistroUsuario U = new FrmRegistroUsuario();
            U.ShowDialog();
        }

        private void BtnGestionFinanciera_Click(object sender, EventArgs e)
        {
            FrmGestionFinanciera frmGestion = new FrmGestionFinanciera();
            this.Hide();
            frmGestion.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmSecretaria cliente = new FrmSecretaria();
            this.Hide();
            cliente.Show();
        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            FacturacionForm facturacion = new FacturacionForm();            
            facturacion.ShowDialog();
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            FrmAlmacen almacen = new FrmAlmacen();
            this.Hide();
            almacen.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
             
        }

        private void button_Ingreso_Egresos_Click(object sender, EventArgs e)
        {
            VentasReportes ventas = new VentasReportes();
            ventas.ShowDialog();
        }
    }
}

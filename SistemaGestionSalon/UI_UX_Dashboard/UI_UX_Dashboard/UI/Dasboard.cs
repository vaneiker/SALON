using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_UX_Dashboard_P1.UI;

namespace UI_UX_Dashboard_P1
{
    public partial class Dasboard : Form
    {
        Seccion seccion = Seccion.Instance;
        public Dasboard()
        {
            InitializeComponent();
            //LblNombre.Text = $"{seccion.Nombre}({seccion.Rol})";
            LblNombre.Text = $"Bienvenido, {seccion.Nombre} - Rol: {seccion.Rol}";
            LblNombre.ForeColor = Color.Blue; // Cambia el color del texto a azul
            LblNombre.Font = new Font("Arial", 12, FontStyle.Bold); // Cambia el estilo de la fuente

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
    }
}

using BLL.Admin;
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
    public partial class UsuarioForm : Form
    {
        private UsuarioAdmin db = new UsuarioAdmin();
        Seccion seccion = Seccion.Instance;
        public UsuarioForm()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            var a = db.ObtenerUsuarioAdmin().Where(x=>x.Usuario== seccion.Usuario).FirstOrDefault();

            if (a != null)
            {
                txt_usuario.Text = a.Usuario.ToString();
                txtRol.Text = a.RolName.ToString();
                txtNombre.Text = a.Nombre.ToString();
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
        } 
    }
}

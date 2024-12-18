﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using UI_UX_Dashboard_P1.Custom;
using BLL.Admin;

namespace UI_UX_Dashboard_P1.UI
{
    public partial class FrmAlmacen : Form
    {
        Seccion seccion = Seccion.Instance;
        public FrmAlmacen()
        {
            InitializeComponent();
        }

        private void FrmAlmacen_Load(object sender, EventArgs e)
        {

          
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

        private void FrmAlmacen_Load_1(object sender, EventArgs e)
        {
            if (seccion.Rol == (int?)Roles.Administrador)
            {
                pictureBox_dasboard.Visible = true;
                btnDasboard.Visible = true;
                btnLogout.Visible = false;
                pictureBox_salir.Visible = false;
            }

            LblNombreUsuario.Text = $"Bienvenido, {seccion.Nombre} - Rol: {seccion.RolName}";
            LblNombreUsuario.ForeColor = Color.Blue; // Cambia el color del texto a azul
            LblNombreUsuario.Font = new Font("Arial", 12, FontStyle.Bold); // Cambia el estilo de la fuente
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            ComprasForm formCompras = new ComprasForm();
            formCompras.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            ProductoServiciosForm productoServicios = new ProductoServiciosForm();
            productoServicios.ShowDialog();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            UsuarioForm usuarioform = new UsuarioForm();
            usuarioform.ShowDialog();   
        }
    }
}

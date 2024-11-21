using System;
using System.IO;
using System.Windows.Forms;
using BLL.Admin;
using UI_UX_Dashboard_P1.Custom;


namespace UI_UX_Dashboard_P1.UI
{
    public partial class GastoForm : Form
    {
        Seccion Seccion = Seccion.Instance;
        GastoAdmin db = new GastoAdmin();
        private byte[] soporte = null;
        public GastoForm()
        {
            InitializeComponent();
        }

        private void GastoForm_Load(object sender, EventArgs e)
        {

        }

        private void GuardarGasto()
        {
            db.InsertarGasto(new ENTITY.Entitis.Gasto()
            {
                GastoID = 0,
                FechaGasto = DateTime.Now,
                Monto = decimal.Parse(textBox_Monto.Text),
                Descripcion = textBox_Detalle.Text,
                UsuarioID = Seccion.UsuarioID,
                Soporte = soporte
            });
        }

        private void button_cargar_documento_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Todos los archivos (*.*)|*.*";
                openFileDialog.Title = "Seleccione un archivo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    textBox_Soporte.Text = filePath;
                    // Convertir el archivo a byte[]
                    byte[] fileBytes = FileToByteArray(filePath);
                    soporte = fileBytes;
                }
            }

        }

        private byte[] FileToByteArray(string filePath)
        {
            return File.ReadAllBytes(filePath); // Lee todos los bytes del archivo
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_Monto.Text))
                {
                    Helpers.ShowValidacion("Monto");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox_Detalle.Text))
                {
                    Helpers.ShowValidacion("Monto");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox_Soporte.Text))
                {
                    Helpers.ShowValidacion("Monto");
                    return;
                }

                GuardarGasto();
                Limpiar();
                Helpers.ShowInfo("Gasto guardado exitosamente.");
            }
            catch (Exception ex)
            {
                Helpers.ShowError("Error en el buttonGuardar_Click ", ex);
            }
        }

        private void Limpiar()
        {
            textBox_Monto.Text = string.Empty;
            textBox_Detalle.Text = string.Empty;
            textBox_Soporte.Text = string.Empty;
            soporte = null; 
        }
    }
}

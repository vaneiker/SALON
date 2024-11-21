using ENTITY.Entitis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_UX_Dashboard_P1.UI.REPORTES
{
    public partial class DetalleMovimiento : Form
    {

        StringBuilder builder = new StringBuilder();
        private TipoMovimientoFinanciero financiero = new TipoMovimientoFinanciero();
        public DetalleMovimiento(TipoMovimientoFinanciero p)
        {
            InitializeComponent();
            financiero = p;
        }

        private void DetalleMovimiento_Load(object sender, EventArgs e)
        {


            byte[] pdfData = financiero.documento;

            if (pdfData == null || pdfData.Length == 0)
            {
                MessageBox.Show("El PDF no contiene datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Ruta para guardar el archivo PDF en la carpeta Temp
            string tempFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp");
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
            string pdfPath = Path.Combine(tempFolder, $"{Guid.NewGuid()}.pdf");

            // 3. Guardar el archivo PDF en disco
            File.WriteAllBytes(pdfPath, pdfData);
            axAcroPDF1.src = pdfPath;
            
            
            // 4. Abrir el archivo PDF con el visor predeterminado
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            //{
            //    FileName = pdfPath,
            //    UseShellExecute = true
            //});



            //OpenFileDialog fp = new OpenFileDialog();

            //if (fp.ShowDialog() == DialogResult.OK) {
            //    
            //} 
            //axAcroPDF1.src=

            // Muestra el texto en el TextBox
            //textBoxResultado.Text = builder.ToString();
        }
    }
}

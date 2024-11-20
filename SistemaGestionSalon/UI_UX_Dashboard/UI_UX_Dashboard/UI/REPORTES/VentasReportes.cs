using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Admin;
using ENTITY.Entitis;
using UI_UX_Dashboard_P1.Custom;
using static ENTITY.Entitis.Facturacion;


namespace UI_UX_Dashboard_P1.UI.REPORTES
{
    public partial class VentasReportes : Form
    {

        Seccion seccion = Seccion.Instance;
        ReporteAdmin db = new ReporteAdmin();

        List<TipoMovimientoFinanciero> tipoMovimientos = new List<TipoMovimientoFinanciero>();
        public VentasReportes()
        {
            InitializeComponent();
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            CargarResultados(dateTimePicker_Desde.Value, dateTimePicker_Hasta.Value);
        }

        private void CargarResultados(DateTime? fechadesde, DateTime? fechahasta)
        {
            tipoMovimientos = db.MovimientosFinancieros(fechadesde, fechahasta).ToList();
            dataGridReportes.DataSource = tipoMovimientos;

            ConfigureDataGridView();
        }

        private void dataGridReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //GenerateDocumento


            // Verifica que el clic haya sido en una celda válida y en una columna de botón
            if (e.RowIndex >= 0 && dataGridReportes.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow fila = dataGridReportes.Rows[e.RowIndex];      // Fila seleccionada

                switch (e.ColumnIndex)
                {
                    case 0:

                        //var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                        //if (result == DialogResult.Yes)
                        //{

                        //}
                        break;

                    case 1:


                        var doc = tipoMovimientos.Where(x => x.NumeroDocumento == fila.Cells[3].Value.ToString()).FirstOrDefault();
                        GenerateDocumento(doc);


                        break;
                }
            }
        }

        private void VentasReportes_Load(object sender, EventArgs e)
        {
            CargarResultados(DateTime.Now.AddDays(-1), DateTime.Now);
        }
        private void GenerateDocumento(TipoMovimientoFinanciero tipo)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format($"{tipo.NumeroDocumento}.pdf");
            string htmlContent = tipo.htmlDocumento;

            var popup = MessageBox.Show($"¿Desea Imprimir el {tipo.TipoMovimiento}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (popup == DialogResult.Yes)
            {
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    Tools.SavePDF(savefile, htmlContent);
                }
            }
        }


        private void button_PrinterAll_Click(object sender, EventArgs e)
        {
            if (tipoMovimientos.Any())
            {
                string htmlContent = Properties.Resources.ReporteEngresoIngreso.ToString();
                string htmlRow = "";
                string path = AppDomain.CurrentDomain.BaseDirectory;

                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format($"{Guid.NewGuid()}.pdf");
                string fechaFactura = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                htmlContent = htmlContent.Replace("{{fecha_factura}}", fechaFactura);

                foreach (var item in tipoMovimientos)
                {
                    htmlRow = htmlRow + $@"
                             <tr> 
                                 <td>{item.TipoMovimiento}</td>
                                 <td>{item.NumeroDocumento}</td> 
                                 <td>RD$ {item.MetodoPago}</td> 
                                 <td>RD$ {item.Monto.Value.ToString("C")}</td> 
                             </tr>";

                }
                htmlContent = htmlContent.Replace("{{<tr></tr>}}", htmlRow);
                // Reemplazar los valores en el HTML con datos dinámicos
                htmlContent = htmlContent.Replace("{{observacion}}", "Ningúna");
                htmlContent = htmlContent.Replace("{{usuario}}", seccion.Nombre);
                var popup = MessageBox.Show("¿Desea Imprimir el comprobante?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (popup == DialogResult.Yes)
                {
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        Tools.SavePDF(savefile, htmlContent);

                    }
                }

            }
            else
            {
                Helpers.ShowTypeError("Para imprimir este reporte se debe buscar registro", "error");
            }
        }


        private void ConfigureDataGridView()
        {
            // Configuración general del DataGridView
            dataGridReportes.AutoGenerateColumns = false;
            dataGridReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridReportes.AllowUserToAddRows = false;
            dataGridReportes.ReadOnly = true;
            dataGridReportes.EnableHeadersVisualStyles = false;

            // Estilo de los encabezados
            dataGridReportes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dataGridReportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridReportes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridReportes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Color alterno para las filas
            dataGridReportes.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridReportes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridReportes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dataGridReportes.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridReportes.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Bordes invisibles para un diseño más limpio
            dataGridReportes.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridReportes.GridColor = Color.FromArgb(224, 224, 224);

            // Limpiar columnas anteriores
            dataGridReportes.Columns.Clear();

            // Columna para el botón de Ver
            var viewButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Ver",
                Text = "👁️ Ver",
                UseColumnTextForButtonValue = true,
                Width = 60,
                FlatStyle = FlatStyle.Standard
            };
            viewButtonColumn.DefaultCellStyle.BackColor = Color.Indigo;
            viewButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            viewButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridReportes.Columns.Add(viewButtonColumn);


            // Columna para el botón de Ver
            var printerButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Imprimir",
                Text = "🖨️ Imprimir",
                UseColumnTextForButtonValue = true,
                Width = 100,
                FlatStyle = FlatStyle.Standard
            };
            printerButtonColumn.DefaultCellStyle.BackColor = Color.GreenYellow;
            printerButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            printerButtonColumn.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridReportes.Columns.Add(printerButtonColumn);




            dataGridReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo Movimiento",
                DataPropertyName = "TipoMovimiento",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });


            dataGridReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Número Documento",
                DataPropertyName = "NumeroDocumento",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            dataGridReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Metodo Pago",
                DataPropertyName = "MetodoPago",
                Width = 200,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
            dataGridReportes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });
        }
    }
}

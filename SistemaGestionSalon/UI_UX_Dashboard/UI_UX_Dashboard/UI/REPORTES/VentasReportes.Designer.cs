using System;
using System.Windows.Forms;

namespace UI_UX_Dashboard_P1.UI.REPORTES
{
    public partial class VentasReportes : Form
    {
       
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dataGridReportes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_Desde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Hasta = new System.Windows.Forms.DateTimePicker();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrinter = new System.Windows.Forms.DataGridViewButtonColumn();
            this._TipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ProveedorCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button_PrinterAll = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).BeginInit();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1035, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1035, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reporte de Egresos e Ingresos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // dataGridReportes
            // 
            this.dataGridReportes.AllowUserToAddRows = false;
            this.dataGridReportes.AllowUserToDeleteRows = false;
            this.dataGridReportes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridReportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridReportes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnVer,
            this.btnPrinter,
            this._TipoMovimiento,
            this._NumeroDocumento,
            this._Fecha,
            this._MetodoPago,
            this._ProveedorCliente});
            this.dataGridReportes.Location = new System.Drawing.Point(12, 164);
            this.dataGridReportes.Name = "dataGridReportes";
            this.dataGridReportes.ReadOnly = true;
            this.dataGridReportes.Size = new System.Drawing.Size(1011, 390);
            this.dataGridReportes.TabIndex = 0;
            this.dataGridReportes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridReportes_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(253, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Hasta:";
            // 
            // dateTimePicker_Desde
            // 
            this.dateTimePicker_Desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Desde.Location = new System.Drawing.Point(146, 8);
            this.dateTimePicker_Desde.Name = "dateTimePicker_Desde";
            this.dateTimePicker_Desde.Size = new System.Drawing.Size(101, 22);
            this.dateTimePicker_Desde.TabIndex = 5;
            // 
            // dateTimePicker_Hasta
            // 
            this.dateTimePicker_Hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Hasta.Location = new System.Drawing.Point(392, 11);
            this.dateTimePicker_Hasta.Name = "dateTimePicker_Hasta";
            this.dateTimePicker_Hasta.Size = new System.Drawing.Size(101, 22);
            this.dateTimePicker_Hasta.TabIndex = 6;
            // 
            // button_Buscar
            // 
            this.button_Buscar.BackColor = System.Drawing.Color.SeaGreen;
            this.button_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.Color.White;
            this.button_Buscar.Location = new System.Drawing.Point(803, 5);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(94, 56);
            this.button_Buscar.TabIndex = 7;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = false;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // btnVer
            // 
            this.btnVer.HeaderText = "Ver";
            this.btnVer.Name = "btnVer";
            this.btnVer.ReadOnly = true;
            this.btnVer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnVer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnPrinter
            // 
            this.btnPrinter.HeaderText = "Imprimir";
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.ReadOnly = true;
            this.btnPrinter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnPrinter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _TipoMovimiento
            // 
            this._TipoMovimiento.DataPropertyName = "TipoMovimiento";
            this._TipoMovimiento.HeaderText = "TipoMovimiento";
            this._TipoMovimiento.Name = "_TipoMovimiento";
            this._TipoMovimiento.ReadOnly = true;
            this._TipoMovimiento.ToolTipText = "TipoMovimiento";
            // 
            // _NumeroDocumento
            // 
            this._NumeroDocumento.DataPropertyName = "NumeroDocumento";
            this._NumeroDocumento.HeaderText = "NumeroDocumento";
            this._NumeroDocumento.Name = "_NumeroDocumento";
            this._NumeroDocumento.ReadOnly = true;
            // 
            // _Fecha
            // 
            this._Fecha.DataPropertyName = "Fecha";
            this._Fecha.HeaderText = "Fecha";
            this._Fecha.Name = "_Fecha";
            this._Fecha.ReadOnly = true;
            // 
            // _MetodoPago
            // 
            this._MetodoPago.DataPropertyName = "MetodoPago";
            this._MetodoPago.HeaderText = "MetodoPago";
            this._MetodoPago.Name = "_MetodoPago";
            this._MetodoPago.ReadOnly = true;
            // 
            // _ProveedorCliente
            // 
            this._ProveedorCliente.DataPropertyName = "ProveedorCliente";
            this._ProveedorCliente.HeaderText = "ProveedorCliente";
            this._ProveedorCliente.Name = "_ProveedorCliente";
            this._ProveedorCliente.ReadOnly = true;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel11.Controls.Add(this.button_PrinterAll);
            this.panel11.Controls.Add(this.button_Buscar);
            this.panel11.Controls.Add(this.dateTimePicker_Hasta);
            this.panel11.Controls.Add(this.dateTimePicker_Desde);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Location = new System.Drawing.Point(12, 66);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1011, 70);
            this.panel11.TabIndex = 11;
            // 
            // button_PrinterAll
            // 
            this.button_PrinterAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button_PrinterAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_PrinterAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_PrinterAll.ForeColor = System.Drawing.Color.White;
            this.button_PrinterAll.Location = new System.Drawing.Point(903, 5);
            this.button_PrinterAll.Name = "button_PrinterAll";
            this.button_PrinterAll.Size = new System.Drawing.Size(88, 56);
            this.button_PrinterAll.TabIndex = 8;
            this.button_PrinterAll.Text = "Imprimir";
            this.button_PrinterAll.UseVisualStyleBackColor = false;
            this.button_PrinterAll.Click += new System.EventHandler(this.button_PrinterAll_Click);
            // 
            // VentasReportes
            // 
            this.ClientSize = new System.Drawing.Size(1035, 600);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.dataGridReportes);
            this.Controls.Add(this.panelHeader);
            this.Name = "VentasReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas Reportes";
            this.Load += new System.EventHandler(this.VentasReportes_Load);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReportes)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridReportes;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker_Desde;
        private DateTimePicker dateTimePicker_Hasta;
        private Button button_Buscar;
        private DataGridViewButtonColumn btnVer;
        private DataGridViewButtonColumn btnPrinter;
        private DataGridViewTextBoxColumn _TipoMovimiento;
        private DataGridViewTextBoxColumn _NumeroDocumento;
        private DataGridViewTextBoxColumn _Fecha;
        private DataGridViewTextBoxColumn _MetodoPago;
        private DataGridViewTextBoxColumn _ProveedorCliente;
        private System.ComponentModel.IContainer components;
        private Panel panel11;
        private Button button_PrinterAll;
    }
}

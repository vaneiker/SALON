namespace UI_UX_Dashboard_P1.UI
{
    partial class GastoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Soporte = new System.Windows.Forms.TextBox();
            this.textBox_Detalle = new System.Windows.Forms.TextBox();
            this.textBox_Monto = new System.Windows.Forms.TextBox();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.button_cargar_documento = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(605, 60);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Registro de gastos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(11, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "MONTO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(11, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "DETALLES:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(15, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "SOPORTE:";
            // 
            // textBox_Soporte
            // 
            this.textBox_Soporte.Enabled = false;
            this.textBox_Soporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Soporte.Location = new System.Drawing.Point(136, 356);
            this.textBox_Soporte.Multiline = true;
            this.textBox_Soporte.Name = "textBox_Soporte";
            this.textBox_Soporte.Size = new System.Drawing.Size(330, 40);
            this.textBox_Soporte.TabIndex = 8;
            // 
            // textBox_Detalle
            // 
            this.textBox_Detalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Detalle.Location = new System.Drawing.Point(136, 139);
            this.textBox_Detalle.Multiline = true;
            this.textBox_Detalle.Name = "textBox_Detalle";
            this.textBox_Detalle.Size = new System.Drawing.Size(398, 211);
            this.textBox_Detalle.TabIndex = 9;
            // 
            // textBox_Monto
            // 
            this.textBox_Monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Monto.Location = new System.Drawing.Point(136, 84);
            this.textBox_Monto.Multiline = true;
            this.textBox_Monto.Name = "textBox_Monto";
            this.textBox_Monto.Size = new System.Drawing.Size(157, 37);
            this.textBox_Monto.TabIndex = 10;
            this.textBox_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.BackColor = System.Drawing.Color.Red;
            this.button_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancelar.ForeColor = System.Drawing.Color.White;
            this.button_Cancelar.Location = new System.Drawing.Point(297, 418);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(88, 56);
            this.button_Cancelar.TabIndex = 12;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = false;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuardar.ForeColor = System.Drawing.Color.White;
            this.buttonGuardar.Location = new System.Drawing.Point(197, 418);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(94, 56);
            this.buttonGuardar.TabIndex = 11;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = false;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // button_cargar_documento
            // 
            this.button_cargar_documento.BackColor = System.Drawing.Color.SeaGreen;
            this.button_cargar_documento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cargar_documento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cargar_documento.ForeColor = System.Drawing.Color.White;
            this.button_cargar_documento.Location = new System.Drawing.Point(472, 356);
            this.button_cargar_documento.Name = "button_cargar_documento";
            this.button_cargar_documento.Size = new System.Drawing.Size(77, 40);
            this.button_cargar_documento.TabIndex = 13;
            this.button_cargar_documento.Text = "Cargar";
            this.button_cargar_documento.UseVisualStyleBackColor = false;
            this.button_cargar_documento.Click += new System.EventHandler(this.button_cargar_documento_Click);
            // 
            // GastoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 486);
            this.Controls.Add(this.button_cargar_documento);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.textBox_Monto);
            this.Controls.Add(this.textBox_Detalle);
            this.Controls.Add(this.textBox_Soporte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "GastoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gasto";
            this.Load += new System.EventHandler(this.GastoForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Soporte;
        private System.Windows.Forms.TextBox textBox_Detalle;
        private System.Windows.Forms.TextBox textBox_Monto;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button button_cargar_documento;
    }
}
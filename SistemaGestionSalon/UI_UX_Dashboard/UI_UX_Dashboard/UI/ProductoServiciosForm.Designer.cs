namespace UI_UX_Dashboard_P1.UI
{
    partial class ProductoServiciosForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_productos_servicios = new System.Windows.Forms.DataGridView();
            this.ProductoServicioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVentaBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVentaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porciento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProveedorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaActualizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource_Producto_Servicios = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_precio_manual = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtbeneficios = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_servicio = new System.Windows.Forms.CheckBox();
            this.textBox_Precio_costo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_precio_base = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Proveedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Codigo = new System.Windows.Forms.TextBox();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productos_servicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Producto_Servicios)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
            this.panel5.Controls.Add(this.label12);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1442, 38);
            this.panel5.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(545, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(203, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Productos y Servicios";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtBuscador);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1442, 60);
            this.panel3.TabIndex = 6;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.Location = new System.Drawing.Point(1240, 10);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(188, 22);
            this.txtBuscador.TabIndex = 2;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
            this.label4.Location = new System.Drawing.Point(1167, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Buscar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(150)))), ((int)(((byte)(202)))));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Productos y Servicios";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridView_productos_servicios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1442, 272);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView_productos_servicios
            // 
            this.dataGridView_productos_servicios.AllowUserToAddRows = false;
            this.dataGridView_productos_servicios.AutoGenerateColumns = false;
            this.dataGridView_productos_servicios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_productos_servicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_productos_servicios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductoServicioID,
            this.PrecioVentaBase,
            this.PrecioVentaFinal,
            this.Porciento,
            this.ProveedorID,
            this.Codigo,
            this.NombreProducto,
            this.Descripcion,
            this.Precio,
            this.Tipo,
            this.Stock,
            this.FechaActualizacion});
            this.dataGridView_productos_servicios.DataSource = this.bindingSource_Producto_Servicios;
            this.dataGridView_productos_servicios.Location = new System.Drawing.Point(7, 12);
            this.dataGridView_productos_servicios.Name = "dataGridView_productos_servicios";
            this.dataGridView_productos_servicios.Size = new System.Drawing.Size(1421, 235);
            this.dataGridView_productos_servicios.TabIndex = 0;
            this.dataGridView_productos_servicios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_productos_servicios_CellContentClick);
            // 
            // ProductoServicioID
            // 
            this.ProductoServicioID.DataPropertyName = "ProductoServicioID";
            this.ProductoServicioID.HeaderText = "ProductoServicioID";
            this.ProductoServicioID.Name = "ProductoServicioID";
            this.ProductoServicioID.Visible = false;
            // 
            // PrecioVentaBase
            // 
            this.PrecioVentaBase.HeaderText = "PrecioVentaBase";
            this.PrecioVentaBase.Name = "PrecioVentaBase";
            this.PrecioVentaBase.Visible = false;
            // 
            // PrecioVentaFinal
            // 
            this.PrecioVentaFinal.HeaderText = "PrecioVentaFinal";
            this.PrecioVentaFinal.Name = "PrecioVentaFinal";
            this.PrecioVentaFinal.Visible = false;
            // 
            // Porciento
            // 
            this.Porciento.HeaderText = "Porciento";
            this.Porciento.Name = "Porciento";
            this.Porciento.Visible = false;
            // 
            // ProveedorID
            // 
            this.ProveedorID.DataPropertyName = "ProveedorID";
            this.ProveedorID.HeaderText = "ProveedorID";
            this.ProveedorID.Name = "ProveedorID";
            this.ProveedorID.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ToolTipText = "Código";
            // 
            // NombreProducto
            // 
            this.NombreProducto.DataPropertyName = "NombreProducto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.NombreProducto.DefaultCellStyle = dataGridViewCellStyle4;
            this.NombreProducto.HeaderText = "Nombre Producto";
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ToolTipText = "Nombre Producto";
            this.NombreProducto.Width = 200;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle5;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ToolTipText = "Descripción";
            this.Descripcion.Width = 200;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle6;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ToolTipText = "Precio";
            this.Precio.Width = 200;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.Width = 200;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ToolTipText = "Stock";
            this.Stock.Width = 200;
            // 
            // FechaActualizacion
            // 
            this.FechaActualizacion.DataPropertyName = "FechaActualizacion";
            this.FechaActualizacion.HeaderText = "Fecha Actualización";
            this.FechaActualizacion.Name = "FechaActualizacion";
            this.FechaActualizacion.ToolTipText = "Fecha Actualizacion";
            this.FechaActualizacion.Width = 150;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 370);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1442, 399);
            this.panel2.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(10, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1418, 377);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnCancelar);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.textBox_precio_manual);
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtbeneficios);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.checkBox_servicio);
            this.tabPage1.Controls.Add(this.textBox_Precio_costo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.textBox_precio_base);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.comboBox_Proveedor);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox_Descripcion);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_nombre);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox_Codigo);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1410, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Información de Producto y Servicios";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(50, 179);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 34);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(778, 105);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 20);
            this.label14.TabIndex = 28;
            this.label14.Text = "Precio Manual";
            // 
            // textBox_precio_manual
            // 
            this.textBox_precio_manual.Location = new System.Drawing.Point(782, 128);
            this.textBox_precio_manual.Name = "textBox_precio_manual";
            this.textBox_precio_manual.Size = new System.Drawing.Size(202, 26);
            this.textBox_precio_manual.TabIndex = 27;
            this.textBox_precio_manual.Text = "0.00";
            this.textBox_precio_manual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_precio_manual.TextChanged += new System.EventHandler(this.textBox_precio_manual_TextChanged);
            this.textBox_precio_manual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_precio_manual_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(150, 179);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(94, 34);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(271, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "Beneficios";
            // 
            // txtbeneficios
            // 
            this.txtbeneficios.Enabled = false;
            this.txtbeneficios.Location = new System.Drawing.Point(271, 183);
            this.txtbeneficios.Name = "txtbeneficios";
            this.txtbeneficios.Size = new System.Drawing.Size(205, 26);
            this.txtbeneficios.TabIndex = 24;
            this.txtbeneficios.Text = "RD$ 0.00";
            this.txtbeneficios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(602, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Precio Costo";
            // 
            // checkBox_servicio
            // 
            this.checkBox_servicio.AutoSize = true;
            this.checkBox_servicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_servicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_servicio.ForeColor = System.Drawing.SystemColors.GrayText;
            this.checkBox_servicio.Location = new System.Drawing.Point(39, 130);
            this.checkBox_servicio.Name = "checkBox_servicio";
            this.checkBox_servicio.Size = new System.Drawing.Size(200, 24);
            this.checkBox_servicio.TabIndex = 14;
            this.checkBox_servicio.Text = "¿Producto Consumo?";
            this.checkBox_servicio.UseVisualStyleBackColor = true;
            this.checkBox_servicio.CheckedChanged += new System.EventHandler(this.checkBox_servicio_CheckedChanged);
            // 
            // textBox_Precio_costo
            // 
            this.textBox_Precio_costo.Location = new System.Drawing.Point(546, 126);
            this.textBox_Precio_costo.Name = "textBox_Precio_costo";
            this.textBox_Precio_costo.Size = new System.Drawing.Size(230, 26);
            this.textBox_Precio_costo.TabIndex = 12;
            this.textBox_Precio_costo.Text = "0.00";
            this.textBox_Precio_costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Precio_costo.TextChanged += new System.EventHandler(this.textBox_Precio_costo_TextChanged);
            this.textBox_Precio_costo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Precio_costo_KeyDown);
            this.textBox_Precio_costo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Precio_costo_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(275, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Precio Sin Impuestos Venta";
            // 
            // textBox_precio_base
            // 
            this.textBox_precio_base.Enabled = false;
            this.textBox_precio_base.Location = new System.Drawing.Point(271, 127);
            this.textBox_precio_base.Name = "textBox_precio_base";
            this.textBox_precio_base.Size = new System.Drawing.Size(269, 26);
            this.textBox_precio_base.TabIndex = 8;
            this.textBox_precio_base.Text = "RD$ 0.00";
            this.textBox_precio_base.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(1011, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Proveedores";
            // 
            // comboBox_Proveedor
            // 
            this.comboBox_Proveedor.FormattingEnabled = true;
            this.comboBox_Proveedor.Location = new System.Drawing.Point(1015, 63);
            this.comboBox_Proveedor.Name = "comboBox_Proveedor";
            this.comboBox_Proveedor.Size = new System.Drawing.Size(247, 28);
            this.comboBox_Proveedor.TabIndex = 6;
            this.comboBox_Proveedor.SelectedIndexChanged += new System.EventHandler(this.comboBox_Proveedor_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(500, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Descripción";
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(497, 63);
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(506, 26);
            this.textBox_Descripcion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(278, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Location = new System.Drawing.Point(271, 63);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(209, 26);
            this.textBox_nombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(43, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código";
            // 
            // textBox_Codigo
            // 
            this.textBox_Codigo.Enabled = false;
            this.textBox_Codigo.Location = new System.Drawing.Point(39, 63);
            this.textBox_Codigo.Name = "textBox_Codigo";
            this.textBox_Codigo.Size = new System.Drawing.Size(205, 26);
            this.textBox_Codigo.TabIndex = 0;
            // 
            // ProductoServiciosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 781);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "ProductoServiciosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductoServicios";
            this.Load += new System.EventHandler(this.ProductoServiciosForm_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_productos_servicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Producto_Servicios)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_productos_servicios;
        private System.Windows.Forms.BindingSource bindingSource_Producto_Servicios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Codigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Proveedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.CheckBox checkBox_servicio;
        private System.Windows.Forms.TextBox textBox_Precio_costo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoServicioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVentaBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVentaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porciento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProveedorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaActualizacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_precio_manual;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtbeneficios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_precio_base;
        private System.Windows.Forms.Button btnCancelar;
    }
}
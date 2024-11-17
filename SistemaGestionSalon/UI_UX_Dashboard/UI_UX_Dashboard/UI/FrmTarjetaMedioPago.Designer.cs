namespace UI_UX_Dashboard_P1.UI
{
    partial class FrmTarjetaMedioPago
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.maskedTextBoxCardNumber = new System.Windows.Forms.MaskedTextBox();
            this.textBoxCardHolder = new System.Windows.Forms.TextBox();
            this.maskedTextBoxExpiryDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCVV = new System.Windows.Forms.MaskedTextBox();
            this.labelCardNumber = new System.Windows.Forms.Label();
            this.labelCardHolder = new System.Windows.Forms.Label();
            this.labelExpiryDate = new System.Windows.Forms.Label();
            this.labelCVV = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.maskedTextBoxCardNumber);
            this.panelMain.Controls.Add(this.textBoxCardHolder);
            this.panelMain.Controls.Add(this.maskedTextBoxExpiryDate);
            this.panelMain.Controls.Add(this.maskedTextBoxCVV);
            this.panelMain.Controls.Add(this.labelCardNumber);
            this.panelMain.Controls.Add(this.labelCardHolder);
            this.panelMain.Controls.Add(this.labelExpiryDate);
            this.panelMain.Controls.Add(this.labelCVV);
            this.panelMain.Controls.Add(this.btnSubmit);
            this.panelMain.Location = new System.Drawing.Point(12, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(360, 320);
            this.panelMain.TabIndex = 0;

            // 
            // maskedTextBoxCardNumber
            // 
            this.maskedTextBoxCardNumber.Location = new System.Drawing.Point(50, 60);
            this.maskedTextBoxCardNumber.Mask = "0000 0000 0000 0000";
            this.maskedTextBoxCardNumber.Name = "maskedTextBoxCardNumber";
            this.maskedTextBoxCardNumber.Size = new System.Drawing.Size(243, 20);
            this.maskedTextBoxCardNumber.TabIndex = 0;
            this.maskedTextBoxCardNumber.ValidatingType = typeof(int);

            // 
            // textBoxCardHolder
            // 
            this.textBoxCardHolder.Location = new System.Drawing.Point(50, 120);
            this.textBoxCardHolder.Name = "textBoxCardHolder";
            this.textBoxCardHolder.Size = new System.Drawing.Size(243, 20);
            this.textBoxCardHolder.TabIndex = 1;

            // 
            // maskedTextBoxExpiryDate
            // 
            this.maskedTextBoxExpiryDate.Location = new System.Drawing.Point(50, 180);
            this.maskedTextBoxExpiryDate.Mask = "00/00";
            this.maskedTextBoxExpiryDate.Name = "maskedTextBoxExpiryDate";
            this.maskedTextBoxExpiryDate.Size = new System.Drawing.Size(78, 20);
            this.maskedTextBoxExpiryDate.TabIndex = 2;

            // 
            // maskedTextBoxCVV
            // 
            this.maskedTextBoxCVV.Location = new System.Drawing.Point(150, 180);
            this.maskedTextBoxCVV.Mask = "000";
            this.maskedTextBoxCVV.Name = "maskedTextBoxCVV";
            this.maskedTextBoxCVV.Size = new System.Drawing.Size(78, 20);
            this.maskedTextBoxCVV.TabIndex = 3;

            // 
            // labelCardNumber
            // 
            this.labelCardNumber.AutoSize = true;
            this.labelCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCardNumber.ForeColor = System.Drawing.Color.Gray;
            this.labelCardNumber.Location = new System.Drawing.Point(50, 40);
            this.labelCardNumber.Name = "labelCardNumber";
            this.labelCardNumber.Size = new System.Drawing.Size(142, 19);
            this.labelCardNumber.TabIndex = 4;
            this.labelCardNumber.Text = "Número de Tarjeta *";

            // 
            // labelCardHolder
            // 
            this.labelCardHolder.AutoSize = true;
            this.labelCardHolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCardHolder.ForeColor = System.Drawing.Color.Gray;
            this.labelCardHolder.Location = new System.Drawing.Point(50, 100);
            this.labelCardHolder.Name = "labelCardHolder";
            this.labelCardHolder.Size = new System.Drawing.Size(115, 19);
            this.labelCardHolder.TabIndex = 5;
            this.labelCardHolder.Text = "Titular de la tarjeta";

            // 
            // labelExpiryDate
            // 
            this.labelExpiryDate.AutoSize = true;
            this.labelExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelExpiryDate.ForeColor = System.Drawing.Color.Gray;
            this.labelExpiryDate.Location = new System.Drawing.Point(50, 160);
            this.labelExpiryDate.Name = "labelExpiryDate";
            this.labelExpiryDate.Size = new System.Drawing.Size(141, 19);
            this.labelExpiryDate.TabIndex = 6;
            this.labelExpiryDate.Text = "Fecha de Expiración *";

            // 
            // labelCVV
            // 
            this.labelCVV.AutoSize = true;
            this.labelCVV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCVV.ForeColor = System.Drawing.Color.Gray;
            this.labelCVV.Location = new System.Drawing.Point(150, 160);
            this.labelCVV.Name = "labelCVV";
            this.labelCVV.Size = new System.Drawing.Size(39, 19);
            this.labelCVV.TabIndex = 7;
            this.labelCVV.Text = "CVV *";

            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(41, 121, 255);
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(100, 220);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(143, 40);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Guardar";
            this.btnSubmit.UseVisualStyleBackColor = false;
            

            // 
            // FrmTarjetaMedioPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.panelMain);
            this.Name = "FrmTarjetaMedioPago";
            this.Text = "Captura de Tarjeta de Crédito";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCardNumber;
        private System.Windows.Forms.TextBox textBoxCardHolder;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxExpiryDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCVV;
        private System.Windows.Forms.Label labelCardNumber;
        private System.Windows.Forms.Label labelCardHolder;
        private System.Windows.Forms.Label labelExpiryDate;
        private System.Windows.Forms.Label labelCVV;
        private System.Windows.Forms.Button btnSubmit;
    }
}

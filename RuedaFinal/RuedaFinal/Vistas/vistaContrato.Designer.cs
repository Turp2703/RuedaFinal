namespace RuedaFinal.Vistas
{
    partial class vistaContrato
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
            this.panelCliente = new System.Windows.Forms.Panel();
            this.lblInquilino = new System.Windows.Forms.Label();
            this.comboInquilino = new System.Windows.Forms.ComboBox();
            this.lblInmueble = new System.Windows.Forms.Label();
            this.comboInmueble = new System.Windows.Forms.ComboBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.dateFVenc = new System.Windows.Forms.DateTimePicker();
            this.lblFVenc = new System.Windows.Forms.Label();
            this.dateFUltimo = new System.Windows.Forms.DateTimePicker();
            this.lblFUltimo = new System.Windows.Forms.Label();
            this.dateFInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFInicio = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCliente
            // 
            this.panelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCliente.AutoScroll = true;
            this.panelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCliente.Controls.Add(this.lblInquilino);
            this.panelCliente.Controls.Add(this.comboInquilino);
            this.panelCliente.Controls.Add(this.lblInmueble);
            this.panelCliente.Controls.Add(this.comboInmueble);
            this.panelCliente.Controls.Add(this.lblPrecio);
            this.panelCliente.Controls.Add(this.numPrecio);
            this.panelCliente.Controls.Add(this.dateFVenc);
            this.panelCliente.Controls.Add(this.lblFVenc);
            this.panelCliente.Controls.Add(this.dateFUltimo);
            this.panelCliente.Controls.Add(this.lblFUltimo);
            this.panelCliente.Controls.Add(this.dateFInicio);
            this.panelCliente.Controls.Add(this.lblFInicio);
            this.panelCliente.Location = new System.Drawing.Point(12, 12);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(360, 381);
            this.panelCliente.TabIndex = 20;
            // 
            // lblInquilino
            // 
            this.lblInquilino.AutoSize = true;
            this.lblInquilino.Location = new System.Drawing.Point(5, 365);
            this.lblInquilino.Margin = new System.Windows.Forms.Padding(5);
            this.lblInquilino.Name = "lblInquilino";
            this.lblInquilino.Size = new System.Drawing.Size(118, 24);
            this.lblInquilino.TabIndex = 32;
            this.lblInquilino.Text = "Inquilino";
            // 
            // comboInquilino
            // 
            this.comboInquilino.FormattingEnabled = true;
            this.comboInquilino.Location = new System.Drawing.Point(9, 397);
            this.comboInquilino.Name = "comboInquilino";
            this.comboInquilino.Size = new System.Drawing.Size(323, 32);
            this.comboInquilino.TabIndex = 31;
            this.comboInquilino.DropDown += new System.EventHandler(this.comboInquilino_DropDown);
            // 
            // lblInmueble
            // 
            this.lblInmueble.AutoSize = true;
            this.lblInmueble.Location = new System.Drawing.Point(5, 293);
            this.lblInmueble.Margin = new System.Windows.Forms.Padding(5);
            this.lblInmueble.Name = "lblInmueble";
            this.lblInmueble.Size = new System.Drawing.Size(106, 24);
            this.lblInmueble.TabIndex = 30;
            this.lblInmueble.Text = "Inmueble";
            // 
            // comboInmueble
            // 
            this.comboInmueble.FormattingEnabled = true;
            this.comboInmueble.Location = new System.Drawing.Point(9, 325);
            this.comboInmueble.Name = "comboInmueble";
            this.comboInmueble.Size = new System.Drawing.Size(323, 32);
            this.comboInmueble.TabIndex = 29;
            this.comboInmueble.DropDown += new System.EventHandler(this.comboInmueble_DropDown);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(5, 221);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(5);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(322, 24);
            this.lblPrecio.TabIndex = 28;
            this.lblPrecio.Text = "Precio de Alquiler (ARS $)";
            // 
            // numPrecio
            // 
            this.numPrecio.Location = new System.Drawing.Point(6, 253);
            this.numPrecio.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(326, 32);
            this.numPrecio.TabIndex = 21;
            // 
            // dateFVenc
            // 
            this.dateFVenc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFVenc.Location = new System.Drawing.Point(6, 181);
            this.dateFVenc.Name = "dateFVenc";
            this.dateFVenc.Size = new System.Drawing.Size(326, 32);
            this.dateFVenc.TabIndex = 19;
            // 
            // lblFVenc
            // 
            this.lblFVenc.AutoSize = true;
            this.lblFVenc.Location = new System.Drawing.Point(2, 149);
            this.lblFVenc.Margin = new System.Windows.Forms.Padding(5);
            this.lblFVenc.Name = "lblFVenc";
            this.lblFVenc.Size = new System.Drawing.Size(250, 24);
            this.lblFVenc.TabIndex = 18;
            this.lblFVenc.Text = "Fecha de Vencimiento";
            // 
            // dateFUltimo
            // 
            this.dateFUltimo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFUltimo.Location = new System.Drawing.Point(6, 109);
            this.dateFUltimo.Name = "dateFUltimo";
            this.dateFUltimo.Size = new System.Drawing.Size(326, 32);
            this.dateFUltimo.TabIndex = 17;
            // 
            // lblFUltimo
            // 
            this.lblFUltimo.AutoSize = true;
            this.lblFUltimo.Location = new System.Drawing.Point(2, 77);
            this.lblFUltimo.Margin = new System.Windows.Forms.Padding(5);
            this.lblFUltimo.Name = "lblFUltimo";
            this.lblFUltimo.Size = new System.Drawing.Size(262, 24);
            this.lblFUltimo.TabIndex = 16;
            this.lblFUltimo.Text = "Fecha del Ultimo Pago";
            // 
            // dateFInicio
            // 
            this.dateFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFInicio.Location = new System.Drawing.Point(6, 37);
            this.dateFInicio.Name = "dateFInicio";
            this.dateFInicio.Size = new System.Drawing.Size(326, 32);
            this.dateFInicio.TabIndex = 15;
            // 
            // lblFInicio
            // 
            this.lblFInicio.AutoSize = true;
            this.lblFInicio.Location = new System.Drawing.Point(2, 5);
            this.lblFInicio.Margin = new System.Windows.Forms.Padding(5);
            this.lblFInicio.Name = "lblFInicio";
            this.lblFInicio.Size = new System.Drawing.Size(190, 24);
            this.lblFInicio.TabIndex = 9;
            this.lblFInicio.Text = "Fecha de Inicio";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Image = global::RuedaFinal.Properties.Resources.iconRefre;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.Location = new System.Drawing.Point(51, 404);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(140, 65);
            this.btnBorrar.TabIndex = 40;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Image = global::RuedaFinal.Properties.Resources.iconCheck;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(197, 404);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(175, 65);
            this.btnConfirmar.TabIndex = 41;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // vistaContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 481);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panelCliente);
            this.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "vistaContrato";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contrato";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.vistaContrato_FormClosing);
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.Label lblFInicio;
        private System.Windows.Forms.DateTimePicker dateFInicio;
        private System.Windows.Forms.DateTimePicker dateFVenc;
        private System.Windows.Forms.Label lblFVenc;
        private System.Windows.Forms.DateTimePicker dateFUltimo;
        private System.Windows.Forms.Label lblFUltimo;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblInmueble;
        private System.Windows.Forms.ComboBox comboInmueble;
        private System.Windows.Forms.Label lblInquilino;
        private System.Windows.Forms.ComboBox comboInquilino;
    }
}
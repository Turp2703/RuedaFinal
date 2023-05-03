namespace RuedaFinal.Vistas
{
    partial class vistaInmueble
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
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panelInmueble = new System.Windows.Forms.Panel();
            this.chckGaraje = new System.Windows.Forms.CheckBox();
            this.chckPatio = new System.Windows.Forms.CheckBox();
            this.numBanos = new System.Windows.Forms.NumericUpDown();
            this.lblBanos = new System.Windows.Forms.Label();
            this.numDormitorios = new System.Windows.Forms.NumericUpDown();
            this.lblDormitorios = new System.Windows.Forms.Label();
            this.numPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.comboPropietario = new System.Windows.Forms.ComboBox();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.comboLocalidad = new System.Windows.Forms.ComboBox();
            this.numCantAmbientes = new System.Windows.Forms.NumericUpDown();
            this.lblCantAmbientes = new System.Windows.Forms.Label();
            this.lblM2 = new System.Windows.Forms.Label();
            this.numSuperficie = new System.Windows.Forms.NumericUpDown();
            this.lblSuperficie = new System.Windows.Forms.Label();
            this.numDirNum = new System.Windows.Forms.NumericUpDown();
            this.txtDirCalle = new System.Windows.Forms.TextBox();
            this.lblDirNum = new System.Windows.Forms.Label();
            this.lblDirCalle = new System.Windows.Forms.Label();
            this.txtNumPartida = new System.Windows.Forms.TextBox();
            this.lblNumPartida = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.panelInmueble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBanos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDormitorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantAmbientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuperficie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Image = global::RuedaFinal.Properties.Resources.iconRefre;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.Location = new System.Drawing.Point(51, 404);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(140, 65);
            this.btnBorrar.TabIndex = 14;
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
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // panelInmueble
            // 
            this.panelInmueble.AutoScroll = true;
            this.panelInmueble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInmueble.Controls.Add(this.chckGaraje);
            this.panelInmueble.Controls.Add(this.chckPatio);
            this.panelInmueble.Controls.Add(this.numBanos);
            this.panelInmueble.Controls.Add(this.lblBanos);
            this.panelInmueble.Controls.Add(this.numDormitorios);
            this.panelInmueble.Controls.Add(this.lblDormitorios);
            this.panelInmueble.Controls.Add(this.numPrecioVenta);
            this.panelInmueble.Controls.Add(this.lblPrecioVenta);
            this.panelInmueble.Controls.Add(this.lblPropietario);
            this.panelInmueble.Controls.Add(this.comboPropietario);
            this.panelInmueble.Controls.Add(this.lblCodigoPostal);
            this.panelInmueble.Controls.Add(this.comboLocalidad);
            this.panelInmueble.Controls.Add(this.numCantAmbientes);
            this.panelInmueble.Controls.Add(this.lblCantAmbientes);
            this.panelInmueble.Controls.Add(this.lblM2);
            this.panelInmueble.Controls.Add(this.numSuperficie);
            this.panelInmueble.Controls.Add(this.lblSuperficie);
            this.panelInmueble.Controls.Add(this.numDirNum);
            this.panelInmueble.Controls.Add(this.txtDirCalle);
            this.panelInmueble.Controls.Add(this.lblDirNum);
            this.panelInmueble.Controls.Add(this.lblDirCalle);
            this.panelInmueble.Controls.Add(this.txtNumPartida);
            this.panelInmueble.Controls.Add(this.lblNumPartida);
            this.panelInmueble.Controls.Add(this.txtDescripcion);
            this.panelInmueble.Controls.Add(this.lblDescripcion);
            this.panelInmueble.Location = new System.Drawing.Point(12, 12);
            this.panelInmueble.Name = "panelInmueble";
            this.panelInmueble.Size = new System.Drawing.Size(360, 381);
            this.panelInmueble.TabIndex = 21;
            // 
            // chckGaraje
            // 
            this.chckGaraje.AutoSize = true;
            this.chckGaraje.Location = new System.Drawing.Point(190, 651);
            this.chckGaraje.Name = "chckGaraje";
            this.chckGaraje.Size = new System.Drawing.Size(101, 28);
            this.chckGaraje.TabIndex = 11;
            this.chckGaraje.Text = "Garaje";
            this.chckGaraje.UseVisualStyleBackColor = true;
            // 
            // chckPatio
            // 
            this.chckPatio.AutoSize = true;
            this.chckPatio.Location = new System.Drawing.Point(38, 651);
            this.chckPatio.Name = "chckPatio";
            this.chckPatio.Size = new System.Drawing.Size(89, 28);
            this.chckPatio.TabIndex = 10;
            this.chckPatio.Text = "Patio";
            this.chckPatio.UseVisualStyleBackColor = true;
            // 
            // numBanos
            // 
            this.numBanos.Location = new System.Drawing.Point(9, 613);
            this.numBanos.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numBanos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBanos.Name = "numBanos";
            this.numBanos.Size = new System.Drawing.Size(323, 32);
            this.numBanos.TabIndex = 9;
            this.numBanos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBanos
            // 
            this.lblBanos.AutoSize = true;
            this.lblBanos.Location = new System.Drawing.Point(5, 581);
            this.lblBanos.Margin = new System.Windows.Forms.Padding(5);
            this.lblBanos.Name = "lblBanos";
            this.lblBanos.Size = new System.Drawing.Size(214, 24);
            this.lblBanos.TabIndex = 31;
            this.lblBanos.Text = "Cantidad de Baños";
            // 
            // numDormitorios
            // 
            this.numDormitorios.Location = new System.Drawing.Point(9, 541);
            this.numDormitorios.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numDormitorios.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDormitorios.Name = "numDormitorios";
            this.numDormitorios.Size = new System.Drawing.Size(323, 32);
            this.numDormitorios.TabIndex = 8;
            this.numDormitorios.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDormitorios
            // 
            this.lblDormitorios.AutoSize = true;
            this.lblDormitorios.Location = new System.Drawing.Point(5, 509);
            this.lblDormitorios.Margin = new System.Windows.Forms.Padding(5);
            this.lblDormitorios.Name = "lblDormitorios";
            this.lblDormitorios.Size = new System.Drawing.Size(286, 24);
            this.lblDormitorios.TabIndex = 29;
            this.lblDormitorios.Text = "Cantidad de Dormitorios";
            // 
            // numPrecioVenta
            // 
            this.numPrecioVenta.Location = new System.Drawing.Point(9, 325);
            this.numPrecioVenta.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPrecioVenta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrecioVenta.Name = "numPrecioVenta";
            this.numPrecioVenta.Size = new System.Drawing.Size(323, 32);
            this.numPrecioVenta.TabIndex = 5;
            this.numPrecioVenta.ThousandsSeparator = true;
            this.numPrecioVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(5, 293);
            this.lblPrecioVenta.Margin = new System.Windows.Forms.Padding(5);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(286, 24);
            this.lblPrecioVenta.TabIndex = 27;
            this.lblPrecioVenta.Text = "Precio de Venta (ARS $)";
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Location = new System.Drawing.Point(5, 687);
            this.lblPropietario.Margin = new System.Windows.Forms.Padding(5);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(238, 24);
            this.lblPropietario.TabIndex = 26;
            this.lblPropietario.Text = "DNI del Propietario";
            // 
            // comboPropietario
            // 
            this.comboPropietario.FormattingEnabled = true;
            this.comboPropietario.Location = new System.Drawing.Point(9, 719);
            this.comboPropietario.Name = "comboPropietario";
            this.comboPropietario.Size = new System.Drawing.Size(323, 32);
            this.comboPropietario.TabIndex = 12;
            this.comboPropietario.DropDown += new System.EventHandler(this.comboPropietario_DropDown);
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(5, 759);
            this.lblCodigoPostal.Margin = new System.Windows.Forms.Padding(5);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(166, 24);
            this.lblCodigoPostal.TabIndex = 24;
            this.lblCodigoPostal.Text = "Codigo Postal";
            // 
            // comboLocalidad
            // 
            this.comboLocalidad.FormattingEnabled = true;
            this.comboLocalidad.Location = new System.Drawing.Point(9, 791);
            this.comboLocalidad.Name = "comboLocalidad";
            this.comboLocalidad.Size = new System.Drawing.Size(323, 32);
            this.comboLocalidad.TabIndex = 13;
            this.comboLocalidad.DropDown += new System.EventHandler(this.comboLocalidad_DropDown);
            // 
            // numCantAmbientes
            // 
            this.numCantAmbientes.Location = new System.Drawing.Point(9, 469);
            this.numCantAmbientes.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numCantAmbientes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantAmbientes.Name = "numCantAmbientes";
            this.numCantAmbientes.Size = new System.Drawing.Size(323, 32);
            this.numCantAmbientes.TabIndex = 7;
            this.numCantAmbientes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCantAmbientes
            // 
            this.lblCantAmbientes.AutoSize = true;
            this.lblCantAmbientes.Location = new System.Drawing.Point(5, 437);
            this.lblCantAmbientes.Margin = new System.Windows.Forms.Padding(5);
            this.lblCantAmbientes.Name = "lblCantAmbientes";
            this.lblCantAmbientes.Size = new System.Drawing.Size(262, 24);
            this.lblCantAmbientes.TabIndex = 21;
            this.lblCantAmbientes.Text = "Cantidad de Ambientes";
            // 
            // lblM2
            // 
            this.lblM2.AutoSize = true;
            this.lblM2.Location = new System.Drawing.Point(286, 399);
            this.lblM2.Margin = new System.Windows.Forms.Padding(5);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(46, 24);
            this.lblM2.TabIndex = 20;
            this.lblM2.Text = "m^2";
            // 
            // numSuperficie
            // 
            this.numSuperficie.Location = new System.Drawing.Point(9, 397);
            this.numSuperficie.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSuperficie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSuperficie.Name = "numSuperficie";
            this.numSuperficie.Size = new System.Drawing.Size(269, 32);
            this.numSuperficie.TabIndex = 6;
            this.numSuperficie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSuperficie
            // 
            this.lblSuperficie.AutoSize = true;
            this.lblSuperficie.Location = new System.Drawing.Point(5, 365);
            this.lblSuperficie.Margin = new System.Windows.Forms.Padding(5);
            this.lblSuperficie.Name = "lblSuperficie";
            this.lblSuperficie.Size = new System.Drawing.Size(130, 24);
            this.lblSuperficie.TabIndex = 18;
            this.lblSuperficie.Text = "Superficie";
            // 
            // numDirNum
            // 
            this.numDirNum.Location = new System.Drawing.Point(9, 253);
            this.numDirNum.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numDirNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDirNum.Name = "numDirNum";
            this.numDirNum.Size = new System.Drawing.Size(323, 32);
            this.numDirNum.TabIndex = 4;
            this.numDirNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDirCalle
            // 
            this.txtDirCalle.Location = new System.Drawing.Point(9, 181);
            this.txtDirCalle.MaxLength = 50;
            this.txtDirCalle.Name = "txtDirCalle";
            this.txtDirCalle.Size = new System.Drawing.Size(323, 32);
            this.txtDirCalle.TabIndex = 3;
            // 
            // lblDirNum
            // 
            this.lblDirNum.AutoSize = true;
            this.lblDirNum.Location = new System.Drawing.Point(5, 221);
            this.lblDirNum.Margin = new System.Windows.Forms.Padding(5);
            this.lblDirNum.Name = "lblDirNum";
            this.lblDirNum.Size = new System.Drawing.Size(226, 24);
            this.lblDirNum.TabIndex = 15;
            this.lblDirNum.Text = "Direccion - Numero";
            // 
            // lblDirCalle
            // 
            this.lblDirCalle.AutoSize = true;
            this.lblDirCalle.Location = new System.Drawing.Point(5, 149);
            this.lblDirCalle.Margin = new System.Windows.Forms.Padding(5);
            this.lblDirCalle.Name = "lblDirCalle";
            this.lblDirCalle.Size = new System.Drawing.Size(214, 24);
            this.lblDirCalle.TabIndex = 14;
            this.lblDirCalle.Text = "Direccion - Calle";
            // 
            // txtNumPartida
            // 
            this.txtNumPartida.Location = new System.Drawing.Point(9, 109);
            this.txtNumPartida.MaxLength = 20;
            this.txtNumPartida.Name = "txtNumPartida";
            this.txtNumPartida.Size = new System.Drawing.Size(323, 32);
            this.txtNumPartida.TabIndex = 2;
            // 
            // lblNumPartida
            // 
            this.lblNumPartida.AutoSize = true;
            this.lblNumPartida.Location = new System.Drawing.Point(5, 77);
            this.lblNumPartida.Margin = new System.Windows.Forms.Padding(5);
            this.lblNumPartida.Name = "lblNumPartida";
            this.lblNumPartida.Size = new System.Drawing.Size(214, 24);
            this.lblNumPartida.TabIndex = 12;
            this.lblNumPartida.Text = "Numero de Partida";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(9, 37);
            this.txtDescripcion.MaxLength = 60;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(323, 32);
            this.txtDescripcion.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(5, 5);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(5);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(142, 24);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // vistaInmueble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 481);
            this.Controls.Add(this.panelInmueble);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnConfirmar);
            this.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "vistaInmueble";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inmueble";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.vistaInmueble_FormClosing);
            this.panelInmueble.ResumeLayout(false);
            this.panelInmueble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBanos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDormitorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantAmbientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSuperficie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDirNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panelInmueble;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.ComboBox comboPropietario;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.ComboBox comboLocalidad;
        private System.Windows.Forms.NumericUpDown numCantAmbientes;
        private System.Windows.Forms.Label lblCantAmbientes;
        private System.Windows.Forms.Label lblM2;
        private System.Windows.Forms.NumericUpDown numSuperficie;
        private System.Windows.Forms.Label lblSuperficie;
        private System.Windows.Forms.NumericUpDown numDirNum;
        private System.Windows.Forms.TextBox txtDirCalle;
        private System.Windows.Forms.Label lblDirNum;
        private System.Windows.Forms.Label lblDirCalle;
        private System.Windows.Forms.TextBox txtNumPartida;
        private System.Windows.Forms.Label lblNumPartida;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.NumericUpDown numPrecioVenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.NumericUpDown numBanos;
        private System.Windows.Forms.Label lblBanos;
        private System.Windows.Forms.NumericUpDown numDormitorios;
        private System.Windows.Forms.Label lblDormitorios;
        private System.Windows.Forms.CheckBox chckPatio;
        private System.Windows.Forms.CheckBox chckGaraje;
    }
}
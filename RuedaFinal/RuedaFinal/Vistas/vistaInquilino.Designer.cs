
namespace RuedaFinal.Vistas
{
    partial class vistaInquilino
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
            this.numVehiculos = new System.Windows.Forms.NumericUpDown();
            this.lblSepararEmails = new System.Windows.Forms.Label();
            this.lblSepararTelefonos = new System.Windows.Forms.Label();
            this.txtEMails = new System.Windows.Forms.TextBox();
            this.lblEMails = new System.Windows.Forms.Label();
            this.txtTelefonos = new System.Windows.Forms.TextBox();
            this.lblTelefonos = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblFNac = new System.Windows.Forms.Label();
            this.comboLocalidad = new System.Windows.Forms.ComboBox();
            this.lblCantVehiculos = new System.Windows.Forms.Label();
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.dateFNac = new System.Windows.Forms.DateTimePicker();
            this.grpbxSexo = new System.Windows.Forms.GroupBox();
            this.rdbMujer = new System.Windows.Forms.RadioButton();
            this.rdbHombre = new System.Windows.Forms.RadioButton();
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.numDNI = new System.Windows.Forms.NumericUpDown();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVehiculos)).BeginInit();
            this.grpbxSexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDNI)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCliente
            // 
            this.panelCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCliente.AutoScroll = true;
            this.panelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCliente.Controls.Add(this.numVehiculos);
            this.panelCliente.Controls.Add(this.lblSepararEmails);
            this.panelCliente.Controls.Add(this.lblSepararTelefonos);
            this.panelCliente.Controls.Add(this.txtEMails);
            this.panelCliente.Controls.Add(this.lblEMails);
            this.panelCliente.Controls.Add(this.txtTelefonos);
            this.panelCliente.Controls.Add(this.lblTelefonos);
            this.panelCliente.Controls.Add(this.lblLocalidad);
            this.panelCliente.Controls.Add(this.lblFNac);
            this.panelCliente.Controls.Add(this.comboLocalidad);
            this.panelCliente.Controls.Add(this.lblCantVehiculos);
            this.panelCliente.Controls.Add(this.lblOcupacion);
            this.panelCliente.Controls.Add(this.lblApellido);
            this.panelCliente.Controls.Add(this.lblNombre);
            this.panelCliente.Controls.Add(this.lblDNI);
            this.panelCliente.Controls.Add(this.dateFNac);
            this.panelCliente.Controls.Add(this.grpbxSexo);
            this.panelCliente.Controls.Add(this.txtOcupacion);
            this.panelCliente.Controls.Add(this.txtApellido);
            this.panelCliente.Controls.Add(this.txtNombre);
            this.panelCliente.Controls.Add(this.numDNI);
            this.panelCliente.Location = new System.Drawing.Point(12, 12);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(360, 381);
            this.panelCliente.TabIndex = 20;
            // 
            // numVehiculos
            // 
            this.numVehiculos.Location = new System.Drawing.Point(6, 320);
            this.numVehiculos.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numVehiculos.Name = "numVehiculos";
            this.numVehiculos.Size = new System.Drawing.Size(323, 32);
            this.numVehiculos.TabIndex = 4;
            // 
            // lblSepararEmails
            // 
            this.lblSepararEmails.AutoSize = true;
            this.lblSepararEmails.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSepararEmails.Location = new System.Drawing.Point(208, 645);
            this.lblSepararEmails.Name = "lblSepararEmails";
            this.lblSepararEmails.Size = new System.Drawing.Size(121, 13);
            this.lblSepararEmails.TabIndex = 21;
            this.lblSepararEmails.Text = "(separar con comas)";
            // 
            // lblSepararTelefonos
            // 
            this.lblSepararTelefonos.AutoSize = true;
            this.lblSepararTelefonos.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSepararTelefonos.Location = new System.Drawing.Point(208, 583);
            this.lblSepararTelefonos.Name = "lblSepararTelefonos";
            this.lblSepararTelefonos.Size = new System.Drawing.Size(121, 13);
            this.lblSepararTelefonos.TabIndex = 20;
            this.lblSepararTelefonos.Text = "(separar con comas)";
            // 
            // txtEMails
            // 
            this.txtEMails.Location = new System.Drawing.Point(6, 661);
            this.txtEMails.Name = "txtEMails";
            this.txtEMails.Size = new System.Drawing.Size(323, 32);
            this.txtEMails.TabIndex = 19;
            // 
            // lblEMails
            // 
            this.lblEMails.AutoSize = true;
            this.lblEMails.Location = new System.Drawing.Point(5, 634);
            this.lblEMails.Name = "lblEMails";
            this.lblEMails.Size = new System.Drawing.Size(94, 24);
            this.lblEMails.TabIndex = 18;
            this.lblEMails.Text = "E-Mails";
            // 
            // txtTelefonos
            // 
            this.txtTelefonos.Location = new System.Drawing.Point(6, 599);
            this.txtTelefonos.Name = "txtTelefonos";
            this.txtTelefonos.Size = new System.Drawing.Size(323, 32);
            this.txtTelefonos.TabIndex = 17;
            // 
            // lblTelefonos
            // 
            this.lblTelefonos.AutoSize = true;
            this.lblTelefonos.Location = new System.Drawing.Point(5, 572);
            this.lblTelefonos.Name = "lblTelefonos";
            this.lblTelefonos.Size = new System.Drawing.Size(118, 24);
            this.lblTelefonos.TabIndex = 16;
            this.lblTelefonos.Text = "Telefonos";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(2, 505);
            this.lblLocalidad.Margin = new System.Windows.Forms.Padding(5);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(118, 24);
            this.lblLocalidad.TabIndex = 15;
            this.lblLocalidad.Text = "Localidad";
            // 
            // lblFNac
            // 
            this.lblFNac.AutoSize = true;
            this.lblFNac.Location = new System.Drawing.Point(2, 433);
            this.lblFNac.Margin = new System.Windows.Forms.Padding(5);
            this.lblFNac.Name = "lblFNac";
            this.lblFNac.Size = new System.Drawing.Size(238, 24);
            this.lblFNac.TabIndex = 14;
            this.lblFNac.Text = "Fecha de Nacimiento";
            // 
            // comboLocalidad
            // 
            this.comboLocalidad.FormattingEnabled = true;
            this.comboLocalidad.Location = new System.Drawing.Point(6, 537);
            this.comboLocalidad.Name = "comboLocalidad";
            this.comboLocalidad.Size = new System.Drawing.Size(323, 32);
            this.comboLocalidad.TabIndex = 7;
            this.comboLocalidad.DropDown += new System.EventHandler(this.comboLocalidad_DropDown);
            // 
            // lblCantVehiculos
            // 
            this.lblCantVehiculos.AutoSize = true;
            this.lblCantVehiculos.Location = new System.Drawing.Point(2, 288);
            this.lblCantVehiculos.Margin = new System.Windows.Forms.Padding(5);
            this.lblCantVehiculos.Name = "lblCantVehiculos";
            this.lblCantVehiculos.Size = new System.Drawing.Size(262, 24);
            this.lblCantVehiculos.TabIndex = 13;
            this.lblCantVehiculos.Text = "Cantidad de Vehiculos";
            // 
            // lblOcupacion
            // 
            this.lblOcupacion.AutoSize = true;
            this.lblOcupacion.Location = new System.Drawing.Point(2, 216);
            this.lblOcupacion.Margin = new System.Windows.Forms.Padding(5);
            this.lblOcupacion.Name = "lblOcupacion";
            this.lblOcupacion.Size = new System.Drawing.Size(118, 24);
            this.lblOcupacion.TabIndex = 12;
            this.lblOcupacion.Text = "Ocupacion";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(2, 144);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(5);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(106, 24);
            this.lblApellido.TabIndex = 11;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(2, 72);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(5);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(82, 24);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(2, 5);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(5);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(46, 24);
            this.lblDNI.TabIndex = 9;
            this.lblDNI.Text = "DNI";
            // 
            // dateFNac
            // 
            this.dateFNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFNac.Location = new System.Drawing.Point(6, 465);
            this.dateFNac.Name = "dateFNac";
            this.dateFNac.Size = new System.Drawing.Size(326, 32);
            this.dateFNac.TabIndex = 6;
            // 
            // grpbxSexo
            // 
            this.grpbxSexo.Controls.Add(this.rdbMujer);
            this.grpbxSexo.Controls.Add(this.rdbHombre);
            this.grpbxSexo.Location = new System.Drawing.Point(6, 358);
            this.grpbxSexo.Name = "grpbxSexo";
            this.grpbxSexo.Size = new System.Drawing.Size(326, 67);
            this.grpbxSexo.TabIndex = 5;
            this.grpbxSexo.TabStop = false;
            this.grpbxSexo.Text = "Sexo";
            // 
            // rdbMujer
            // 
            this.rdbMujer.AutoSize = true;
            this.rdbMujer.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdbMujer.Location = new System.Drawing.Point(200, 28);
            this.rdbMujer.Name = "rdbMujer";
            this.rdbMujer.Padding = new System.Windows.Forms.Padding(0, 0, 35, 0);
            this.rdbMujer.Size = new System.Drawing.Size(123, 36);
            this.rdbMujer.TabIndex = 1;
            this.rdbMujer.TabStop = true;
            this.rdbMujer.Text = "Mujer";
            this.rdbMujer.UseVisualStyleBackColor = true;
            // 
            // rdbHombre
            // 
            this.rdbHombre.AutoSize = true;
            this.rdbHombre.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdbHombre.Location = new System.Drawing.Point(3, 28);
            this.rdbHombre.Name = "rdbHombre";
            this.rdbHombre.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.rdbHombre.Size = new System.Drawing.Size(135, 36);
            this.rdbHombre.TabIndex = 0;
            this.rdbHombre.TabStop = true;
            this.rdbHombre.Text = "Hombre";
            this.rdbHombre.UseVisualStyleBackColor = true;
            // 
            // txtOcupacion
            // 
            this.txtOcupacion.Location = new System.Drawing.Point(6, 248);
            this.txtOcupacion.MaxLength = 50;
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Size = new System.Drawing.Size(323, 32);
            this.txtOcupacion.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(6, 176);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(323, 32);
            this.txtApellido.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 104);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(323, 32);
            this.txtNombre.TabIndex = 1;
            // 
            // numDNI
            // 
            this.numDNI.Location = new System.Drawing.Point(6, 32);
            this.numDNI.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numDNI.Name = "numDNI";
            this.numDNI.Size = new System.Drawing.Size(326, 32);
            this.numDNI.TabIndex = 0;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Image = global::RuedaFinal.Properties.Resources.iconRefre;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.Location = new System.Drawing.Point(51, 404);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(140, 65);
            this.btnBorrar.TabIndex = 21;
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
            this.btnConfirmar.TabIndex = 22;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // vistaInquilino
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
            this.Name = "vistaInquilino";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inquilino";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.vistaInquilino_FormClosing);
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVehiculos)).EndInit();
            this.grpbxSexo.ResumeLayout(false);
            this.grpbxSexo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDNI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.Label lblSepararEmails;
        private System.Windows.Forms.Label lblSepararTelefonos;
        private System.Windows.Forms.TextBox txtEMails;
        private System.Windows.Forms.Label lblEMails;
        private System.Windows.Forms.TextBox txtTelefonos;
        private System.Windows.Forms.Label lblTelefonos;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblFNac;
        private System.Windows.Forms.ComboBox comboLocalidad;
        private System.Windows.Forms.Label lblCantVehiculos;
        private System.Windows.Forms.Label lblOcupacion;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.DateTimePicker dateFNac;
        private System.Windows.Forms.GroupBox grpbxSexo;
        private System.Windows.Forms.RadioButton rdbMujer;
        private System.Windows.Forms.RadioButton rdbHombre;
        private System.Windows.Forms.TextBox txtOcupacion;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown numDNI;
        private System.Windows.Forms.NumericUpDown numVehiculos;
    }
}
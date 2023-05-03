namespace RuedaFinal
{
    partial class vistaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vistaPrincipal));
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnOrdenar = new System.Windows.Forms.Button();
            this.lblSeparador1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCuentas = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.btnContratos = new System.Windows.Forms.Button();
            this.btnInquilinos = new System.Windows.Forms.Button();
            this.btnDuenos = new System.Windows.Forms.Button();
            this.btnInmuebles = new System.Windows.Forms.Button();
            this.pnlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.AutoScroll = true;
            this.pnlPrincipal.Controls.Add(this.lblUsuarioActual);
            this.pnlPrincipal.Controls.Add(this.btnManual);
            this.pnlPrincipal.Controls.Add(this.btnAcercaDe);
            this.pnlPrincipal.Controls.Add(this.btnCerrarSesion);
            this.pnlPrincipal.Controls.Add(this.btnSalir);
            this.pnlPrincipal.Controls.Add(this.btnCerrar);
            this.pnlPrincipal.Controls.Add(this.btnOrdenar);
            this.pnlPrincipal.Controls.Add(this.lblSeparador1);
            this.pnlPrincipal.Controls.Add(this.btnExportar);
            this.pnlPrincipal.Controls.Add(this.btnCuentas);
            this.pnlPrincipal.Controls.Add(this.btnLocalidades);
            this.pnlPrincipal.Controls.Add(this.btnContratos);
            this.pnlPrincipal.Controls.Add(this.btnInquilinos);
            this.pnlPrincipal.Controls.Add(this.btnDuenos);
            this.pnlPrincipal.Controls.Add(this.btnInmuebles);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(275, 681);
            this.pnlPrincipal.TabIndex = 1;
            this.pnlPrincipal.EnabledChanged += new System.EventHandler(this.pnlPrincipal_EnabledChanged);
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUsuarioActual.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUsuarioActual.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioActual.Location = new System.Drawing.Point(0, 511);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(275, 30);
            this.lblUsuarioActual.TabIndex = 16;
            this.lblUsuarioActual.Text = "Cuenta: debug";
            this.lblUsuarioActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManual
            // 
            this.btnManual.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnManual.Image = ((System.Drawing.Image)(resources.GetObject("btnManual.Image")));
            this.btnManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManual.Location = new System.Drawing.Point(0, 541);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(275, 35);
            this.btnManual.TabIndex = 12;
            this.btnManual.Text = "Manual de Usuario";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAcercaDe.Image = ((System.Drawing.Image)(resources.GetObject("btnAcercaDe.Image")));
            this.btnAcercaDe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcercaDe.Location = new System.Drawing.Point(0, 576);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(275, 35);
            this.btnAcercaDe.TabIndex = 13;
            this.btnAcercaDe.Text = "Acerca De";
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.btnAcercaDe_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 611);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(275, 35);
            this.btnCerrarSesion.TabIndex = 14;
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(0, 646);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(275, 35);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(0, 300);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(275, 35);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "Cerrar Ventanas";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrdenar.Image = ((System.Drawing.Image)(resources.GetObject("btnOrdenar.Image")));
            this.btnOrdenar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrdenar.Location = new System.Drawing.Point(0, 265);
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(275, 35);
            this.btnOrdenar.TabIndex = 9;
            this.btnOrdenar.Text = "Ordenar Ventanas";
            this.btnOrdenar.UseVisualStyleBackColor = true;
            this.btnOrdenar.Click += new System.EventHandler(this.btnOrdenar_Click);
            // 
            // lblSeparador1
            // 
            this.lblSeparador1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparador1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeparador1.Location = new System.Drawing.Point(0, 245);
            this.lblSeparador1.Name = "lblSeparador1";
            this.lblSeparador1.Size = new System.Drawing.Size(275, 20);
            this.lblSeparador1.TabIndex = 8;
            // 
            // btnExportar
            // 
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(0, 210);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(275, 35);
            this.btnExportar.TabIndex = 7;
            this.btnExportar.Text = "Exportar Tabla";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCuentas
            // 
            this.btnCuentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCuentas.Image = ((System.Drawing.Image)(resources.GetObject("btnCuentas.Image")));
            this.btnCuentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCuentas.Location = new System.Drawing.Point(0, 175);
            this.btnCuentas.Name = "btnCuentas";
            this.btnCuentas.Size = new System.Drawing.Size(275, 35);
            this.btnCuentas.TabIndex = 6;
            this.btnCuentas.Text = "Cuentas";
            this.btnCuentas.UseVisualStyleBackColor = true;
            this.btnCuentas.Click += new System.EventHandler(this.btnCuentas_Click);
            // 
            // btnLocalidades
            // 
            this.btnLocalidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLocalidades.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalidades.Image")));
            this.btnLocalidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalidades.Location = new System.Drawing.Point(0, 140);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(275, 35);
            this.btnLocalidades.TabIndex = 5;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // btnContratos
            // 
            this.btnContratos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContratos.Image = ((System.Drawing.Image)(resources.GetObject("btnContratos.Image")));
            this.btnContratos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContratos.Location = new System.Drawing.Point(0, 105);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(275, 35);
            this.btnContratos.TabIndex = 4;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.UseVisualStyleBackColor = true;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnInquilinos
            // 
            this.btnInquilinos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInquilinos.Image = ((System.Drawing.Image)(resources.GetObject("btnInquilinos.Image")));
            this.btnInquilinos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInquilinos.Location = new System.Drawing.Point(0, 70);
            this.btnInquilinos.Name = "btnInquilinos";
            this.btnInquilinos.Size = new System.Drawing.Size(275, 35);
            this.btnInquilinos.TabIndex = 3;
            this.btnInquilinos.Text = "Inquilinos";
            this.btnInquilinos.UseVisualStyleBackColor = true;
            this.btnInquilinos.Click += new System.EventHandler(this.btnInquilinos_Click);
            // 
            // btnDuenos
            // 
            this.btnDuenos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuenos.Image = ((System.Drawing.Image)(resources.GetObject("btnDuenos.Image")));
            this.btnDuenos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDuenos.Location = new System.Drawing.Point(0, 35);
            this.btnDuenos.Name = "btnDuenos";
            this.btnDuenos.Size = new System.Drawing.Size(275, 35);
            this.btnDuenos.TabIndex = 2;
            this.btnDuenos.Text = "Dueños";
            this.btnDuenos.UseVisualStyleBackColor = true;
            this.btnDuenos.Click += new System.EventHandler(this.btnDuenos_Click);
            // 
            // btnInmuebles
            // 
            this.btnInmuebles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInmuebles.Image = ((System.Drawing.Image)(resources.GetObject("btnInmuebles.Image")));
            this.btnInmuebles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInmuebles.Location = new System.Drawing.Point(0, 0);
            this.btnInmuebles.Name = "btnInmuebles";
            this.btnInmuebles.Size = new System.Drawing.Size(275, 35);
            this.btnInmuebles.TabIndex = 1;
            this.btnInmuebles.Text = "Inmuebles";
            this.btnInmuebles.UseVisualStyleBackColor = true;
            this.btnInmuebles.Click += new System.EventHandler(this.btnInmuebles_Click);
            // 
            // vistaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pnlPrincipal);
            this.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1024, 576);
            this.Name = "vistaPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RuedaFinal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.vistaPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.vistaPrincipal_Load);
            this.pnlPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnInmuebles;
        private System.Windows.Forms.Button btnCuentas;
        private System.Windows.Forms.Button btnLocalidades;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.Button btnInquilinos;
        private System.Windows.Forms.Button btnDuenos;
        private System.Windows.Forms.Label lblSeparador1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnOrdenar;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnAcercaDe;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.Button btnSalir;
    }
}


namespace RuedaFinal.Vistas
{
    partial class vistaLocalidades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.dataGridLocalidades = new System.Windows.Forms.DataGridView();
            this.Codigo_Postal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Filler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLocalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(24, 28);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(166, 24);
            this.lblCantidad.TabIndex = 2;
            this.lblCantidad.Text = "X Localidades";
            // 
            // btnAlta
            // 
            this.btnAlta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlta.Image = global::RuedaFinal.Properties.Resources.iconAlta;
            this.btnAlta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlta.Location = new System.Drawing.Point(385, 12);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(330, 56);
            this.btnAlta.TabIndex = 5;
            this.btnAlta.Text = "Añadir nueva Localidad";
            this.btnAlta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // dataGridLocalidades
            // 
            this.dataGridLocalidades.AllowUserToAddRows = false;
            this.dataGridLocalidades.AllowUserToDeleteRows = false;
            this.dataGridLocalidades.AllowUserToResizeColumns = false;
            this.dataGridLocalidades.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dataGridLocalidades.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridLocalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridLocalidades.BackgroundColor = System.Drawing.Color.White;
            this.dataGridLocalidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridLocalidades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridLocalidades.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridLocalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLocalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo_Postal,
            this.Nombre,
            this.Modificar,
            this.Eliminar,
            this.Filler});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridLocalidades.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridLocalidades.EnableHeadersVisualStyles = false;
            this.dataGridLocalidades.GridColor = System.Drawing.Color.White;
            this.dataGridLocalidades.Location = new System.Drawing.Point(19, 74);
            this.dataGridLocalidades.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.dataGridLocalidades.Name = "dataGridLocalidades";
            this.dataGridLocalidades.ReadOnly = true;
            this.dataGridLocalidades.RowHeadersVisible = false;
            this.dataGridLocalidades.RowTemplate.Height = 42;
            this.dataGridLocalidades.Size = new System.Drawing.Size(696, 348);
            this.dataGridLocalidades.TabIndex = 6;
            this.dataGridLocalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLocalidades_CellContentClick);
            this.dataGridLocalidades.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridLocalidades_CellPainting);
            // 
            // Codigo_Postal
            // 
            this.Codigo_Postal.HeaderText = "Codigo Postal";
            this.Codigo_Postal.Name = "Codigo_Postal";
            this.Codigo_Postal.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Text = "";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "";
            // 
            // Filler
            // 
            this.Filler.HeaderText = "";
            this.Filler.Name = "Filler";
            this.Filler.ReadOnly = true;
            this.Filler.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Filler.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vistaLocalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(734, 441);
            this.Controls.Add(this.dataGridLocalidades);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.lblCantidad);
            this.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "vistaLocalidades";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localidades";
            this.Load += new System.EventHandler(this.vistaLocalidades_Load);
            this.SizeChanged += new System.EventHandler(this.vistaLocalidades_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLocalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.DataGridView dataGridLocalidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Postal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filler;
    }
}
using RuedaFinal.Controladores;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuedaFinal.Vistas
{
    public partial class vistaLocalidades : Form
    {
        private Localidad[] localidades;

        public vistaLocalidades()
        {
            InitializeComponent();
        }

        private void vistaLocalidades_Load(object sender, EventArgs e) { refrescar(); }
        public void refrescar()
        {
            temaColores.ElegirTema("rojo");
            ForeColor = temaColores.Fuente;
            BackColor = temaColores.Fondo;
            btnAlta.ForeColor = Color.Black;
            dataGridLocalidades.BackgroundColor = temaColores.Paneles;
            dataGridLocalidades.ColumnHeadersDefaultCellStyle.BackColor = temaColores.Paneles;
            dataGridLocalidades.ColumnHeadersDefaultCellStyle.ForeColor = temaColores.Fuente;
            dataGridLocalidades.RowsDefaultCellStyle.BackColor = temaColores.Fila;
            dataGridLocalidades.AlternatingRowsDefaultCellStyle.BackColor = temaColores.FilaAlt;

            dataGridLocalidades.Sort(dataGridLocalidades.Columns[0], ListSortDirection.Ascending);
            dataGridLocalidades.Rows.Clear();
            controlLocalidades control = new controlLocalidades();
            localidades = control.listaLocalidades();
            if (localidades != null)
            {
                foreach (Localidad localidad in localidades)
                {
                    int n = dataGridLocalidades.Rows.Add();
                    dataGridLocalidades.Rows[n].Cells[0].Value = localidad.CodigoPostal;
                    dataGridLocalidades.Rows[n].Cells[1].Value = localidad.Nombre;
                }
            }
            lblCantidad.Text = dataGridLocalidades.Rows.Count + " Localidades";
            refrescarSize();
        }
        private void refrescarSize()
        {
            int cantCols = dataGridLocalidades.Columns.Count;
            for (int i = 0; i < cantCols - 1; i++)
            {
                dataGridLocalidades.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridLocalidades.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int fillerw = dataGridLocalidades.Columns[cantCols - 1].Width;
            for (int i = 0; i < cantCols - 1; i++)
            {
                int colw = dataGridLocalidades.Columns[i].Width;
                dataGridLocalidades.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridLocalidades.Columns[i].Width = colw + fillerw / (cantCols - 1);
            }
            fillerw = dataGridLocalidades.Columns[cantCols - 1].Width;
            dataGridLocalidades.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridLocalidades.Columns[cantCols - 1].Width = fillerw;
        }
        private void vistaLocalidades_SizeChanged(object sender, EventArgs e){ refrescarSize(); }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Enabled = false;
            vistaLocalidad vLocalidad = new vistaLocalidad(this, "alta") { MdiParent = MdiParent };
            vLocalidad.Show();
            vLocalidad.Focus();
        }

        private void dataGridLocalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridLocalidades.Columns.Count - 3)
            {
                DataGridViewRow registro = dataGridLocalidades.Rows[e.RowIndex];
                Localidad locOriginal = new Localidad
                {
                    CodigoPostal = registro.Cells[0].Value.ToString(),
                    Nombre = registro.Cells[1].Value.ToString()
                };


                Enabled = false;
                vistaLocalidad vLocalidad = new vistaLocalidad(this, "modif", locOriginal) { MdiParent = MdiParent };
                vLocalidad.Show();
                vLocalidad.Focus();
            }
            else if (e.ColumnIndex == dataGridLocalidades.Columns.Count - 2)
            {
                DataGridViewRow registro = dataGridLocalidades.Rows[e.RowIndex];
                Localidad loc = new Localidad
                {
                    CodigoPostal = registro.Cells[0].Value.ToString(),
                    Nombre = registro.Cells[1].Value.ToString()
                };

                DialogResult = MessageBox.Show("¿Esta completamente seguro de que quiere eliminar la localidad " + loc.CodigoPostal + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    controlLocalidades control = new controlLocalidades();
                    string rtaCtrl = control.bajaLocalidad(loc);
                    if (rtaCtrl == "Exitosa") { refrescar(); }
                    else
                    {
                        MessageBox.Show(rtaCtrl, "Error al eliminar localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridLocalidades_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridLocalidades.Columns.Count - 3) { iconoBotones(e, Properties.Resources.iconModif); }
            else if (e.ColumnIndex == dataGridLocalidades.Columns.Count - 2) { iconoBotones(e, Properties.Resources.iconBaja); }
        }
        private void iconoBotones(DataGridViewCellPaintingEventArgs e, Bitmap icono)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            var w = icono.Width - 20;
            var h = icono.Height - 20;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            e.Graphics.DrawImage(icono, new Rectangle(x, y, w, h));
            e.Handled = true;
        }
    }
}

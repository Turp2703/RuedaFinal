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
    public partial class vistaInquilinos : Form
    {
        private Inquilino[] inquilinos;
        private string campoBusqueda;

        public vistaInquilinos()
        {
            InitializeComponent();
            comboBusqueda.Items.Add("DNI");
            comboBusqueda.Items.Add("Nombre");
            comboBusqueda.Items.Add("Apellido");
            comboBusqueda.SelectedIndex = 0;
        }

        private void vistaInquilinos_Load(object sender, EventArgs e) { refrescar(); }
        public void refrescar()
        {
            temaColores.ElegirTema("amarillo");
            ForeColor = temaColores.Fuente;
            BackColor = temaColores.Fondo;
            btnAlta.ForeColor = Color.Black;
            dataGridInquilinos.BackgroundColor = temaColores.Paneles;
            dataGridInquilinos.ColumnHeadersDefaultCellStyle.BackColor = temaColores.Paneles;
            dataGridInquilinos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridInquilinos.RowsDefaultCellStyle.BackColor = temaColores.Fila;
            dataGridInquilinos.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridInquilinos.AlternatingRowsDefaultCellStyle.BackColor = temaColores.FilaAlt;


            dataGridInquilinos.DataSource = null;
            dataGridInquilinos.Rows.Clear();
            dataGridInquilinos.Sort(dataGridInquilinos.Columns[0], ListSortDirection.Ascending);
            controlInquilinos control = new controlInquilinos();
            inquilinos = control.listaInquilinos();
            if (inquilinos != null)
            {
                foreach (Inquilino inquilino in inquilinos)
                {
                    int n = dataGridInquilinos.Rows.Add();
                    dataGridInquilinos.Rows[n].Cells[0].Value = inquilino.DNI;
                    dataGridInquilinos.Rows[n].Cells[1].Value = inquilino.Nombre;
                    dataGridInquilinos.Rows[n].Cells[2].Value = inquilino.Apellido;
                }
            }
            lblCantidad.Text = dataGridInquilinos.Rows.Count + " Inquilinos";
            refrescarSize();
        }
        private void refrescarSize()
        {
            int cantCols = dataGridInquilinos.Columns.Count;
            for (int i = 0; i < cantCols - 1; i++)
            {
                dataGridInquilinos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridInquilinos.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int fillerw = dataGridInquilinos.Columns[cantCols - 1].Width;
            for (int i = 0; i < cantCols - 1; i++)
            {
                int colw = dataGridInquilinos.Columns[i].Width;
                dataGridInquilinos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridInquilinos.Columns[i].Width = colw + fillerw / (cantCols - 1);
            }
            fillerw = dataGridInquilinos.Columns[cantCols - 1].Width;
            dataGridInquilinos.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridInquilinos.Columns[cantCols - 1].Width = fillerw;
        }
        private void vistaInquilinos_SizeChanged(object sender, EventArgs e) { refrescarSize(); }
        
        private void btnAlta_Click(object sender, EventArgs e)
        {
            Enabled = false;
            vistaInquilino vInquilino = new vistaInquilino(this, "alta") { MdiParent = MdiParent };
            vInquilino.Show();
            vInquilino.Focus();
        }

        private void dataGridInquilinos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridInquilinos.Columns.Count - 2)
            {
                DataGridViewRow registro = dataGridInquilinos.Rows[e.RowIndex];
                string dni = registro.Cells[0].Value.ToString();
                string nombre = registro.Cells[1].Value.ToString();

                DialogResult = MessageBox.Show("¿Esta completamente seguro de que quiere eliminar al inquilino " + nombre + " (" + dni + ")?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    controlInquilinos control = new controlInquilinos();
                    string rtaCtrl = control.bajaInquilino(dni);
                    if (rtaCtrl == "Exitosa") { refrescar(); }
                    else
                    {
                        MessageBox.Show(rtaCtrl, "Error al eliminar inquilino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dataGridInquilinos.Columns.Count - 3 || e.ColumnIndex == dataGridInquilinos.Columns.Count - 4)
            {
                refrescar();
                DataGridViewRow registro = dataGridInquilinos.Rows[e.RowIndex];
                controlInquilinos control = new controlInquilinos();
                string dni = registro.Cells[0].Value.ToString();
                Inquilino inqui = Array.Find(inquilinos, inq => inq.DNI == dni);
                string operacion = e.ColumnIndex == dataGridInquilinos.Columns.Count - 3 ? "modif" : "ver";

                Enabled = false;
                vistaInquilino vInquilino = new vistaInquilino(this, operacion, inqui) { MdiParent = MdiParent };
                vInquilino.Show();
                vInquilino.Focus();
            }
        }

        private void dataGridInquilinos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridInquilinos.Columns.Count - 4) { iconoBotones(e, Properties.Resources.iconVer); }
            else if (e.ColumnIndex == dataGridInquilinos.Columns.Count - 3) { iconoBotones(e, Properties.Resources.iconModif); }
            else if (e.ColumnIndex == dataGridInquilinos.Columns.Count - 2) { iconoBotones(e, Properties.Resources.iconBaja); }
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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

            if (txtBusqueda.Text != string.Empty)
            {
                foreach (DataGridViewRow row in dataGridInquilinos.Rows)
                {
                    if (row.Cells[campoBusqueda].Value.ToString().Trim().ToLower().Contains(txtBusqueda.Text.Trim().ToLower()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                refrescar();
            }
        }

        private void comboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            campoBusqueda = comboBusqueda.SelectedItem.ToString();
        }
    }
}

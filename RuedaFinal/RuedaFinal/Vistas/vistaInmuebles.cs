using RuedaFinal.Controladores;
using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
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
    public partial class vistaInmuebles : Form
    {
        private Inmueble[] inmuebles;
        private string campoBusqueda;

        public vistaInmuebles()
        {
            InitializeComponent();
            comboBusqueda.Items.Add("ID");
            comboBusqueda.Items.Add("Numero_Partida");
            comboBusqueda.Items.Add("Direccion");
            comboBusqueda.SelectedIndex = 0;
        }

        private void vistaInmuebles_Load(object sender, EventArgs e) { refrescar(); }
        public void refrescar()
        {
            temaColores.ElegirTema("violeta");
            ForeColor = temaColores.Fuente;
            BackColor = temaColores.Fondo;
            btnAlta.ForeColor = Color.Black;
            dataGridInmuebles.BackgroundColor = temaColores.Paneles;
            dataGridInmuebles.ColumnHeadersDefaultCellStyle.BackColor = temaColores.Paneles;
            dataGridInmuebles.ColumnHeadersDefaultCellStyle.ForeColor = temaColores.Fuente;
            dataGridInmuebles.RowsDefaultCellStyle.BackColor = temaColores.Fila;
            dataGridInmuebles.AlternatingRowsDefaultCellStyle.BackColor = temaColores.FilaAlt;

            dataGridInmuebles.DataSource = null;
            dataGridInmuebles.Rows.Clear();
            dataGridInmuebles.Sort(dataGridInmuebles.Columns[0], ListSortDirection.Ascending);
            controlInmuebles control = new controlInmuebles();
            inmuebles = control.listaInmuebles();
            if (inmuebles != null)
            {
                foreach (Inmueble inm in inmuebles)
                {
                    int n = dataGridInmuebles.Rows.Add();
                    dataGridInmuebles.Rows[n].Cells[0].Value = inm.ID;
                    dataGridInmuebles.Rows[n].Cells[1].Value = inm.Numero_Partida;
                    dataGridInmuebles.Rows[n].Cells[2].Value = inm.Direccion_Calle + " " + inm.Direccion_Numero;
                }
            }
            lblCantidad.Text = dataGridInmuebles.Rows.Count + " Inmuebles";
            refrescarSize();
        }
        private void refrescarSize()
        {
            int cantCols = dataGridInmuebles.Columns.Count;
            for (int i = 0; i < cantCols - 1; i++)
            {
                dataGridInmuebles.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridInmuebles.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int fillerw = dataGridInmuebles.Columns[cantCols - 1].Width;
            for (int i = 0; i < cantCols - 1; i++)
            {
                int colw = dataGridInmuebles.Columns[i].Width;
                dataGridInmuebles.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridInmuebles.Columns[i].Width = colw + fillerw / (cantCols - 1);
            }
            fillerw = dataGridInmuebles.Columns[cantCols - 1].Width;
            dataGridInmuebles.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridInmuebles.Columns[cantCols - 1].Width = fillerw;
        }
        private void vistaInmuebles_SizeChanged(object sender, EventArgs e) { refrescarSize(); }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Enabled = false;
            vistaInmueble vInmueble = new vistaInmueble(this, "alta") { MdiParent = MdiParent };
            vInmueble.Show();
            vInmueble.Focus();
        }

        private void dataGridInmuebles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridInmuebles.Columns.Count - 2)
            {
                DataGridViewRow registro = dataGridInmuebles.Rows[e.RowIndex];
                int id = int.Parse(registro.Cells[0].Value.ToString());
                string partida = registro.Cells[1].Value.ToString();

                DialogResult = MessageBox.Show("¿Esta completamente seguro de que quiere eliminar el inmueble " + partida + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    controlInmuebles control = new controlInmuebles();
                    string rtaCtrl = control.bajaInmueble(id);
                    if (rtaCtrl == "Exitosa") { refrescar(); }
                    else
                    {
                        MessageBox.Show(rtaCtrl, "Error al eliminar inmueble", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dataGridInmuebles.Columns.Count - 3 || e.ColumnIndex == dataGridInmuebles.Columns.Count - 4)
            {
                refrescar();
                DataGridViewRow registro = dataGridInmuebles.Rows[e.RowIndex];
                controlInmuebles control = new controlInmuebles();
                int id = int.Parse(registro.Cells[0].Value.ToString());
                Inmueble inmueble = Array.Find(inmuebles, inm => inm.ID == id);
                string operacion = e.ColumnIndex == dataGridInmuebles.Columns.Count - 3 ? "modif" : "ver";

                Enabled = false;
                vistaInmueble vInmueble = new vistaInmueble(this, operacion, inmueble) { MdiParent = MdiParent };
                vInmueble.Show();
                vInmueble.Focus();
            }
        }

        private void dataGridInmuebles_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridInmuebles.Columns.Count - 4) { iconoBotones(e, Properties.Resources.iconVer); }
            else if (e.ColumnIndex == dataGridInmuebles.Columns.Count - 3) { iconoBotones(e, Properties.Resources.iconModif); }
            else if (e.ColumnIndex == dataGridInmuebles.Columns.Count - 2) { iconoBotones(e, Properties.Resources.iconBaja); }
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
                foreach (DataGridViewRow row in dataGridInmuebles.Rows)
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

        private void chckAlquilados_CheckedChanged(object sender, EventArgs e)
        {
            refrescar();
            foreach (DataGridViewRow row in dataGridInmuebles.Rows)
            {
                if (chckAlquilados.Checked)
                {
                    modeloInmuebles modelo = new modeloInmuebles();
                    row.Visible = modelo.estaEnContrato(int.Parse(row.Cells[0].Value.ToString().Trim()));
                }
                else
                {
                    row.Visible = true;
                }
            }
        }
    }
}

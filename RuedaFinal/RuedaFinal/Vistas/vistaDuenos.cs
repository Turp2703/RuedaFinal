using MySqlX.XDevAPI.Relational;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RuedaFinal.Vistas
{
    public partial class vistaDuenos : Form
    {
        private Dueno[] duenos;
        private string campoBusqueda;

        public vistaDuenos()
        {
            InitializeComponent();
            comboBusqueda.Items.Add("DNI");
            comboBusqueda.Items.Add("Nombre");
            comboBusqueda.Items.Add("Apellido");
            comboBusqueda.SelectedIndex = 0;
        }

        private void vistaDuenos_Load(object sender, EventArgs e) { refrescar(); }
        public void refrescar()
        {
            temaColores.ElegirTema("negro");
            ForeColor = temaColores.Fuente;
            BackColor = temaColores.Fondo;
            btnAlta.ForeColor = Color.Black;
            dataGridDuenos.BackgroundColor = temaColores.Paneles;
            dataGridDuenos.ColumnHeadersDefaultCellStyle.BackColor = temaColores.Paneles;
            dataGridDuenos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridDuenos.RowsDefaultCellStyle.BackColor = temaColores.Fila;
            dataGridDuenos.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridDuenos.AlternatingRowsDefaultCellStyle.BackColor = temaColores.FilaAlt;

            dataGridDuenos.DataSource = null;
            dataGridDuenos.Rows.Clear();
            dataGridDuenos.Sort(dataGridDuenos.Columns[0], ListSortDirection.Ascending);
            controlDuenos control = new controlDuenos();
            duenos = control.listaDuenos();
            if (duenos != null)
            {
                foreach (Dueno dueno in duenos)
                {
                    int n = dataGridDuenos.Rows.Add();
                    dataGridDuenos.Rows[n].Cells[0].Value = dueno.DNI;
                    dataGridDuenos.Rows[n].Cells[1].Value = dueno.Nombre;
                    dataGridDuenos.Rows[n].Cells[2].Value = dueno.Apellido;
                }
            }
            lblCantidad.Text = dataGridDuenos.Rows.Count + " Dueños";
            refrescarSize();
        }
        private void refrescarSize()
        {
            int cantCols = dataGridDuenos.Columns.Count;
            for (int i = 0; i < cantCols - 1; i++)
            {
                dataGridDuenos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridDuenos.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int fillerw = dataGridDuenos.Columns[cantCols - 1].Width;
            for (int i = 0; i < cantCols - 1; i++)
            {
                int colw = dataGridDuenos.Columns[i].Width;
                dataGridDuenos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridDuenos.Columns[i].Width = colw + fillerw / (cantCols - 1);
            }
            fillerw = dataGridDuenos.Columns[cantCols - 1].Width;
            dataGridDuenos.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridDuenos.Columns[cantCols - 1].Width = fillerw;
        }
        private void vistaDuenos_SizeChanged(object sender, EventArgs e) { refrescarSize(); }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Enabled = false;
            vistaDueno vDueno = new vistaDueno(this, "alta") { MdiParent = MdiParent };
            vDueno.Show();
            vDueno.Focus();
        }

        private void dataGridDuenos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridDuenos.Columns.Count - 2)
            {
                DataGridViewRow registro = dataGridDuenos.Rows[e.RowIndex];
                string dni = registro.Cells[0].Value.ToString();
                string nombre = registro.Cells[1].Value.ToString();

                DialogResult = MessageBox.Show("¿Esta completamente seguro de que quiere eliminar al dueño " + nombre + " (" + dni + ")?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    controlDuenos control = new controlDuenos();
                    string rtaCtrl = control.bajaDueno(dni);
                    if (rtaCtrl == "Exitosa") { refrescar(); }
                    else
                    {
                        MessageBox.Show(rtaCtrl, "Error al eliminar dueño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dataGridDuenos.Columns.Count - 3 || e.ColumnIndex == dataGridDuenos.Columns.Count - 4)
            {
                refrescar();
                if (dataGridDuenos.Rows.Count > 0)
                {
                    DataGridViewRow registro = dataGridDuenos.Rows[e.RowIndex];
                    controlDuenos control = new controlDuenos();
                    string dni = registro.Cells[0].Value.ToString();
                    Dueno dueno = Array.Find(duenos, due => due.DNI == dni);
                    string operacion = e.ColumnIndex == dataGridDuenos.Columns.Count - 3 ? "modif" : "ver";

                    Enabled = false;
                    vistaDueno vDueno = new vistaDueno(this, operacion, dueno) { MdiParent = MdiParent };
                    vDueno.Show();
                    vDueno.Focus(); 
                }
            }
        }

        private void dataGridDuenos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridDuenos.Columns.Count - 4) { iconoBotones(e, Properties.Resources.iconVer); }
            else if (e.ColumnIndex == dataGridDuenos.Columns.Count - 3) { iconoBotones(e, Properties.Resources.iconModif); }
            else if (e.ColumnIndex == dataGridDuenos.Columns.Count - 2) { iconoBotones(e, Properties.Resources.iconBaja); }
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
                foreach (DataGridViewRow row in dataGridDuenos.Rows)
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

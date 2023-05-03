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
    public partial class vistaContratos : Form
    {
        private Contrato[] contratos;
        private string campoBusqueda;

        public vistaContratos()
        {
            InitializeComponent();
            comboBusqueda.Items.Add("ID");
            comboBusqueda.Items.Add("Inquilino");
            comboBusqueda.Items.Add("Inmueble");
            comboBusqueda.SelectedIndex = 0;
        }

        private void vistaContratos_Load(object sender, EventArgs e) { refrescar(); }
        public void refrescar()
        {
            temaColores.ElegirTema("azul");
            ForeColor = temaColores.Fuente;
            BackColor = temaColores.Fondo;
            btnAlta.ForeColor = Color.Black;
            dataGridContratos.BackgroundColor = temaColores.Paneles;
            dataGridContratos.ColumnHeadersDefaultCellStyle.BackColor = temaColores.Paneles;
            dataGridContratos.ColumnHeadersDefaultCellStyle.ForeColor = temaColores.Fuente;
            dataGridContratos.RowsDefaultCellStyle.BackColor = temaColores.Fila;
            dataGridContratos.AlternatingRowsDefaultCellStyle.BackColor = temaColores.FilaAlt;


            dataGridContratos.DataSource = null;
            dataGridContratos.Rows.Clear();
            dataGridContratos.Sort(dataGridContratos.Columns[0], ListSortDirection.Ascending);
            controlContratos control = new controlContratos();
            contratos = control.listaContratos();
            if (contratos != null)
            {
                foreach (Contrato contrato in contratos)
                {
                    int n = dataGridContratos.Rows.Add();
                    dataGridContratos.Rows[n].Cells[0].Value = contrato.ID;
                    dataGridContratos.Rows[n].Cells[1].Value = contrato.Inquilino_DNI;
                    dataGridContratos.Rows[n].Cells[2].Value = contrato.Inmueble_ID;
                }
            }
            lblCantidad.Text = dataGridContratos.Rows.Count + " Contratos";
            refrescarSize();
        }
        private void refrescarSize()
        {
            int cantCols = dataGridContratos.Columns.Count;
            for (int i = 0; i < cantCols - 1; i++)
            {
                dataGridContratos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridContratos.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int fillerw = dataGridContratos.Columns[cantCols - 1].Width;
            for (int i = 0; i < cantCols - 1; i++)
            {
                int colw = dataGridContratos.Columns[i].Width;
                dataGridContratos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridContratos.Columns[i].Width = colw + fillerw / (cantCols - 1);
            }
            fillerw = dataGridContratos.Columns[cantCols - 1].Width;
            dataGridContratos.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridContratos.Columns[cantCols - 1].Width = fillerw;
        }
        private void vistaContratos_SizeChanged(object sender, EventArgs e) { refrescarSize(); }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            Enabled = false;
            vistaContrato vContrato = new vistaContrato(this, "alta") { MdiParent = MdiParent };
            vContrato.Show();
            vContrato.Focus();
        }

        private void dataGridContratos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridContratos.Columns.Count - 2)
            {
                DataGridViewRow registro = dataGridContratos.Rows[e.RowIndex];
                int id = int.Parse(registro.Cells[0].Value.ToString());

                DialogResult = MessageBox.Show("¿Esta completamente seguro de que quiere eliminar el contrato numero " + id + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    controlContratos control = new controlContratos();
                    string rtaCtrl = control.bajaContrato(id);
                    if (rtaCtrl == "Exitosa") { refrescar(); }
                    else
                    {
                        MessageBox.Show(rtaCtrl, "Error al eliminar contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (e.ColumnIndex == dataGridContratos.Columns.Count - 3 || e.ColumnIndex == dataGridContratos.Columns.Count - 4)
            {
                refrescar();
                DataGridViewRow registro = dataGridContratos.Rows[e.RowIndex];
                controlContratos control = new controlContratos();
                int id = int.Parse(registro.Cells[0].Value.ToString());
                Contrato contrato = Array.Find(contratos, con => con.ID == id);
                string operacion = e.ColumnIndex == dataGridContratos.Columns.Count - 3 ? "modif" : "ver";

                Enabled = false;
                vistaContrato vContrato = new vistaContrato(this, operacion, contrato) { MdiParent = MdiParent };
                vContrato.Show();
                vContrato.Focus();
            }
        }

        private void dataGridContratos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridContratos.Columns.Count - 4) { iconoBotones(e, Properties.Resources.iconVer); }
            else if (e.ColumnIndex == dataGridContratos.Columns.Count - 3) { iconoBotones(e, Properties.Resources.iconModif); }
            else if (e.ColumnIndex == dataGridContratos.Columns.Count - 2) { iconoBotones(e, Properties.Resources.iconBaja); }
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
                foreach (DataGridViewRow row in dataGridContratos.Rows)
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

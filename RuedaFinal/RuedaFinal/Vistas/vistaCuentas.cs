using Microsoft.Win32;
using RuedaFinal.Controladores;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuedaFinal.Vistas
{
    public partial class vistaCuentas : Form
    {
        private Cuenta[] cuentas;
        private string campoBusqueda;

        public vistaCuentas()
        {
            InitializeComponent();
            comboBusqueda.Items.Add("ID");
            comboBusqueda.Items.Add("Usuario");
            comboBusqueda.Items.Add("Tipo");
            comboBusqueda.SelectedIndex = 0;
        }

        private void vistaCuentas_Load(object sender, EventArgs e){ refrescar(); }
        public void refrescar()
        {
            temaColores.ElegirTema("verde");
            ForeColor = temaColores.Fuente;
            BackColor = temaColores.Fondo;
            btnAlta.ForeColor = Color.Black;
            dataGridCuentas.BackgroundColor = temaColores.Paneles;
            dataGridCuentas.ColumnHeadersDefaultCellStyle.BackColor = temaColores.Paneles;
            dataGridCuentas.ColumnHeadersDefaultCellStyle.ForeColor = temaColores.Fuente;
            dataGridCuentas.RowsDefaultCellStyle.BackColor = temaColores.Fila;
            dataGridCuentas.AlternatingRowsDefaultCellStyle.BackColor = temaColores.FilaAlt;


            dataGridCuentas.Sort(dataGridCuentas.Columns[0], ListSortDirection.Ascending);
            dataGridCuentas.Rows.Clear();
            controlCuentas control = new controlCuentas();
            cuentas = control.listaCuentas();
            //dataGridCuentas.DataSource = usuarios;
            if (cuentas != null)
            {
                foreach (Cuenta cuenta in cuentas)
                {
                    int n = dataGridCuentas.Rows.Add();
                    dataGridCuentas.Rows[n].Cells[0].Value = cuenta.Id;
                    dataGridCuentas.Rows[n].Cells[1].Value = cuenta.Usuario;
                    dataGridCuentas.Rows[n].Cells[2].Value = cuenta.TipoID == 1 ? "Administrador" : "Normal";
                }
            }
            lblCantidad.Text = dataGridCuentas.Rows.Count + " Cuentas";
            refrescarSize();
        }
        private void refrescarSize()
        {
            int cantCols = dataGridCuentas.Columns.Count;
            for (int i = 0; i < cantCols - 1; i++)
            {
                dataGridCuentas.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridCuentas.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            int fillerw = dataGridCuentas.Columns[cantCols - 1].Width;
            for (int i = 0; i < cantCols - 1; i++)
            {
                int colw = dataGridCuentas.Columns[i].Width;
                dataGridCuentas.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridCuentas.Columns[i].Width = colw + fillerw / (cantCols - 1);
            }
            fillerw = dataGridCuentas.Columns[cantCols - 1].Width;
            dataGridCuentas.Columns[cantCols - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridCuentas.Columns[cantCols - 1].Width = fillerw;
        }
        private void vistaCuentas_SizeChanged(object sender, EventArgs e) { refrescarSize(); }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            Enabled = false;
            vistaCuenta vCuenta = new vistaCuenta(this, "alta") { MdiParent = MdiParent };
            vCuenta.Show();
            vCuenta.Focus();
        }

        private void dataGridCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                DataGridViewRow registro = dataGridCuentas.Rows[e.RowIndex];
                string strUsuario = registro.Cells[1].Value.ToString();

                Enabled = false;
                vistaCuenta vCuenta = new vistaCuenta(this, "modif", strUsuario) { MdiParent = MdiParent };
                vCuenta.Show();
                vCuenta.Focus();
            }
            else if(e.ColumnIndex == 4)
            {
                DataGridViewRow registro = dataGridCuentas.Rows[e.RowIndex];
                string idCuenta = registro.Cells[0].Value.ToString();
                string strUsuario = registro.Cells[1].Value.ToString();

                DialogResult = MessageBox.Show("¿Esta completamente seguro de que quiere eliminar la cuenta " + strUsuario + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    controlCuentas control = new controlCuentas();
                    string rtaCtrl = control.bajaCuenta(idCuenta);
                    if (rtaCtrl == "Exitosa") { refrescar(); }
                    else
                    {
                        MessageBox.Show(rtaCtrl, "Error al eliminar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridCuentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 3) { iconoBotones(e, Properties.Resources.iconModif); }
            else if (e.ColumnIndex == 4) { iconoBotones(e, Properties.Resources.iconBaja); }
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
                foreach (DataGridViewRow row in dataGridCuentas.Rows)
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

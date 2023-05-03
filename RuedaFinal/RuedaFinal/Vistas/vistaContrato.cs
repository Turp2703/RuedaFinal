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
    public partial class vistaContrato : Form
    {
        private vistaContratos vContratos;
        private string operacion;
        private Contrato contratoOriginal;

        public vistaContrato(vistaContratos vc, string op)
        {
            InitializeComponent();
            vContratos = vc;
            operacion = op;
            refrescarComboInmueble();
            refrescarComboInquilino();
        }

        public vistaContrato(vistaContratos vc, string op, Contrato c) : this(vc, op)
        {
            if (op == "ver")
            {
                dateFInicio.Enabled = false;
                dateFUltimo.Enabled = false;
                dateFVenc.Enabled = false;
                numPrecio.ReadOnly = true;
                numPrecio.Increment = 0;
                comboInmueble.Enabled = false;
                comboInquilino.Enabled = false;
            }

            contratoOriginal = c;

            dateFInicio.Value = c.Fecha_Inicio;
            dateFUltimo.Value = c.Fecha_Ultimo_Pago;
            dateFVenc.Value = c.Fecha_Vencimiento;
            numPrecio.Value = c.Precio_Alquiler;

            int i = 0, index = -1;
            while (i < comboInmueble.Items.Count && index == -1)
            {
                if (comboInmueble.Items[i].ToString().Split(' ')[0] == c.Inmueble_ID.ToString()) { index = i; }
                i++;
            }
            if (index == -1) { index = 0; }
            comboInmueble.SelectedIndex = index;

            i = 0; index = -1;
            while (i < comboInquilino.Items.Count && index == -1)
            {
                if (comboInquilino.Items[i].ToString().Split(' ')[0] == c.Inquilino_DNI) { index = i; }
                i++;
            }
            if (index == -1) { index = 0; }
            comboInquilino.SelectedIndex = index;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (operacion == "ver") { Close(); }
            else if (comboInmueble.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un inmueble para el contrato.", "Error de inmueble", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboInquilino.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un inquilino para el contrato.", "Error de inquilino", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (operacion == "alta" || operacion == "modif")
            {
                Contrato con = new Contrato
                {
                    Fecha_Inicio = dateFInicio.Value,
                    Fecha_Ultimo_Pago = dateFUltimo.Value,
                    Fecha_Vencimiento = dateFVenc.Value,
                    Precio_Alquiler = (int)numPrecio.Value,
                    Inmueble_ID = int.Parse(comboInmueble.Text.Split(' ')[0].Trim()),
                    Inquilino_DNI = comboInquilino.Text.Split(' ')[0]
                };

                controlContratos control = new controlContratos();

                string rtaCtrl = operacion == "alta" ? control.altaContrato(con) : control.modifContrato(con, contratoOriginal);
                string error = operacion == "alta" ? "agregar" : "modificar";

                if (rtaCtrl == "Exitosa")
                {
                    vContratos.refrescar();
                    Close();
                }
                else
                {
                    MessageBox.Show(rtaCtrl, "Error al " + error + " contrato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboInmueble_DropDown(object sender, EventArgs e)
        {
            refrescarComboInmueble();
        }
        private void refrescarComboInmueble()
        {
            comboInmueble.Items.Clear();
            controlInmuebles cInms = new controlInmuebles();
            Inmueble[] inmuebles = cInms.listaInmuebles();
            foreach (Inmueble inm in inmuebles)
            {
                comboInmueble.Items.Add(inm.ID + " - " + inm.Direccion_Calle + " " + inm.Direccion_Numero);
            }
        }

        private void comboInquilino_DropDown(object sender, EventArgs e)
        {
            refrescarComboInquilino();
        }
        private void refrescarComboInquilino()
        {
            comboInquilino.Items.Clear();
            controlInquilinos cInq = new controlInquilinos();
            Inquilino[] inquilinos = cInq.listaInquilinos();
            foreach (Inquilino inq in inquilinos)
            {
                comboInquilino.Items.Add(inq.DNI + " - " + inq.Nombre + " " + inq.Apellido);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            dateFInicio.Value = DateTime.Now;
            dateFUltimo.Value = DateTime.Now;
            dateFVenc.Value = DateTime.Now;
            numPrecio.Value = 0;
            comboInmueble.SelectedIndex = 0;
            comboInquilino.SelectedIndex = 0;
            numPrecio.Focus();
        }

        private void vistaContrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            vContratos.Enabled = true;
            vContratos.Focus();
            vContratos.refrescar();
        }
    }
}

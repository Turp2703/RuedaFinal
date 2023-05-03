using RuedaFinal.Controladores;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace RuedaFinal.Vistas
{
    public partial class vistaInmueble : Form
    {
        private vistaInmuebles vInmuebles;
        private string operacion;
        private Inmueble inmuebleOriginal;

        public vistaInmueble(vistaInmuebles vI, string op)
        {
            InitializeComponent();
            vInmuebles = vI;
            operacion = op;
            refrescarComboPropietario();
            refrescarComboLocalidad();
        }

        public vistaInmueble(vistaInmuebles vistaInmuebles, string op, Inmueble inmueble) : this(vistaInmuebles, op)
        {
            if (op == "ver")
            {
                txtDescripcion.ReadOnly = true;
                txtNumPartida.ReadOnly = true;
                txtDirCalle.ReadOnly = true;
                numDirNum.ReadOnly = true;
                numDirNum.Increment = 0;
                numPrecioVenta.ReadOnly = true;
                numPrecioVenta.Increment = 0;
                numSuperficie.ReadOnly = true;
                numSuperficie.Increment = 0;
                numCantAmbientes.ReadOnly = true;
                numCantAmbientes.Increment = 0;
                numDormitorios.ReadOnly = true;
                numDormitorios.Increment = 0;
                numBanos.ReadOnly = true;
                numBanos.Increment = 0;
                chckPatio.Enabled = false;
                chckGaraje.Enabled = false;
                comboLocalidad.Enabled = false;
                comboPropietario.Enabled = false;
                btnBorrar.Visible = false;
            }

            inmuebleOriginal = inmueble;

            txtDescripcion.Text = inmueble.Descripcion;
            txtNumPartida.Text = inmueble.Numero_Partida;
            txtDirCalle.Text = inmueble.Direccion_Calle;
            numDirNum.Value = inmueble.Direccion_Numero;
            numPrecioVenta.Value = inmueble.Precio_Venta;
            numSuperficie.Value = inmueble.Superficie;
            numCantAmbientes.Value = inmueble.Ambientes;
            numDormitorios.Value = inmueble.Dormitorios;
            numBanos.Value = inmueble.Banos;
            chckPatio.Checked = inmueble.Patio;
            chckGaraje.Checked = inmueble.Garaje;

            int i = 0, index = -1;
            while (i < comboPropietario.Items.Count && index == -1)
            {
                if (comboPropietario.Items[i].ToString().Split(' ')[0] == inmueble.Propietario_DNI) { index = i; }
                i++;
            }
            if (index == -1) { index = 0; }
            comboPropietario.SelectedIndex = index;

            i = 0; index = -1;
            while (i < comboLocalidad.Items.Count && index == -1)
            {
                if (comboLocalidad.Items[i].ToString().Split(' ')[0] == inmueble.Codigo_Postal) { index = i; }
                i++;
            }
            if (index == -1) { index = 0; }
            comboLocalidad.SelectedIndex = index;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (operacion == "ver") { Close(); }
            else if(comboPropietario.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un propietario para el inmueble.", "Error de propietario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboLocalidad.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una localidad para el inmueble.", "Error de localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (operacion == "alta" || operacion == "modif")
            {
                Inmueble inm = new Inmueble
                {
                    Descripcion = txtDescripcion.Text,
                    Numero_Partida = txtNumPartida.Text,
                    Direccion_Calle = txtDirCalle.Text,
                    Direccion_Numero = (int)numDirNum.Value,
                    Precio_Venta = (int)numDirNum.Value,
                    Superficie = (int)numSuperficie.Value,
                    Ambientes = (int)numCantAmbientes.Value,
                    Dormitorios = (int)numDormitorios.Value,
                    Banos = (int)numBanos.Value,
                    Patio = chckPatio.Checked,
                    Garaje = chckGaraje.Checked,
                    Propietario_DNI = comboPropietario.Text.Split(' ')[0],
                    Codigo_Postal = comboLocalidad.Text.Split(' ')[0]
                };

                controlInmuebles control = new controlInmuebles();

                string rtaCtrl = operacion == "alta" ? control.altaInmueble(inm) : control.modifInmueble(inm, inmuebleOriginal);
                string error = operacion == "alta" ? "agregar" : "modificar";

                if (rtaCtrl == "Exitosa")
                {
                    vInmuebles.refrescar();
                    Close();
                }
                else
                {
                    MessageBox.Show(rtaCtrl, "Error al " + error + " inmueble", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboPropietario_DropDown(object sender, EventArgs e) { refrescarComboPropietario(); }
        private void refrescarComboPropietario()
        {
            comboPropietario.Items.Clear();
            controlDuenos cDues = new controlDuenos();
            Dueno[] duenos = cDues.listaDuenos();
            foreach (Dueno d in duenos)
            {
                comboPropietario.Items.Add(d.DNI + " - " + d.Nombre);
            }
        }

        private void comboLocalidad_DropDown(object sender, EventArgs e) { refrescarComboLocalidad(); }
        private void refrescarComboLocalidad()
        {
            comboLocalidad.Items.Clear();
            controlLocalidades cLocs = new controlLocalidades();
            Localidad[] localidades = cLocs.listaLocalidades();
            foreach (Localidad loc in localidades)
            {
                comboLocalidad.Items.Add(loc.CodigoPostal + " - " + loc.Nombre);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtNumPartida.Text = "";
            txtDirCalle.Text = "";
            numDirNum.Value = 1;
            numPrecioVenta.Value = 1;
            numSuperficie.Value = 1;
            numCantAmbientes.Value = 1;
            numDormitorios.Value = 1;
            numBanos.Value = 1;
            chckPatio.Checked = false;
            chckGaraje.Checked = false;
            comboPropietario.SelectedIndex = 0;
            comboLocalidad.SelectedIndex = 0;
            txtDescripcion.Focus();
        }

        private void vistaInmueble_FormClosing(object sender, FormClosingEventArgs e)
        {
            vInmuebles.Enabled = true;
            vInmuebles.Focus();
            vInmuebles.refrescar();
        }
    }
}

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
    public partial class vistaInquilino : Form
    {
        private vistaInquilinos vInquilinos;
        private string operacion;
        private Inquilino inquiOriginal;

        public vistaInquilino(vistaInquilinos vistaInquilinos, string op)
        {
            InitializeComponent();
            vInquilinos = vistaInquilinos;
            operacion = op;
            refrescarCombo();
            rdbHombre.Checked = true;
        }

        public vistaInquilino(vistaInquilinos vistaInquilinos, string op, Inquilino inqui) : this(vistaInquilinos, op)
        {
            if (op == "ver")
            {
                numDNI.ReadOnly = true;
                numDNI.Increment = 0;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtOcupacion.ReadOnly = true;
                numVehiculos.ReadOnly = true;
                numVehiculos.Increment = 0;
                grpbxSexo.Enabled = false;
                dateFNac.Enabled = false;
                comboLocalidad.Enabled = false;
                txtTelefonos.ReadOnly = true;
                txtEMails.ReadOnly = true;
                btnBorrar.Visible = false;
            }

            inquiOriginal = inqui;

            numDNI.Value = int.Parse(inqui.DNI);
            txtNombre.Text = inqui.Nombre;
            txtApellido.Text = inqui.Apellido;
            txtOcupacion.Text = inqui.Ocupacion;
            numVehiculos.Value = inqui.Cantidad_Vehiculos;

            if (inqui.Sexo == "Hombre") { rdbHombre.Checked = true; rdbMujer.Checked = false; }
            else { rdbMujer.Checked = true; rdbHombre.Checked = false; }

            dateFNac.Value = inqui.Fecha_Nacimiento;

            int i = 0, index = -1;
            while (i < comboLocalidad.Items.Count && index == -1)
            {
                if (comboLocalidad.Items[i].ToString().Split(' ')[0] == inqui.Codigo_Postal) { index = i; }
                i++;
            }
            if (index == -1) { index = 0; }
            comboLocalidad.SelectedIndex = index;

            txtTelefonos.Text = "";
            foreach (string tel in inqui.Telefonos)
            {
                txtTelefonos.Text += tel + ",";
            }
            if (txtTelefonos.Text.Length > 0)
            {
                txtTelefonos.Text = txtTelefonos.Text.Remove(txtTelefonos.Text.Length - 1);
            }

            txtEMails.Text = "";
            foreach (string mail in inqui.Emails)
            {
                txtEMails.Text += mail + ",";
            }
            if (txtEMails.Text.Length > 0)
            {
                txtEMails.Text = txtEMails.Text.Remove(txtEMails.Text.Length - 1);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (operacion == "ver") { Close(); }
            else if (comboLocalidad.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una localidad para el inquilino.", "Error de localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (operacion == "alta" || operacion == "modif")
            {
                Inquilino inq = new Inquilino
                {
                    DNI = numDNI.Value.ToString(),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Ocupacion = txtOcupacion.Text,
                    Cantidad_Vehiculos = (int)numVehiculos.Value,
                    Sexo = rdbHombre.Checked ? "Hombre" : "Mujer",
                    Fecha_Nacimiento = dateFNac.Value,
                    Telefonos = new List<string>(txtTelefonos.Text.Split(',')),
                    Emails = new List<string>(txtEMails.Text.Split(',')),
                    Codigo_Postal = comboLocalidad.Text.Split(' ')[0]
                };

                controlInquilinos control = new controlInquilinos();

                string rtaCtrl = operacion == "alta" ? control.altaInquilino(inq) : control.modifInquilino(inq, inquiOriginal);
                string error = operacion == "alta" ? "agregar" : "modificar";

                if (rtaCtrl == "Exitosa")
                {
                    vInquilinos.refrescar();
                    Close();
                }
                else
                {
                    MessageBox.Show(rtaCtrl, "Error al " + error + " inquilino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboLocalidad_DropDown(object sender, EventArgs e) { refrescarCombo(); }
        private void refrescarCombo()
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
            numDNI.Value = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtOcupacion.Text = "";
            numVehiculos.Value = 0;
            rdbHombre.Checked = true;
            rdbMujer.Checked = false;
            dateFNac.Value = DateTime.Now;
            comboLocalidad.SelectedIndex = 0;
            txtTelefonos.Text = "";
            txtEMails.Text = "";
            numDNI.Focus();
        }

        private void vistaInquilino_FormClosing(object sender, FormClosingEventArgs e)
        {
            vInquilinos.Enabled = true;
            vInquilinos.Focus();
            vInquilinos.refrescar();
        }
    }
}

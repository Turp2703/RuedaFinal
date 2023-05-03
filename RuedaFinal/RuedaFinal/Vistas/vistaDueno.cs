using RuedaFinal.Controladores;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuedaFinal.Vistas
{
    public partial class vistaDueno : Form
    {
        private vistaDuenos vDuenos;
        private string operacion;
        private Dueno duenoOriginal;

        public vistaDueno(vistaDuenos vistaDuenos, string op)
        {
            InitializeComponent();
            vDuenos = vistaDuenos;
            operacion = op;
            refrescarCombo();
            rdbHombre.Checked = true;
        }

        public vistaDueno(vistaDuenos vistaDuenos, string op, Dueno d) : this(vistaDuenos, op)
        {
            if(op == "ver")
            {
                //foreach(Control c in panelCliente.Controls)
                //{
                //    c.Enabled = false;
                //}
                numDNI.ReadOnly = true;
                numDNI.Increment = 0;
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtDirCalle.ReadOnly = true;
                numDirNum.ReadOnly = true;
                numDirNum.Increment = 0;
                grpbxSexo.Enabled = false;
                dateFNac.Enabled = false;
                comboLocalidad.Enabled = false;
                txtTelefonos.ReadOnly = true;
                txtEMails.ReadOnly = true;
                btnBorrar.Visible = false;
            }

            duenoOriginal = d;

            numDNI.Value = int.Parse(d.DNI);
            txtNombre.Text = d.Nombre;
            txtApellido.Text = d.Apellido;
            txtDirCalle.Text = d.Direccion_Calle;
            numDirNum.Value = d.Direccion_Numero;

            if (d.Sexo == "Hombre") { rdbHombre.Checked = true; rdbMujer.Checked = false; }
            else { rdbMujer.Checked = true; rdbHombre.Checked = false; }

            dateFNac.Value = d.Fecha_Nacimiento;

            int i = 0, index = -1;
            while (i < comboLocalidad.Items.Count && index == -1)
            {
                if (comboLocalidad.Items[i].ToString().Split(' ')[0] == d.Codigo_Postal) { index = i; }
                i++;
            }
            if (index == -1) { index = 0; }
            comboLocalidad.SelectedIndex = index;

            txtTelefonos.Text = "";
            foreach (string tel in d.Telefonos)
            {
                txtTelefonos.Text += tel + ",";
            }
            if (txtTelefonos.Text.Length > 0)
            {
                txtTelefonos.Text = txtTelefonos.Text.Remove(txtTelefonos.Text.Length - 1);
            }

            txtEMails.Text = "";
            foreach (string mail in d.Emails)
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
            if(operacion == "ver") { Close(); }
            else if (comboLocalidad.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar una localidad para el dueño.", "Error de localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (operacion == "alta" || operacion == "modif")
            {
                Dueno due = new Dueno
                {
                    DNI = numDNI.Value.ToString(),
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Direccion_Calle = txtDirCalle.Text,
                    Direccion_Numero = (int)numDirNum.Value,
                    Sexo = rdbHombre.Checked ? "Hombre" : "Mujer",
                    Fecha_Nacimiento = dateFNac.Value,
                    Telefonos = new List<string>(txtTelefonos.Text.Split(',')),
                    Emails = new List<string>(txtEMails.Text.Split(',')),
                    Codigo_Postal = comboLocalidad.Text.Split(' ')[0]
                };

                controlDuenos control = new controlDuenos();

                string rtaCtrl = operacion == "alta" ? control.altaDueno(due) : control.modifDueno(due, duenoOriginal);
                string error = operacion == "alta" ? "agregar" : "modificar";

                if (rtaCtrl == "Exitosa")
                {
                    vDuenos.refrescar();
                    Close();
                }
                else
                {
                    MessageBox.Show(rtaCtrl, "Error al " + error + " dueño", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtDirCalle.Text = "";
            numDirNum.Value = 0;
            rdbHombre.Checked = true;
            rdbMujer.Checked = false;
            dateFNac.Value = DateTime.Now;
            comboLocalidad.SelectedIndex = 0;
            txtTelefonos.Text = "";
            txtEMails.Text = "";
            numDNI.Focus();
        }

        private void vistaDueno_FormClosing(object sender, FormClosingEventArgs e)
        {
            vDuenos.Enabled = true;
            vDuenos.Focus();
            vDuenos.refrescar();
        }
    }
}

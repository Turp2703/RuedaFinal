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
    public partial class vistaLocalidad : Form
    {
        private vistaLocalidades vLocalidades;
        private string operacion;
        private Localidad localidadOriginal;

        public vistaLocalidad(vistaLocalidades vl, string op)
        {
            InitializeComponent();
            vLocalidades = vl;
            operacion = op;
        }

        public vistaLocalidad(vistaLocalidades vl, string op, Localidad original) : this(vl, op)
        {
            localidadOriginal = new Localidad
            {
                CodigoPostal = original.CodigoPostal,
                Nombre = original.Nombre,
            };
            txtCodigoPostal.Text = original.CodigoPostal;
            txtNombre.Text = original.Nombre;
        }

        private void vistaLocalidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            vLocalidades.Enabled = true;
            vLocalidades.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            controlLocalidades control = new controlLocalidades();

            if(operacion == "alta" || operacion == "modif")
            {
                Localidad localidad = new Localidad
                {
                    CodigoPostal = txtCodigoPostal.Text,
                    Nombre = txtNombre.Text
                };

                string rtaCtrl = operacion == "alta" ? control.altaLocalidad(localidad) : control.modifLocalidad(localidad, localidadOriginal);
                string error = operacion == "alta" ? "agregar" : "modificar";

                if(rtaCtrl == "Exitosa")
                {
                    vLocalidades.refrescar();
                    Close();
                }
                else
                {
                    MessageBox.Show(rtaCtrl, "Error al " + error + " localidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoPostal.Focus();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtCodigoPostal.Text = "";
            txtNombre.Text = "";
            txtCodigoPostal.Focus();
        }

        private void txtCodigoPostal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnConfirmar_Click(sender, e); }
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnConfirmar_Click(sender, e); }
        }
    }
}
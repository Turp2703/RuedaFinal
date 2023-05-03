using RuedaFinal.Controladores;
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
    public partial class vistaCuenta : Form
    {
        private vistaCuentas vCuentas;
        private string operacion;
        private string usuarioOriginal;

        public vistaCuenta(vistaCuentas vc, string operacion)
        {
            InitializeComponent();
            vCuentas = vc;
            this.operacion = operacion;
        }

        public vistaCuenta(vistaCuentas vc, string operacion, string strUsuario) : this(vc, operacion)
        {
            txtClave.Enabled = false;
            txtConfClave.Enabled = false;
            txtUsuario.Text = strUsuario;
            usuarioOriginal = strUsuario;
        }

        private void vistaCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            vCuentas.Enabled = true;
            vCuentas.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            controlCuentas control = new controlCuentas();
            if (operacion == "alta")
            {
                string rtaCtrl = control.altaCuenta(txtUsuario.Text, txtClave.Text, txtConfClave.Text);

                if (rtaCtrl == "Exitosa")
                {
                    vCuentas.refrescar();
                    Close();
                }
                else
                {
                    MessageBox.Show(rtaCtrl, "Error al agregar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }
            }
            else if (operacion == "modif")
            {
                string rtaCtrl = control.modifCuenta(txtUsuario.Text, usuarioOriginal);
                if (rtaCtrl == "Exitosa")
                {
                    vCuentas.refrescar();
                    Close();
                }
                else
                {
                    MessageBox.Show(rtaCtrl, "Error al modificar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            txtConfClave.Text = "";
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnConfirmar_Click(sender, e); }
        }
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnConfirmar_Click(sender, e); }
        }
        private void txtConfClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btnConfirmar_Click(sender, e); }
        }
    }
}

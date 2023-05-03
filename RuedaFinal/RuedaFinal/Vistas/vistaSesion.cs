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
    public partial class vistaSesion : Form
    {
        private Panel panelP;

        public vistaSesion(Panel pp)
        {
            InitializeComponent();
            panelP = pp;
            txtUsuario.Focus();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtUsuario.Text = "";
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string strUsuario = txtUsuario.Text;
            string strClave = txtClave.Text;

            controlCuentas control = new controlCuentas();
            string rtaCtrl = control.ctrlSesion(strUsuario, strClave);

            if (rtaCtrl == "Ingresando")
            {
                ((vistaPrincipal)MdiParent).EsAdmin = control.obtenerUltimoTipo() == 1;
                panelP.Enabled = true;
                Close();
            }
            else
            {
                MessageBox.Show(rtaCtrl, "Error en el inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtUsuario.Text == "") { txtUsuario.Focus(); }
                else { txtClave.Focus(); }
            }
        }

        private void vistaSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { btnIngresar_Click(sender, e); }
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { btnIngresar_Click(sender, e); }
        }
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) { btnIngresar_Click(sender, e); }
        }
    }
}

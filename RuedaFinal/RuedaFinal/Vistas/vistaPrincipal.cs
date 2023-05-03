using RuedaFinal.Entidades;
using RuedaFinal.Vistas;
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

namespace RuedaFinal
{
    public partial class vistaPrincipal : Form
    {
        public bool Ocupado { get; set; }
        public bool EsAdmin { get; set; }
        public bool Cerrando { get; set; }
        private vistaCuentas vCuentas;
        private vistaLocalidades vLocalidades;
        private vistaDuenos vDuenos;
        private vistaInmuebles vInmuebles;
        private vistaInquilinos vInquilinos;
        private vistaContratos vContratos;
        private vistaExportar vExportar;

        public vistaPrincipal()
        {
            InitializeComponent();
        }

        private void vistaPrincipal_Load(object sender, EventArgs e)
        {
            // Inicializaciones
            Ocupado = false;
            EsAdmin = false;
            Cerrando = false;

            // Desactivar panel sin sesion
            pnlPrincipal.Enabled = false;

            // Tipo de cuenta
            lblUsuarioActual.Text = " ";

            // Vista inicio de sesion
            vistaSesion vSesion = new vistaSesion(pnlPrincipal)
            {
                MdiParent = this
            };
            vSesion.Show();
            vSesion.Location = new Point(ClientSize.Width / 2 - vSesion.Width, (ClientSize.Height - vSesion.Height) / 2);
            vSesion.Focus();

            // Iconos
            btnInmuebles.Image = (Image)(new Bitmap((btnInmuebles.Image), new Size(32, 32)));
            btnDuenos.Image = (Image)(new Bitmap((btnDuenos.Image), new Size(32, 32)));
            btnInquilinos.Image = (Image)(new Bitmap((btnInquilinos.Image), new Size(32, 32)));
            btnContratos.Image = (Image)(new Bitmap((btnContratos.Image), new Size(32, 32)));
            btnLocalidades.Image = (Image)(new Bitmap((btnLocalidades.Image), new Size(32, 32)));
            btnCuentas.Image = (Image)(new Bitmap((btnCuentas.Image), new Size(32, 32)));
            btnExportar.Image = (Image)(new Bitmap((btnExportar.Image), new Size(32, 32)));
            
            btnOrdenar.Image = (Image)(new Bitmap((btnOrdenar.Image), new Size(32, 32)));
            btnCerrar.Image = (Image)(new Bitmap((btnCerrar.Image), new Size(32, 32)));
            
            btnManual.Image = (Image)(new Bitmap((btnManual.Image), new Size(32, 32)));
            btnAcercaDe.Image = (Image)(new Bitmap((btnAcercaDe.Image), new Size(32, 32)));
            btnCerrarSesion.Image = (Image)(new Bitmap((btnCerrarSesion.Image), new Size(32, 32)));
            btnSalir.Image = (Image)(new Bitmap((btnSalir.Image), new Size(32, 32)));
        }

        private void vistaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
         {
            if (!Cerrando)
            {
                DialogResult pregunta = MessageBox.Show("Estas por salir del programa \n ¿Estas seguro de que quieres salir?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pregunta == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (Ocupado)
                {
                    e.Cancel = true;
                    MessageBox.Show("No es posible salir del programa en este momento, la base de datos esta siendo actualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Estas por salir del programa \n ¿Estas seguro de que quieres salir?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                if (Ocupado)
                {
                    MessageBox.Show("No es posible salir del programa en este momento, la base de datos esta siendo actualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cerrando = true;
                    Close();
                }
            }
            
        }

        private void pnlPrincipal_EnabledChanged(object sender, EventArgs e)
        {
            if (pnlPrincipal.Enabled)
            {
                lblUsuarioActual.Text = "Cuenta: ";
                lblUsuarioActual.Text += EsAdmin ? "Administrador" : "Normal";
                btnCuentas.Enabled = EsAdmin;
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Ocupado) { MessageBox.Show("No es posible cerrar la sesion en este momento, la base de datos esta siendo actualizada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                btnCerrar_Click(sender, e);
                vistaPrincipal_Load(sender, e);
            }
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            int baseX = 15;
            int baseY = Size.Height - ClientSize.Height + 15;
            foreach(Form frm in MdiChildren)
            {
                frm.Location = new Point(baseX, baseY);
                baseX += 30;
                baseY += 30;
                frm.SendToBack();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            foreach (Form frm in MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }
            vCuentas = null;
            vLocalidades = null;
            vDuenos = null;
            vInmuebles = null;
            vInquilinos = null;
            vContratos = null;
            vExportar = null;
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            if (EsAdmin)
            {
                if (vCuentas == null)
                {
                    vCuentas = new vistaCuentas { MdiParent = this };
                    vCuentas.FormClosed += new FormClosedEventHandler(CerrarVistaCuentas);
                    vCuentas.Show();
                }
                else
                {
                    vCuentas.Focus();
                }
            }
        }
        private void CerrarVistaCuentas(object sender, FormClosedEventArgs e) { vCuentas = null; }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            if (vLocalidades == null)
            {
                vLocalidades = new vistaLocalidades { MdiParent = this };
                vLocalidades.FormClosed += new FormClosedEventHandler(CerrarVistaLocalidades);
                vLocalidades.Show();
            }
            else
            {
                vLocalidades.Focus();
            }
        }
        private void CerrarVistaLocalidades(object sender, FormClosedEventArgs e) { vLocalidades = null; }

        private void btnDuenos_Click(object sender, EventArgs e)
        {
            if (vDuenos == null)
            {
                vDuenos = new vistaDuenos { MdiParent = this };
                vDuenos.FormClosed += new FormClosedEventHandler(CerrarVistaDuenos);
                vDuenos.Show();
            }
            else
            {
                vDuenos.Focus();
            }
        }
        private void CerrarVistaDuenos(object sender, FormClosedEventArgs e) { vDuenos= null; }

        private void btnInmuebles_Click(object sender, EventArgs e)
        {
            if (vInmuebles == null)
            {
                vInmuebles = new vistaInmuebles { MdiParent = this };
                vInmuebles.FormClosed += new FormClosedEventHandler(CerrarVistaInmuebles);
                vInmuebles.Show();
            }
            else
            {
                vInmuebles.Focus();
            }
        }
        private void CerrarVistaInmuebles(object sender, FormClosedEventArgs e) { vInmuebles = null; }

        private void btnInquilinos_Click(object sender, EventArgs e)
        {
            if (vInquilinos == null)
            {
                vInquilinos = new vistaInquilinos { MdiParent = this };
                vInquilinos.FormClosed += new FormClosedEventHandler(CerrarVistaInquilinos);
                vInquilinos.Show();
            }
            else
            {
                vInquilinos.Focus();
            }
        }
        private void CerrarVistaInquilinos(object sender, FormClosedEventArgs e) { vInquilinos = null; }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            if (vContratos == null)
            {
                vContratos = new vistaContratos { MdiParent = this };
                vContratos.FormClosed += new FormClosedEventHandler(CerrarVistaContratos);
                vContratos.Show();
            }
            else
            {
                vContratos.Focus();
            }
        }
        private void CerrarVistaContratos(object sender, FormClosedEventArgs e) { vContratos = null; }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(vExportar == null)
            {
                vExportar = new vistaExportar { MdiParent = this };
                vExportar.FormClosed += new FormClosedEventHandler(CerrarVistaExportar);
                vExportar.Show();
            }
            else
            {
                vExportar.Focus();
            }
        }
        private void CerrarVistaExportar(object sender, FormClosedEventArgs e) { vExportar = null; }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por: Rueda Tomas - EESTN2 - 7°5 - Informatica \n" + "Sistema de Gestion para Inmobiliarias"
                , "Acerca De", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"userman.pdf");
        }
    }
}
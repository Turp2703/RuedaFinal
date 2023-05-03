using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Color = iText.Kernel.Colors.Color;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;

namespace RuedaFinal.Vistas
{
    public partial class vistaExportar : Form
    {
        private PdfFont fontHeader = PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD);
        private PdfFont fontCell = PdfFontFactory.CreateFont(StandardFonts.COURIER);
        
        public vistaExportar()
        {
            InitializeComponent();
            comboTabla.Items.Add("Dueños");
            comboTabla.Items.Add("Inmuebles");
            comboTabla.Items.Add("Contratos");
            comboTabla.Items.Add("Inquilinos");
            comboTabla.SelectedIndex = 0;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDestino.Text))
            {
                MessageBox.Show("No hay una ruta de destino seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                crearPDF(comboTabla.SelectedItem.ToString());
            }
        }

        private void crearPDF(string nombreTabla)
        {
            fontHeader = PdfFontFactory.CreateFont(StandardFonts.COURIER_BOLD);
            fontCell = PdfFontFactory.CreateFont(StandardFonts.COURIER);

            DateTime now = DateTime.Now;
            string tiempo = now.Date.Year.ToString() + now.Date.Month + now.Date.Day + "-" + now.Hour + now.Minute + now.Second;
            string nombre = nombreTabla + "-" + tiempo + ".pdf";
            PdfWriter pdfWriter = new PdfWriter(txtDestino.Text + "\\" + nombre);
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document doc = new Document(pdf, PageSize.A4.Rotate());
            
            doc.SetMargins(18f, 18f, 18f, 18f);

            agregarTabla(doc, nombreTabla);

            doc.Close();
        }
        private void agregarTabla(Document doc, string nombreTabla)
        {
            // Tabla
            float[] cols = new float[] {};
            switch (nombreTabla)
            {
                case "Dueños": cols = new float[] {1.2f, 1, 1.5f, 2, 1, 2, 1.1f, 3, 4}; break;
                case "Inmuebles": cols = new float[] {0.5f, 3, 2, 2, 1.1f, 1, 1, 1.1f, 1, 1, 1.1f, 2, 1.1f}; break;
                case "Contratos": cols = new float[] {0.5f, 1, 1, 1, 1, 1, 1, 1}; break;
                case "Inquilinos": cols = new float[] { 1.2f, 1.2f, 1.5f, 1, 2, 2, 2, 1.2f, 3, 4 }; break;
            }
            Table table = new Table(cols);
            table.SetWidth(UnitValue.CreatePercentValue(100));
            table.SetFixedLayout();
            
            // Encabezados
            string[] headers = new string[] {};
            if(nombreTabla == "Dueños")
            {
                headers = new string[] {"DNI", "Nombre", "Apellido", "Direccion", "Sexo", "Fecha de Nacimiento", "Codigo Postal", "Telefonos", "E-Mails"};
            }
            else if(nombreTabla == "Inmuebles")
            {
                headers = new string[] {"ID", "Descripcion", "Numero de Partida", "Direccion", "Precio Venta", "Superficie", "Ambientes", "Dormitorios", "Baños", "Patio", "Garaje", "Propietario DNI", "Codigo Postal"};
            }
            else if (nombreTabla == "Contratos")
            {
                headers = new string[] { "ID", "Fecha de Inicio", "Fecha del Ultimo Pago", "Fecha de Vencimiento", "Meses de Antiguedad", "Precio de Alquiler", "Inmueble ID", "Inquilino DNI"};
            }
            else if (nombreTabla == "Inquilinos")
            {
                headers = new string[] { "DNI", "Nombre", "Apellido", "Sexo", "Fecha de Nacimiento", "Ocupacion", "Cantidad Vehiculos", "Codigo Postal", "Telefonos", "E-Mails" };
            }
            foreach (string header in headers)
            {
                Paragraph p = new Paragraph(header);
                p.SetFont(fontHeader);
                p.SetFontSize(12f);
                p.SetTextAlignment(TextAlignment.CENTER);
                Cell c = new Cell().Add(p);
                c.SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                c.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                c.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                table.AddHeaderCell(c);
            }

            // Registros
            if (nombreTabla == "Dueños")
            {
                modeloDuenos modelo = new modeloDuenos();
                Dueno[] duenos = modelo.listaDuenos();

                foreach (Dueno due in duenos)
                {
                    table.AddCell(new Cell().Add(new Paragraph(due.DNI.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(due.Nombre).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(due.Apellido).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(due.Direccion_Calle + " " + due.Direccion_Numero).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(due.Sexo).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(due.Fecha_Nacimiento.ToString("d")).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(due.Codigo_Postal).SetFontSize(7f)));
                    string tels = "";
                    foreach (string tel in due.Telefonos) { tels += tel + "\n"; };
                    table.AddCell(new Cell().Add(new Paragraph(tels)).SetFontSize(6f));
                    string ems = "";
                    foreach (string em in due.Emails) { ems += em + "\n"; };
                    table.AddCell(new Cell().Add(new Paragraph(ems)).SetFontSize(6f));
                }
            }
            else if (nombreTabla == "Inmuebles")
            {
                modeloInmuebles modelo = new modeloInmuebles();
                Inmueble[] inmuebles = modelo.listaInmuebles();

                foreach (Inmueble inm in inmuebles)
                {
                    table.AddCell(new Cell().Add(new Paragraph(inm.ID.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Descripcion).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Numero_Partida).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Direccion_Calle + " " + inm.Direccion_Numero).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph("$ " + inm.Precio_Venta.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Superficie.ToString() + " m^2").SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Ambientes.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Dormitorios.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Banos.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Patio.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Garaje.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Propietario_DNI).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inm.Codigo_Postal).SetFontSize(7f)));
                }
            }
            else if (nombreTabla == "Contratos")
            {
                modeloContratos modelo = new modeloContratos();
                Contrato[] contratos = modelo.listaContratos();

                foreach (Contrato con in contratos)
                {
                    table.AddCell(new Cell().Add(new Paragraph(con.ID.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(con.Fecha_Inicio.ToString("d")).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(con.Fecha_Ultimo_Pago.ToString("d")).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(con.Fecha_Vencimiento.ToString("d")).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(con.Meses_Antiguedad.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph("$ " + con.Precio_Alquiler.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(con.Inmueble_ID.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(con.Inquilino_DNI).SetFontSize(7f)));
                }
            }
            else if (nombreTabla == "Inquilinos")
            {
                modeloInquilinos modelo = new modeloInquilinos();
                Inquilino[] inquilinos = modelo.listaInquilinos();

                foreach (Inquilino inq in inquilinos)
                {
                    table.AddCell(new Cell().Add(new Paragraph(inq.DNI.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inq.Nombre).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inq.Apellido).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inq.Sexo).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inq.Fecha_Nacimiento.ToString("d")).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inq.Ocupacion).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inq.Cantidad_Vehiculos.ToString()).SetFontSize(7f)));
                    table.AddCell(new Cell().Add(new Paragraph(inq.Codigo_Postal).SetFontSize(7f)));
                    string tels = "";
                    foreach (string tel in inq.Telefonos) { tels += tel + "\n"; };
                    table.AddCell(new Cell().Add(new Paragraph(tels)).SetFontSize(6f));
                    string ems = "";
                    foreach (string em in inq.Emails) { ems += em + "\n"; };
                    table.AddCell(new Cell().Add(new Paragraph(ems)).SetFontSize(6f));
                }
            }

            doc.Add(table);
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog { ShowNewFolderButton = true };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDestino.Text = dialog.SelectedPath;
            }
        }

        private void vistaExportar_Load(object sender, EventArgs e)
        {
            temaColores.ElegirTema("violeta");
            ForeColor = temaColores.Fuente;
            BackColor = temaColores.Fondo;
            btnDestino.ForeColor = System.Drawing.Color.Black;
            btnExportar.ForeColor = System.Drawing.Color.Black;
        }
    }
}

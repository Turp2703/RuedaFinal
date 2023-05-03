using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuedaFinal.Vistas
{
    public class temaColores
    {
        public static Color Fuente { get; set; }
        public static Color Fondo { get; set; }
        public static Color Paneles { get; set; }
        public static Color Fila { get; set; }
        public static Color FilaAlt { get; set; }
        public static Color Interact { get; set; }

        // "azul"
        private static readonly Color fuenteAZUL = Color.White;
        private static readonly Color fondoAZUL = Color.FromArgb(48, 53, 112);
        private static readonly Color panelesAZUL = Color.FromArgb(15, 21, 112);
        private static readonly Color filaAZUL = Color.FromArgb(31, 45, 240);
        private static readonly Color filaAltAZUL = Color.FromArgb(25, 35, 189);
        private static readonly Color interactAZUL = Color.FromArgb(104, 113, 242);

        // "verde"
        private static readonly Color fuenteVERDE = Color.White;
        private static readonly Color fondoVERDE = Color.FromArgb(75, 112, 37);
        private static readonly Color panelesVERDE = Color.FromArgb(58, 112, 3);
        private static readonly Color filaVERDE = Color.FromArgb(124, 240, 7);
        private static readonly Color filaAltVERDE = Color.FromArgb(97, 189, 6);
        private static readonly Color interactVERDE = Color.FromArgb(161, 242, 80);

        // "negro"
        private static readonly Color fuenteNEGRO = Color.White;
        private static readonly Color fondoNEGRO = Color.FromArgb(110, 110, 110);
        private static readonly Color panelesNEGRO = Color.FromArgb(173, 173, 173);
        private static readonly Color filaNEGRO = Color.FromArgb(212, 212, 212);
        private static readonly Color filaAltNEGRO = Color.FromArgb(236, 236, 236);
        private static readonly Color interactNEGRO = Color.FromArgb(250, 250, 250);

        // "violeta"
        private static readonly Color fuenteVIOLETA = Color.White;
        private static readonly Color fondoVIOLETA = Color.FromArgb(79, 60, 92);
        private static readonly Color panelesVIOLETA = Color.FromArgb(68, 32, 92);
        private static readonly Color filaVIOLETA = Color.FromArgb(162, 77, 219);
        private static readonly Color filaAltVIOLETA = Color.FromArgb(125, 59, 168);
        private static readonly Color interactVIOLETA = Color.FromArgb(194, 146, 225);

        // "amarillo"
        private static readonly Color fuenteAMARILLO = Color.White;
        private static readonly Color fondoAMARILLO = Color.FromArgb(117, 104, 0);
        private static readonly Color panelesAMARILLO = Color.FromArgb(128, 115, 18);
        private static readonly Color filaAMARILLO = Color.FromArgb(194, 172, 0);
        private static readonly Color filaAltAMARILLO = Color.FromArgb(245, 216, 0);
        private static readonly Color interactAMARILLO = Color.FromArgb(247, 226, 74);

        // "rojo"
        private static readonly Color fuenteROJO = Color.White;
        private static readonly Color fondoROJO = Color.FromArgb(117, 23, 0);
        private static readonly Color panelesROJO = Color.FromArgb(128, 40, 18);
        private static readonly Color filaROJO = Color.FromArgb(194, 39, 0);
        private static readonly Color filaAltROJO = Color.FromArgb(245, 49, 0);
        private static readonly Color interactROJO = Color.FromArgb(247, 108, 74);

        public static void ElegirTema(string tema)
        {
            if (tema == "azul")
            {
                Fuente = fuenteAZUL;
                Fondo = fondoAZUL;
                Paneles = panelesAZUL;
                Fila = filaAZUL;
                FilaAlt = filaAltAZUL;
                Interact = interactAZUL;
            }
            else if (tema == "verde")
            {
                Fuente = fuenteVERDE;
                Fondo = fondoVERDE;
                Paneles = panelesVERDE;
                Fila = filaVERDE;
                FilaAlt = filaAltVERDE;
                Interact = interactVERDE;
            }
            else if (tema == "negro")
            {
                Fuente = fuenteNEGRO;
                Fondo = fondoNEGRO;
                Paneles = panelesNEGRO;
                Fila = filaNEGRO;
                FilaAlt = filaAltNEGRO;
                Interact = interactNEGRO;
            }
            else if(tema == "violeta")
            {
                Fuente = fuenteVIOLETA;
                Fondo = fondoVIOLETA;
                Paneles = panelesVIOLETA;
                Fila = filaVIOLETA;
                FilaAlt = filaAltVIOLETA;
                Interact = interactVIOLETA;
            }
            else if(tema == "amarillo")
            {
                Fuente = fuenteAMARILLO;
                Fondo = fondoAMARILLO;
                Paneles = panelesAMARILLO;
                Fila = filaAMARILLO;
                FilaAlt = filaAltAMARILLO;
                Interact = interactAMARILLO;
            }
            else if (tema == "rojo")
            {
                Fuente = fuenteROJO;
                Fondo = fondoROJO;
                Paneles = panelesROJO;
                Fila = filaROJO;
                FilaAlt = filaAltROJO;
                Interact = interactROJO;
            }
        }
    }
}

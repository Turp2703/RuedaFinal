using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Entidades
{
    public class Inmueble
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Numero_Partida { get; set; }
        public string Direccion_Calle { get; set; }
        public int Direccion_Numero { get; set; }
        public int Precio_Venta { get; set; }
        public int Superficie { get; set; }
        public int Ambientes { get; set; }
        public int Dormitorios { get; set; }
        public int Banos { get; set; }
        public bool Patio { get; set; }
        public bool Garaje { get; set; }
        public string Propietario_DNI { get; set; }
        public string Codigo_Postal { get; set; }
    }
}

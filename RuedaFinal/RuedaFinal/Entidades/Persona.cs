using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Entidades
{
    public class Persona
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Codigo_Postal { get; set; }

        private List<string> telefonos = new List<string>();
        public List<string> Telefonos { get => telefonos; set => telefonos = value; }
        private List<string> emails = new List<string>();
        public List<string> Emails { get => emails; set => emails = value; }
    }
}

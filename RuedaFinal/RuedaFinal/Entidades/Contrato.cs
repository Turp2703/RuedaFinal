using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Entidades
{
    public class Contrato
    {
        public int ID { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Ultimo_Pago { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public int Meses_Antiguedad { get; set; }
        public int Precio_Alquiler { get; set; }
        public int Inmueble_ID { get; set; }
        public string Inquilino_DNI { get; set; }

        public Contrato()
        {
            Meses_Antiguedad = ((DateTime.Now.Year - Fecha_Inicio.Year) * 12) + DateTime.Now.Month - Fecha_Inicio.Month;
        }
    }
}

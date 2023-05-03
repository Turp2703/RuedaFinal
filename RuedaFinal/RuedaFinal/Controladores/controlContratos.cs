using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Controladores
{
    public class controlContratos
    {
        public Contrato[] listaContratos()
        {
            modeloContratos modelo = new modeloContratos();
            Contrato[] contratos = modelo.listaContratos();
            return contratos;
        }

        public string altaContrato(Contrato c)
        {
            modeloContratos modelo = new modeloContratos();
            string rta = "";

            if (modelo.yaExisteContrato(c)) { rta = "Ya existe un contrato entre ese inquilino y ese inmueble."; }
            else if (c.Fecha_Ultimo_Pago < c.Fecha_Inicio 
                  || c.Fecha_Vencimiento < c.Fecha_Ultimo_Pago) { rta = "Fechas incorrectas."; }
            else
            {
                rta = modelo.altaContrato(c);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string modifContrato(Contrato c, Contrato cOriginal)
        {
            modeloContratos modelo = new modeloContratos();
            string rta = "";

            if ((c.Inquilino_DNI != cOriginal.Inquilino_DNI || c.Inmueble_ID != cOriginal.Inmueble_ID)
              && modelo.yaExisteContrato(c)) { rta = "Ya existe un contrato entre ese inquilino y ese inmueble."; }
            else if (c.Fecha_Ultimo_Pago < c.Fecha_Inicio ||
                     c.Fecha_Vencimiento < c.Fecha_Ultimo_Pago) { rta = "Fechas incorrectas."; }
            else
            {
                rta = modelo.modifContrato(c, cOriginal);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string bajaContrato(int id)
        {
            modeloContratos modelo = new modeloContratos();
            string rta = "";

            rta = modelo.bajaContrato(id);
            if (rta == "Fallida") { rta = "Error en la base de datos."; }

            return rta;
        }
    }
}

using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Controladores
{
    public class controlInmuebles
    {
        public Inmueble[] listaInmuebles()
        {
            modeloInmuebles modelo = new modeloInmuebles();
            Inmueble[] inmuebles = modelo.listaInmuebles();
            return inmuebles;
        }
        
        public string altaInmueble(Inmueble inm)
        {
            modeloInmuebles modelo = new modeloInmuebles();
            string rta = "";

            if (string.IsNullOrEmpty(inm.Descripcion) ||
                string.IsNullOrEmpty(inm.Numero_Partida) ||
                string.IsNullOrEmpty(inm.Direccion_Calle) ||
                string.IsNullOrEmpty(inm.Codigo_Postal) ||
                string.IsNullOrEmpty(inm.Propietario_DNI)) { rta = "Datos incompletos, llenar todos los campos."; }
            else
            {
                rta = modelo.altaInmueble(inm);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string modifInmueble(Inmueble inm, Inmueble inmuebleOriginal)
        {
            modeloInmuebles modelo = new modeloInmuebles();
            string rta = "";

            if (string.IsNullOrEmpty(inm.Descripcion) ||
                string.IsNullOrEmpty(inm.Numero_Partida) ||
                string.IsNullOrEmpty(inm.Direccion_Calle) ||
                string.IsNullOrEmpty(inm.Codigo_Postal) ||
                string.IsNullOrEmpty(inm.Propietario_DNI)) { rta = "Datos incompletos, llenar todos los campos."; }
            else
            {
                rta = modelo.modifInmueble(inm, inmuebleOriginal);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }
            
            return rta;
        }

        public string bajaInmueble(int id)
        {
            modeloInmuebles modelo = new modeloInmuebles();
            string rta = "";

            if (modelo.estaEnContrato(id)) 
            {
                rta = "No se puede eliminar el inmueble porque esta en los siguientes contratos: \n";
                Contrato[] cons = modelo.contratosInmueble(id);
                foreach (Contrato c in cons)
                {
                    rta += "#" + c.ID + " - Inquilino: " + c.Inquilino_DNI + " \n";
                }
            }
            else
            {
                rta = modelo.bajaInmueble(id);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }
    }
}

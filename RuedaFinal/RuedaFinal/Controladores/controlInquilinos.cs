using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace RuedaFinal.Controladores
{
    public class controlInquilinos
    {
        public Inquilino[] listaInquilinos()
        {
            modeloInquilinos modelo = new modeloInquilinos();
            Inquilino[] inquilinos = modelo.listaInquilinos();
            return inquilinos;
        }

        public string altaInquilino(Inquilino inqui)
        {
            modeloInquilinos modelo = new modeloInquilinos();
            string rta = "";

            if (string.IsNullOrEmpty(inqui.DNI) ||
                string.IsNullOrEmpty(inqui.Nombre) ||
                string.IsNullOrEmpty(inqui.Apellido) ||
                string.IsNullOrEmpty(inqui.Ocupacion)) { rta = "Datos incompletos, llenar todos los campos."; }
            else if (modelo.yaExisteDNI(inqui.DNI)) { rta = "Ya existe un inquilino con ese DNI."; }
            else if (inqui.Telefonos.Count < 1) { rta = "Debes introducir por lo menos un telefono."; }
            else if (!telefonosCorrectos(inqui.Telefonos)) { rta = "Formato de telefonos incorrecto, introducir solo numeros, separar telefonos con comas y no repetirlos"; }
            else if (inqui.Emails.Count < 1 || !emailsCorrectos(inqui.Emails)) { rta = "Debes introducir por lo menos un E-Mail y no repetirlos."; }
            else
            {
                rta = modelo.altaInquilino(inqui);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }
        private bool telefonosCorrectos(List<string> telefonos)
        {
            bool ret = true;
            int reps = 0;
            foreach (string s in telefonos)
            {
                if (!long.TryParse(s, out long r)) { ret = false; }
                foreach (string s2 in telefonos)
                {
                    if (s.Trim() == s2.Trim()) { reps++; }
                }
                if (reps > 1) { ret = false; }
                reps = 0;
            }
            return ret;
        }
        private bool emailsCorrectos(List<string> emails)
        {
            bool ret = true;
            int reps = 0;
            foreach (string e in emails)
            {
                if (string.IsNullOrEmpty(e)) { ret = false; }
                foreach (string e2 in emails)
                {
                    if (e.Trim() == e2.Trim()) { reps++; }
                }
                if (reps > 1) { ret = false; }
                reps = 0;
            }
            return ret;
        }

        public string modifInquilino(Inquilino inqui, Inquilino iOriginal)
        {
            modeloInquilinos modelo = new modeloInquilinos();
            string rta = "";

            if (string.IsNullOrEmpty(inqui.DNI) ||
                string.IsNullOrEmpty(inqui.Nombre) ||
                string.IsNullOrEmpty(inqui.Apellido) ||
                string.IsNullOrEmpty(inqui.Ocupacion)) { rta = "Datos incompletos, llenar todos los campos."; }
            else if (inqui.DNI != iOriginal.DNI && modelo.yaExisteDNI(inqui.DNI)) { rta = "Ya existe un inquilino con ese DNI."; }
            else if (inqui.Telefonos.Count < 1) { rta = "Debes introducir por lo menos un telefono."; }
            else if (!telefonosCorrectos(inqui.Telefonos)) { rta = "Formato de telefonos incorrecto, introducir solo numeros, separar telefonos con comas y no repetirlos"; }
            else if (inqui.Emails.Count < 1 || !emailsCorrectos(inqui.Emails)) { rta = "Debes introducir por lo menos un E-Mail y no repetirlos."; }
            else
            {
                rta = modelo.modifInquilino(inqui, iOriginal);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string bajaInquilino(string dni)
        {
            modeloInquilinos modelo = new modeloInquilinos();
            string rta = "";

            if (modelo.estaEnContrato(dni))
            {
                rta = "No se puede eliminar al inquilino porque esta en los siguientes contratos: \n";
                Contrato[] cons = modelo.contratosInquilino(dni);
                foreach (Contrato c in cons)
                {
                    rta += "#" + c.ID + " - Inmueble: #" + c.Inmueble_ID + " \n";
                }
            }
            else
            {
                rta = modelo.bajaInquilino(dni);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }
    }
}

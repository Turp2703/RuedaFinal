using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Controladores
{
    class controlDuenos
    {
        public Dueno[] listaDuenos()
        {
            modeloDuenos modelo = new modeloDuenos();
            Dueno[] duenos = modelo.listaDuenos();
            return duenos;
        }

        public string altaDueno(Dueno d)
        {
            modeloDuenos modelo = new modeloDuenos();
            string rta = "";

            if (string.IsNullOrEmpty(d.DNI) ||
                string.IsNullOrEmpty(d.Nombre) ||
                string.IsNullOrEmpty(d.Apellido) ||
                string.IsNullOrEmpty(d.Direccion_Calle)) { rta = "Datos incompletos, llenar todos los campos."; }
            else if (modelo.yaExisteDNI(d.DNI)) { rta = "Ya existe un dueño con ese DNI."; }
            else if (d.Telefonos.Count < 1) { rta = "Debes introducir por lo menos un telefono."; }
            else if (!telefonosCorrectos(d.Telefonos)) { rta = "Formato de telefonos incorrecto, introducir solo numeros, separar telefonos con comas y no repetirlos"; }
            else if (d.Emails.Count < 1 || !emailsCorrectos(d.Emails)) { rta = "Debes introducir por lo menos un E-Mail y no repetirlos."; }
            else
            {
                rta = modelo.altaDueno(d);
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

        public string modifDueno(Dueno d, Dueno dOriginal)
        {
            modeloDuenos modelo = new modeloDuenos();
            string rta = "";

            if (string.IsNullOrEmpty(d.DNI) ||
                string.IsNullOrEmpty(d.Nombre) ||
                string.IsNullOrEmpty(d.Apellido) ||
                string.IsNullOrEmpty(d.Direccion_Calle)) { rta = "Datos incompletos, llenar todos los campos."; }
            else if (d.DNI != dOriginal.DNI && modelo.yaExisteDNI(d.DNI)) { rta = "Ya existe un dueño con ese DNI."; }
            else if (d.Telefonos.Count < 1) { rta = "Debes introducir por lo menos un telefono."; }
            else if (!telefonosCorrectos(d.Telefonos)) { rta = "Formato de telefonos incorrecto, introducir solo numeros, separar telefonos con comas y no repetirlos"; }
            else if (d.Emails.Count < 1 || !emailsCorrectos(d.Emails)) { rta = "Debes introducir por lo menos un E-Mail y no repetirlos."; }
            else
            {
                rta = modelo.modifDueno(d, dOriginal);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string bajaDueno(string dni)
        {
            modeloDuenos modelo = new modeloDuenos();
            string rta = "";

            if (modelo.esDuenio(dni)) 
            {
                rta = "No se puede eliminar al dueño porque posee los siguientes inmuebles: \n"; 
                foreach(Inmueble inm in modelo.inmueblesDuenio(dni))
                {
                    rta += "#" + inm.ID + " - " + inm.Numero_Partida + " - " + inm.Direccion_Calle + " " + inm.Direccion_Numero + " \n";
                }
            }
            else
            {
                rta = modelo.bajaDueno(dni);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }
    }
}

using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Controladores
{
    public class controlLocalidades
    {
        public Localidad[] listaLocalidades()
        {
            modeloLocalidades modelo = new modeloLocalidades();
            Localidad[] localidades = modelo.listaLocalidades();
            return localidades;
        }

        public string altaLocalidad(Localidad localidad)
        {
            modeloLocalidades modelo = new modeloLocalidades();
            string rta = "";

            if (string.IsNullOrEmpty(localidad.CodigoPostal) || string.IsNullOrEmpty(localidad.Nombre)) { rta = "Datos incompletos, llenar todos los campos."; }
            else if (localidad.CodigoPostal.Length > 20) { rta = "El codigo postal excede el limite de 20 caracteres."; }
            else if (modelo.yaExisteCodigoPostal(localidad.CodigoPostal)) { rta = "Una localidad con ese codigo postal ya existe."; }
            else if (localidad.Nombre.Length > 60) { rta = "El nombre excede el limite de 60 caracteres."; }
            else
            {
                rta = modelo.altaLocalidad(localidad);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string modifLocalidad(Localidad localidad, Localidad localidadOriginal)
        {
            modeloLocalidades modelo = new modeloLocalidades();
            string rta = "";

            if (string.IsNullOrEmpty(localidad.CodigoPostal) || string.IsNullOrEmpty(localidad.Nombre)) { rta = "Datos incompletos, llenar todos los campos."; }
            else if (localidad.CodigoPostal.Length > 20) { rta = "El codigo postal excede el limite de 20 caracteres."; }
            else if (localidad.CodigoPostal != localidadOriginal.CodigoPostal && modelo.yaExisteCodigoPostal(localidad.CodigoPostal)) { rta = "Una localidad con ese codigo postal ya existe."; }
            else if (localidad.Nombre.Length > 60) { rta = "El nombre excede el limite de 60 caracteres."; }
            else
            {
                rta = modelo.modifLocalidad(localidad, localidadOriginal);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string bajaLocalidad(Localidad loc)
        {
            modeloLocalidades modelo = new modeloLocalidades();
            string rta = "";

            if (modelo.localidadEnUso(loc)) { rta = "No se puede eliminar una localidad en uso"; }
            else
            {
                rta = modelo.bajaLocalidad(loc);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }
            
            return rta;
        }
    }
}

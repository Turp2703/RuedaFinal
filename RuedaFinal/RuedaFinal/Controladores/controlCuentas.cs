using RuedaFinal.Entidades;
using RuedaFinal.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RuedaFinal.Controladores
{
    public class controlCuentas
    {
        private Cuenta ultimaCuenta = null;

        public string ctrlSesion(string strUsuario, string strClave)
        {
            string rta = "";

            if (string.IsNullOrEmpty(strUsuario) || string.IsNullOrEmpty(strClave)) { rta = "Datos incompletos, llenar todos los campos."; }
            else
            {
                modeloCuentas modelo = new modeloCuentas();
                Cuenta resultado = modelo.obtenerCuenta(strUsuario);
                if (resultado == null) { rta = "El usuario no existe o no hay conexion con la base de datos."; }
                else if (resultado.Clave == generarSHA1(strClave)) { rta = "Ingresando"; ultimaCuenta = resultado; }
                else { rta = "Contraseña incorrecta."; }
            }

            return rta;
        }

        public int obtenerUltimoTipo()
        {
            if (ultimaCuenta != null) { return ultimaCuenta.TipoID; }
            else { return 0; }
        }

        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                    sb.Append("0");
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }

        public Cuenta[] listaCuentas()
        {
            modeloCuentas modelo = new modeloCuentas();
            Cuenta[] cuentas = modelo.listaCuentas();
            return cuentas;
        }

        public string altaCuenta(string strUsuario, string strClave, string strConfClave)
        {
            modeloCuentas modelo = new modeloCuentas();
            string rta = "";

            if (string.IsNullOrEmpty(strUsuario) || string.IsNullOrEmpty(strClave) || string.IsNullOrEmpty(strConfClave))
            {
                rta = "Datos incompletos, llenar todos los campos.";
            }
            else if (strUsuario.Length > 50) { rta = "El nombre de usuario excede el limite de 50 caracteres."; }
            else if (modelo.yaExisteUsuario(strUsuario)) { rta = "Un usuario con ese nombre ya existe."; }
            else if (strClave.Length > 50) { rta = "La clave excede el limite de 50 caracteres."; }
            else if (strClave != strConfClave) { rta = "Las contraseñas no coinciden."; }
            else
            {
                rta = modelo.altaUsuario(strUsuario, generarSHA1(strClave));
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string modifCuenta(string strUsuario, string usuarioOriginal)
        {
            modeloCuentas modelo = new modeloCuentas();
            string rta = "";

            if (string.IsNullOrEmpty(strUsuario)) { rta = "Datos Incompletos, llenar todos los campos."; }
            else if (strUsuario.Length > 50) { rta = "El nuevo nombre de usuario excede el limite de 50 caracteres."; }
            else if (strUsuario != usuarioOriginal && modelo.yaExisteUsuario(strUsuario)) { rta = "Un usuario con ese nombre ya existe."; }
            else
            {
                rta = modelo.modifCuenta(strUsuario, usuarioOriginal);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }

        public string bajaCuenta(string idCuenta)
        {
            modeloCuentas modelo = new modeloCuentas();
            string rta = "";

            if (modelo.esAdmin(idCuenta)) { rta = "No se puede eliminar una cuenta de tipo 'Administrador'"; }
            else
            {
                rta = modelo.bajaCuenta(idCuenta);
                if (rta == "Fallida") { rta = "Error en la base de datos."; }
            }

            return rta;
        }
    }
}

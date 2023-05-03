using MySql.Data.MySqlClient;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuedaFinal.Modelos
{
    public class modeloLocalidades
    {
        static MySqlConnection conexion = Conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;

        public bool yaExisteCodigoPostal(string codigoPostal)
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM localidad WHERE Codigo_Postal=@codigo";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@codigo", codigoPostal);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                conexion.Close();
                return cantidad > 0;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return true;
            }
        }

        public bool localidadEnUso(Localidad localidad)
        {
            bool ret = false;

            modeloDuenos mDuenos = new modeloDuenos();
            Dueno[] duenos = mDuenos.listaDuenos();
            foreach (Dueno d in duenos)
            {
                if (d.Codigo_Postal == localidad.CodigoPostal) { ret = true; }
            }

            modeloInmuebles mInmuebles = new modeloInmuebles();
            Inmueble[] inmuebles = mInmuebles.listaInmuebles();
            foreach (Inmueble i in inmuebles)
            {
                if (i.Codigo_Postal == localidad.CodigoPostal) { ret = true; }
            }

            modeloInquilinos mInquilinos = new modeloInquilinos();
            Inquilino[] inquilinos = mInquilinos.listaInquilinos();
            foreach (Inquilino i in inquilinos)
            {
                if (i.Codigo_Postal == localidad.CodigoPostal) { ret = true; }
            }

            return ret;
        }

        public Localidad[] listaLocalidades()
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM localidad";
                comando = new MySqlCommand(sql, conexion);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Localidad[] localidades = new Localidad[cantidad];
                sql = "SELECT * FROM localidad";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        localidades[i] = new Localidad();
                        localidades[i].CodigoPostal = reader["Codigo_Postal"].ToString();
                        localidades[i].Nombre = reader["Nombre"].ToString();
                        i++;
                    }
                }

                conexion.Close();
                return localidades;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string altaLocalidad(Localidad localidad)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "INSERT INTO localidad(Codigo_Postal, Nombre) VALUES(@codigo, @nombre)";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@codigo", localidad.CodigoPostal);
                comando.Parameters.AddWithValue("@nombre", localidad.Nombre);

                int registrosAgregados = comando.ExecuteNonQuery();
                if (registrosAgregados > 0) { rta = "Exitosa"; }
                else { rta = "Fallida"; }

                conexion.Close();
                return rta;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string modifLocalidad(Localidad localidad, Localidad localidadOriginal)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "UPDATE localidad SET Codigo_Postal=@codigo, Nombre=@nombre WHERE Codigo_Postal=@original";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@codigo", localidad.CodigoPostal);
                comando.Parameters.AddWithValue("@nombre", localidad.Nombre);
                comando.Parameters.AddWithValue("@original", localidadOriginal.CodigoPostal);

                int registrosModificados = comando.ExecuteNonQuery();
                if (registrosModificados > 0) { rta = "Exitosa"; }
                else { rta = "Fallida"; }

                conexion.Close();
                return rta;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string bajaLocalidad(Localidad localidad)
        {
            try
            {
                conexion.Open();
                string rta = "";

                sql = "DELETE FROM localidad WHERE Codigo_Postal=@codigo";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@codigo", localidad.CodigoPostal);

                int registrosModificados = comando.ExecuteNonQuery();
                if (registrosModificados > 0) { rta = "Exitosa"; }
                else { rta = "Fallida"; }

                conexion.Close();
                return rta;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}

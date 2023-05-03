using MySql.Data.MySqlClient;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuedaFinal.Modelos
{
    public class modeloCuentas
    {
        static MySqlConnection conexion = Conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;

        public Cuenta obtenerCuenta(string strUsuario)
        {
            try
            {
                Cuenta cuenta = null;
                conexion.Open();

                sql = "SELECT * FROM cuenta WHERE Usuario LIKE @user";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@user", strUsuario);

                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cuenta = new Cuenta
                        {
                            Id = int.Parse(reader["ID"].ToString()),
                            Usuario = reader["Usuario"].ToString(),
                            Clave = reader["Clave"].ToString(),
                            TipoID = int.Parse(reader["Tipo_ID"].ToString())
                        };
                    }
                }

                conexion.Close();
                return cuenta;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public Cuenta[] listaCuentas()
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM cuenta";
                comando = new MySqlCommand(sql, conexion);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Cuenta[] cuentas = new Cuenta[cantidad];
                sql = "SELECT * FROM cuenta";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        cuentas[i] = new Cuenta();
                        cuentas[i].Id = int.Parse(reader["ID"].ToString());
                        cuentas[i].Usuario = reader["Usuario"].ToString();
                        cuentas[i].Clave = reader["Clave"].ToString();
                        cuentas[i].TipoID = int.Parse(reader["Tipo_ID"].ToString());
                        i++;
                    }
                }

                conexion.Close();
                return cuentas;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string altaUsuario(string strUsuario, string strClave)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "INSERT INTO cuenta(ID, Usuario, Clave, Tipo_ID) VALUES(@id, @usuario, @clave, @tipo)";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", null);
                comando.Parameters.AddWithValue("@usuario", strUsuario);
                comando.Parameters.AddWithValue("@clave", strClave);
                comando.Parameters.AddWithValue("@tipo", 2);

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

        public bool yaExisteUsuario(string strUsuario)
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM cuenta WHERE Usuario=@usuario";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@usuario", strUsuario);
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

        public string modifCuenta(string strUsuario, string usuarioOriginal)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "UPDATE cuenta SET Usuario=@usuario WHERE Usuario=@original";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@usuario", strUsuario);
                comando.Parameters.AddWithValue("@original", usuarioOriginal);

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

        public bool esAdmin(string idUsuario)
        {
            try
            {
                conexion.Open();

                sql = "SELECT Tipo_ID FROM cuenta WHERE ID=@id";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", idUsuario);
                string rta = comando.ExecuteScalar().ToString();

                conexion.Close();
                return rta == "1";
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return true;
            }
        }

        public string bajaCuenta(string idCuenta)
        {
            try
            {
                conexion.Open();
                string rta = "";

                sql = "DELETE FROM cuenta WHERE ID=@id";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", idCuenta);

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

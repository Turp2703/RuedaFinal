using MySql.Data.MySqlClient;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuedaFinal.Modelos
{
    public class modeloContratos
    {
        static MySqlConnection conexion = Conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;

        public bool yaExisteContrato(Contrato c)
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM contrato WHERE Inquilino_DNI=@inq AND Inmueble_ID=@inm";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@inq", c.Inquilino_DNI);
                comando.Parameters.AddWithValue("@inm", c.Inmueble_ID);
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

        public Contrato[] listaContratos()
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM contrato";
                comando = new MySqlCommand(sql, conexion);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Contrato[] contratos = new Contrato[cantidad];
                sql = "SELECT * FROM contrato";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        contratos[i] = new Contrato
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Fecha_Inicio = DateTime.Parse(reader["Fecha_Inicio"].ToString()),
                            Fecha_Ultimo_Pago = DateTime.Parse(reader["Fecha_Ultimo_Pago"].ToString()),
                            Fecha_Vencimiento = DateTime.Parse(reader["Fecha_Vencimiento"].ToString()),
                            Meses_Antiguedad = int.Parse(reader["Meses_Antiguedad"].ToString()),
                            Precio_Alquiler = int.Parse(reader["Precio_Alquiler"].ToString()),
                            Inmueble_ID = int.Parse(reader["Inmueble_ID"].ToString()),
                            Inquilino_DNI = reader["Inquilino_DNI"].ToString()
                        };
                        i++;
                    }
                }
                reader.Close();

                conexion.Close();
                return contratos;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string altaContrato(Contrato c)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "INSERT INTO contrato(ID, Fecha_Inicio, Fecha_Ultimo_Pago, Fecha_Vencimiento, Meses_Antiguedad, Precio_Alquiler, Inmueble_ID, Inquilino_DNI)" +
                      " VALUES(@id, @finicio, @fultimo, @fvenc, @meses, @precio, @inmueble, @inquilino)";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", c.ID);
                comando.Parameters.AddWithValue("@finicio", c.Fecha_Inicio);
                comando.Parameters.AddWithValue("@fultimo", c.Fecha_Ultimo_Pago);
                comando.Parameters.AddWithValue("@fvenc", c.Fecha_Vencimiento);
                comando.Parameters.AddWithValue("@meses", c.Meses_Antiguedad);
                comando.Parameters.AddWithValue("@precio", c.Precio_Alquiler);
                comando.Parameters.AddWithValue("@inmueble", c.Inmueble_ID);
                comando.Parameters.AddWithValue("@inquilino", c.Inquilino_DNI);
                int contratosAgregados = comando.ExecuteNonQuery();

                if (contratosAgregados > 0) { rta = "Exitosa"; }
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

        public string modifContrato(Contrato c, Contrato cOriginal)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "UPDATE contrato SET " +
                      "Fecha_Inicio=@finicio, " +
                      "Fecha_Ultimo_Pago=@fultimo, " +
                      "Fecha_Vencimiento=@fvenc, " +
                      "Meses_Antiguedad=@meses, " +
                      "Precio_Alquiler=@precio, " +
                      "Inmueble_ID=@inmueble, " +
                      "Inquilino_DNI=@inquilino " +
                      "WHERE ID=@original";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@finicio", c.Fecha_Inicio);
                comando.Parameters.AddWithValue("@fultimo", c.Fecha_Ultimo_Pago);
                comando.Parameters.AddWithValue("@fvenc", c.Fecha_Vencimiento);
                comando.Parameters.AddWithValue("@meses", c.Meses_Antiguedad);
                comando.Parameters.AddWithValue("@precio", c.Precio_Alquiler);
                comando.Parameters.AddWithValue("@inmueble", c.Inmueble_ID);
                comando.Parameters.AddWithValue("@inquilino", c.Inquilino_DNI);
                comando.Parameters.AddWithValue("@original", cOriginal.ID);
                int duenosModificados = comando.ExecuteNonQuery();

                if (duenosModificados > 0) { rta = "Exitosa"; }
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

        public string bajaContrato(int id)
        {
            try
            {
                conexion.Open();
                string rta = "";

                sql = "DELETE FROM contrato WHERE ID=@id";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                int duenosModificados = comando.ExecuteNonQuery();

                if (duenosModificados > 0) { rta = "Exitosa"; }
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

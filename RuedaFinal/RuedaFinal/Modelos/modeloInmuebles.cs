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
    public class modeloInmuebles
    {
        static MySqlConnection conexion = Conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;

        public bool estaEnContrato(int id)
        {
            bool ret = false;

            modeloContratos mContratos = new modeloContratos();
            Contrato[] contratos = mContratos.listaContratos();
            foreach (Contrato c in contratos)
            {
                if (c.Inmueble_ID == id) { ret = true; }
            }
            
            return ret;
        }
        public Contrato[] contratosInmueble(int id)
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM contrato WHERE Inmueble_ID=@id";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Contrato[] contratos = new Contrato[cantidad];
                sql = "SELECT * FROM contrato WHERE Inmueble_ID=@id";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
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

        public Inmueble[] listaInmuebles()
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM inmueble";
                comando = new MySqlCommand(sql, conexion);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Inmueble[] inmuebles = new Inmueble[cantidad];
                sql = "SELECT * FROM inmueble";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        inmuebles[i] = new Inmueble
                        {
                            ID = int.Parse(reader["ID"].ToString()),
                            Descripcion = reader["Descripcion"].ToString(),
                            Numero_Partida = reader["Numero_Partida"].ToString(),
                            Direccion_Calle = reader["Direccion_Calle"].ToString(),
                            Direccion_Numero = int.Parse(reader["Direccion_Numero"].ToString()),
                            Precio_Venta = int.Parse(reader["Precio_Venta"].ToString()),
                            Superficie = int.Parse(reader["Superficie"].ToString()),
                            Ambientes = int.Parse(reader["Ambientes"].ToString()),
                            Dormitorios = int.Parse(reader["Dormitorios"].ToString()),
                            Banos = int.Parse(reader["Banos"].ToString()),
                            Patio = reader["Patio"].ToString() == "True",
                            Garaje = reader["Garaje"].ToString() == "True",
                            Propietario_DNI = reader["Propietario_DNI"].ToString(),
                            Codigo_Postal = reader["Codigo_Postal"].ToString()
                        };
                        i++;
                    }
                }

                conexion.Close();
                return inmuebles;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string altaInmueble(Inmueble inm)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "INSERT INTO inmueble(ID, Descripcion, Numero_Partida, Direccion_Calle, Direccion_Numero, Precio_Venta, Superficie, Ambientes, Dormitorios, Banos, Patio, Garaje, Codigo_Postal, Propietario_DNI)" +
                      "VALUES(@id, @desc, @numPar, @dirCalle, @dirNum, @precVen, @super, @cantAmb, @dorms, @banos, @patio, @garaje, @codPos, @propDNI)";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", null);
                comando.Parameters.AddWithValue("@desc", inm.Descripcion);
                comando.Parameters.AddWithValue("@numPar", inm.Numero_Partida);
                comando.Parameters.AddWithValue("@dirCalle", inm.Direccion_Calle);
                comando.Parameters.AddWithValue("@dirNum", inm.Direccion_Numero);
                comando.Parameters.AddWithValue("@precVen", inm.Precio_Venta);
                comando.Parameters.AddWithValue("@super", inm.Superficie);
                comando.Parameters.AddWithValue("@cantAmb", inm.Ambientes);
                comando.Parameters.AddWithValue("@dorms", inm.Dormitorios);
                comando.Parameters.AddWithValue("@banos", inm.Banos);
                comando.Parameters.AddWithValue("@patio", inm.Patio);
                comando.Parameters.AddWithValue("@garaje", inm.Garaje);
                comando.Parameters.AddWithValue("@codPos", inm.Codigo_Postal);
                comando.Parameters.AddWithValue("@propDNI", inm.Propietario_DNI);
                
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

        public string modifInmueble(Inmueble inm, Inmueble inmuebleOriginal)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "UPDATE inmueble SET " +
                      "Descripcion=@desc, " +
                      "Numero_Partida=@numPar, " +
                      "Direccion_Calle=@dirCalle, " +
                      "Direccion_Numero=@dirNum, " +
                      "Precio_Venta=@precVen, " +
                      "Superficie=@super, " +
                      "Ambientes=@cantAmb, " +
                      "Dormitorios=@dorms, " +
                      "Banos=@banos, " +
                      "Patio=@patio, " +
                      "Garaje=@garaje, " +
                      "Codigo_Postal=@codPos, " +
                      "Propietario_DNI=@propDNI " +
                      "WHERE ID=@original";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@desc", inm.Descripcion);
                comando.Parameters.AddWithValue("@numPar", inm.Numero_Partida);
                comando.Parameters.AddWithValue("@dirCalle", inm.Direccion_Calle);
                comando.Parameters.AddWithValue("@dirNum", inm.Direccion_Numero);
                comando.Parameters.AddWithValue("@precVen", inm.Precio_Venta);
                comando.Parameters.AddWithValue("@super", inm.Superficie);
                comando.Parameters.AddWithValue("@cantAmb", inm.Ambientes);
                comando.Parameters.AddWithValue("@dorms", inm.Dormitorios);
                comando.Parameters.AddWithValue("@banos", inm.Banos);
                comando.Parameters.AddWithValue("@patio", inm.Patio);
                comando.Parameters.AddWithValue("@garaje", inm.Garaje);
                comando.Parameters.AddWithValue("@codPos", inm.Codigo_Postal);
                comando.Parameters.AddWithValue("@propDNI", inm.Propietario_DNI);
                comando.Parameters.AddWithValue("@original", inmuebleOriginal.ID);
                int inmueblesModificados = comando.ExecuteNonQuery();

                if (inmueblesModificados > 0) { rta = "Exitosa"; }
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

        public string bajaInmueble(int id)
        {
            try
            {
                conexion.Open();
                string rta = "";

                sql = "DELETE FROM inmueble WHERE ID=@id";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@id", id);
                int inmueblesModificados = comando.ExecuteNonQuery();

                if (inmueblesModificados > 0) { rta = "Exitosa"; }
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

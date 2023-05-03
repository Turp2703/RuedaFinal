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
    class modeloDuenos
    {
        static MySqlConnection conexion = Conexion.getConexion();
        static string sql = "";
        static MySqlCommand comando;
        static MySqlDataReader reader;

        public bool yaExisteDNI(string dni)
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM dueno WHERE DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
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

        public bool esDuenio(string dni)
        {
            bool ret = false;

            modeloInmuebles mInmuebles = new modeloInmuebles();
            Inmueble[] inmuebles = mInmuebles.listaInmuebles();
            foreach (Inmueble i in inmuebles)
            {
                if (i.Propietario_DNI == dni) { ret = true; }
            }

            return ret;
        }
        public Inmueble[] inmueblesDuenio(string dni)
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM inmueble WHERE Propietario_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Inmueble[] inmuebles = new Inmueble[cantidad];
                sql = "SELECT * FROM inmueble WHERE Propietario_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
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
                reader.Close();

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

        public Dueno[] listaDuenos()
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM dueno";
                comando = new MySqlCommand(sql, conexion);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Dueno[] duenos = new Dueno[cantidad];
                sql = "SELECT * FROM dueno";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        duenos[i] = new Dueno
                        {
                            DNI = reader["DNI"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Direccion_Calle = reader["Direccion_Calle"].ToString(),
                            Direccion_Numero = int.Parse(reader["Direccion_Numero"].ToString()),
                            Sexo = reader["Sexo"].ToString(),
                            Fecha_Nacimiento = DateTime.Parse(reader["Fecha_Nacimiento"].ToString()),
                            Codigo_Postal = reader["Codigo_Postal"].ToString()
                        };
                        i++;
                    }
                }
                reader.Close();

                sql = "SELECT * FROM duenotelefono";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Dueno d = Array.Find(duenos, due => due.DNI == reader["Dueno_DNI"].ToString());
                        d.Telefonos.Add(reader["Telefono"].ToString());
                        i++;
                    }
                }
                reader.Close();

                sql = "SELECT * FROM duenoemail";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Dueno d = Array.Find(duenos, due => due.DNI == reader["Dueno_DNI"].ToString());
                        d.Emails.Add(reader["Email"].ToString());
                        i++;
                    }
                }

                conexion.Close();
                return duenos;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string altaDueno(Dueno d)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "INSERT INTO dueno(DNI, Nombre, Apellido, Direccion_Calle, Direccion_Numero, Sexo, Fecha_Nacimiento, Codigo_Postal)" +
                      " VALUES(@dni, @nombre, @apellido, @dirCalle, @dirNum, @sexo, @fnac, @codPos)";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", d.DNI);
                comando.Parameters.AddWithValue("@nombre", d.Nombre);
                comando.Parameters.AddWithValue("@apellido", d.Apellido);
                comando.Parameters.AddWithValue("@dirCalle", d.Direccion_Calle);
                comando.Parameters.AddWithValue("@dirNum", d.Direccion_Numero);
                comando.Parameters.AddWithValue("@sexo", d.Sexo);
                comando.Parameters.AddWithValue("@fnac", d.Fecha_Nacimiento);
                comando.Parameters.AddWithValue("@codPos", d.Codigo_Postal);
                int duenosAgregados = comando.ExecuteNonQuery();

                int telefonosAgregados = 0;
                for (int i = 0; i < d.Telefonos.Count; i++)
                {
                    sql = "INSERT INTO duenotelefono(Dueno_DNI, Telefono) VALUES(@dni, @tel)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", d.DNI);
                    comando.Parameters.AddWithValue("@tel", d.Telefonos[i].Trim());
                    comando.ExecuteNonQuery();
                    telefonosAgregados++;
                }

                int emailsAgregados = 0;
                for (int i = 0; i < d.Emails.Count; i++)
                {
                    sql = "INSERT INTO duenoemail(Dueno_DNI, EMail) VALUES(@dni, @mail)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", d.DNI);
                    comando.Parameters.AddWithValue("@mail", d.Emails[i].Trim());
                    comando.ExecuteNonQuery();
                    emailsAgregados++;
                }

                if (duenosAgregados > 0 && telefonosAgregados > 0 && emailsAgregados > 0) { rta = "Exitosa"; }
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

        public string modifDueno(Dueno d, Dueno dOriginal)
        {
            try
            {
                string rta = "";
                conexion.Open();

                int telefonosModificados = 0;
                sql = "DELETE FROM duenotelefono WHERE Dueno_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dOriginal.DNI);
                telefonosModificados += comando.ExecuteNonQuery();

                int emailsModificados = 0;
                sql = "DELETE FROM duenoemail WHERE Dueno_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dOriginal.DNI);
                emailsModificados += comando.ExecuteNonQuery();

                sql = "UPDATE dueno SET " +
                      "DNI=@dni, " +
                      "Nombre=@nombre, " +
                      "Apellido=@apellido, " +
                      "Direccion_Calle=@dirCalle, " +
                      "Direccion_Numero=@dirNum, " +
                      "Sexo=@sexo, " +
                      "Fecha_Nacimiento=@fnac, " +
                      "Codigo_Postal=@codPos " +
                      "WHERE DNI=@original";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", d.DNI);
                comando.Parameters.AddWithValue("@nombre", d.Nombre);
                comando.Parameters.AddWithValue("@apellido", d.Apellido);
                comando.Parameters.AddWithValue("@dirCalle", d.Direccion_Calle);
                comando.Parameters.AddWithValue("@dirNum", d.Direccion_Numero);
                comando.Parameters.AddWithValue("@sexo", d.Sexo);
                comando.Parameters.AddWithValue("@fnac", d.Fecha_Nacimiento);
                comando.Parameters.AddWithValue("@codPos", d.Codigo_Postal);
                comando.Parameters.AddWithValue("@original", dOriginal.DNI);
                int duenosModificados = comando.ExecuteNonQuery();

                for (int i = 0; i < d.Telefonos.Count; i++)
                {
                    sql = "INSERT INTO duenotelefono(Dueno_DNI, Telefono) VALUES(@dni, @tel)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", d.DNI);
                    comando.Parameters.AddWithValue("@tel", d.Telefonos[i].Trim());
                    comando.ExecuteNonQuery();
                    telefonosModificados++;
                }

                for (int i = 0; i < d.Emails.Count; i++)
                {
                    sql = "INSERT INTO duenoemail(Dueno_DNI, email) VALUES(@dni, @mail)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", d.DNI);
                    comando.Parameters.AddWithValue("@mail", d.Emails[i].Trim());
                    comando.ExecuteNonQuery();
                    emailsModificados++;
                }

                if (duenosModificados > 0 && telefonosModificados > 0 && emailsModificados > 0) { rta = "Exitosa"; }
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

        public string bajaDueno(string dni)
        {
            try
            {
                conexion.Open();
                string rta = "";

                sql = "DELETE FROM duenotelefono WHERE Dueno_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int telefonosModificados = comando.ExecuteNonQuery();

                sql = "DELETE FROM duenoemail WHERE Dueno_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int emailsModificados = comando.ExecuteNonQuery();

                sql = "DELETE FROM dueno WHERE DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int duenosModificados = comando.ExecuteNonQuery();

                if (duenosModificados > 0 && telefonosModificados > 0 && emailsModificados > 0) { rta = "Exitosa"; }
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

using MySql.Data.MySqlClient;
using RuedaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace RuedaFinal.Modelos
{
    public class modeloInquilinos
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

                sql = "SELECT COUNT(*) FROM inquilino WHERE DNI=@dni";
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

        public bool estaEnContrato(string dni)
        {
            bool ret = false;

            modeloContratos mContratos = new modeloContratos();
            Contrato[] contratos = mContratos.listaContratos();
            foreach (Contrato c in contratos)
            {
                if (c.Inquilino_DNI == dni) { ret = true; }
            }

            return ret;
        }
        public Contrato[] contratosInquilino(string dni)
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM contrato WHERE Inquilino_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Contrato[] contratos = new Contrato[cantidad];
                sql = "SELECT * FROM contrato WHERE Inquilino_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
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

        public Inquilino[] listaInquilinos()
        {
            try
            {
                conexion.Open();

                sql = "SELECT COUNT(*) FROM inquilino";
                comando = new MySqlCommand(sql, conexion);
                int cantidad = int.Parse(comando.ExecuteScalar().ToString());

                Inquilino[] inquilinos = new Inquilino[cantidad];
                sql = "SELECT * FROM inquilino";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        inquilinos[i] = new Inquilino
                        {
                            DNI = reader["DNI"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Ocupacion = reader["Ocupacion"].ToString(),
                            Cantidad_Vehiculos = int.Parse(reader["Cantidad_Vehiculos"].ToString()),
                            Sexo = reader["Sexo"].ToString(),
                            Fecha_Nacimiento = DateTime.Parse(reader["Fecha_Nacimiento"].ToString()),
                            Codigo_Postal = reader["Codigo_Postal"].ToString()
                        };
                        i++;
                    }
                }
                reader.Close();

                sql = "SELECT * FROM inquilinotelefono";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Inquilino inqui = Array.Find(inquilinos, inq => inq.DNI == reader["Inquilino_DNI"].ToString());
                        inqui.Telefonos.Add(reader["Telefono"].ToString());
                        i++;
                    }
                }
                reader.Close();

                sql = "SELECT * FROM inquilinoemail";
                comando = new MySqlCommand(sql, conexion);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Inquilino inqui = Array.Find(inquilinos, inq => inq.DNI == reader["Inquilino_DNI"].ToString());
                        inqui.Emails.Add(reader["Email"].ToString());
                        i++;
                    }
                }

                conexion.Close();
                return inquilinos;
            }
            catch (Exception ex)
            {
                conexion.Close();
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public string altaInquilino(Inquilino inqui)
        {
            try
            {
                string rta = "";
                conexion.Open();

                sql = "INSERT INTO inquilino(DNI, Nombre, Apellido, Ocupacion, Cantidad_Vehiculos, Sexo, Fecha_Nacimiento, Codigo_Postal)" +
                      " VALUES(@dni, @nombre, @apellido, @ocup, @vehi, @sexo, @fnac, @codPos)";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", inqui.DNI);
                comando.Parameters.AddWithValue("@nombre", inqui.Nombre);
                comando.Parameters.AddWithValue("@apellido", inqui.Apellido);
                comando.Parameters.AddWithValue("@ocup", inqui.Ocupacion);
                comando.Parameters.AddWithValue("@vehi", inqui.Cantidad_Vehiculos);
                comando.Parameters.AddWithValue("@sexo", inqui.Sexo);
                comando.Parameters.AddWithValue("@fnac", inqui.Fecha_Nacimiento);
                comando.Parameters.AddWithValue("@codPos", inqui.Codigo_Postal);
                int inquilinosAgregados = comando.ExecuteNonQuery();

                int telefonosAgregados = 0;
                for (int i = 0; i < inqui.Telefonos.Count; i++)
                {
                    sql = "INSERT INTO inquilinotelefono(Inquilino_DNI, Telefono) VALUES(@dni, @tel)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", inqui.DNI);
                    comando.Parameters.AddWithValue("@tel", inqui.Telefonos[i].Trim());
                    comando.ExecuteNonQuery();
                    telefonosAgregados++;
                }

                int emailsAgregados = 0;
                for (int i = 0; i < inqui.Emails.Count; i++)
                {
                    sql = "INSERT INTO inquilinoemail(Inquilino_DNI, EMail) VALUES(@dni, @mail)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", inqui.DNI);
                    comando.Parameters.AddWithValue("@mail", inqui.Emails[i].Trim());
                    comando.ExecuteNonQuery();
                    emailsAgregados++;
                }

                if (inquilinosAgregados > 0 && telefonosAgregados > 0 && emailsAgregados > 0) { rta = "Exitosa"; }
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

        public string modifInquilino(Inquilino inqui, Inquilino iOriginal)
        {
            try
            {
                string rta = "";
                conexion.Open();

                int telefonosModificados = 0;
                sql = "DELETE FROM inquilinotelefono WHERE Inquilino_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", iOriginal.DNI);
                telefonosModificados += comando.ExecuteNonQuery();

                int emailsModificados = 0;
                sql = "DELETE FROM inquilinoemail WHERE Inquilino_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", iOriginal.DNI);
                emailsModificados += comando.ExecuteNonQuery();

                sql = "UPDATE inquilino SET " +
                      "DNI=@dni, " +
                      "Nombre=@nombre, " +
                      "Apellido=@apellido, " +
                      "Ocupacion=@ocup, " +
                      "Cantidad_Vehiculos=@vehi, " +
                      "Sexo=@sexo, " +
                      "Fecha_Nacimiento=@fnac, " +
                      "Codigo_Postal=@codPos " +
                      "WHERE DNI=@original";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", inqui.DNI);
                comando.Parameters.AddWithValue("@nombre", inqui.Nombre);
                comando.Parameters.AddWithValue("@apellido", inqui.Apellido);
                comando.Parameters.AddWithValue("@ocup", inqui.Ocupacion);
                comando.Parameters.AddWithValue("@vehi", inqui.Cantidad_Vehiculos);
                comando.Parameters.AddWithValue("@sexo", inqui.Sexo);
                comando.Parameters.AddWithValue("@fnac", inqui.Fecha_Nacimiento);
                comando.Parameters.AddWithValue("@codPos", inqui.Codigo_Postal);
                comando.Parameters.AddWithValue("@original", iOriginal.DNI);
                int inquilinosModificados = comando.ExecuteNonQuery();

                for (int i = 0; i < inqui.Telefonos.Count; i++)
                {
                    sql = "INSERT INTO inquilinotelefono(Inquilino_DNI, Telefono) VALUES(@dni, @tel)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", inqui.DNI);
                    comando.Parameters.AddWithValue("@tel", inqui.Telefonos[i].Trim());
                    comando.ExecuteNonQuery();
                    telefonosModificados++;
                }

                for (int i = 0; i < inqui.Emails.Count; i++)
                {
                    sql = "INSERT INTO inquilinoemail(Inquilino_DNI, email) VALUES(@dni, @mail)";
                    comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@dni", inqui.DNI);
                    comando.Parameters.AddWithValue("@mail", inqui.Emails[i].Trim());
                    comando.ExecuteNonQuery();
                    emailsModificados++;
                }

                if (inquilinosModificados > 0 && telefonosModificados > 0 && emailsModificados > 0) { rta = "Exitosa"; }
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

        public string bajaInquilino(string dni)
        {
            try
            {
                conexion.Open();
                string rta = "";

                sql = "DELETE FROM inquilinotelefono WHERE Inquilino_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int telefonosModificados = comando.ExecuteNonQuery();

                sql = "DELETE FROM inquilinoemail WHERE Inquilino_DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int emailsModificados = comando.ExecuteNonQuery();

                sql = "DELETE FROM inquilino WHERE DNI=@dni";
                comando = new MySqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@dni", dni);
                int inquilinosModificados = comando.ExecuteNonQuery();

                if (inquilinosModificados > 0 && telefonosModificados > 0 && emailsModificados > 0) { rta = "Exitosa"; }
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

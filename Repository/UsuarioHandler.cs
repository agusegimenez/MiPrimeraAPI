using MiPrimeraAPI.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraAPI.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString = "Server=LAPTOP-UMJOUFAT;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> resultados = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                resultados.Add(usuario);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return resultados;
        }

        public static bool BorrarUsuario(int id)
        {
            bool resultado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE * FROM Usuario WHERE Id = @id";

                SqlParameter sqlParameter = new SqlParameter("id", SqlDbType.BigInt);
                sqlParameter.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows>0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();
            }

            return resultado;
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            bool resultado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO Usuario (Nombre, Apellido, Contraseña, NombreUsuario, Mail) VALUES (@Nombre, @Apellido, @Contraseña, @NombreUsuario, @Mail)";

                SqlParameter nombreParametro = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParametro = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter contraseñaParametro = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter usuarioParametro = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter mailParametro = new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParametro);
                    sqlCommand.Parameters.Add(apellidoParametro);
                    sqlCommand.Parameters.Add(contraseñaParametro);
                    sqlCommand.Parameters.Add(usuarioParametro);
                    sqlCommand.Parameters.Add(mailParametro);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows>0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close(); 

            }

            return resultado;
        }

        public static bool CambiarDatos(Usuario usuario)
        {
            bool resultado = false;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE Usuario SET (Nombre=@Nombre, Apellido=@Apellido, Contraseña=@Contraseña, NombreUsuario=@NombreUsuario, Mail=@Mail) WHERE Id=@Id";

                SqlParameter idParametro = new SqlParameter("Id", SqlDbType.BigInt) { Value = usuario.Id };
                SqlParameter nombreParametro = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParametro = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter contraseñaParametro = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter usuarioParametro = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter mailParametro = new SqlParameter("Mail", SqlDbType.VarChar) { Value = usuario.Mail };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParametro);
                    sqlCommand.Parameters.Add(apellidoParametro);
                    sqlCommand.Parameters.Add(contraseñaParametro);
                    sqlCommand.Parameters.Add(usuarioParametro);
                    sqlCommand.Parameters.Add(mailParametro);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();

            }

            return resultado;
        }
    }
}

using ProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString = "Server=DESKTOP-CDSDU8R;Database=SistemaGestion;Trusted_Connection=True";


        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM USUARIO",sqlConnection))
                {
                    sqlConnection.Open();
                    
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // pregunto si hay filas 
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader ["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Email = dataReader["Email"].ToString();

                                usuarios.Add(usuario);

                            }
                        }
                    }

                }
                  
            }

            return usuarios;
        }
        
        public static Usuario FindUsuario(string nombreUsuario, string contraseña)
        {
            Usuario usuarioEncontrado = new Usuario();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand("SELECT *  FROM USUARIO WHERE NombreUsuario = @pNobreUsuario AND Contraseña = @pContraseña", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@pNombreUsuario", nombreUsuario);
                    sqlCommand.Parameters.AddWithValue("@pContraseña",contraseña);
                    sqlCommand.CommandType = CommandType.Text;

                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // pregunto si hay filas 
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Email = dataReader["Email"].ToString();

                                usuarioEncontrado = usuario;

                            }
                        }
                    }
                    sqlConnection.Close();
                }

            }

            return usuarioEncontrado;
        }

        public static bool DeleteUsuario(int id)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Usuario WHERE Id = @id";

                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);

                sqlParameter.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows=sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        result =  true;
                    }

                }

                sqlConnection.Close();
            }

            return result;
                
        }

        public static bool InsertUsuario( Usuario usuario)
        {
            bool result = false;
          
            using (SqlConnection sqlConnection = new SqlConnection)
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[usuario] (Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@nombreParameter, @apellidoParameter,@nombreUsuarioParameter,@contraseñaParameter,@emailParameter)";
                    
                SqlParameter nombreParameter = new SqlParameter("Nombre", SqlDbType.VarChar) {Value=usuario.Nombre};
                SqlParameter apellidoParameter = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido};
                SqlParameter nombreUsuarioParameter = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario};
                SqlParameter contraseñaParameter = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter emailParameter = new SqlParameter("Email", SqlDbType.VarChar) { Value = usuario.Email };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(nombreUsuarioParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);
                    sqlCommand.Parameters.Add(emailParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        result = true;
                    }

                }

                sqlConnection.Close();
            
            }

            return result;

        }

        public static bool UpdateUsuario (Usuario usuario)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection)
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[usuario] SET Nombre=@nombreParameter,Apellido=@apellidoParameter,NombreUsuario=@nombreUsuarioParameter,Contraseña=@contraseñaParameter,Mail=@emailParameter WHERE Id=@idParameter";

                SqlParameter idParameter = new SqlParameter("Id", SqlDbType.VarChar) { Value = usuario.Id };
                SqlParameter nombreParameter = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParameter = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter nombreUsuarioParameter = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter contraseñaParameter = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter emailParameter = new SqlParameter("Email", SqlDbType.VarChar) { Value = usuario.Email };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(nombreUsuarioParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);
                    sqlCommand.Parameters.Add(emailParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {
                        result = true;
                    }

                }

                sqlConnection.Close();

            }

            return result;
        }
    }

}

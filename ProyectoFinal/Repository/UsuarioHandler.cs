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


    
    }
}

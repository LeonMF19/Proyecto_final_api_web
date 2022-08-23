using ProyectoFinal.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public static class ProductoHandler
    {

        public const string ConnectionString = "Server=DESKTOP-CDSDU8R;Database=SistemaGestion;Trusted_Connection=True";


        public static List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PRODUCTO", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // pregunto si hay filas 
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Descripcion = dataReader["Descripcion"].ToString();
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.Costo = Convert.ToDouble(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dataReader["PrecioVenta"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader ["IdUsuario"]);

                                productos.Add(producto);

                            }
                        }
                    }

                    sqlConnection.Close();

                }

            }

            return productos;
        }

        public static bool InsertProducto(Producto producto)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection)
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[producto] (IdUsuario,Descripcion,Costo,PrecioVenta,Stock) VALUES (@idUsuarioParameter, @descripcionParameter, @costoParameter,@precioVentaParameter,@stockParameter)";

                SqlParameter idUsuarioParameter = new SqlParameter("IdUsuario", SqlDbType.BigInt) { Value = producto.IdUsuario };
                SqlParameter descripcionParameter = new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion };
                SqlParameter costoParameter = new SqlParameter("Costo", SqlDbType.Float) { Value = producto.Costo };
                SqlParameter precioVentaParameter = new SqlParameter("PrecioVenta", SqlDbType.Float) { Value = producto.PrecioVenta };
                SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock };
     

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(idUsuarioParameter);
                    sqlCommand.Parameters.Add(descripcionParameter);
                    sqlCommand.Parameters.Add(costoParameter);
                    sqlCommand.Parameters.Add(precioVentaParameter);
                    sqlCommand.Parameters.Add(stockParameter);

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

        public static bool UpdateProducto(Producto producto)
        {
            bool result = false;

            using (SqlConnection sqlConnection = new SqlConnection)
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[producto] SET Costo =@costoParameter ,PrecioVenta=@precioVentaParameter,Stock=@stockParameter WHERE Id = @idParameter";

                SqlParameter idParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = producto.Id};
                SqlParameter costoParameter = new SqlParameter("Costo", SqlDbType.Float) { Value = producto.Costo };
                SqlParameter precioVentaParameter = new SqlParameter("PrecioVenta", SqlDbType.Float) { Value = producto.PrecioVenta };
                SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock };


                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(costoParameter);
                    sqlCommand.Parameters.Add(precioVentaParameter);
                    sqlCommand.Parameters.Add(stockParameter);

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

        public static bool DeleteProducto( int id)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Producto INNER JOIN ProductoVendido ON Id = IdProducto AND Id = @id";
               

                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);

                sqlParameter.Value = id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
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

    

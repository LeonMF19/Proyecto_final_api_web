using ProyectoFinal.Model;
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


    }
}

    }
}

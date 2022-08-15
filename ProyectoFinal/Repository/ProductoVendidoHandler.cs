
using ProyectoFinal.Model;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public static class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server=DESKTOP-CDSDU8R;Database=SistemaGestion;Trusted_Connection=True";


        public static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> productos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // pregunto si hay filas 
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido producto = new ProductoVendido();

                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                              

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

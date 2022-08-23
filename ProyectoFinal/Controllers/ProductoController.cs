using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Controllers.DTOS;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {

        [HttpGet(Name = "ObtenerProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }

        [HttpPost]
        public bool InsertProducto([FromBody] PostProducto producto)
        {
            return ProductoHandler.InsertProducto(new Producto
            {
                IdUsuario = producto.IdUsuario,
                Descripcion = producto.Descripcion,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,

            });
            
        }

        [HttpPut]

        public bool UpdateProducto([FromBody] PutProducto producto)
        {
            return ProductoHandler.UpdateProducto(new Producto
            {
               Costo = producto.Costo,
               PrecioVenta = producto.PrecioVenta,
               Stock = producto.Stock,
              
            });
        }

        [HttpDelete]
        public bool DeleteProducto([FromBody] int id)
        {
            try
            {
                return ProductoHandler.DeleteProducto(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

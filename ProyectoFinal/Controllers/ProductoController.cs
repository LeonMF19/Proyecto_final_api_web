using Microsoft.AspNetCore.Mvc;
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
    }
}

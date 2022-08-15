
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;


namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {

        [HttpGet(Name = "ObtenerProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {

            return ProductoVendidoHandler.GetProductosVendidos();

        }

    }
}

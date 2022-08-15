using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;


namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {

        [HttpGet(Name = "ObtenerVentas")]
        public List<Venta> GetVentas()
        {

            return VentaHandler.GetVentas();

        }


    }
}

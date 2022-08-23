using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Controllers.DTOS;
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
        [HttpPost]
        public bool InsertVenta([FromBody] PostVenta venta)
        {
            return VentaHandler.InsertVenta(new Venta
            {
                Comentario = venta.Comentario

            }) ;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;


namespace ProyectoFinal.Controllers
{
    public class VentaController : ControllerBase
    {

        public List<Venta> GetVentas()
        {

            return VentaHandler.GetVentas();

        }


    }
}


using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;


namespace ProyectoFinal.Controllers
{
    public class ProductoVendidoController : ControllerBase
    {
        public List<ProductoVendido> GetProductosVendidos()
        {

            return ProductoVendidoHandler.GetProductosVendidos();

        }

    }
}

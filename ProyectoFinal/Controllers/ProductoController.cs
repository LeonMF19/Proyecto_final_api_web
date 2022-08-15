using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    public class ProductoController : ControllerBase
    {
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        [HttpGet(Name = "ObtenerUsuarios")]
        public List<Usuario> GetUsuarios()
        {

            return UsuarioHandler.GetUsuarios();
            
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public static bool Login(string nombreUsuario, string contraseña)
        {
            Usuario usuario = new Usuario();

            usuario = UsuarioHandler.FindUsuario(nombreUsuario, contraseña);

            if (usuario.NombreUsuario == null || usuario.Nombre != nombreUsuario)
            {
                return false;
            }
            else
                if(usuario.Contraseña == null || usuario.Contraseña != contraseña)
            {
                return false;
            }
            else
                return true;
        }


    }
}

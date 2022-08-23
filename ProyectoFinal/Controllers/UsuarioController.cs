using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Controllers.DTOS;
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

        [HttpDelete]
        public bool  DeleteUsuario ([FromBody] int id)
        {
            try
            {
                return UsuarioHandler.DeleteUsuario(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
           

        }

        [HttpPut]

        public bool UpdateUsuario([FromBody]PutUsuario usuario)
        {
            return UsuarioHandler.UpdateUsuario(new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Email = usuario.Email

            });
        }

        [HttpPost]
        public bool InsertUsuario ([FromBody]PostUsuario usuario)
        {
            return UsuarioHandler.InsertUsuario(new Usuario
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Email = usuario.Email

            });
        }

    }
}

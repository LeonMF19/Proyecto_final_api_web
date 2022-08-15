using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : ControllerBase
    {

        public List<Usuario> GetUsuarios()
        {

            return UsuarioHandler.GetUsuarios();
            
        }


        public static bool Login(string nombreUsuario, string contraseña)
        {
            Usuario usuario = new Usuario();

            usuario = UsuarioHandler.FindUsuario(nombreUsuario, contraseña);

            if (usuario.NombreUsuario == null)
            {
                return false;
            }
            else
                return true;
        }


    }
}

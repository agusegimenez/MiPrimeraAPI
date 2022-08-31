using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI.Controllers.DTOS;
using MiPrimeraAPI.Model;
using MiPrimeraAPI.Repository;

namespace MiPrimeraAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }

        
        [HttpDelete(Name = "BorrarUsuario")]
        public bool BorrarUsuario([FromBody]int id)
        {
            try
            {
                return UsuarioHandler.BorrarUsuario(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }


        [HttpPut(Name = "ModificarUsuario")]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            try
            {
                return UsuarioHandler.CambiarDatos(new Usuario
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Contraseña = usuario.Contraseña,
                    NombreUsuario = usuario.NombreUsuario,
                    Mail = usuario.Mail
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        [HttpPost(Name = "NuevoUsuario")]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            try
            {
                return UsuarioHandler.CrearUsuario(new Usuario
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Contraseña = usuario.Contraseña,
                    NombreUsuario = usuario.NombreUsuario,
                    Mail = usuario.Mail
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

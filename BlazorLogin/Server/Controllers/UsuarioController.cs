using BlazorLogin.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorLogin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();
            if (login.Correo == "admin@gmail.com" && login.Clave == "admin")
            {
                sesionDTO.Nombre = "Admin";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Administrador";

            }
            else
            {
                sesionDTO.Nombre = "Empleado";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Empleado";
            }

            return StatusCode(statusCode: 200, sesionDTO);
        }
    }
}

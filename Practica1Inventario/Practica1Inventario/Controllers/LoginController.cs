using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1Inventario.DTO;

namespace Practica1Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public bool login([FromBody] Usuario user)
        {
            bool regreso = false;
            if (user != null)
            {
                if (user.NombreUsuario == "Moni" && user.Contrasena == "123")
                    regreso = true;
            }
            return regreso;

        }
    }
}

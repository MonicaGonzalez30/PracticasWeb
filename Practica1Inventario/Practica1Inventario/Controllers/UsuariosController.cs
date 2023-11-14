using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1Inventario.Context;
using Practica1Inventario.Model;

namespace Practica1Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public JsonResult getUsuarios() //Mostrar todos los usuarios
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (AlmacenContext almacenC = new AlmacenContext()) //Conectar con la BD almacenada en el contexto (virtual)
            {
                var aux = almacenC.usuarios;
                foreach (var i in aux)
                {
                    usuarios.Add(new Usuario { Id = i.Id, Nombre = i.Nombre, NombreUsuario = i.NombreUsuario, Contrasena = i.Contrasena, NivelAcceso = i.NivelAcceso });
                }
            }
            return new JsonResult(usuarios);
        }
        /*
        [HttpPost]
        public JsonResult insertUser([FromBody] Usuario arg) //Insertar datos a partir del cuerpo
        {
            bool resultado = false;
            using(AlmacenContext almacenC = new AlmacenContext())
            {
                almacenC.usuarios.Add(arg);
                almacenC.SaveChanges();
                resultado = true;
            }
            return new JsonResult(resultado);
        }
        
        [HttpPatch]
        public JsonResult updateUser([FromBody] Usuario arg) //Modificar un usuario a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                var existUser = almacenC.usuarios.SingleOrDefault(u => u.Id == arg.Id);
                if (existUser != null)
                {
                    almacenC.usuarios.Attach(arg);
                    almacenC.Entry(arg).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Cambiar a estado modificado
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }

        [HttpDelete]
        public JsonResult deleteUser([FromBody] Usuario arg) //Eliminar un usuario a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                var existUser = almacenC.usuarios.SingleOrDefault(u => u.Id == arg.Id);
                if (existUser != null)
                {
                    almacenC.usuarios.Remove(existUser); // Elimina el usuario
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }*/
    }
}

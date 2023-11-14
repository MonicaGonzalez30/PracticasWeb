using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1Inventario.Context;
using Practica1Inventario.Model;

namespace Practica1Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        [HttpGet]
        public JsonResult getInventarios() //Mostrar todos los inventarios
        {
            List<Inventario> inventarios = new List<Inventario>();
            using (AlmacenContext almacenC = new AlmacenContext()) //Conectar con la BD almacenada en el contexto (virtual)
            {
                var aux = almacenC.inventarios;
                foreach (var i in aux)
                {
                    inventarios.Add(new Inventario { Numero = i.Numero, Cantidad = i.Cantidad, Due = i.Due, NumAlmacen = i.NumAlmacen });
                }
            }
            return new JsonResult(inventarios);
        }

        [HttpPost]
        public JsonResult insertInv([FromBody] Inventario arg) //Insertar datos a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                almacenC.inventarios.Add(arg);
                almacenC.SaveChanges();
                resultado = true;
            }
            return new JsonResult(resultado);
        }

        [HttpPatch]
        public JsonResult updateInv([FromBody] Inventario arg) //Modificar un inventario a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                var existInv = almacenC.inventarios.SingleOrDefault(i => i.Numero == arg.Numero);
                if (existInv != null)
                {
                    almacenC.inventarios.Attach(arg);
                    almacenC.Entry(arg).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Cambiar a estado modificado
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }

        [HttpDelete]
        public JsonResult deleteInv([FromBody] Inventario arg) //Eliminar un inventario a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                var existInv = almacenC.inventarios.SingleOrDefault(i => i.Numero == arg.Numero);
                if (existInv != null)
                {
                    almacenC.inventarios.Remove(existInv); // Elimina el inventario
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }
    }
}
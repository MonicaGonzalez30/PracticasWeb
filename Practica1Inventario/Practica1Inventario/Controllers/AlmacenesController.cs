using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1Inventario.Context;
using Practica1Inventario.Model;

namespace Practica1Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AlmacenesController : ControllerBase
    {
        [HttpGet]
        public JsonResult getAlmacenes() //Mostrar todos los almacenes
        {
            List<Almacen> almacenes = new List<Almacen>();
            using (AlmacenContext almacenC = new AlmacenContext()) //Conectar con la BD almacenada en el contexto (virtual)
            {
                var aux = almacenC.almacenes;
                foreach (var i in aux)
                {
                    almacenes.Add(new Almacen { Numero = i.Numero, Nombre = i.Nombre });
                }
            }
            return new JsonResult(almacenes);
        }

        [HttpPost]
        public JsonResult insertInv([FromBody] Almacen arg) //Insertar datos a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                almacenC.almacenes.Add(arg);
                almacenC.SaveChanges();
                resultado = true;
            }
            return new JsonResult(resultado);
        }

        [HttpPatch]
        public JsonResult updateInv([FromBody] Almacen arg) //Modificar un almacen a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                var existAlm = almacenC.almacenes.SingleOrDefault(i => i.Numero == arg.Numero);
                if (existAlm != null)
                {
                    almacenC.almacenes.Attach(arg);
                    almacenC.Entry(arg).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Cambiar a estado modificado
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }

        [HttpDelete]
        public JsonResult deleteInv([FromBody] Almacen arg) //Eliminar un almacen a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                var existAlm = almacenC.almacenes.SingleOrDefault(i => i.Numero == arg.Numero);
                if (existAlm != null)
                {
                    almacenC.almacenes.Remove(existAlm); // Elimina el almacen
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }
    }
}

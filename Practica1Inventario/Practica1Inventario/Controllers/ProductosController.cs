using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica1Inventario.Context;
using Practica1Inventario.Model;

namespace Practica1Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public JsonResult getProductos() //Mostrar todos los productos
        {
            List<Producto> productos = new List<Producto>();
            using(AlmacenContext almacenC = new AlmacenContext()) //Conectar con la BD almacenada en el contexto (virtual)
            {
                var aux = almacenC.productos;
                foreach(var i in aux)
                {
                    productos.Add(new Producto { NumeroSKU = i.NumeroSKU, Nombre = i.Nombre, Descripcion = i.Descripcion, Foto = i.Foto, NumInventario = i.NumInventario});
                }
            }
            return new JsonResult(productos);
        }

        [HttpPost]
        public JsonResult insertProd([FromBody] Producto arg) //Insertar datos a partir del cuerpo
        {
            bool resultado = false;
            using(AlmacenContext almacenC = new AlmacenContext())
            {
                almacenC.productos.Add(arg);
                almacenC.SaveChanges();
                resultado = true;
            }
            return new JsonResult(resultado);
        }

        [HttpPatch]
        public JsonResult updateProd([FromBody] Producto arg) //Modificar un producto a partir del cuerpo
        {
            bool resultado = false;
            using(AlmacenContext almacenC = new AlmacenContext())
            {
                var existProd = almacenC.productos.SingleOrDefault(p => p.NumeroSKU == arg.NumeroSKU);
                if (existProd != null)
                {
                    almacenC.productos.Attach(arg);
                    almacenC.Entry(arg).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //Cambiar a estado modificado
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }

        [HttpDelete]
        public JsonResult deleteProd([FromBody] Producto arg) //Eliminar un producto a partir del cuerpo
        {
            bool resultado = false;
            using (AlmacenContext almacenC = new AlmacenContext())
            {
                var existProd = almacenC.productos.SingleOrDefault(p => p.NumeroSKU == arg.NumeroSKU);
                if (existProd != null)
                {
                    almacenC.productos.Remove(existProd); // Elimina el producto
                    almacenC.SaveChanges();
                    resultado = true;
                }
            }
            return new JsonResult(resultado);
        }
    }
}

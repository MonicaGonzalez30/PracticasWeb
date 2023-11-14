namespace Practica1Inventario.DTO
{
    public class Producto
    {
        public int NumeroSKU { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }

        public Producto(int sku,string nombre, string descripcion, string foto)
        {
            NumeroSKU = sku;
            Nombre = nombre;
            Descripcion = descripcion;
            Foto = foto;
        }
    }
}

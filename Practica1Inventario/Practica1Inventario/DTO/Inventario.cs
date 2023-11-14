namespace Practica1Inventario.DTO
{
    public class Inventario
    {
        public int Numero { get; set; }
        public List<Producto> Productos { get; set; }
        public int Cantidad { get; set; }
        public string Due { get; set; }

        public Inventario(int numero, int cantidad, string due, List<Producto> productos)
        {
            Numero = numero;
            Productos = productos;
            Cantidad = cantidad;
            Due = due;
        }
    }
}

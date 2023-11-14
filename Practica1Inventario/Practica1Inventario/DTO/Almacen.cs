namespace Practica1Inventario.DTO
{
    public class Almacen
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public List<Inventario> Inventarios { get; set; } //Al crearlo como una lista se puede cambiar su tamaño de forma flexible.

        //Contructor de la clase
        public Almacen(int numero, string nombre, List<Inventario> invenarios)
        {
            Numero = numero;
            Nombre = nombre;
            Inventarios = invenarios;
        }
    }
}

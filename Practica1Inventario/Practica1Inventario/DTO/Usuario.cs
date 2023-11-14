namespace Practica1Inventario.DTO
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string NombreUsuario { get; set; }
        public string NivelAcceso { get; set; }

        public Usuario(string nombre, string contrasena, string nombreUsuario, string nivelAcceso)
        {
            Nombre = nombre;
            Contrasena = contrasena;
            NombreUsuario = nombreUsuario;
            NivelAcceso = nivelAcceso;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Practica1Inventario.Model;
using Practica1Inventario.Context;

namespace Practica1Inventario.Context
{
    public class AlmacenContext: DbContext
    {
        public DbSet<Producto> productos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Almacen> almacenes { get; set; }
        public DbSet<Inventario> inventarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder buildier)
        {
            buildier.UseMySQL("server=localhost; database=Almacen; user=root; password=moni30"); //Puerto 3306
            buildier.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //Para los updates
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar las relaciones y restricciones de los modelos
            modelBuilder.Entity<Producto>(entity => {
                entity.HasKey(a => a.NumeroSKU);
                entity.Property(a => a.Nombre);
                entity.Property(a => a.Descripcion);
                entity.Property(a => a.Foto);
                entity.Property(a => a.NumInventario);
            });

            modelBuilder.Entity<Usuario>(entity => {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nombre);
                entity.Property(a => a.Contrasena);
                entity.Property(a => a.NombreUsuario);
                entity.Property(a => a.NivelAcceso);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(a => a.Numero);
                entity.Property(a => a.Cantidad);
                entity.Property(a => a.Due);
                entity.Property(a => a.NumAlmacen);
            });

            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasKey(a => a.Numero);
                entity.Property(a => a.Nombre);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using ExamenB.Model;
using ExamenB.Context;

namespace ExamenB.Context
{
    public class SistemaMedicoContext: DbContext
    {
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Expediente> expedientes { get; set; }
        public DbSet<Consulta> consultas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder buildier)
        {
            buildier.UseMySQL("server=localhost; database=SistemaMedico; user=root; password=moni30");
            buildier.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //Updates
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(p => p.NSS);
                entity.Property(p => p.Nombre);
                entity.Property(p => p.ApPaterno);
                entity.Property(p => p.ApMaterno);
                entity.Property(p => p.Sexo);
                entity.Property(p => p.FechaNac);
                entity.Property(p => p.Domicilio);
                entity.Property(p => p.Telefono);
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(e => e.IdExpediente);
                entity.Property(e => e.NSSPaciente);
                entity.Property(e => e.FechaApertura);
                entity.Property(e => e.Estudios);
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(c => c.IdConsulta);
                entity.Property(c => c.NSSPaciente);
                entity.Property(c => c.IdExpediente);
                entity.Property(c => c.IdMedico);
                entity.Property(c => c.FechaConsulta);
                entity.Property(c => c.Sintomas);
                entity.Property(c => c.Diagnostico);
                entity.Property(c => c.Tratamiento);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TUP_Materias.Models;

namespace TUP_Materias.Data
{
    // Heredamos de DbContext para que esta clase herede todos los superpoderes de Entity Framework
    public class ApplicationDbContext : DbContext
    {
        // 1. El constructor: Recibe la configuración de la base de datos (como la conexión de appsettings)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // 2. Los DbSets: Cada uno de estos se va a transformar en una tabla real en MySQL
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        // 🔥 AGREGAMOS ESTE BLOQUE (Fluent API):
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Le explicamos a EF Core la relación Muchos a Muchos explícita
            modelBuilder.Entity<Materia>()
                .HasMany(m => m.AlumnosInscriptos) // Una Materia tiene muchos AlumnosInscriptos
                .WithMany(a => a.Materias)          // Un Alumno tiene muchas Materias
                .UsingEntity(j => j.ToTable("AlumnoMateria")); // Nombre de la tabla intermedia real
        }
    }
}

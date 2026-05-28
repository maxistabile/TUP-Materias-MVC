using System.Linq;
using System.Collections.Generic;
using TUP_Materias.Models;

namespace TUP_Materias.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // 1. Nos fijamos si ya hay datos. Si ya hay materias, no hacemos nada para no duplicar
            if (context.Materias.Any())
            {
                return;
            }

            // 2. Creamos los profesores de prueba
            var profe1 = new Profesor { Nombre = "Jorge", Apellido = "Pérez" };
            var profe2 = new Profesor { Nombre = "Alba", Apellido = "Acosta" };
            context.Profesores.AddRange(profe1, profe2);

            // 3. Creamos los alumnos de prueba
            var alumno1 = new Alumno { Nombre = "Maxi", Apellido = "Stabile" };
            var alumno2 = new Alumno { Nombre = "Juan", Apellido = "Gómez" };
            var alumno3 = new Alumno { Nombre = "María", Apellido = "López" };
            context.Alumnos.AddRange(alumno1, alumno2, alumno3);

            // Guardamos acá para que MySQL les asigne sus IDs automáticamente
            context.SaveChanges();

            // 4. Creamos las materias y les enlazamos los objetos que ya creamos arriba
            var materias = new List<Materia>
            {
                new Materia
                {
                    Nombre = "Programación III",
                    ProfesorAsignado = profe1,
                    AlumnosInscriptos = new List<Alumno> { alumno1, alumno2, alumno3 } // Se llena la intermedia sola
                },
                new Materia
                {
                    Nombre = "Base de Datos II",
                    ProfesorAsignado = profe2,
                    AlumnosInscriptos = new List<Alumno> { alumno1, alumno3 }
                }
            };

            context.Materias.AddRange(materias);

            // Guardada final en la base de datos
            context.SaveChanges();
        }
    }
}
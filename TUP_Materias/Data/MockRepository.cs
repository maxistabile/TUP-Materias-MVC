using TUP_Materias.Models;

namespace TUP_Materias.Data
{
    public static class MockRepository
    {
        // La lista global que va a guardar las materias en la memoria RAM
        public static List<Materia> Materias { get; set; } = new List<Materia>();

        // El constructor estático que se ejecuta una sola vez al arrancar la app
        static MockRepository()
        {
            // 1. Inventamos unos alumnos
            var alumno1 = new Alumno { Id = 1, Nombre = "Maximiliano", Apellido = "Stabile" };
            var alumno2 = new Alumno { Id = 2, Nombre = "Anahí", Apellido = "López" };
            var alumno3 = new Alumno { Id = 3, Nombre = "Lucas", Apellido = "Fernández" };
            var alumno4 = new Alumno { Id = 4, Nombre = "Bruno", Apellido = "Díaz" };

            // 2. Inventamos los profesores
            var profe1 = new Profesor { Id = 1, Nombre = "Carlos", Apellido = "Gómez" };
            var profe2 = new Profesor { Id = 2, Nombre = "Patricia", Apellido = "Rodríguez" };

            // 3. Armamos las materias y las metemos en la lista global
            Materias.Add(new Materia
            {
                Id = 1,
                Nombre = "Programación III",
                ProfesorAsignado = profe1,
                AlumnosInscriptos = new List<Alumno> { alumno1, alumno2, alumno3 }
            });

            Materias.Add(new Materia
            {
                Id = 2,
                Nombre = "Base de Datos II",
                ProfesorAsignado = profe2,
                AlumnosInscriptos = new List<Alumno> { alumno1, alumno4 }
            });
        }
    }
}
namespace TUP_Materias.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Profesor ProfesorAsignado { get; set; }
        public List<Alumno> AlumnosInscriptos { get; set; }
    }
}

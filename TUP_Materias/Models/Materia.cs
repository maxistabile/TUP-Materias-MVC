namespace TUP_Materias.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Profesor ProfesorAsignado { get; set; } = new Profesor();
        public List<Alumno> AlumnosInscriptos { get; set; } = new List<Alumno>();
    }
}

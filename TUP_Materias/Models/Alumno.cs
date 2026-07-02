namespace TUP_Materias.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;

        // 🔥 Asegurate de que esta línea esté tal cual:
        public List<Materia> Materias { get; set; } = new List<Materia>();
    }
}

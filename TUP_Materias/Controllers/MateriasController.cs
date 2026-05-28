using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // ¡Importantísimo para el .Include()!
using TUP_Materias.Data; // Para que reconozca tu ApplicationDbContext

namespace TUP_Materias.Controllers
{
    public class MateriasController : Controller
    {
        // 1. Declaramos una variable privada y de solo lectura para nuestra base de datos
        private readonly ApplicationDbContext _context;

        // 2. El Constructor: .NET inyecta automáticamente la base de datos acá adentro
        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 3. La Acción Index: Trae las materias de la base de datos real
        public IActionResult Index()
        {
            // Usamos Eager Loading (.Include) para traer el profesor y los alumnos asociados de cada materia
            var listaMaterias = _context.Materias
                                        .Include(m => m.ProfesorAsignado)
                                        .Include(m => m.AlumnosInscriptos)
                                        .ToList();

            return View(listaMaterias);
        }
        // 4. Acción Details: Muestra los datos de una sola materia por su ID
        public IActionResult Details(int? id)
        {
            // Si no nos mandan un ID por la URL, devolvemos un error 404
            if (id == null)
            {
                return NotFound();
            }

            // Buscamos en la base de datos la materia que coincida con el ID
            // Y le sumamos el Profesor y los Alumnos con Eager Loading
            var materia = _context.Materias
                                  .Include(m => m.ProfesorAsignado)
                                  .Include(m => m.AlumnosInscriptos)
                                  .FirstOrDefault(m => m.Id == id);

            // Si la materia no existe en la base de datos, tiramos un 404
            if (materia == null)
            {
                return NotFound();
            }

            // Si todo está bien, mandamos la materia con todos sus datos a la Vista
            return View(materia);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TUP_Materias.Data; // Para poder usar el MockRepository
using System.Linq;

namespace TUP_Materias.Controllers
{
    public class MateriasController : Controller
    {
        // 1. Pantalla principal: Muestra el listado de todas las materias
        public IActionResult Index()
        {
            var listaDeMaterias = MockRepository.Materias;
            return View(listaDeMaterias); // Le pasamos la lista a la Vista
        }

        // 2. Pantalla de detalle: Recibe el ID de la materia por la URL (ej: /Materias/Details/1)
        public IActionResult Details(int id)
        {
            // Buscamos la materia que coincida con el ID usando LINQ (como un SELECT en base de datos)
            var materiaBuscada = MockRepository.Materias.FirstOrDefault(m => m.Id == id);

            if (materiaBuscada == null)
            {
                return NotFound(); // Si ponen un ID que no existe, tira error 404
            }

            return View(materiaBuscada); // Le mandamos esa materia específica a la Vista
        }
    }
}
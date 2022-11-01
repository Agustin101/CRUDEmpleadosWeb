using CRUDEmpleados.Models;
using CRUDEmpleados.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace CRUDEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IRepositorio<Empleado, int> _repository;
        public EmpleadoController(IRepositorio<Empleado,int> repositorio)
        {
            _repository = repositorio;  
        }

        public IActionResult Index()
        {
            var empleados = _repository.ObtenerTodos();
            
            return View(empleados);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }

            _repository.Agregar(empleado);
            return RedirectToAction("Index");
        }
    }
}

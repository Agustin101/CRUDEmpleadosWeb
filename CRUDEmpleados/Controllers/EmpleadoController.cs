using CRUDEmpleados.Models;
using CRUDEmpleados.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Eliminar(int id)
        {
            if(id < 1 || !_repository.Existe(id))
            {
                return NotFound();
            }

            Empleado emp = _repository.Obtener(id);

            if (emp is null)
                return NotFound();

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Empleado emp)
        {
            if (!_repository.Existe(emp.Id))
                return NotFound();

            _repository.Eliminar(emp.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            Empleado emp = _repository.Obtener(id);
            if(emp is not null)
            {
                return View(emp);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View(empleado);
            }

            _repository.Modificar(empleado.Id,empleado);
            return RedirectToAction("Index");
        }
    }
}

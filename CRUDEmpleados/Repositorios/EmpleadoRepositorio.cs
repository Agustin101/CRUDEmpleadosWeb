using CRUDEmpleados.Data;
using CRUDEmpleados.Models;

namespace CRUDEmpleados.Repositorios
{
    public class EmpleadoRepositorio : IRepositorio<Empleado, int>
    {
        private readonly EmpleadoDbContext _context;
        public EmpleadoRepositorio(EmpleadoDbContext dbContext)
        {
            _context = dbContext;
        }


        public void Agregar(Empleado objeto)
        {
            if(objeto is not null)
            {
                _context.Empleados.Add(objeto);
                _context.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            Empleado empleado = _context.Empleados.FirstOrDefault(e => e.Id == id);
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
        }

        public void Modificar(int id, Empleado objeto)
        {
            Empleado empleado = _context.Empleados.FirstOrDefault(e => e.Id == id);
            empleado.Sector = objeto.Sector;
            empleado.Sueldo = objeto.Sueldo;
            empleado.Nombre = objeto.Nombre;
            empleado.Apellido = objeto.Apellido;
            empleado.FechaNacimiento = objeto.FechaNacimiento;
            _context.SaveChanges();
        }

        public Empleado Obtener(int id)
        {
            return _context.Empleados.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return _context.Empleados;
        }

        public bool Existe(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}

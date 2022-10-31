using CRUDEmpleados.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDEmpleados.Data
{
    public class EmpleadoDbContext : DbContext
    {
        public EmpleadoDbContext(DbContextOptions<EmpleadoDbContext> opts) : base(opts)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}

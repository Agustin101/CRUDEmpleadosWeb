using System.ComponentModel.DataAnnotations;

namespace CRUDEmpleados.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sector { get; set; }
        public decimal Sueldo { get; set; }
    }
}

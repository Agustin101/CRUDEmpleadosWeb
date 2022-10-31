namespace CRUDEmpleados.Repositorios
{
    public interface IRepositorio<TObjeto,TId >
    {
        TObjeto ObtenerTodos();
        TObjeto Obtener(TId id);
        void Agregar(TObjeto objeto);
        void Eliminar(TId id);
        void Modificar(TId id, TObjeto objeto);
    }
}

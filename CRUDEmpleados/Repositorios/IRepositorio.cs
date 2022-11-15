namespace CRUDEmpleados.Repositorios
{
    public interface IRepositorio<TObjeto,TId >
    {
        IEnumerable<TObjeto> ObtenerTodos();
        TObjeto Obtener(TId id);
        void Agregar(TObjeto objeto);
        void Eliminar(TId id);
        void Modificar(TId id, TObjeto objeto);
        bool Existe(TId id);

    }
}

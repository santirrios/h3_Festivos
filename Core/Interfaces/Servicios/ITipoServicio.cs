using Dominio.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ITipoServicio
    {
        Task<Tipo> Agregar(Tipo tipo);

        Task<Tipo> Modificar(Tipo tipo);

        Task<bool> Eliminar(int Id);

        Task<Tipo> Obtener(int Id);

        Task<IEnumerable<Tipo>> ObtenerTodos();
    }
}

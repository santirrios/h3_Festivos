using Dominio.Entidades;

namespace Core.Interfaces.Repositorios
{
    public interface ITipoRepositorio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();

        Task<Tipo> Obtener(int Id);

        Task<Tipo> Agregar(Tipo Seleccion);

        Task<Tipo> Modificar(Tipo Seleccion);

        Task<bool> Eliminar(int Id);
    }
}

using Dominio.Entidades;

namespace Core.Interfaces.Repositorios
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<Festivo> Obtener(int Id);

        Task<Festivo> Agregar(Festivo Seleccion);

        Task<Festivo> Modificar(Festivo Seleccion);

        Task<bool> Eliminar(int Id);
    }
}

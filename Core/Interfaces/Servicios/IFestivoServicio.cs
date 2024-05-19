using Dominio.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IFestivoServicio
    {
        Task<Festivo> Agregar(Festivo festivo);

        Task<Festivo> Modificar(Festivo festivo);

        Task<bool> Eliminar(int Id);

        Task<Festivo> Obtener(int Id);

        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<bool> Verificar(int ano, int mes, int dia);

        Task<IEnumerable<Festivo>> ObtenerFestivosNano(int nano);
    }
}

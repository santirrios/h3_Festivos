using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Dominio.Entidades;

namespace Aplicacion
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio _repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public Task<Festivo> Agregar(Festivo festivo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Festivo> Modificar(Festivo festivo)
        {
            throw new NotImplementedException();
        }

        public Task<Festivo> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await _repositorio.ObtenerTodos();
        }
    }
}

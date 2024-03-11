using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Dominio.Entidades;

namespace Aplicacion
{
    public class TipoServicio : ITipoServicio
    {
        private readonly ITipoRepositorio _repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public Task<Tipo> Agregar(Tipo tipo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Tipo> Modificar(Tipo tipo)
        {
            throw new NotImplementedException();
        }

        public Task<Tipo> Obtener(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await _repositorio.ObtenerTodos();
        }
    }
}

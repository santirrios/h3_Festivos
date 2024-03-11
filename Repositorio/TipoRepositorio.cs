using AutoMapper;
using Core.Interfaces.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.Contexto;

namespace Repositorio
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly FestivosContext context;
        private readonly IMapper mapper;


        public TipoRepositorio(FestivosContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Tipo> Agregar(Tipo Seleccion)
        {
            context.Tipos.Add(Seleccion);
            await context.SaveChangesAsync();
            return Seleccion;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var tipoExistente = await context.Tipos.FindAsync(Id);
            if (tipoExistente == null)
            {
                return false;
            }

            context.Tipos.Remove(tipoExistente);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Tipo> Modificar(Tipo Seleccion)
        {
            var tipoExistente = await context.Tipos.FindAsync(Seleccion.Id);

            if (tipoExistente is null)
                return null;

            mapper.Map(Seleccion, tipoExistente);
            await context.SaveChangesAsync();

            return tipoExistente;
        }

        public async Task<Tipo> Obtener(int Id)
        {
            return await context.Tipos.FindAsync(Id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            var resultado = await context.Tipos.ToListAsync();
            return resultado;
        }
    }
}

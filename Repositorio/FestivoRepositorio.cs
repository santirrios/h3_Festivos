using AutoMapper;
using Core.Interfaces.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Persistencia.Contexto;

namespace Repositorio
{
    public class FestivoRepositorio : IFestivoRepositorio
    {
        private readonly FestivosContext context;
        private readonly IMapper mapper;


        public FestivoRepositorio(FestivosContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Festivo> Agregar(Festivo Seleccion)
        {
            context.Festivos.Add(Seleccion);
            await context.SaveChangesAsync();
            return Seleccion;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var festivoExistente = await context.Festivos.FindAsync(Id);
            if (festivoExistente == null)
            {
                return false;
            }

            context.Festivos.Remove(festivoExistente);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Festivo> Modificar(Festivo Seleccion)
        {
            var festivoExistente = await context.Festivos.FindAsync(Seleccion.Id);

            if (festivoExistente is null)
                return null;

            mapper.Map(Seleccion, festivoExistente);
            await context.SaveChangesAsync();

            return festivoExistente;
        }

        public async Task<Festivo> Obtener(int Id)
        {
            return await context.Festivos.FindAsync(Id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await context.Festivos.Include(e => e.Tipo).ToArrayAsync();
        }
    }
}

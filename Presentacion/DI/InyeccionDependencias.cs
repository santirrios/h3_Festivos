using Aplicacion;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Microsoft.EntityFrameworkCore;
using Persistencia.Contexto;
using Repositorio;

namespace Presentacion.DI
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios, IConfiguration configuracion)
        {

            //Agregar el DBContext
            servicios.AddDbContext<FestivosContext>(opcionesConstruccion =>
            {
                opcionesConstruccion.UseSqlServer(configuracion.GetConnectionString("Festivos"));
            });

            //Agregar los repositorios
            servicios.AddTransient<ITipoRepositorio, TipoRepositorio>();
            servicios.AddTransient<IFestivoRepositorio, FestivoRepositorio>();

            //Agregar los servicios
            servicios.AddTransient<ITipoServicio, TipoServicio>();
            servicios.AddTransient<IFestivoServicio, FestivoServicio>();


            return servicios;
        }


        public static string CusToString(this int numero)
        {
            return Convert.ToString(numero);
        }
    }
}

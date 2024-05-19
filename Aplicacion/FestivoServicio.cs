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

        public async Task<IEnumerable<Festivo>> ObtenerFestivosNano(int nano)
        {
            IEnumerable<Festivo> retorno = new List<Festivo>();

            ValidarNano(nano);

            var festivos = await ObtenerTodos();

            //Tipo uno
            retorno = festivos.Where(e => e.IdTipo == TipoFestivo.Fijo.GetHashCode()).ToList();


            //Tipo dos

            var festivosLunes = festivos.Where(e => e.IdTipo == TipoFestivo.LeyPuenteFestivo.GetHashCode()).ToList();

            foreach (var festivoLunes in festivosLunes)
            {
                DateTime fechaFestivoLunes = new DateTime(nano, festivoLunes.Mes, festivoLunes.Dia);

                fechaFestivoLunes = TransformarFestivoLunes(fechaFestivoLunes);

                festivoLunes.Dia = fechaFestivoLunes.Day;
                festivoLunes.Mes = fechaFestivoLunes.Month;

                retorno = retorno.Append(festivoLunes);
            }

            //Tipo tres
            var festivosPascua = festivos.Where(e => e.IdTipo == TipoFestivo.BasadoPascua.GetHashCode()).ToList();
            foreach (var festivoPascua in festivosPascua)
            {
                var domigoPascua = CalcularDomingoPascua(nano);

                domigoPascua = domigoPascua.AddDays(festivoPascua.DiasPascua);

                festivoPascua.Dia = domigoPascua.Day;
                festivoPascua.Mes = domigoPascua.Month;

                retorno = retorno.Append(festivoPascua);
            }

            //Tipo cuatro
            var festivosPascuaPasaLunes = festivos.Where(e => e.IdTipo == TipoFestivo.BasadoPascualYLeyPuenteFes.GetHashCode()).ToList();
            foreach (var festivoPascuaLunes in festivosPascuaPasaLunes)
            {
                var domigoPascua = CalcularDomingoPascua(nano);

                domigoPascua = domigoPascua.AddDays(festivoPascuaLunes.DiasPascua);

                domigoPascua = TransformarFestivoLunes(domigoPascua);

                festivoPascuaLunes.Dia = domigoPascua.Day;
                festivoPascuaLunes.Mes = domigoPascua.Month;

                retorno = retorno.Append(festivoPascuaLunes);
            }

            return retorno;
        }

        private void ValidarNano(int nano)
        {
            if (nano < 1900)
                throw new Exception("El año minimo es 1900");

            if (nano > 3000)
                throw new Exception("El año maximo es 3000");
        }

        public async Task<bool> Verificar(int ano, int mes, int dia)
        {
            bool esFestivo = false;
            var festivos = await ObtenerTodos();

            ValidarFecha(ano, mes, dia);

            //Tipo uno
            var festivosInmutables = festivos.Where(e => e.IdTipo == TipoFestivo.Fijo.GetHashCode()).ToList();

            if (festivosInmutables.Exists(e => e.Dia == dia && e.Mes == mes))
                esFestivo = true;

            //Tipo dos
            var festivosLunes = festivos.Where(e => e.IdTipo == TipoFestivo.LeyPuenteFestivo.GetHashCode()).ToList();

            foreach (var festivoLunes in festivosLunes)
            {
                DateTime fechaFestivoLunes = new DateTime(ano, festivoLunes.Mes, festivoLunes.Dia);

                fechaFestivoLunes = TransformarFestivoLunes(fechaFestivoLunes);

                if (fechaFestivoLunes.Day == dia && fechaFestivoLunes.Month == mes)
                    esFestivo = true;
            }

            //Tipo tres
            var festivosPascua = festivos.Where(e => e.IdTipo == TipoFestivo.BasadoPascua.GetHashCode()).ToList();

            foreach (var festivoPascua in festivosPascua)
            {
                var domigoPascua = CalcularDomingoPascua(ano);

                domigoPascua = domigoPascua.AddDays(festivoPascua.DiasPascua);

                if (mes == domigoPascua.Month && dia == domigoPascua.Day)
                    esFestivo = true;
            }

            //Tipo cuatro
            var festivosPascuaPasaLunes = festivos.Where(e => e.IdTipo == TipoFestivo.BasadoPascualYLeyPuenteFes.GetHashCode()).ToList();

            foreach (var festivoPascuaLunes in festivosPascuaPasaLunes)
            {
                var domigoPascua = CalcularDomingoPascua(ano);

                domigoPascua = domigoPascua.AddDays(festivoPascuaLunes.DiasPascua);

                domigoPascua = TransformarFestivoLunes(domigoPascua);

                if (domigoPascua.Day == dia && domigoPascua.Month == mes)
                    esFestivo = true;
            }

            return esFestivo;
        }

        private DateTime TransformarFestivoLunes(DateTime fechaFestivoLunes)
        {
            switch (fechaFestivoLunes.DayOfWeek.GetHashCode())
            {
                case 0:
                    fechaFestivoLunes = fechaFestivoLunes.AddDays(1);
                    break;
                case 2:
                    fechaFestivoLunes = fechaFestivoLunes.AddDays(6);
                    break;
                case 3:
                    fechaFestivoLunes = fechaFestivoLunes.AddDays(5);
                    break;
                case 4:
                    fechaFestivoLunes = fechaFestivoLunes.AddDays(4);
                    break;
                case 5:
                    fechaFestivoLunes = fechaFestivoLunes.AddDays(3);
                    break;
                case 6:
                    fechaFestivoLunes = fechaFestivoLunes.AddDays(2);
                    break;
            }

            return fechaFestivoLunes;
        }

        private DateTime CalcularDomingoPascua(int ano)
        {
            var a = ano % 19;
            var b = ano % 4;
            var c = ano % 7;
            var d = ((19 * a) + 24) % 30;

            var dias = d + ((2 * b) + (4 * c) + (6 * d) + 5) % 7;

            //mes marzo
            var domingoPascua = new DateTime(ano, 3, 22);
            domingoPascua = domingoPascua.AddDays(dias);

            return domingoPascua;
        }

        private void ValidarFecha(int ano, int mes, int dia)
        {
            DateTime fecha;
            try
            {
                fecha = new DateTime(ano, mes, dia);
            }
            catch (Exception)
            {
                throw new Exception("Fecha invalida.");
            }

            if(fecha < new DateTime(1900, 1, 1))
            {
                throw new Exception("La fecha minima es 1900/01/01");
            }

            if(fecha > new DateTime(3000,1,1))
            {
                throw new Exception("No se puede ingresar fecha mayor a 3000/01/01");
            }
        }
    }

    public enum TipoFestivo
    {
        Fijo = 1,
        LeyPuenteFestivo = 2,
        BasadoPascua = 3,
        BasadoPascualYLeyPuenteFes = 4
    }
}

using Core.Interfaces.Servicios;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [ApiController]
    [Route("api/festivo")]
    public class FestivoController : ControllerBase
    {
        private readonly IFestivoServicio _servicio;

        public FestivoController(IFestivoServicio servicio)
        {
            this._servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerTodos()
        {
            try
            {
                return Ok(await _servicio.ObtenerTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("verificar/{ano}/{mes}/{dia}")]
        public async Task<ActionResult<IEnumerable<Tipo>>> Verificar([FromRoute] int ano, [FromRoute] int mes, [FromRoute] int dia)
        {
            try
            {
                var esFestivo = await _servicio.Verificar(ano, mes, dia);

                if (esFestivo)
                {
                    return Ok($"El dia {dia}/{mes}/{ano} es FESTIVOOOOO!!!!!");
                }
                else
                {
                    return Ok($"El dia {dia}/{mes}/{ano} no es festivo, a trabajar.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerFestivosNano/{ano}")]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerFestivosNano([FromRoute] int ano)
        {
            try
            {
                var festivosNano = await _servicio.ObtenerFestivosNano(ano);

                return Ok(festivosNano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

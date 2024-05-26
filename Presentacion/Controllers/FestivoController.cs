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

        [HttpGet("verificar/{ano}/{mes}/{dia}")]
        public async Task<ActionResult<IEnumerable<Tipo>>> Verificar([FromRoute] int ano, [FromRoute] int mes, [FromRoute] int dia)
        {
            try
            {
                var esFestivo = await _servicio.Verificar(ano, mes, dia);

                return Ok(esFestivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerFestivosNano/{nano}")]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerFestivosNano([FromRoute] int nano)
        {
            try
            {
                var festivosNano = await _servicio.ObtenerFestivosNano(nano);

                return Ok(festivosNano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

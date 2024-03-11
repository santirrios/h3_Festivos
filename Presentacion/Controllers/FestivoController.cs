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
    }
}

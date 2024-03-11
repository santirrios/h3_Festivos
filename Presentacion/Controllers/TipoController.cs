using Core.Interfaces.Servicios;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [ApiController]
    [Route("api/tipo")]
    public class TipoController :ControllerBase
    {
        private readonly ITipoServicio _servicio;

        public TipoController(ITipoServicio servicio)
        {
            this._servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerTodos()
        {
            try
            {
                return Ok(await _servicio.ObtenerTodos());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

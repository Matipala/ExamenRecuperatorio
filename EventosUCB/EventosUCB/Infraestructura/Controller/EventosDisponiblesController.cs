using Microsoft.AspNetCore.Mvc;
using EventosUCB.Application;
using System.Threading.Tasks;

namespace EventosUCB.Infraestructura.Controller
{
    [Controller]
    [Route("api/eventos")]
    public class EventosDisponiblesController : ControllerBase
    {
        private readonly IVerListaEventosUseCase _listarEventosUseCase;

        public EventosDisponiblesController(IVerListaEventosUseCase listarEventosUseCase)
        {
            _listarEventosUseCase = listarEventosUseCase;
        }

        [HttpGet("disponibles")]
        public async Task<IActionResult> GetEventosDisponibles()
        {
            var eventos = await _listarEventosUseCase.ExecuteAsync();
            return Ok(eventos);
        }

    }
}
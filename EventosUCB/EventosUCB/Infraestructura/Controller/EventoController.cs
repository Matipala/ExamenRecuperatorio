using Microsoft.AspNetCore.Mvc;
using EventosUCB.Application;
using System.Threading.Tasks;

namespace EventosUCB.Infraestructura.Controller
{
    [Controller]
    [Route("api/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly IRegistrarUsuarioUseCase _registrarUsuarioUseCase;

        public EventoController(IRegistrarUsuarioUseCase registrarUsuarioUseCase)
        {
            _registrarUsuarioUseCase = registrarUsuarioUseCase;
        }

        [HttpPost("{eventoId}/registrar")]
        public async Task<IActionResult> RegistrarUsuario(string eventoId, [FromBody] RegistrarUsuarioRequest request)
        {
            request.EventoId = eventoId;
            var result = await _registrarUsuarioUseCase.ExecuteAsync(request);

            if (!result.Success)
                return BadRequest(new { error = result.Message });

            return Ok(result);
        }
    }
}

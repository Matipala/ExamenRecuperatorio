using Microsoft.AspNetCore.Mvc;
using EventosUCB.Application;
using System.Threading.Tasks;

namespace EventosUCB.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioEventosController : ControllerBase
    {
        private readonly IVerEventosInscritosUseCase _useCase;

        public UsuarioEventosController(IVerEventosInscritosUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("{usuarioId}/eventos")]
        public async Task<IActionResult> GetEventosInscritos(string usuarioId)
        {
            var result = await _useCase.ExecuteAsync(new VerEventosInscritosRequest { UsuarioId = usuarioId });
            return Ok(result);
        }
    }

}
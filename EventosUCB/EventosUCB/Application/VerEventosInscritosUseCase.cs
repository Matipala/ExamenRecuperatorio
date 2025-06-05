using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;
using EventosUCB.Infraestructura.Repository;

namespace EventosUCB.Application
{
    public class VerEventosInscritosRequest
    {
        public string UsuarioId { get; set; }
    }

    public class VerEventosInscritosResponse
    {
        public List<EventoDto> EventosInscritos { get; set; } = new();
    }

    public interface IVerEventosInscritosUseCase
    {
        Task<VerEventosInscritosResponse> ExecuteAsync(VerEventosInscritosRequest request);
    }

    public class VerEventosInscritosUseCase : IVerEventosInscritosUseCase
    {
        private readonly IInscripcionRepository _inscripcionRepository;
        private readonly IEventoRepository _eventoRepository;

        public VerEventosInscritosUseCase(IInscripcionRepository inscripcionRepository, IEventoRepository eventoRepository)
        {
            _inscripcionRepository = inscripcionRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<VerEventosInscritosResponse> ExecuteAsync(VerEventosInscritosRequest request)
        {
            var inscripciones = await _inscripcionRepository.GetByUsuarioIdAsync(request.UsuarioId);
            var eventos = new List<EventoDto>();

            foreach (var inscripcion in inscripciones)
            {
                var evento = await _eventoRepository.GetByIdAsync(inscripcion.EventoId);
                if (evento != null)
                {
                    eventos.Add(new EventoDto
                    {
                        Id = evento.Id,
                        Nombre = evento.Nombre,
                        Fecha = evento.Fecha.ToString("dd/MM/yyyy"),
                        Costo = evento.Costo,
                        Capacidad = evento.Capacidad
                    });
                }
            }

            return new VerEventosInscritosResponse { EventosInscritos = eventos };
        }
    }

}

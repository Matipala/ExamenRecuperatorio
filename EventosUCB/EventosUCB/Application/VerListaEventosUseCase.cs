using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventosUCB.Domain.Entities;
using EventosUCB.Infraestructura.Repository;

namespace EventosUCB.Application
{
    public class EventoDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public decimal Costo { get; set; }
        public int Capacidad { get; set; }
    }

    public interface IVerListaEventosUseCase
    {
        Task<List<EventoDto>> ExecuteAsync();
    }

    public class VerListaEventosUseCase : IVerListaEventosUseCase
    {
        private readonly IEventoRepository _eventoRepository;

        public VerListaEventosUseCase(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<List<EventoDto>> ExecuteAsync()
        {
            var eventos = await _eventoRepository.GetAllAsync();

            return eventos.Select(e => new EventoDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Fecha = e.Fecha.ToString("dd/MM/yyyy"),
                Costo = e.Costo,
                Capacidad = e.Capacidad
            }).ToList();
        }
    }
}
